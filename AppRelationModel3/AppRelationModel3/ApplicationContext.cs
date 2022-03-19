using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRelationModel3
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb3;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(p => p.Company)
            .WithMany(t => t.Users)
            .HasForeignKey(p => p.CompanyName)
            .HasPrincipalKey(t => t.Name);
        }
    }

}
