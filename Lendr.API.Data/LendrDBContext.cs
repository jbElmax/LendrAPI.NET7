using Lendr.API.Models;
using Lendr.API.Models.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lendr.API.Data
{
    public class LendrDBContext:IdentityDbContext<ApiUser>
    {
        public LendrDBContext(DbContextOptions options):base(options)
        {
            
        }       
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<CivilStatus> CivilStatuses { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CivilStatusConfiguration());
            modelBuilder.ApplyConfiguration(new BorrowerConfiguration());

        }
    }

}
