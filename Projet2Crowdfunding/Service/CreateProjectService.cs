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
            string location, DateTime endDate, string image, string video, string materialDonation,
            double amount1, string descriptionA1, double amount2, string descriptionA2,
            double amount3, string descriptionA3)
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

            Step step1 = new Step
            {
                Amount = amount1,
                Description = descriptionA1,
                Project = project
            };

            if (amount2 != 0 && descriptionA2 != null)
            {
                Step step2 = new Step
                {
                    Amount = amount2,
                    Description = descriptionA2,
                    Project = project
                };
                this.bddContext.Steps.Add(step2);
            }

            if (amount3 != 0 && descriptionA3 != null)
            {
                Step step3 = new Step
                {
                    Amount = amount3,
                    Description = descriptionA3,
                    Project = project
                };
                this.bddContext.Steps.Add(step3);
            }

            this.bddContext.Projects.Add(project);
            this.bddContext.Collections.Add(collection);
            this.bddContext.Steps.Add(step1);
            this.bddContext.SaveChanges();
            return project.Id;
        }

        public void ModifyProject(int idProject, string name, string summary, string description, Category? category,
           string location, DateTime endDate, string image, string video, string materialDonation,
           double amount1, string descriptionA1, double amount2, string descriptionA2,
           double amount3, string descriptionA3)
        {
            BddContext ctx = new BddContext();
            Project project = ctx.Projects.Find(idProject);
            List<Step> steps = ctx.Steps.Where(s => s.ProjectId == idProject).ToList();

            if (project != null)
            {
                project.Name = name;
                project.Summary = summary;
                project.Descritpion = description;
                project.Category = category;
                project.Location = location;
                project.EndDate = endDate;
                project.MaterialDonation = materialDonation;
                if(image != "")
                {
                    project.Picture = image;
                }
                if (video != "")
                {
                    project.Video = video;
                }

                steps[0].Amount = amount1;
                steps[0].Description = descriptionA1;
                if (steps.Count() > 1)
                {
                    steps[1].Amount = amount2;
                    steps[1].Description = descriptionA2;
                }
                if (steps.Count() > 2)
                {
                    steps[2].Amount = amount3;
                    steps[2].Description = descriptionA3;
                }
                
                ctx.SaveChanges();
            }
        }


    }
}



