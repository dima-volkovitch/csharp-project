using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.DataAccessLayer.Context
{
    public class PMSContext : DbContext
    {
        public PMSContext() { }

        public PMSContext(string connectionString) : base(connectionString) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>().HasKey(b => new { b.UserId, b.ProjectId });
            modelBuilder.Entity<Project>().Property(p => p.StartDate).HasColumnType("datetime2");
            modelBuilder.Entity<Project>().Property(p => p.FinishDate).HasColumnType("datetime2");
        }
    }
}
