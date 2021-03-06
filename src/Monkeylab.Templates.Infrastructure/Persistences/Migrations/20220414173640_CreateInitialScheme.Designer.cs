// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monkeylab.Templates.Infrastructure.Persistences.Contexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Monkeylab.Templates.Infrastructure.Persistences.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220414173640_CreateInitialScheme")]
    partial class CreateInitialScheme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Monkeylab.Templates.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("45cb6716-7c13-4903-be4e-5da0513d834e"),
                            CreatedAt = new DateTime(2012, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Customer One"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
