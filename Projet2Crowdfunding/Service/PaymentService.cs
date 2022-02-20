using System;
using System.Collections.Generic;
using System.Linq;
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

       


        //public static string EncodeMD5(string cvv)
        //{
        //    string cvvSel = "Projet2Crowdfunding" + cvv + "ASP.NET MVC";
        //    return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(cvvSel)));
        //}

        //public int CreateCreditCard(string cardNumber, string ownerName, DateTime expirationDate, string cvv)
        //{
        //    string encodedCvv = EncodeMD5(cvv);

        //    CreditCard creditCard = new CreditCard()
        //    {
        //        CardNumber = cardNumber,
        //        OwnerName = ownerName,
        //        ExpirationDate = expirationDate,
        //        Cvv = encodedCvv
        //    };

        //    this.bddContext.CreditCards.Add(creditCard);
        //    this.bddContext.SaveChanges();
        //    return creditCard.Id;
        //}



        public void CreateDonation(int? projectId, int participantId, double amount)
        {
            Collection collection = bddContext.Collections.FirstOrDefault(c => c.ProjectId == projectId);
            Donation donation = new Donation()
            {
                Amount = amount,
                ParticipantId = participantId,
                Collection = collection
            };
            collection.Amount += amount;
            this.bddContext.Donations.Add(donation);
            this.bddContext.SaveChanges();
            
        }

        //public List<Donation> GetDonationsFromParticipantId(int Id)
        //{
        //    List<Donation> ParticipantDonationList = new List<Donation>();
        //    var donations = bddContext.Donations.Where(p => p.ParticipantId == Id).ToList();
        //    foreach (Donation donation in donations)
        //    {
        //        ParticipantDonationList.Add(donation);
        //    }
        //    return (ParticipantDonationList);
        //}



        //public double CreateCollectionForProject(double amount, int Id)
        //{
        //    Collection collection = new Collection()

        //    {
        //        Amount = amount
        //    };
        //    this.bddContext.Collections.Add(collection);
        //    this.bddContext.SaveChanges();
        //    return collection.Id;
        //}


        //public double AddDonationToCollection(double CurrentDonations, double addDonation)
        //{
        //    double collectionAmount = CurrentDonations += addDonation;
        //    {
        //        return collectionAmount;
        //    };

        //}



    }






    //public int CreatePaypalAccount(string mail)
    //{
    //    PayPalAccount payPalAccount = new PayPalAccount()
    //    {
    //        Mail = mail
    //    };
    //    this.bddContext.PayPalAccounts.Add(payPalAccount);
    //    this.bddContext.SaveChanges();
    //    return payPalAccount.Id;
    //}

    //public Boolean ValidateCreditCardInfo(string cardNumber, string ownerName, DateTime ExpirationDate, string cvv)
    //{

    //}
    //return

    //public Boolean ValidatePaypalAccount(string mail)
    //{

    //}
    //return
    //}   

}

