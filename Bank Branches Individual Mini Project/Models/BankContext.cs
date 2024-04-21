using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Bank_Branches_Individual_Mini_Project.Models
{
    public class BankContext : DbContext
    {
        public DbSet<BankBranch> BankBranches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite("Data Source=banks.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed sample blog data:::::::::::::::::::::::::::
            modelBuilder.Entity<BankBranch>().HasData(
                new BankBranch { Id = 1, Name = "Khaldiya", Location = "https://maps.app.goo.gl/s2aCpoGSUFZHa4KS8", BranchManager = "Majed", EmployeeCount = 4 },
                new BankBranch{ Id = 2, Name = "Mansouriya", Location = "https://maps.app.goo.gl/N1AwujroTFMhVbVj9", BranchManager = "Ahmad", EmployeeCount = 3  }
            );
        }


    }
}
