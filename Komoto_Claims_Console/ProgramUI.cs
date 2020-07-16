using _102_Komoto_Claims;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Komoto_Claims_Console
{
    public class ProgramUI
    {


       Claims _claimsRepo = new Claims();
       private readonly ClaimsRepository _repo = new ClaimsRepository();


        public void Run()
        {
            SeedClaimsList();
            RunMenu();
        }

        private void RunMenu()
        {
            //   string input = "";
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                    "Please select a number from below: \n" +
                    "1. Show all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Add new claim \n" +
                    //"4. remove menu items \n" +
                    "5. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //show all
                        ShowAllClaims();
                        break;
                    case "2"://-------------------------------------------****
                        //find by title
                        GetNextClaim();
                        break;//----------------------------------------------***
                    case "3":
                        //Add new 
                        AddNewClaim();
                        //add all properties here?
                        break;
                    case "4":
                        //remove
                        DeleteExistingMenuItem();
                        break;
                    case "5":
                        //exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5. \n" +
                            "Press any key to continue....");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddNewClaim()
        {
            Console.Clear();
            Claims _menu = new Claims();//-------new instance of Menu = _menu

            // claims ID number
            Console.WriteLine("Please enter the Claims ID Number: ");
            _claimsRepo.ClaimID = int.Parse(Console.ReadLine());

            //meal name
            Console.WriteLine("Please enter the type of claim: \n"+
                "1. Home \n"+
                "2. Car \n"+
                "3. Theft \n");
           // _claimsRepo.TypeOfClaim = Console.ReadLine();
            string claimInput = Console.ReadLine();
            int claimNumber = int.Parse(claimInput);
            _claimsRepo.TypeOfClaim = (ClaimType)claimNumber;

            //description
            Console.WriteLine("Please enter the claim description: ");
            _claimsRepo.Description = Console.ReadLine();

            Console.WriteLine("Please enter the amount of the claim: ");
            _claimsRepo.ClaimAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date of the accident: ");
            _claimsRepo.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date of the claim: ");
            _claimsRepo.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _repo.AddNewClaim(_claimsRepo);
        }
        private void ShowAllClaims()
        {
            Console.Clear();
            List<Claims> listOfClaims = _repo.ShowAllClaims();

            foreach (Claims contentItem in listOfClaims)
            {
                DisplayContent(contentItem);
                Console.WriteLine("---------------------");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void GetNextClaim()
        {
            List<Claims> listOfClaims = _repo.ShowOneClaim();

            foreach (Claims contentItem in listOfClaims)
            {
                DisplayContent(contentItem);
                Console.WriteLine("---------------------");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
//Console.WriteLine("Press any key to continue...");
//            Console.ReadKey();

            //-----------------------------------------------------------

            //----------------------------------------------------------------------------------------------
        
        private void DeleteExistingMenuItem()
        {
            Console.WriteLine("Which item would you like to remove?");
            List<Claims> listOfClaims= _repo.GetContents();
            int count = 0;
            foreach (Claims content in listOfClaims)
            {
                count++;
                Console.WriteLine($"{count}. {content.ClaimID}");
            }

            int targetContentId = int.Parse(Console.ReadLine());
            int targetIndex = targetContentId - 1;
            if (targetIndex >= 0 && targetIndex < listOfClaims.Count)
            {
                Claims desiredContent = listOfClaims[targetIndex];
                if (_repo.DeleteExistingClaim(desiredContent))
                {
                    Console.WriteLine($"{desiredContent.ClaimID} successfully removed.");
                }
                else
                {
                    Console.WriteLine("I'm sorry, Dave. I'm afraid I can't do that.");
                }
            }
            else
            {
                Console.WriteLine("No content has that ID");
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        private void DisplayContent(Claims content)
        {
            Console.WriteLine($"Claim Number: {content.ClaimID} " +
                $"Type: {content.TypeOfClaim} " +
                $"Description: {content.Description} " +
                $"Amount: {content.ClaimAmount} " +
                $"DateOfAccident: {content.DateOfIncident} "+
                $"DateOfAccident: {content.DateOfClaim} " +
                $"IsValid: {content.IsValid} ");
        }


        public void SeedClaimsList()
        {
            Claims claim1 = new Claims(int.Parse("1"),ClaimType.car, "accident on 465",  float.Parse("400.00"),DateTime.Parse("4/25/18"),DateTime.Parse("4/27/18"),bool.Parse("true"));

            Claims claim2 = new Claims(int.Parse("2"), ClaimType.home, "house fire in kitchen", float.Parse("4000.00"), DateTime.Parse("4/11/18"), DateTime.Parse("4/12/18"), bool.Parse("true"));

            Claims claim3 = new Claims(int.Parse("3"), ClaimType.theft, "stolen pancakes", float.Parse("4.00"), DateTime.Parse("4/27/18"), DateTime.Parse("6/01/18"), bool.Parse("false"));



            _repo.AddNewClaim(claim1);
            _repo.AddNewClaim(claim2);
            _repo.AddNewClaim(claim3);
        }
    }
}

