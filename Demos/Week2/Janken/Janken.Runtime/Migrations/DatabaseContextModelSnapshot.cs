﻿// <auto-generated />
using System;
using Janken.Runtime.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Janken.Runtime.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Janken.Runtime.Models.Choice", b =>
                {
                    b.Property<Guid>("ChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("ChoiceId");

                    b.ToTable("Choice");

                    b.HasData(
                        new
                        {
                            ChoiceId = new Guid("5e739768-8422-4e4b-9eae-f917d417f15c"),
                            Name = "type",
                            Value = 0
                        },
                        new
                        {
                            ChoiceId = new Guid("eedce8ef-9da8-4148-be16-3c905f9d334c"),
                            Name = "type",
                            Value = 1
                        },
                        new
                        {
                            ChoiceId = new Guid("14db97b0-e33d-4704-b474-6c29303a8c9a"),
                            Name = "type",
                            Value = 2
                        },
                        new
                        {
                            ChoiceId = new Guid("96c29708-7bed-4338-9266-22821a38993b"),
                            Name = "type",
                            Value = 3
                        });
                });

            modelBuilder.Entity("Janken.Runtime.Models.Player", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Computer")
                        .HasColumnType("bit");

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.ToTable("Player");

                    b.HasData(
                        new
                        {
                            PlayerId = new Guid("cd62a0b8-1b65-43a2-8cd8-d00088d39d6c"),
                            Computer = true,
                            Handle = "Computer",
                            Password = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
