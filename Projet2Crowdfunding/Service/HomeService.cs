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
            int NbProjects = 0;
            List<Project> Projects = this.bddContext.Projects.ToList();
            foreach (var project in Projects)
            {
                if (project.Status == Status.Publié)
                {
                    NbProjects++;
                }
            }
            return NbProjects;
        }

        public int GetClosedProjects()
        {
            int NbProjects = 0;
            List<Project> Projects = this.bddContext.Projects.ToList();
            foreach (var project in Projects)
            {
                if (project.Status == Status.Clôturé)
                {
                    NbProjects++;
                }
            }
            return NbProjects;
        }

        public double GetTotalAmount()
        {
            double AmountTotal = 0;
            
            List<Project> Project = this.bddContext.Projects.Where(p => p.Status == Status.Clôturé).ToList();
            foreach (var project in Project)
            {
                Collection Collection = this.bddContext.Collections.FirstOrDefault(p => p.ProjectId == project.Id);
                AmountTotal += Collection.Amount; 
            }
            return AmountTotal;
        }

        public List<Project> Get8ProjetsFavorits()
        {
            List<Project> projectList = this.bddContext.Projects.OrderByDescending(p => p.HeartCounter).ToList();
            List<Project> favoriteList = new List<Project>();
            for (int i = 0; i < 8; i++)
            {
                if (projectList[i] != null)
                {
                    favoriteList.Add(projectList[i]);
                }                
            }
            return favoriteList;
        }

    }
}
