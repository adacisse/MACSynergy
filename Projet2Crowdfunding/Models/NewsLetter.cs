using System;
using System.Collections.Generic;

namespace Projet2Crowdfunding.Models
{
    public class NewsLetter
    {
        public HashSet<Project> favorateProjets; //un groupe de projet favoris sans doublons
        public HashSet<ProjectOwner> FavorateAssoPO; //un groupe d'associations favoris sans doublons
        public HashSet<TypeCategory> FavorateCategory; 
    }
}