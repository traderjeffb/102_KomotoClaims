using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _102_Komoto_Claims
{
    public class ClaimsRepository
    {
        protected readonly List<Claims> _claims = new List<Claims>();

        //CRUD

        //CREATE
        public bool AddNewClaim(Claims content)
        {
            int startingCount = _claims.Count;
            _claims.Add(content);
            bool wasAdded = (_claims.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //READ
        public Claims GetClaimByClaimID(int claimID)
        {
            foreach (Claims content in _claims)
            {
                if (content.ClaimID == claimID )
                {
                    return content;
                }
            }
            return null;
        }


        //SHOW ALL MENU ITEMS
        //GetMenuItemsAll(int mealNumber, string mealName, string mealDescription, string ingredients, float price )
        public List<Claims> GetContents()
        {
            return _claims;
        }

        public List<Claims> ShowAllClaims()
        {
            List<Claims> allClaimsItems = new List<Claims>();
            foreach (Claims content in _claims)
            {
                if (content is Claims)
                {
                    allClaimsItems.Add((Claims)content);
                }
            }
            return allClaimsItems;
        }
        //-------------------------------------------------
        public List<Claims> ShowOneClaim()
        {
            int i = 0;
            List<Claims> allClaimsItems = new List<Claims>();
            foreach (Claims content in _claims)
            {
                if (content is Claims && (i<0))
                {
                    allClaimsItems.Add((Claims)content);
                    i++;
                }
            }
            return allClaimsItems;
        }
        //-------------------------
        //DELETE
        public bool DeleteExistingClaim(Claims existingContent)
        {
            bool deleteResult = _claims.Remove(existingContent);
            return deleteResult;
        }

        //public bool ShowNextClaim(Claims existingContent)
        //{
        //    List<Claims> allClaimsItems = new List<Claims>();
            //allClaimsItems.Remove([0]);
            //_claims.Remove[0];
            //_claims.Remove();
            //return deletedResult;

        }
}
