﻿// <auto-generated />
using System;
using EMP.DbScaffold.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EMP.DbScaffold.Migrations.Employees
{
    [DbContext(typeof(employeesContext))]
    [Migration("20210211152430_UpdatedDb_2")]
    partial class UpdatedDb_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EMP.DbScaffold.Models.Departments", b =>
                {
                    b.Property<string>("DeptNo")
                        .HasColumnName("dept_no")
                        .HasColumnType("char(4)")
                        .IsFixedLength(true)
                        .HasMaxLength(4);

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnName("dept_name")
                        .HasColumnType("varchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("DeptShortName")
                        .HasColumnType("text");

                    b.HasKey("DeptNo")
                        .HasName("PRIMARY");

                    b.HasIndex("DeptName")
                        .IsUnique()
                        .HasName("dept_name");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.DeptEmp", b =>
                {
                    b.Property<int>("EmpNo")
                        .HasColumnName("emp_no")
                        .HasColumnType("int(11)");

                    b.Property<string>("DeptNo")
                        .HasColumnName("dept_no")
                        .HasColumnType("char(4)")
                        .IsFixedLength(true)
                        .HasMaxLength(4);

                    b.Property<DateTime>("FromDate")
                        .HasColumnName("from_date")
                        .HasColumnType("date");

                    b.Property<DateTime>("ToDate")
                        .HasColumnName("to_date")
                        .HasColumnType("date");

                    b.HasKey("EmpNo", "DeptNo", "FromDate", "ToDate")
                        .HasName("PRIMARY");

                    b.HasIndex("DeptNo")
                        .HasName("dept_no");

                    b.HasIndex("EmpNo", "ToDate")
                        .HasName("dept_emp_emp_no_IDX");

                    b.ToTable("dept_emp");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.DeptEmpCurrent", b =>
                {
                    b.Property<int>("EmpNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("emp_no")
                        .HasColumnType("int(11)");

                    b.Property<string>("DeptNo")
                        .IsRequired()
                        .HasColumnName("dept_no")
                        .HasColumnType("char(4)")
                        .IsFixedLength(true)
                        .HasMaxLength(4);

                    b.Property<DateTime>("FromDate")
                        .HasColumnName("from_date")
                        .HasColumnType("date");

                    b.Property<DateTime>("ToDate")
                        .HasColumnName("to_date")
                        .HasColumnType("date");

                    b.HasKey("EmpNo")
                        .HasName("PRIMARY");

                    b.HasIndex("DeptNo")
                        .HasName("dept_emp_current_dept_no_IDX");

                    b.HasIndex("EmpNo")
                        .IsUnique()
                        .HasName("dept_emp_current_emp_no_IDX");

                    b.ToTable("dept_emp_current");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.DeptManager", b =>
                {
                    b.Property<int>("EmpNo")
                        .HasColumnName("emp_no")
                        .HasColumnType("int(11)");

                    b.Property<string>("DeptNo")
                        .HasColumnName("dept_no")
                        .HasColumnType("char(4)")
                        .IsFixedLength(true)
                        .HasMaxLength(4);

                    b.Property<DateTime>("FromDate")
                        .HasColumnName("from_date")
                        .HasColumnType("date");

                    b.Property<DateTime>("ToDate")
                        .HasColumnName("to_date")
                        .HasColumnType("date");

                    b.HasKey("EmpNo", "DeptNo", "FromDate", "ToDate")
                        .HasName("PRIMARY");

                    b.HasIndex("DeptNo", "ToDate")
                        .HasName("dept_manager_dept_no_IDX");

                    b.ToTable("dept_manager");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.DeptManagerCurrent", b =>
                {
                    b.Property<string>("DeptNo")
                        .HasColumnName("dept_no")
                        .HasColumnType("char(4)")
                        .IsFixedLength(true)
                        .HasMaxLength(4);

                    b.Property<int>("EmpNo")
                        .HasColumnName("emp_no")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnName("from_date")
                        .HasColumnType("date");

                    b.Property<DateTime>("ToDate")
                        .HasColumnName("to_date")
                        .HasColumnType("date");

                    b.HasKey("DeptNo")
                        .HasName("PRIMARY");

                    b.HasIndex("DeptNo")
                        .IsUnique()
                        .HasName("dept_manager_current_dept_no_IDX");

                    b.ToTable("dept_manager_current");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Efmigrationshistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("MigrationId")
                        .HasName("PRIMARY");

                    b.ToTable("__efmigrationshistory");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.EmpDetailsCache", b =>
                {
                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("birth_date")
                        .HasColumnType("date");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnName("dept_name")
                        .HasColumnType("varchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("DeptNo")
                        .IsRequired()
                        .HasColumnName("dept_no")
                        .HasColumnType("char(4)")
                        .IsFixedLength(true)
                        .HasMaxLength(4);

                    b.Property<int>("EmpNo")
                        .HasColumnName("emp_no")
                        .HasColumnType("int(11)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnName("gender")
                        .HasColumnType("enum('M','F')");

                    b.Property<DateTime>("HireDate")
                        .HasColumnName("hire_date")
                        .HasColumnType("date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(16)")
                        .HasMaxLength(16);

                    b.Property<int>("ManagerEmpNo")
                        .HasColumnName("manager_emp_no")
                        .HasColumnType("int(11)");

                    b.Property<string>("ManagerFirstName")
                        .IsRequired()
                        .HasColumnName("manager_first_name")
                        .HasColumnType("varchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("ManagerLastName")
                        .IsRequired()
                        .HasColumnName("manager_last_name")
                        .HasColumnType("varchar(16)")
                        .HasMaxLength(16);

                    b.Property<int?>("Salary")
                        .HasColumnName("salary")
                        .HasColumnType("int(11)");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.ToTable("emp_details_cache");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Employees", b =>
                {
                    b.Property<int>("EmpNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("emp_no")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("birth_date")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnName("gender")
                        .HasColumnType("enum('M','F')");

                    b.Property<DateTime>("HireDate")
                        .HasColumnName("hire_date")
                        .HasColumnType("date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(16)")
                        .HasMaxLength(16);

                    b.HasKey("EmpNo")
                        .HasName("PRIMARY");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Salaries", b =>
                {
                    b.Property<int>("EmpNo")
                        .HasColumnName("emp_no")
                        .HasColumnType("int(11)");

                    b.Property<int>("Salary")
                        .HasColumnName("salary")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnName("from_date")
                        .HasColumnType("date");

                    b.Property<DateTime>("ToDate")
                        .HasColumnName("to_date")
                        .HasColumnType("date");

                    b.HasKey("EmpNo", "Salary", "FromDate", "ToDate")
                        .HasName("PRIMARY");

                    b.HasIndex("EmpNo", "ToDate")
                        .HasName("salaries_emp_no_IDX");

                    b.ToTable("salaries");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.SalariesCurrent", b =>
                {
                    b.Property<int>("EmpNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("emp_no")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnName("from_date")
                        .HasColumnType("date");

                    b.Property<int>("Salary")
                        .HasColumnName("salary")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("ToDate")
                        .HasColumnName("to_date")
                        .HasColumnType("date");

                    b.HasKey("EmpNo")
                        .HasName("PRIMARY");

                    b.HasIndex("EmpNo")
                        .IsUnique()
                        .HasName("salaries_current_emp_no_IDX");

                    b.HasIndex("Salary")
                        .HasName("salaries_current_salary_IDX");

                    b.ToTable("salaries_current");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Titles", b =>
                {
                    b.Property<int>("EmpNo")
                        .HasColumnName("emp_no")
                        .HasColumnType("int(11)");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("FromDate")
                        .HasColumnName("from_date")
                        .HasColumnType("date");

                    b.Property<DateTime>("ToDate")
                        .HasColumnName("to_date")
                        .HasColumnType("date");

                    b.HasKey("EmpNo", "Title", "FromDate", "ToDate")
                        .HasName("PRIMARY");

                    b.HasIndex("EmpNo", "ToDate")
                        .HasName("titles_emp_no_IDX");

                    b.ToTable("titles");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.TitlesCurrent", b =>
                {
                    b.Property<int>("EmpNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("emp_no")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnName("from_date")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ToDate")
                        .HasColumnName("to_date")
                        .HasColumnType("date");

                    b.HasKey("EmpNo")
                        .HasName("PRIMARY");

                    b.HasIndex("EmpNo")
                        .IsUnique()
                        .HasName("titles_current_emp_no_IDX");

                    b.HasIndex("Title")
                        .HasName("titles_current_title_IDX");

                    b.ToTable("titles_current");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.DeptEmp", b =>
                {
                    b.HasOne("EMP.DbScaffold.Models.Departments", "DeptNoNavigation")
                        .WithMany("DeptEmp")
                        .HasForeignKey("DeptNo")
                        .HasConstraintName("dept_emp_ibfk_2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMP.DbScaffold.Models.Employees", "EmpNoNavigation")
                        .WithMany("DeptEmp")
                        .HasForeignKey("EmpNo")
                        .HasConstraintName("dept_emp_ibfk_1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.DeptManager", b =>
                {
                    b.HasOne("EMP.DbScaffold.Models.Departments", "DeptNoNavigation")
                        .WithMany("DeptManager")
                        .HasForeignKey("DeptNo")
                        .HasConstraintName("dept_manager_ibfk_2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMP.DbScaffold.Models.Employees", "EmpNoNavigation")
                        .WithMany("DeptManager")
                        .HasForeignKey("EmpNo")
                        .HasConstraintName("dept_manager_ibfk_1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Salaries", b =>
                {
                    b.HasOne("EMP.DbScaffold.Models.Employees", "EmpNoNavigation")
                        .WithMany("Salaries")
                        .HasForeignKey("EmpNo")
                        .HasConstraintName("salaries_ibfk_1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Titles", b =>
                {
                    b.HasOne("EMP.DbScaffold.Models.Employees", "EmpNoNavigation")
                        .WithMany("Titles")
                        .HasForeignKey("EmpNo")
                        .HasConstraintName("titles_ibfk_1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
