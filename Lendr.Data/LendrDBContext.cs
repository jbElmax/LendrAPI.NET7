
using Lendr.API.Models;
using Lendr.API.Models.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

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
    public class LendrDbContextFactory : IDesignTimeDbContextFactory<LendrDBContext>
    {
        public LendrDBContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",optional:false,reloadOnChange:true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<LendrDBContext>();
            var conn = config.GetConnectionString("LendrDBConnectionString");
            optionsBuilder.UseSqlServer(conn);
            return new LendrDBContext(optionsBuilder.Options);   
        }
    }
}
