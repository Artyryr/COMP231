﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Models;

namespace Project.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BillingAddress")
                        .IsRequired();

                    b.Property<int>("CVV");

                    b.Property<string>("CardNumber")
                        .IsRequired();

                    b.Property<DateTime>("ExpiryDate");

                    b.Property<string>("NameOnCard")
                        .IsRequired();

                    b.Property<string>("PostalCode")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Project.Models.RequestedService", b =>
                {
                    b.Property<int>("RequestedServiceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apartment")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<double>("NumberOfHours");

                    b.Property<int?>("PaymentId");

                    b.Property<string>("Province")
                        .IsRequired();

                    b.Property<int>("ServiceId");

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<string>("Telephone")
                        .IsRequired();

                    b.Property<double>("TotalPrice");

                    b.Property<string>("UserId");

                    b.Property<string>("ZIP")
                        .IsRequired();

                    b.HasKey("RequestedServiceId");

                    b.HasIndex("PaymentId");

                    b.ToTable("RequestedServices");
                });

            modelBuilder.Entity("Project.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("Rating");

                    b.Property<string>("ReviewText")
                        .IsRequired();

                    b.Property<int>("ServiceId");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("ReviewId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Project.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<double>("PricePerHour");

                    b.Property<string>("ServiceName");

                    b.Property<int>("ServiceTypeId");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Project.Models.ServiceType", b =>
                {
                    b.Property<int>("ServiceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("ServiceTypeName");

                    b.HasKey("ServiceTypeId");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("Project.Models.RequestedService", b =>
                {
                    b.HasOne("Project.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");
                });

            modelBuilder.Entity("Project.Models.Review", b =>
                {
                    b.HasOne("Project.Models.Service")
                        .WithMany("Reviews")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
