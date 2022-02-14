using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Projet2Crowdfunding.Models;

namespace Projet2Crowdfunding.Service
{
    public class AccountService
    {
        private BddContext bddContext;
        public AccountService()
        {
            bddContext = new BddContext();
        }

        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "Projet2Crowdfunding" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        public int CreateParticipant(string lastName, string firstname, string mail, string password
        , Gender gender, DateTime birthdate, string phoneNumber, ParticipantAccount participantAccount)
        {
            string encodedPassword = EncodeMD5(password);

            Account account = new Account() { Mail = mail, Password = encodedPassword };


            Participant participant = new Participant()
            {
                FirstName = firstname,
                LastName = lastName,
                Gender = gender,
                Birthdate = birthdate,

                PhoneNumber = phoneNumber,
                ParticipantAccount = participantAccount
            };

            this.bddContext.Participants.Add(participant);
            this.bddContext.SaveChanges();
            return participant.Id;
        }


        public int CreateProjectOwner(string name, string phoneNumber, string mail, string password, string summary, string description, string hyperlink, string volunteerDescritpion
        , string patnerShip, string associationProof, ProjectOwnerAccount projectOwnerAccount)

        {
            string encodedPassword = EncodeMD5(password);
            Account user = new Account() { Mail = mail, Password = encodedPassword };

            ProjectOwner projectOwner = new ProjectOwner()
            {
                Name = name,
                PhoneNumber = phoneNumber,
                Summary = summary,
                Description = description,
                HyperLink = hyperlink,
                VolunteerDescritpion = volunteerDescritpion,
                Partnership = patnerShip,
                AssociationProof = associationProof,
                ProjectOwnerAccount = projectOwnerAccount

            };

            this.bddContext.ProjectOwners.Add(projectOwner);
            this.bddContext.SaveChanges();
            return projectOwner.Id;
        }

        public int CreateAdministrator(string lastName, string firstName, string mail, string password
        , string phoneNumber, AdministratorAccount administratorAccount)
        {
            string encodedPassword = EncodeMD5(password);
            Account user = new Account() { Mail = mail, Password = encodedPassword };

            Administrator administrator = new Administrator()
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                AdministratorAccount = administratorAccount

            };

            this.bddContext.Administrators.Add(administrator);
            this.bddContext.SaveChanges();
            return administrator.Id;

        }

        public Account Login(string mail, string password)
        {
            string encodedPassword = EncodeMD5(password);
            Account account = this.bddContext.Users.FirstOrDefault
                (u => u.Mail == mail && u.Password == password);
            return account;
        }

    }
}
