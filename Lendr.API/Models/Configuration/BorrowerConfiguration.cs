using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lendr.API.Models.Configuration
{
    public class BorrowerConfiguration : IEntityTypeConfiguration<Borrower>
    {
        public void Configure(EntityTypeBuilder<Borrower> builder)
        {
            builder.HasData(
                new Borrower
                {
                    Id = 1,
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
