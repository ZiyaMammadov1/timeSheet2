﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeSheet.DatabaseContext;

namespace TimeSheet.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220704061525_UpdateOrderTable2.1")]
    partial class UpdateOrderTable21
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimeSheet.Entities.Company", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("databaseId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("id");

                    b.HasIndex("databaseId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TimeSheet.Entities.Contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Databaseid")
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dbId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("phone1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("id");

                    b.HasIndex("Databaseid");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("TimeSheet.Entities.DBEmployee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.Property<int>("databaseId")
                        .HasColumnType("int");

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("isDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("positionId")
                        .HasColumnType("int");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("companyId");

                    b.HasIndex("databaseId");

                    b.HasIndex("departmentId");

                    b.HasIndex("employeeId");

                    b.HasIndex("positionId");

                    b.HasIndex("projectId");

                    b.ToTable("dBEmployees");
                });

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

                    b.Property<string>("port")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("server")
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
                        .HasColumnType("nvarchar(450)");

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

                    b.HasIndex("code")
                        .IsUnique()
                        .HasFilter("[code] IS NOT NULL");

                    b.HasIndex("databaseId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TimeSheet.Entities.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Databaseid")
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("id");

                    b.HasIndex("Databaseid");

                    b.HasIndex("fin")
                        .IsUnique()
                        .HasFilter("[fin] IS NOT NULL");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TimeSheet.Entities.FamilyMembers", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("dbId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("fin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("relative")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("id");

                    b.HasIndex("code")
                        .IsUnique()
                        .HasFilter("[code] IS NOT NULL");

                    b.ToTable("FamilyMembers");
                });

            modelBuilder.Entity("TimeSheet.Entities.IdentityCard", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("databaseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("expireTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("issiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("series")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("id");

                    b.HasIndex("databaseId");

                    b.HasIndex("employeeId");

                    b.ToTable("IdentityCards");
                });

            modelBuilder.Entity("TimeSheet.Entities.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateEffective")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateExpired")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateTo")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("days")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("dbCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("deprtmentID")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("orderType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("positionId")
                        .HasColumnType("int");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.Property<decimal>("salary1")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("salary2")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("salaryTotal")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("tin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("totalDays")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("id");

                    b.HasIndex("code")
                        .IsUnique()
                        .HasFilter("[code] IS NOT NULL");

                    b.HasIndex("companyId");

                    b.HasIndex("deprtmentID");

                    b.HasIndex("positionId");

                    b.HasIndex("projectId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TimeSheet.Entities.Position", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(450)");

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

                    b.HasIndex("code")
                        .IsUnique()
                        .HasFilter("[code] IS NOT NULL");

                    b.HasIndex("databaseId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("TimeSheet.Entities.Project", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(450)");

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

                    b.HasIndex("code")
                        .IsUnique()
                        .HasFilter("[code] IS NOT NULL");

                    b.HasIndex("databaseId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TimeSheet.Entities.RefreshToken", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("RefreshTokenEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshTokenString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("employeeId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("TimeSheet.Entities.typeOfOrder", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
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

                    b.HasIndex("code")
                        .IsUnique()
                        .HasFilter("[code] IS NOT NULL");

                    b.ToTable("typeOfOrders");
                });

            modelBuilder.Entity("TimeSheet.Entities.Company", b =>
                {
                    b.HasOne("TimeSheet.Entities.Database", "Database")
                        .WithMany("Companies")
                        .HasForeignKey("databaseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TimeSheet.Entities.Contact", b =>
                {
                    b.HasOne("TimeSheet.Entities.Database", null)
                        .WithMany("Contact")
                        .HasForeignKey("Databaseid")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TimeSheet.Entities.DBEmployee", b =>
                {
                    b.HasOne("TimeSheet.Entities.Company", "Company")
                        .WithMany("DbEmployees")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TimeSheet.Entities.Database", "Database")
                        .WithMany("DbEmployees")
                        .HasForeignKey("databaseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TimeSheet.Entities.Department", "Depament")
                        .WithMany("DbEmployees")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TimeSheet.Entities.Employee", "Employee")
                        .WithMany("DbEmployees")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TimeSheet.Entities.Position", "Position")
                        .WithMany("dBEmployees")
                        .HasForeignKey("positionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TimeSheet.Entities.Project", "Project")
                        .WithMany("DbEmployees")
                        .HasForeignKey("projectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TimeSheet.Entities.Department", b =>
                {
                    b.HasOne("TimeSheet.Entities.Database", "Database")
                        .WithMany("Departments")
                        .HasForeignKey("databaseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TimeSheet.Entities.Employee", b =>
                {
                    b.HasOne("TimeSheet.Entities.Database", null)
                        .WithMany("Employees")
                        .HasForeignKey("Databaseid")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TimeSheet.Entities.IdentityCard", b =>
                {
                    b.HasOne("TimeSheet.Entities.Database", "Database")
                        .WithMany("IdentityCards")
                        .HasForeignKey("databaseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TimeSheet.Entities.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TimeSheet.Entities.Order", b =>
                {
                    b.HasOne("TimeSheet.Entities.Company", "Company")
                        .WithMany("Orders")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TimeSheet.Entities.Department", "Deprtment")
                        .WithMany("Orders")
                        .HasForeignKey("deprtmentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TimeSheet.Entities.Position", "Position")
                        .WithMany("Orders")
                        .HasForeignKey("positionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TimeSheet.Entities.Project", "Project")
                        .WithMany("Orders")
                        .HasForeignKey("projectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TimeSheet.Entities.Position", b =>
                {
                    b.HasOne("TimeSheet.Entities.Database", "Database")
                        .WithMany("Positions")
                        .HasForeignKey("databaseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TimeSheet.Entities.Project", b =>
                {
                    b.HasOne("TimeSheet.Entities.Database", "Database")
                        .WithMany("Projects")
                        .HasForeignKey("databaseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TimeSheet.Entities.RefreshToken", b =>
                {
                    b.HasOne("TimeSheet.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
