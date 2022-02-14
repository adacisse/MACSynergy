using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Projet2Crowdfunding.Models;

namespace Projet2Crowdfunding.Service
{
    public class UserService
    {
        private BddContext bddContext;
        public UserService()
        {
            bddContext = new BddContext();
        }
        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "Projet2Crowdfunding" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        public int CreateParticipant(string lastName, string firstname, string mail, string password
        , Gender gender, DateTime birthdate, string phoneNumber)
        {
            string encodedPassword = EncodeMD5(password);
            User user = new User() { Mail = mail, Password = encodedPassword };


            Participant participant = new Participant()
            {
                FirstName = firstname,
                LastName = lastName,
                Gender = gender,
                Birthdate = birthdate,
                PhoneNumber = phoneNumber,
                User = user
            };

            this.bddContext.Participants.Add(participant);
            this.bddContext.SaveChanges();
            return participant.Id;
        }


        public int CreateProjectOwner(string name, string phoneNumber, string mail, string password, string summary, string description, string hyperlink, string volunteerDescritpion
        , string patnerShip, string associationProof)

        {
            string encodedPassword = EncodeMD5(password);
            User user = new User() { Mail = mail, Password = encodedPassword };

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
                User = user

            };

            this.bddContext.ProjectOwners.Add(projectOwner);
            this.bddContext.SaveChanges();
            return projectOwner.Id;
        }

        public int CreateAdministrator(string lastName, string firstName, string mail, string password
        , string phoneNumber)
        {
            string encodedPassword = EncodeMD5(password);
            User user = new User() { Mail = mail, Password = encodedPassword };

            Administrator administrator = new Administrator()
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                User = user

            };

            this.bddContext.Administrators.Add(administrator);
            this.bddContext.SaveChanges();
            return administrator.Id;

        }

        public User Login (string mail, string password)
        {
            string encodedPassword = EncodeMD5(password);
            User user = this.bddContext.Users.FirstOrDefault
                (u => u.Mail == mail && u.Password == password);
            return user;
        }
    }
}
