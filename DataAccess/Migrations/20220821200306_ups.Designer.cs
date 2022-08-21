﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220821200306_ups")]
    partial class ups
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Boat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("AreHeadlightsOn")
                        .HasColumnType("bit");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Boats");
                });

            modelBuilder.Entity("Entities.Bus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("AreHeadlightsOn")
                        .HasColumnType("bit");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("Entities.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("AreHeadlightsOn")
                        .HasColumnType("bit");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Entities.Wheel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("BusID")
                        .HasColumnType("int");

                    b.Property<int?>("CarID")
                        .HasColumnType("int");

                    b.Property<int>("Diameter")
                        .HasColumnType("int");

                    b.Property<int>("WheelCount")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BusID");

                    b.HasIndex("CarID");

                    b.ToTable("Wheel");
                });

            modelBuilder.Entity("Entities.Wheel", b =>
                {
                    b.HasOne("Entities.Bus", null)
                        .WithMany("Wheels")
                        .HasForeignKey("BusID");

                    b.HasOne("Entities.Car", null)
                        .WithMany("Wheels")
                        .HasForeignKey("CarID");
                });

            modelBuilder.Entity("Entities.Bus", b =>
                {
                    b.Navigation("Wheels");
                });

            modelBuilder.Entity("Entities.Car", b =>
                {
                    b.Navigation("Wheels");
                });
#pragma warning restore 612, 618
        }
    }
}