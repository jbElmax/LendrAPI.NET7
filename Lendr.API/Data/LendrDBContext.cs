using Lendr.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Lendr.API.Data
{
    public class LendrDBContext:DbContext
    {
        public LendrDBContext(DbContextOptions options):base(options)
        {
            
        }       
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<CivilStatus> CivilStatuses { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CivilStatus>().HasData(
                new CivilStatus
                {
                    Id = 1,
                    Name = "Single",
                },
                new CivilStatus
                {
                    Id= 2,
                    Name = "Married"
                },
                new CivilStatus
                {
                    Id= 3,
                    Name = "Widow"
                },
                new CivilStatus
                {
                   Id = 4,
                   Name = "Common Law"
                }
            );
            modelBuilder.Entity<Borrower>().HasData(
                new Borrower
                {
                    Id= 1,
                    FirstName = "Jan",
                    MiddleName = "Bongcawel",
                    LastName = "Elnas",
                    CivilStatusId = 2,
                    Suffix = ""

                },
                                new Borrower
                                {
                                    Id = 2,
                                    FirstName = "Grace",
                                    MiddleName = "Namocatcat",
                                    LastName = "Bongcawel",
                                    CivilStatusId = 2,
                                    Suffix = ""

                                },
                                                                new Borrower
                                                                {
                                                                    Id = 3,
                                                                    FirstName = "Louie Ysabelle",
                                                                    MiddleName = "Mariano",
                                                                    LastName = "Elnas",
                                                                    CivilStatusId = 1,
                                                                    Suffix = ""

                                                                }
                );

        }
    }

}
