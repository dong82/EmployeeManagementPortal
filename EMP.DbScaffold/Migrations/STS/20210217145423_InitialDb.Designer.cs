﻿// <auto-generated />
using EMP.DbScaffold.Models.Sts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EMP.DbScaffold.Migrations.Sts
{
    [DbContext(typeof(stsContext))]
    [Migration("20210217145423_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EMP.DbScaffold.Models.Sts.Aspnetroleclaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId")
                        .HasName("IX_AspNetRoleClaims_RoleId");

                    b.ToTable("aspnetroleclaims");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Sts.Aspnetroles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("aspnetroles");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Sts.Aspnetuserclaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .HasName("IX_AspNetUserClaims_UserId");

                    b.ToTable("aspnetuserclaims");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Sts.Aspnetuserlogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("PRIMARY");

                    b.HasIndex("UserId")
                        .HasName("IX_AspNetUserLogins_UserId");

                    b.ToTable("aspnetuserlogins");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Sts.Aspnetuserroles", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(767)");

                    b.HasKey("UserId", "RoleId")
                        .HasName("PRIMARY");

                    b.HasIndex("RoleId")
                        .HasName("IX_AspNetUserRoles_RoleId");

                    b.ToTable("aspnetuserroles");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Sts.Aspnetusers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int(11)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit(1)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("aspnetusers");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Sts.Aspnetusertokens", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("PRIMARY");

                    b.ToTable("aspnetusertokens");
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Sts.Efmigrationshistory", b =>
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

            modelBuilder.Entity("EMP.DbScaffold.Models.Sts.Aspnetroleclaims", b =>
                {
                    b.HasOne("EMP.DbScaffold.Models.Sts.Aspnetroles", "Role")
                        .WithMany("Aspnetroleclaims")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Sts.Aspnetuserclaims", b =>
                {
                    b.HasOne("EMP.DbScaffold.Models.Sts.Aspnetusers", "User")
                        .WithMany("Aspnetuserclaims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Sts.Aspnetuserlogins", b =>
                {
                    b.HasOne("EMP.DbScaffold.Models.Sts.Aspnetusers", "User")
                        .WithMany("Aspnetuserlogins")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Sts.Aspnetuserroles", b =>
                {
                    b.HasOne("EMP.DbScaffold.Models.Sts.Aspnetroles", "Role")
                        .WithMany("Aspnetuserroles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMP.DbScaffold.Models.Sts.Aspnetusers", "User")
                        .WithMany("Aspnetuserroles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMP.DbScaffold.Models.Sts.Aspnetusertokens", b =>
                {
                    b.HasOne("EMP.DbScaffold.Models.Sts.Aspnetusers", "User")
                        .WithMany("Aspnetusertokens")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
