using System;
using System.Security.Cryptography;
using System.Text;
using Projet2Crowdfunding.Models;

namespace Projet2Crowdfunding.Service
{
    public class PaymentService
    {
        private BddContext bddContext;
        public PaymentService()
        {
            bddContext = new BddContext();
        }

        public static string EncodeMD5(string cvv)
        {
            string cvvSel = "Projet2Crowdfunding" + cvv + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(cvvSel)));
        }

        public int CreateCreditCard(string cardNumber, string ownerName, DateTime ExpirationDate, string cvv)
        {
            string encodedCvv= EncodeMD5(cvv);

            CreditCard creditCard = new CreditCard()
            {
                CardNumber  = cardNumber,
                OwnerName = ownerName,
                ExpirationDate = ExpirationDate,
                Cvv = encodedCvv
            };

            this.bddContext.CreditCards.Add(creditCard);
            this.bddContext.SaveChanges();
            return creditCard.Id;
        }

        public int CreatePaypalAccount (string mail)
        {
            PayPalAccount payPalAccount = new PayPalAccount()
            {
                Mail = mail
            };
            this.bddContext.PayPalAccounts.Add(payPalAccount);
            this.bddContext.SaveChanges();
            return payPalAccount.Id;
        }
       

    }
}

