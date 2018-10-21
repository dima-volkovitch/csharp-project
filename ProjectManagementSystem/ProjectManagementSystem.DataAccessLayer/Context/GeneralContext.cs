using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.DataAccessLayer.Context
{
    public class GeneralContext : DbContext
    {
        public GeneralContext() { }

        public GeneralContext(string connectionString) : base(connectionString) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Property(p => p.StartDate).HasColumnType("datetime2");
            modelBuilder.Entity<Project>().Property(p => p.FinishDate).HasColumnType("datetime2");
            modelBuilder.Entity<PaticipationHistory>().Property(ph => ph.FinishDate).HasColumnType("datetime2");
            modelBuilder.Entity<PaticipationHistory>().Property(ph => ph.StartDate).HasColumnType("datetime2");
        }
    }
}
