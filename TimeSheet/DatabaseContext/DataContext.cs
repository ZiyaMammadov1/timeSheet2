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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DBEmployee> dBEmployees { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<mainTimeSheet> MainTimeSheets { get; set; }
        //public DbSet<Salary> Salaries { get; set; }
        public DbSet<IdentityCard> IdentityCards { get; set; }
        public DbSet<FamilyMembers> FamilyMembers { get; set; }
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

            modelBuilder.Entity<Employee>()
             .Property(p => p.uuid)
             .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Employee>()
                .Property(p => p.isDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Employee>()
                .HasIndex(p => p.fin)
                .IsUnique(true);


            modelBuilder.Entity<IdentityCard>()
             .Property(p => p.uuid)
             .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<IdentityCard>()
                .Property(p => p.isDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<IdentityCard>()
                .Property(p => p.isActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Contact>()
           .Property(p => p.uuid)
           .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Contact>()
                .Property(p => p.isDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Contact>()
           .Property(p => p.dbCode)
           .IsRequired(true);

            modelBuilder.Entity<Order>()
        .Property(p => p.uuid)
        .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Order>()
               .Property(p => p.isDeleted)
               .HasDefaultValue(false);

            modelBuilder.Entity<DBEmployee>()
             .Property(p => p.isDelete)
             .HasDefaultValue(false);

            modelBuilder.Entity<DBEmployee>()
             .Property(p => p.isActive)
             .HasDefaultValue(true);

            modelBuilder.Entity<FamilyMembers>()
              .Property(p => p.uuid)
              .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<FamilyMembers>()
               .Property(p => p.isDeleted)
               .HasDefaultValue(false);

            modelBuilder.Entity<Project>()
                .HasIndex(x => x.code)
                .IsUnique(true);
            
            modelBuilder.Entity<Department>()
                .HasIndex(x => x.code)
                .IsUnique(true);

            modelBuilder.Entity<Position>()
                .HasIndex(x => x.code)
                .IsUnique(true);

            modelBuilder.Entity<Order>()
               .HasIndex(x => x.code)
               .IsUnique(true);

            //modelBuilder.Entity<User>()
            //    .HasIndex(a => a.fin)
            //    .IsUnique();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }



        }
    }
}
