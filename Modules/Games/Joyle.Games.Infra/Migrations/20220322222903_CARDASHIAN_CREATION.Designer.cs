// <auto-generated />
using System;
using Joyle.Games.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Joyle.Games.Infra.Migrations
{
    [DbContext(typeof(GamesContext))]
    [Migration("20220322222903_CARDASHIAN_CREATION")]
    partial class CARDASHIAN_CREATION
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Joyle.Games.Domain.Cardashians.Cardashian", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.ToTable("Cardashian");
                });

            modelBuilder.Entity("Joyle.Games.Domain.Cardashians.Cardashian", b =>
                {
                    b.OwnsMany("Joyle.Games.Domain.Cardashians.CardashianCard", "Cards", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("CardashianId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("VARCHAR(255)");

                            b1.Property<byte>("Position")
                                .HasColumnType("TINYINT");

                            b1.HasKey("Id");

                            b1.HasIndex("CardashianId");

                            b1.ToTable("CardashianCard");

                            b1.WithOwner()
                                .HasForeignKey("CardashianId");
                        });

                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
