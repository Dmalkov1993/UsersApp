﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UsersApp.DAL;

namespace UsersApp.DAL.Migrations
{
    [DbContext(typeof(UsersAppDbContext))]
    partial class UsersAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("UsersApp.DAL.Entities.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Organizations", "UsersApp");
                });

            modelBuilder.Entity("UsersApp.DAL.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<long?>("OrganizationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text")
                        .HasColumnName("Patronymic");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("PhoneNumber");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("Surname");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Users", "UsersApp");
                });

            modelBuilder.Entity("UsersApp.DAL.Entities.User", b =>
                {
                    b.HasOne("UsersApp.DAL.Entities.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("UsersApp.DAL.Entities.Organization", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
