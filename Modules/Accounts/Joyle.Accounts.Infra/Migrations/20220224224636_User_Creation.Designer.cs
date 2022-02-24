﻿// <auto-generated />
using System;
using Joyle.Accounts.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Joyle.Accounts.Infra.Migrations
{
    [DbContext(typeof(AccountsContext))]
    [Migration("20220224224636_User_Creation")]
    partial class User_Creation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Joyle.Accounts.Domain.UserRegistrations.UserRegistration", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ConfirmationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UserRegistration");
                });

            modelBuilder.Entity("Joyle.Accounts.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Joyle.Accounts.Domain.UserRegistrations.UserRegistration", b =>
                {
                    b.OwnsOne("Joyle.Accounts.Domain.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserRegistrationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("VARCHAR(100)")
                                .HasColumnName("Email");

                            b1.HasKey("UserRegistrationId");

                            b1.ToTable("UserRegistration");

                            b1.WithOwner()
                                .HasForeignKey("UserRegistrationId");
                        });

                    b.OwnsOne("Joyle.Accounts.Domain.UserRegistrations.UserRegistrationStatus", "Status", b1 =>
                        {
                            b1.Property<Guid>("UserRegistrationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("varchar(30)")
                                .HasColumnName("Status");

                            b1.HasKey("UserRegistrationId");

                            b1.ToTable("UserRegistration");

                            b1.WithOwner()
                                .HasForeignKey("UserRegistrationId");
                        });

                    b.OwnsOne("Joyle.Accounts.Domain.Username", "Username", b1 =>
                        {
                            b1.Property<Guid>("UserRegistrationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("VARCHAR(30)")
                                .HasColumnName("Username");

                            b1.HasKey("UserRegistrationId");

                            b1.ToTable("UserRegistration");

                            b1.WithOwner()
                                .HasForeignKey("UserRegistrationId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Status")
                        .IsRequired();

                    b.Navigation("Username")
                        .IsRequired();
                });

            modelBuilder.Entity("Joyle.Accounts.Domain.Users.User", b =>
                {
                    b.OwnsOne("Joyle.Accounts.Domain.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("VARCHAR(100)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Joyle.Accounts.Domain.Username", "Username", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("VARCHAR(30)")
                                .HasColumnName("Username");

                            b1.HasKey("UserId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Username")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
