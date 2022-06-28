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
        public DbSet<DbEmployee> DbEmployees { get; set; }
        //public DbSet<Employee> Employees{ get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Card> IdentityCards { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<typeOfOrder> typeOfOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Contact> Contacts { get; set; }


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

            //modelBuilder.Entity<Employee>()
            // .Property(p => p.uuid)
            // .HasDefaultValueSql("NEWID()");

            //modelBuilder.Entity<Employee>()
            //    .Property(p => p.isDeleted)
            //    .HasDefaultValue(false);

            //modelBuilder.Entity<Employee>()
            //    .HasIndex(p => p.fin)
            //    .IsUnique(true);

            modelBuilder.Entity<Database>()
               .HasIndex(p => p.code)
               .IsUnique(true);

            modelBuilder.Entity<DbEmployee>()
               .Property(p => p.uuid)
             .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<DbEmployee>()
             .Property(p => p.isDeleted)
             .HasDefaultValue(false);

            modelBuilder.Entity<DbEmployee>()
               .Property(p => p.isActive)
               .HasDefaultValue(true);

            modelBuilder.Entity<Card>()
             .Property(p => p.uuid)
           .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Card>()
               .Property(p => p.isActive)
               .HasDefaultValue(true);

            modelBuilder.Entity<Card>()
              .Property(p => p.isDeleted)
              .HasDefaultValue(false);

            modelBuilder.Entity<Contact>()
             .Property(p => p.isDeleted)
             .HasDefaultValue(false);

            modelBuilder.Entity<Contact>()
            .Property(p => p.uuid)
            .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Order>()
           .Property(p => p.uuid)
           .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Order>()
            .Property(p => p.isDeleted)
            .HasDefaultValue(false);

            modelBuilder.Entity<User>()
          .Property(p => p.uuid)
          .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<User>()
            .Property(p => p.isDeleted)
            .HasDefaultValue(false);

            modelBuilder.Entity<User>()
             .HasIndex(p => p.code)
             .IsUnique(true);

            modelBuilder.Entity<Card>()
               .Property(p => p.isDeleted)
               .HasDefaultValue(false);
            
            modelBuilder.Entity<Card>()
               .Property(p => p.isActive)
               .HasDefaultValue(false);

            modelBuilder.Entity<Card>()
          .Property(p => p.uuid)
          .HasDefaultValueSql("NEWID()");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //modelBuilder.Entity<User>()
            //    .HasIndex(a => a.fin)
            //    .IsUnique();





        }
    }
}
