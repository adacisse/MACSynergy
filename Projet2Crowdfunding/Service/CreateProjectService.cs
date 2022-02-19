using Projet2Crowdfunding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Service
{
    public class CreateProjectService
    {
        private BddContext bddContext;

        public CreateProjectService()
        {
            bddContext = new BddContext();
        }

        public int CreateProject(int idPO, string name, string summary, string description, Category? category,
            string location, DateTime endDate, string image, string video, string materialDonation)
        {

            string imageProject = "";
            if (image != null)
            {
                imageProject = "/ImagesProject/" + image;
            }
            else
            {
                switch (category)
                {
                    case Category.Animaux:
                        imageProject = "/ImagesProject/animal.jpg";
                        break;
                    case Category.Education:
                        imageProject = "/ImagesProject/education.png";
                        break;
                    case Category.Environnement:
                        imageProject = "/ImagesProject/environnement.jpg";
                        break;
                    case Category.Humanitaire:
                        imageProject = "/ImagesProject/humanitaire.jpg";
                        break;
                    case Category.Santé:
                        imageProject = "/ImagesProject/sante.jpg";
                        break;
                    case Category.BesoinsElémentaires:
                        imageProject = "/ImagesProject/besoins.jpg";
                        break;
                    case Category.Autre:
                        imageProject = "/ImagesProject/autres.jpg";
                        break;
                }
            }
            

            Project project = new Project
            {
                Name = name,
                Summary = summary,
                Descritpion = description,
                Category = category,
                Location = location,
                EndDate = endDate,
                Picture = imageProject,
                Video = "/VideosProject/" + video,
                MaterialDonation = materialDonation,
                Status = Status.submittedForEvaluation,
                ProjectOwnerId = idPO,
                HeartCounter = 0
            };

            Collection collection = new Collection
            {
                Amount = 0,
                Project = project
            };

            this.bddContext.Projects.Add(project);
            this.bddContext.SaveChanges();
            return project.Id;
        }

    }
}
