using Projet2Crowdfunding.Models;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

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

        public void ModifyParticipantPhone(int id, string phoneNumber)
        {
            BddContext ctx = new BddContext();
            Participant participant = ctx.Participants.Find(id);

            if (participant != null)
            {
                participant.PhoneNumber = phoneNumber;
                ctx.SaveChanges();
            }
        }

        public void ModifyParticipantEmail(int id, string mail)
        {
            BddContext ctx = new BddContext();
            Account account = ctx.Accounts.Find(id);

            if (account != null)
            {
                account.Mail = mail;
                ctx.SaveChanges();
            }
        }

        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "Projet2Crowdfunding" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        public void ModifyParticipantPwd(int id, string password)
        {
            string encodedPassword = EncodeMD5(password);

            BddContext ctx = new BddContext();
            Account account = ctx.Accounts.Find(id);

            if (account != null)
            {
                account.Password = encodedPassword;
                ctx.SaveChanges();
            }
        }

        public void ModifyParticipantAddress(int id, string streetNumber, string streetName, string zipCode, string city, string country)
        {
            BddContext ctx = new BddContext();
            Participant participant = ctx.Participants.Find(id);
            Address address = ctx.Addresses.Find(participant.AddressId);
            participant.Address = address;

            if (participant != null)
            {
                participant.Address.StreetNumber = streetNumber;
                participant.Address.StreetName = streetName;
                participant.Address.ZipCode = zipCode;
                participant.Address.City = city;
                participant.Address.Country = country;
                ctx.SaveChanges();
            }
        }
    }
}
