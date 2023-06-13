﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Objectives.Repositories;

#nullable disable

namespace Objectives.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230613155446_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ObjectivePerformer", b =>
                {
                    b.Property<Guid>("ObjectivesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PerformersId")
                        .HasColumnType("uuid");

                    b.HasKey("ObjectivesId", "PerformersId");

                    b.HasIndex("PerformersId");

                    b.ToTable("ObjectivePerformer");
                });

            modelBuilder.Entity("Objectives.Models.Objective", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Objectives");
                });

            modelBuilder.Entity("Objectives.Models.Performer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Performers");
                });

            modelBuilder.Entity("ObjectivePerformer", b =>
                {
                    b.HasOne("Objectives.Models.Objective", null)
                        .WithMany()
                        .HasForeignKey("ObjectivesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Objectives.Models.Performer", null)
                        .WithMany()
                        .HasForeignKey("PerformersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
