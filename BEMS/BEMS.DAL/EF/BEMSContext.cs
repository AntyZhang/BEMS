using BEMS.DAL.EF.DBModels;
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
            //optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["BEMSConnection"].ConnectionString);
            optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=123;port=3306;database=bems;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Menu>().HasKey(t => t.ID);
            modelBuilder.Entity<Menu>()
                        .HasMany(t => t.Children)
                        .WithOne(t => t.Parent)
                        .HasForeignKey(t => t.ParentID);
        }


        public DbSet<Users> Users { get; set; }

        public DbSet<FlowNewEqRequest> FlowNewEqRequests { get; set; }
        
        public DbSet<Menu> Menus { get; set; }
    }
}
