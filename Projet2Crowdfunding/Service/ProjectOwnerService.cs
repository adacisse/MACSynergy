using Projet2Crowdfunding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Service
{
    public class ProjectOwnerService
    {
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
    }
}
