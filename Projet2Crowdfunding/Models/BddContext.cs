using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public class BddContext : DbContext
    {
        //public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AdministratorAccount> AdministratorAccounts { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<ParticipantAccount> ParticipantAccounts { get; set; }
        public DbSet<PayPalAccount> PayPalAccounts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectOwner> ProjectOwners { get; set; }
        public DbSet<ProjectOwnerAccount> ProjectOwnerAccounts { get; set; }
        public DbSet<Report> Reports { get; set; }
        //public DbSet<StatisticsPlateform> StatisticsPlateforms { get; set; }
        //public DbSet<StatisticsProjet> StatisticsProjets { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrrrrr;database=Project2Crowdfunding");
        }

        public void InitializedDB()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            //Instances Adress
            this.Addresses.AddRange(
                    new Address
                    {
                        Id = 5,
                        StreetName = "Street of Wansington",
                        StreetNumber = "31A",
                        ZipCode = "58943",
                        City = "Liverpool",
                        Country = "Anglaterre"
                    },
                    new Address
                    {
                        Id = 6,
                        StreetName = "Rue de Paris",
                        StreetNumber = "2",
                        ZipCode = "67444",
                        City = "Reins",
                        Country = "France"
                    },
                    new Address
                    {
                        Id = 7,
                        StreetName = "Calle de abril",
                        StreetNumber = "7",
                        ZipCode = "84337",
                        City = "Sevilla",
                        Country = "Espagne"
                    }
                );

            //Instances Participant
            this.Participants.AddRange(
            new Participant
            {
                Id = 1,
                LastName = "Cisse",
                FirstName = "Ada",
                Gender = Gender.Female,
                PhoneNumber = "6666666666",
                Birthdate = DateTime.Parse("2013-07-04"),
                Address = new Address
                {
                    Id = 1,
                    StreetName = "Rue de la fleur",
                    StreetNumber = "12",
                    ZipCode = "57888",
                    City = "Toulouse",
                    Country = "France"
                },
                Account = new ParticipantAccount {
                    Id = 1,
                    Newsletter = false,
                    ConfidentialityCharter = true,
                    Account = new Account
                    {
                        Id = 1,
                        Mail = "adacisse@gmail.com",
                        Password = "aaaaa"
                    }  
                }
            },
             new Participant
             {
                 Id = 2,
                 LastName = "Rchouk",
                 FirstName = "Sara",
                 Gender = Gender.Female,
                 PhoneNumber = "5555555555",
                 Birthdate = DateTime.Parse("2011-03-14"),
                 Address = new Address
                 {
                     Id = 2,
                     StreetName = "Rue du presidant",
                     StreetNumber = "24",
                     ZipCode = "75007",
                     City = "Paris",
                     Country = "France"
                 },
                  Account = new ParticipantAccount
                  {
                      Id = 2,
                      Newsletter = true,
                      ConfidentialityCharter = true,
                      Account = new Account
                      {
                          Id = 2,
                          Mail = "sararchouk@gmail.com",
                          Password = "sssss"
                      }
                  }
             },
             new Participant
             {
                 Id = 3,
                 LastName = "Equisoain",
                 FirstName = "Cristina",
                 Gender = Gender.Female,
                 PhoneNumber = "4444444444",
                 Birthdate = DateTime.Parse("1994-07-04"),
                 Address = new Address
                 {
                     Id = 3,
                     StreetName = "Calle de Barcelona",
                     StreetNumber = "52",
                     ZipCode = "36666",
                     City = "Madrid",
                     Country = "Espagne"
                 },
                   Account = new ParticipantAccount
                   {
                       Id = 3,
                       Newsletter = true,
                       ConfidentialityCharter = true,
                       Account = new Account
                       {
                           Id = 3,
                           Mail = "cristinaequisoain@gmail.com",
                           Password = "ccccc"
                       }
                   }
             },
             new Participant
             {
                 Id = 4,
                 LastName = "Faucillon",
                 FirstName = "Matthieu",
                 Gender = Gender.Male,
                 PhoneNumber = "3333333333",
                 Birthdate = DateTime.Parse("1990-07-04"),
                 Address = new Address
                 {
                     Id = 4,
                     StreetName = "Rue de la gare",
                     StreetNumber = "43",
                     ZipCode = "97532",
                     City = "Bordeaux",
                     Country = "France"
                 },
                  Account = new ParticipantAccount
                  {
                      Id = 4,
                      Newsletter = false,
                      ConfidentialityCharter = true,
                      Account = new Account
                      {
                          Id = 4,
                          Mail = "matthieu.faucillon@gmail.com",
                          Password = "mmmmm"
                      }
                  }
             }

            );

            this.SaveChanges();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipantAccount>()
                .HasIndex(u => u.AccountId)
                .IsUnique();

            modelBuilder.Entity<AdministratorAccount>()
                .HasIndex(u => u.AccountId)
                .IsUnique();

            modelBuilder.Entity<ProjectOwnerAccount>()
                .HasIndex(u => u.AccountId)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(u => new { u.Mail, u.Password })
                .IsUnique();

        }

    }
}

