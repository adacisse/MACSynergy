using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<PayPalAccount> PayPalAccounts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectOwner> ProjectOwners { get; set; }
        public DbSet<Report> Reports { get; set; }
        //public DbSet<StatisticsPlateform> StatisticsPlateforms { get; set; }
        //public DbSet<StatisticsProjet> StatisticsProjets { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrrrrr;database=Project2Crowdfunding");
        }

        public void InitializedDB()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

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
                    Newsletter = false,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 1,
                        StreetName = "Rue de la fleur",
                        StreetNumber = "12",
                        ZipCode = "57888",
                        City = "Toulouse",
                        Country = "France"
                    },
                    Account = new Account
                    {
                        Id = 1,
                        Mail = "adacisse@gmail.com",
                        Password = "aaaaa",
                        Role ="participant"
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

                    Newsletter = true,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 2,
                        StreetName = "Rue du presidant",
                        StreetNumber = "24",
                        ZipCode = "75007",
                        City = "Paris",
                        Country = "France"
                    },
                    Account = new Account
                    {
                        Id = 2,
                        Mail = "sara.rchouk@gmail.com",
                        Password = "sssss",
                        Role = "participant"
                    }
                },
                new Participant
                {
                    Id = 3,
                    LastName = "Perez",
                    FirstName = "Juanjo",
                    Gender = Gender.Male,
                    PhoneNumber = "4444114444",
                    Birthdate = DateTime.Parse("1987-09-12"),

                    Newsletter = true,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 3,
                        StreetName = "Calle de las rosas",
                        StreetNumber = "22",
                        ZipCode = "36611",
                        City = "Málaga",
                        Country = "Espagne"
                    },
                    Account = new Account
                    {
                        Id = 3,
                        Mail = "juanjoperez@gmail.com",
                        Password = "juanjuan",
                        Role = "participant"
                    }
                },
                new Participant
                {
                    Id = 4,
                    LastName = "Dupuy",
                    FirstName = "Laura",
                    Gender = Gender.Female,
                    PhoneNumber = "3333113333",
                    Birthdate = DateTime.Parse("1994-02-09"),
                    Newsletter = false,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 4,
                        StreetName = "Calle de abril",
                        StreetNumber = "7",
                        ZipCode = "84337",
                        City = "Sevilla",
                        Country = "Espagne"
                    },
                    Account = new Account
                    {
                        Id = 4,
                        Mail = "lauradupuy@gmail.com",
                        Password = "laulau",
                        Role = "participant"
                    }
                }

            );


            //Instances Gestionnaires
            this.Administrators.AddRange(
                new Administrator
                {
                    Id = 1,
                    LastName = "Faucillon",
                    FirstName = "Matthieu",
                    PhoneNumber = "3333333333",
                    Type = AdministratorType.employee,
                    Account = new Account
                    {
                        Id = 5,
                        Mail = "matthieu.faucillon@gmail.com",
                        Password = "mmmmm",
                        Role = "admin"
                    }
                },

                new Administrator
                {
                    Id = 2,
                    LastName = "Equisoain",
                    FirstName = "Cristina",
                    PhoneNumber = "4444444444",
                    Account = new Account
                    {
                        Id = 6,
                        Mail = "cristinaequisoain@gmail.com",
                        Password = "ccccc",
                        Role = "admin"
                    }
                },

                new Administrator
                {
                    Id = 3,
                    LastName = "Lacroix",
                    FirstName = "Florent",
                    PhoneNumber = "3333333311",
                    Type = AdministratorType.employee,
                    Account = new Account
                    {
                        Id = 7,
                        Mail = "florentlacroix@gmail.com",
                        Password = "floflo",
                        Role = "admin"
                    }
                },

                new Administrator
                {
                    Id = 4,
                    LastName = "Martin",
                    FirstName = "Clara",
                    PhoneNumber = "1133333333",
                    Type = AdministratorType.volunteer,
                    Account = new Account
                    {
                        Id = 8,
                        Mail = "clara.martin@gmail.com",
                        Password = "clacla",
                        Role = "admin"
                    }
                }
            );

            ////Instances PPs
            //this.ProjectOwners.AddRange(
            //    new ProjectOwner
            //    {
            //        Id = 1,
            //        PhoneNumber = "4499444444",
            //        Name = ,
            //        Summary = ,
            //        Description = ,
            //        HyperLink = ,
            //        VolunteerDescritpion = ,
            //        Partnership = ,
            //        Type = ProjectOwnerType.association,
            //        AssociationProof = ,
            //        Image = ,
            //        Status = AssoStatus.published,
            //        Address = new Address
            //        {
            //            Id = 5,
            //            StreetName = "Rue de Paris",
            //            StreetNumber = "2",
            //            ZipCode = "67444",
            //            City = "Reins",
            //            Country = "France"
            //        },
            //        Account = new ProjectOwnerAccount
            //        {
            //            Id = 1,
            //            Newsletter = true,
            //            ConfidentialityCharter = true,
            //            Account = new Account
            //            {
            //                Id = 9,
            //                Mail = "",
            //                Password = ""
            //            }
            //        }
            //    },

            //    new ProjectOwner
            //    {
            //        Id = 2,
            //        PhoneNumber = "4499455444",
            //        Name = ,
            //        Summary = ,
            //        Description = ,
            //        HyperLink = ,
            //        VolunteerDescritpion = ,
            //        Partnership = ,
            //        Type = ProjectOwnerType.association,
            //        AssociationProof = ,
            //        Image = ,
            //        Status = AssoStatus.published,
            //        Address = new Address
            //        {
            //            Id = 6,
            //            StreetName = "Street of Wansington",
            //            StreetNumber = "31A",
            //            ZipCode = "58943",
            //            City = "Liverpool",
            //            Country = "Anglaterre"
            //        },
            //        Account = new ProjectOwnerAccount
            //        {
            //            Id = 2,
            //            Newsletter = false,
            //            ConfidentialityCharter = true,
            //            Account = new Account
            //            {
            //                Id = 10,
            //                Mail = "",
            //                Password = ""
            //            }
            //        }
            //    },

            //    new ProjectOwner
            //    {
            //        Id = 3,
            //        PhoneNumber = "4499444444",
            //        Name = ,
            //        Summary = ,
            //        Description = ,
            //        HyperLink = ,
            //        VolunteerDescritpion = ,
            //        Partnership = ,
            //        Type = ProjectOwnerType.association,
            //        AssociationProof = ,
            //        Image = ,
            //        Status = AssoStatus.registered,
            //        Address = new Address
            //        {
            //            Id = 7,
            //            StreetName = "Calle de Barcelona",
            //            StreetNumber = "52",
            //            ZipCode = "36666",
            //            City = "Madrid",
            //            Country = "Espagne"
            //        },
            //        Account = new ProjectOwnerAccount
            //        {
            //            Id = 3,
            //            Newsletter = true,
            //            ConfidentialityCharter = true,
            //            Account = new Account
            //            {
            //                Id = 11,
            //                Mail = "",
            //                Password = ""
            //            }
            //        }
            //    },

            //    new ProjectOwner
            //    {
            //        Id = 4,
            //        PhoneNumber = "4499444444",
            //        Name = ,
            //        Summary = ,
            //        Description = ,
            //        HyperLink = ,
            //        VolunteerDescritpion = ,
            //        Partnership = ,
            //        Type = ProjectOwnerType.ONG,
            //        AssociationProof = ,
            //        Image = ,
            //        Status = AssoStatus.published,
            //        Address = new Address
            //        {
            //            Id = 8,
            //            StreetName = "Rue de la gare",
                        //StreetNumber = "43",
                        //ZipCode = "97532",
                        //City = "Bordeaux",
                        //Country = "France"
            //        },
            //        Account = new ProjectOwnerAccount
            //        {
            //            Id = 4,
            //            Newsletter = true,
            //            ConfidentialityCharter = true,
            //            Account = new Account
            //            {
            //                Id = 12,
            //                Mail = "",
            //                Password = ""
            //            }
            //        }
            //    },

            //    new ProjectOwner
            //    {
            //        Id = 5,
            //        PhoneNumber = "4499444444",
            //        Name = ,
            //        Summary = ,
            //        Description = ,
            //        HyperLink = ,
            //        VolunteerDescritpion = ,
            //        Partnership = ,
            //        Type = ProjectOwnerType.ONG,
            //        AssociationProof = ,
            //        Image = ,
            //        Status = AssoStatus.registered,
            //        Address = new Address
            //        {
            //            Id = 9,
            //            StreetName = "",
            //            StreetNumber = "37",
            //            ZipCode = "17634",
            //            City = "Strasbourg",
            //            Country = "France"
            //        },
            //        Account = new ProjectOwnerAccount
            //        {
            //            Id = 5,
            //            Newsletter = false,
            //            ConfidentialityCharter = true,
            //            Account = new Account
            //            {
            //                Id = 13,
            //                Mail = "",
            //                Password = ""
            //            }
            //        }
            //    }
            //);

            ////Instances Projects
            //this.Projects.AddRange(

            //);



            this.SaveChanges(); 
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                .HasIndex(u => u.AccountId)
                .IsUnique();

            modelBuilder.Entity<Administrator>()
                .HasIndex(u => u.AccountId)
                .IsUnique();

            modelBuilder.Entity<ProjectOwner>()
                .HasIndex(u => u.AccountId)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(u => new { u.Mail, u.Password })
                .IsUnique();

            modelBuilder.Entity<Collection>()
               .HasIndex(u => u.DonationId)
               .IsUnique();

            modelBuilder.Entity<Favorite>()
              .HasIndex(u => new { u.ProjectId, u.ParticipantId })
              .IsUnique();

            modelBuilder.Entity<ProjectOwner>()
               .HasIndex(u => u.Name)
               .IsUnique();

        }

    }
}


