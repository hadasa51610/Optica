﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Optica.Data;

#nullable disable

namespace Optica.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250108165821_optica")]
    partial class optica
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ModelOrder", b =>
                {
                    b.Property<int>("ModelsId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("int");

                    b.HasKey("ModelsId", "OrdersOrderId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("ModelOrder");
                });

            modelBuilder.Entity("Optica.Core.Entites.Check", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CheckDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CheckId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CheckerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NeedGlass")
                        .HasColumnType("bit");

                    b.Property<double>("Number")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Check");
                });

            modelBuilder.Entity("Optica.Core.Entites.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<string>("DiscountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EAge")
                        .HasColumnType("int");

                    b.Property<int>("ESickFundName")
                        .HasColumnType("int");

                    b.Property<string>("Rules")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SickFundId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("Optica.Core.Entites.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GlassSort")
                        .HasColumnType("int");

                    b.Property<int>("GlassTarget")
                        .HasColumnType("int");

                    b.Property<string>("ModelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Scop")
                        .HasColumnType("float");

                    b.Property<string>("Shape")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("Optica.Core.Entites.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<int>("EPayment")
                        .HasColumnType("int");

                    b.Property<int>("EPlaceOrder")
                        .HasColumnType("int");

                    b.Property<int>("ItemsNumber")
                        .HasColumnType("int");

                    b.Property<string>("OrderCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrederDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceptionNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Optica.Core.Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<int>("CheckId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ESickFund")
                        .HasColumnType("int");

                    b.Property<int>("EStatus")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CheckId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("ModelOrder", b =>
                {
                    b.HasOne("Optica.Core.Entites.Model", null)
                        .WithMany()
                        .HasForeignKey("ModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Optica.Core.Entites.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Optica.Core.Entites.Order", b =>
                {
                    b.HasOne("Optica.Core.Entites.Discount", "Discount")
                        .WithMany("Orders")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Optica.Core.Entites.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discount");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Optica.Core.Entites.User", b =>
                {
                    b.HasOne("Optica.Core.Entites.Check", "Check")
                        .WithOne("User")
                        .HasForeignKey("Optica.Core.Entites.User", "CheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Check");
                });

            modelBuilder.Entity("Optica.Core.Entites.Check", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Optica.Core.Entites.Discount", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Optica.Core.Entites.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
