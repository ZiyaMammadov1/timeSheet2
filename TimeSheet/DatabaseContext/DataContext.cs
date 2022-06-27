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
        public DbSet<Database> Database { get; set; }
        //public DbSet<User> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        //public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        //public DbSet<WorkType> WorkType { get; set; }
        //public DbSet<mainTimeSheet> MainTimeSheets { get; set; }
        //public DbSet<Salary> Salaries { get; set; }
        //public DbSet<IdentityCard> IdentityCards { get; set; }
        //public DbSet<FamilyMembers> FamilyMembers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<typeOfOrder> typeOfOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Database>()
                .Property(p => p.uuid)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Database>()
                .Property(p => p.isDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Department>()
                .Property(p => p.uuid)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Department>()
                .Property(p => p.isDeleted)
                .HasDefaultValue(false);
            
            modelBuilder.Entity<Project>()
                .Property(p => p.uuid)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Project>()
                .Property(p => p.isDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Position>()
              .Property(p => p.uuid)
              .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Position>()
                .Property(p => p.isDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<typeOfOrder>()
             .Property(p => p.uuid)
             .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<typeOfOrder>()
                .Property(p => p.isDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Company>()
             .Property(p => p.uuid)
             .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Company>()
                .Property(p => p.isDeleted)
                .HasDefaultValue(false); 
            
            modelBuilder.Entity<Company>()
                .Property(p => p.isActive)
                .HasDefaultValue(true);

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
