using Projet2Crowdfunding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Service
{
    public class HomeService
    {
        private BddContext bddContext;
        public HomeService()
        {
            bddContext = new BddContext();
        }

        public int GetInscriptions()
        {
            int Inscriptions = 0;
            List<Account> Accounts = this.bddContext.Accounts.ToList();
            foreach(var account in Accounts)
            {
                if ( account.Role != "admin")
                {
                    Inscriptions++;
                }
            }
            return Inscriptions;
        }

        public int GetPublishedProjects()
        {
            return 1;
        }

        public int GetClosedProjects()
        {
            return 1;
        }

        public int GetTotalAmount()
        {
            return 1;
        }


    }
}
