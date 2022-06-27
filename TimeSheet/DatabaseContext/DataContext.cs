using Microsoft.EntityFrameworkCore;
using System.Linq;
using TimeSheet.Entities;

namespace TimeSheet.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //public DbSet<User> Employees { get; set; }
        //public DbSet<Position> Positions { get; set; }
        //public DbSet<RefreshToken> RefreshTokens { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Project> Projects { get; set; }
        //public DbSet<WorkType> WorkType { get; set; }
        //public DbSet<mainTimeSheet> MainTimeSheets { get; set; }
        //public DbSet<Salary> Salaries { get; set; }
        //public DbSet<IdentityCard> IdentityCards { get; set; }
        //public DbSet<FamilyMembers> FamilyMembers { get; set; }
        //public DbSet<Company> Companies { get; set; }
        //public DbSet<OrderTypes> OrderTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>()
            //    .HasIndex(a => a.fin)
            //    .IsUnique();

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}
            


        }
    }
}
