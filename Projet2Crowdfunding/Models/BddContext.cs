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
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectOwner> ProjectOwners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=christelle;database=Project2Crowdfunding");
        }

        public void InitializedDB()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            //this.Participants.AddRange(
                //new Participant
                //{
                //    Id = 1,
                //    LastName = "Cisse",
                //    FirstName = "Ada",
                //    Gender = Gender.Female,
                   
                //    Birthdate = DateTime.Parse("2013-07-04"),
                //    User = new User { Id = 1, PhoneNumber = "6666666666", Account = new Account { Id = 1, Mail = "adacisse@gmail.com", Password = "aaaa"} },

                //    //Address = new Address { Id = 1}

                //}
               /* new Participant
                {
                    Id = 2,
                    LastName = "Rchouk",
                    FirstName = "Sara",
                    Gender = Gender.Female,
                    PhoneNumber = "5555555555",
                    Birthdate = DateTime.Parse("2011-07-04"),
                    Account = new ParticipantAccount { Id = 2 },
                    Address = new Address { Id = 2 }
                },
                new Participant
                {
                    Id = 3,
                    LastName = "Equisoain",
                    FirstName = "Cristina",
                    Gender = Gender.Female,
                    PhoneNumber = "4444444444",
                    Birthdate = DateTime.Parse("1994-07-04"),
                    Account = new ParticipantAccount { Id = 3 },
                    Address = new Address { Id = 3 }
                },
                new Participant
                {
                    Id = 4,
                    LastName = "Faucillon",
                    FirstName = "Matthieu",
                    Gender = Gender.Male,
                    PhoneNumber = "3333333333",
                    Birthdate = DateTime.Parse("1990-07-04"),
                    Account = new ParticipantAccount { Id = 4 },
                    Address = new Address { Id = 4 }
                }*/

            //); ;
           // this.SaveChanges();
        }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Participant>()
        //        .HasIndex(u => u.Account)
        //        .IsUnique();
        //    modelBuilder.Entity<Address>().Property(a => a.Street).HasMaxLength(12);
        //}

    }
}
