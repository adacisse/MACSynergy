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
          
           TimeSpan timeLeftProject = this.bddContext.Projects.Find(id).EndDate - DateTime.Now;
            return (timeLeftProject);

        }
        //public Favorite Favorite { get; set; } à rajouter dans accoutnviewmodel
        public void FollowMyFavorite(int? idProject, int idParticipant)
        {
           
                Project project = this.bddContext.Projects.Find(idProject);
            Favorite favorite = new Favorite();
            if (project!= null)
            {
                project.HeartCounter++;
                this.bddContext.Favorites.Add(favorite);
                this.bddContext.SaveChanges();
            }

        }

        public List<Collection> GetAllCollections()
        {
            List<Collection> collectionList = this.bddContext.Collections.ToList();
            return collectionList;

        }


    }
}
