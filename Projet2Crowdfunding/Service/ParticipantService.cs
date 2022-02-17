using Projet2Crowdfunding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Service
{
    public class ParticipantService
    {
        public void ModifyParticipantInfos(int id, string lastName, string firstName, Gender gender, DateTime birthdate)
        {
            BddContext ctx = new BddContext();
            Participant participant = ctx.Participants.Find(id);

            if (participant != null)
            {
                participant.LastName = lastName;
                participant.FirstName = firstName;
                participant.Gender = gender;
                participant.Birthdate = birthdate;
                ctx.SaveChanges();
            }
        }

    }
}
