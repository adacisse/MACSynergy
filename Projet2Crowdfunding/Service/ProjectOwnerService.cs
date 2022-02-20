using Projet2Crowdfunding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Service
{
    public class ProjectOwnerService
    {
        private BddContext bddContext;

        public ProjectOwnerService()
        {
            bddContext = new BddContext();
        }

        public List<ProjectOwner> GetAllProjectOwnersStatus(AssoStatus? status)
        {
            List<ProjectOwner> ProjectOwnerList = new List<ProjectOwner>();
            var projectOwners = bddContext.ProjectOwners.Where(p => p.Status == status).ToList();
            foreach (ProjectOwner projectOwner in projectOwners)
            {
                ProjectOwnerList.Add(projectOwner);
            }
            return (ProjectOwnerList);
        }

        public void ModifyProjectOwnerInfos(int id, string name, ProjectOwnerType type, string hyperLink)
        {
            BddContext ctx = new BddContext();
            ProjectOwner projectOwner = ctx.ProjectOwners.Find(id);

            if (projectOwner != null)
            {
                projectOwner.Name = name;
                projectOwner.Type = type;
                projectOwner.HyperLink = hyperLink;
                ctx.SaveChanges();
            }
        }

        public void ModifyProjectOwnerAddress(int id, string streetNumber, string streetName, string zipCode, string city, string country)
        {
            BddContext ctx = new BddContext();
            ProjectOwner projectOwner = ctx.ProjectOwners.Find(id);
            Address address = ctx.Addresses.Find(projectOwner.AddressId);
            projectOwner.Address = address;

            if (projectOwner != null)
            {
                projectOwner.Address.StreetNumber = streetNumber;
                projectOwner.Address.StreetName = streetName;
                projectOwner.Address.ZipCode = zipCode;
                projectOwner.Address.City = city;
                projectOwner.Address.Country = country;
                ctx.SaveChanges();
            }
        }

        public void ModifyProjectOwnerPhone(int id, string phoneNumber)
        {
            BddContext ctx = new BddContext();
            ProjectOwner projectOwner = ctx.ProjectOwners.Find(id);

            if (projectOwner != null)
            {
                projectOwner.PhoneNumber = phoneNumber;
                ctx.SaveChanges();
            }
        }

        public void ModifyProjectOwnerDescription(int id, string summary, string description, string volunteerDescritpion, string partnership)
        {
            BddContext ctx = new BddContext();
            ProjectOwner projectOwner = ctx.ProjectOwners.Find(id);

            if (projectOwner != null)
            {
                projectOwner.Summary = summary;
                projectOwner.Description = description;
                projectOwner.VolunteerDescritpion = volunteerDescritpion;
                projectOwner.Partnership = partnership;
                ctx.SaveChanges();
            }
        }

        public void ModifyProjectOwnerLogo(int id, string image)
        {
            BddContext ctx = new BddContext();
            ProjectOwner projectOwner = ctx.ProjectOwners.Find(id);

            if (projectOwner != null)
            {
                projectOwner.Image = "/ImageAssos/" + image;
                ctx.SaveChanges();
            }
        }

        public void ModifyProjectOwnerStatus(int id, AssoStatus status)
        {
            BddContext ctx = new BddContext();
            ProjectOwner projectOwner = ctx.ProjectOwners.Find(id);

            if (projectOwner != null)

                projectOwner.Status = status;
                ctx.SaveChanges();

        }





    }
}
