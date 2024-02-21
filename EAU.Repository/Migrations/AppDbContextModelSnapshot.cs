﻿// <auto-generated />
using System;
using EAU.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EAU.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EAU.Core.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DoorNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlumbingNumberId")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PlumbingNumberId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EAU.Core.Models.Consumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Consumers");
                });

            modelBuilder.Entity("EAU.Core.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EICCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastPaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("boolean");

                    b.Property<int>("PlumbingId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlumbingId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("EAU.Core.Models.Plumbing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Plumbings");
                });

            modelBuilder.Entity("EAU.Core.Models.Subscriber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PlumbingId")
                        .HasColumnType("integer");

                    b.Property<int>("PlumbingNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlumbingId");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("EAU.Core.Models.Address", b =>
                {
                    b.HasOne("EAU.Core.Models.Plumbing", "PlumbingNumber")
                        .WithMany()
                        .HasForeignKey("PlumbingNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlumbingNumber");
                });

            modelBuilder.Entity("EAU.Core.Models.Consumer", b =>
                {
                    b.HasOne("EAU.Core.Models.Subscriber", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("EAU.Core.Models.Invoice", b =>
                {
                    b.HasOne("EAU.Core.Models.Plumbing", "Plumbing")
                        .WithMany("Invoices")
                        .HasForeignKey("PlumbingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plumbing");
                });

            modelBuilder.Entity("EAU.Core.Models.Subscriber", b =>
                {
                    b.HasOne("EAU.Core.Models.Plumbing", "Plumbing")
                        .WithMany()
                        .HasForeignKey("PlumbingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plumbing");
                });

            modelBuilder.Entity("EAU.Core.Models.Plumbing", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
