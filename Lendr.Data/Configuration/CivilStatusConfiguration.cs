using Lendr.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lendr.API.Models.Configuration
{
    public class CivilStatusConfiguration : IEntityTypeConfiguration<CivilStatus>
    {
        public void Configure(EntityTypeBuilder<CivilStatus> builder)
        {
            builder.HasData(
                new CivilStatus
                {
                    Id = 1,
                    Name = "Single",
                },
                new CivilStatus
                {
                    Id = 2,
                    Name = "Married"
                },
                new CivilStatus
                {
                    Id = 3,
                    Name = "Widow"
                },
                new CivilStatus
                {
                    Id = 4,
                    Name = "Common Law"
                }
            );
        }
    }
}
