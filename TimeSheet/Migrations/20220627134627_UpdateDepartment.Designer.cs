﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeSheet.DatabaseContext;

namespace TimeSheet.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220627134627_UpdateDepartment")]
    partial class UpdateDepartment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimeSheet.Entities.Database", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("id");

                    b.ToTable("Database");
                });

            modelBuilder.Entity("TimeSheet.Entities.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("databaseId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("id");

                    b.HasIndex("databaseId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TimeSheet.Entities.Department", b =>
                {
                    b.HasOne("TimeSheet.Entities.Database", "Database")
                        .WithMany("Departments")
                        .HasForeignKey("databaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
