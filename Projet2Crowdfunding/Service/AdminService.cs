using Projet2Crowdfunding.Models;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Projet2Crowdfunding.Service
{
    public class AdminService
    {

        public void ModifyAdminInfos(int id, string lastName, string firstName)
        {
            BddContext ctx = new BddContext();
            Administrator administrator = ctx.Administrators.Find(id);

            if (administrator != null)
            {
                administrator.LastName = lastName;
                administrator.FirstName = firstName;
                ctx.SaveChanges();
            }
        }

        public void ModifyAdminPhone(int id, string phoneNumber)
        {
            BddContext ctx = new BddContext();
            Administrator administrator = ctx.Administrators.Find(id);

            if (administrator != null)
            {
                administrator.PhoneNumber = phoneNumber;
                ctx.SaveChanges();
            }
        }

        public void ModifyAdminEmail(int id, string mail)
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

        public void ModifyAdminPwd(int id, string password)
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
    }
}
