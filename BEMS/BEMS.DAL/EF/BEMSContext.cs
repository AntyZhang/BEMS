using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace BEMS.DAL.EF
{
    public partial class BEMSContext : DbContext
    {
        public BEMSContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["BEMSConnection"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<BEMSUsers>();
        }
    }
}
