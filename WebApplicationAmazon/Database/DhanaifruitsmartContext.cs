using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationAmazon.Database
{
    public partial class DhanaifruitsmartContext : DbContext
    {
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=dhanaifruitsdb.cmap97gbtb25.us-west-2.rds.amazonaws.com;Initial Catalog=DhanaiFruitsMart;Persist Security Info=True;User ID=DhanaiFruitsDB;Password=DhanaiFruitsDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.CreatedDt).HasDefaultValueSql("getdate()");

                entity.Property(e => e.ModifiedDt).HasDefaultValueSql("getdate()");
            });
        }
    }
}