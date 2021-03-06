// <auto-generated />
using System;
using BootcampFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BootcampFinal.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20210704140455_rmve")]
    partial class rmve
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BootcampFinal.Models.AppointedPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("UserFlatId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.HasIndex("UserFlatId");

                    b.ToTable("AppointedPayments");
                });

            modelBuilder.Entity("BootcampFinal.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("BootcampFinal.Models.BuildingFlat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<int>("FlatId")
                        .HasColumnType("int");

                    b.Property<int>("FlatTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("FlatId");

                    b.HasIndex("FlatTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("BuildingFlats");
                });

            modelBuilder.Entity("BootcampFinal.Models.Flat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Flats");
                });

            modelBuilder.Entity("BootcampFinal.Models.FlatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FlatTypes");
                });

            modelBuilder.Entity("BootcampFinal.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BootcampFinal.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("BootcampFinal.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TCKN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@mail.com",
                            LastName = "Yavuz",
                            Name = "Ali",
                            Password = "123123",
                            PhoneNumber = "05056424177",
                            TCKN = "123456778901",
                            UserRole = 0
                        });
                });

            modelBuilder.Entity("BootcampFinal.Models.UserFlat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingFlatId")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingFlatId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFlats");
                });

            modelBuilder.Entity("BootcampFinal.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("BootcampFinal.Models.AppointedPayment", b =>
                {
                    b.HasOne("BootcampFinal.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BootcampFinal.Models.UserFlat", "UserFlat")
                        .WithMany()
                        .HasForeignKey("UserFlatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");

                    b.Navigation("UserFlat");
                });

            modelBuilder.Entity("BootcampFinal.Models.BuildingFlat", b =>
                {
                    b.HasOne("BootcampFinal.Models.Building", "Building")
                        .WithMany("BuildingFlats")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BootcampFinal.Models.Flat", "Flat")
                        .WithMany("BuildingFlats")
                        .HasForeignKey("FlatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BootcampFinal.Models.FlatType", "FlatType")
                        .WithMany("BuildingFlats")
                        .HasForeignKey("FlatTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BootcampFinal.Models.User", null)
                        .WithMany("BuildingFlats")
                        .HasForeignKey("UserId");

                    b.Navigation("Building");

                    b.Navigation("Flat");

                    b.Navigation("FlatType");
                });

            modelBuilder.Entity("BootcampFinal.Models.Payment", b =>
                {
                    b.HasOne("BootcampFinal.Models.PaymentType", "PaymentType")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("BootcampFinal.Models.UserFlat", b =>
                {
                    b.HasOne("BootcampFinal.Models.BuildingFlat", "BuildingFlat")
                        .WithMany("UserFlats")
                        .HasForeignKey("BuildingFlatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BootcampFinal.Models.Payment", "Payment")
                        .WithMany("UserFlats")
                        .HasForeignKey("PaymentId");

                    b.HasOne("BootcampFinal.Models.User", "User")
                        .WithMany("UserFlats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingFlat");

                    b.Navigation("Payment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BootcampFinal.Models.Vehicle", b =>
                {
                    b.HasOne("BootcampFinal.Models.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BootcampFinal.Models.Building", b =>
                {
                    b.Navigation("BuildingFlats");
                });

            modelBuilder.Entity("BootcampFinal.Models.BuildingFlat", b =>
                {
                    b.Navigation("UserFlats");
                });

            modelBuilder.Entity("BootcampFinal.Models.Flat", b =>
                {
                    b.Navigation("BuildingFlats");
                });

            modelBuilder.Entity("BootcampFinal.Models.FlatType", b =>
                {
                    b.Navigation("BuildingFlats");
                });

            modelBuilder.Entity("BootcampFinal.Models.Payment", b =>
                {
                    b.Navigation("UserFlats");
                });

            modelBuilder.Entity("BootcampFinal.Models.PaymentType", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("BootcampFinal.Models.User", b =>
                {
                    b.Navigation("BuildingFlats");

                    b.Navigation("UserFlats");

                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
