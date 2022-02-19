using Microsoft.EntityFrameworkCore;
using Projet2Crowdfunding.Models;
using Projet2Crowdfunding.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Service
{
    public class ProjectService
    {

        private BddContext bddContext;
        private TimeSpan timeLeftProject;

        public ProjectService()
        {
            bddContext = new BddContext();
        }
        public List<Project> GetProjectsFromProjectOwnerId(int Id)
        {
            List<Project> ProjectList = new List<Project>();
            var projects = bddContext.Projects.Where(p => p.ProjectOwnerId == Id).ToList();
            foreach (Project project in projects)
            {
                ProjectList.Add(project);
            }
            return (ProjectList);
        }
        public List<Project> GetProjectsFromPOIdStatus(int Id, Status? status)
        {
            List<Project> ProjectList = new List<Project>();
            var projects = bddContext.Projects.Where(p => p.ProjectOwnerId == Id && p.Status == status).ToList();
            foreach (Project project in projects)
            {
                ProjectList.Add(project);
            }
            return (ProjectList);
        }
        

        public List<Project> GetAllProjectsStatus(Status? status)
        {
            List<Project> ProjectList = new List<Project>();
            var projects = bddContext.Projects.Where(p => p.Status == status).ToList();
            foreach (Project project in projects)
            {
                ProjectList.Add(project);
            }
            return (ProjectList);
        }
        

        public List<Project> GetAllProjects()
        {
            List<Project> projectList = this.bddContext.Projects.ToList();
            return projectList;
        }

        public Project GetProject(int id)
        {
            return this.bddContext.Projects.Find(id);
        }
        
        
        public TimeSpan TimeLeftCalculator(int id)
        {

            TimeSpan timeLeftProject = this.bddContext.Projects.Find(id).EndDate.Subtract(DateTime.Now);
            return timeLeftProject;

        }
     

        public List<Collection> GetAllCollections()
        {
            List<Collection> collectionList = this.bddContext.Collections.ToList();
            return collectionList;

        }

       
        public List<Step> GetStepsFromProjectId(int? idProject)
        {

            List<Step> ProjectStepsList = new List<Step>();
            var Steps = bddContext.Steps.Where(s => s.ProjectId == idProject).ToList();
            foreach (Step step in Steps)
            {
                ProjectStepsList.Add(step);
            }
            return (ProjectStepsList);


        }

        //public Favorite Favorite { get; set; } à rajouter dans accoutnviewmodel
        //compter les coups de coeur sur un projets
       //******** public void setProjectHeartCounter()
        public int CountProjectFavoriteSum(int? idProject)
        {

            /////////////////////////////////////
            Project project = this.bddContext.Projects.Find(idProject);
            
            List<Favorite> MyFavoritesList = new List<Favorite>();
            var favorites = bddContext.Favorites.Where(f => f.ProjectId == idProject).ToList();

            return favorites.Count;
           
        }
        public void AddAFavoriteForAParticipantOnAProject(int? idProject, int id)
        {//recuperer le participant depuis son account
         //puis stocker le favorite 
         //puis afficher le nombre de favorite dans le heartcounter
            BddContext ctx = new BddContext();
            Project project = ctx.Projects.Find(idProject);
            Participant participant = ctx.Participants.Find(id);
            if (participant != null)
            {
                Favorite favorite = new Favorite();
                favorite.ProjectId = idProject;
                favorite.ParticipantId = id;
                ctx.SaveChanges();
                //AccountService.GetParticipantFromAccountId(Id);
            }
        }

       
        //public void
        //  HeartCounting()
        //// {
        //    Project.HeartCounter++;
        // }

    }
}
