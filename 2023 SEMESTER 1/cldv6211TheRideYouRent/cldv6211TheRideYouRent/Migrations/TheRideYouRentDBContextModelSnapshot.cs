﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cldv6211TheRideYouRent.Data;

#nullable disable

namespace cldv6211TheRideYouRent.Migrations
{
    [DbContext(typeof(TheRideYouRentDBContext))]
    partial class TheRideYouRentDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("cldv6211TheRideYouRent.Models.Car", b =>
                {
                    b.Property<string>("CarNo")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Avaliable")
                        .IsRequired()
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("varchar(4)");

                    b.Property<string>("BodyType")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("CarMake")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Car_Make");

                    b.Property<int?>("KilometresTravelled")
                        .HasColumnType("int")
                        .HasColumnName("Kilometres_Travelled");

                    b.Property<string>("Model")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("ServiceKilometres")
                        .HasColumnType("int")
                        .HasColumnName("Service_kilometres");

                    b.HasKey("CarNo")
                        .HasName("PK__Car__68A00DDDD9F8C0AF");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("cldv6211TheRideYouRent.Models.CarBodyType", b =>
                {
                    b.Property<int>("CarBodyTypeId")
                        .HasColumnType("int")
                        .HasColumnName("Car_BodyTypeID");

                    b.Property<string>("BodyTypeDescription")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("BodyType_Description");

                    b.HasKey("CarBodyTypeId");

                    b.ToTable("Car_BodyType", (string)null);
                });

            modelBuilder.Entity("cldv6211TheRideYouRent.Models.CarMake", b =>
                {
                    b.Property<int>("CarMakeId")
                        .HasColumnType("int")
                        .HasColumnName("Car_MakeID");

                    b.Property<string>("MakeDescription")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Make_Description");

                    b.HasKey("CarMakeId");

                    b.ToTable("Car_Make", (string)null);
                });

            modelBuilder.Entity("cldv6211TheRideYouRent.Models.Driver", b =>
                {
                    b.Property<string>("DriverId")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Driver_ID");

                    b.Property<string>("DriverAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DriverContactNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("DriverEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DriverName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("DriverId");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("cldv6211TheRideYouRent.Models.Inspector", b =>
                {
                    b.Property<string>("InspectorNo")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("Inspector_no");

                    b.Property<string>("InspectorEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("InspectorMobile")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("InspectorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("InspectorNo")
                        .HasName("PK__Inspecto__F49FBEAF2C10A3C3");

                    b.ToTable("Inspector");
                });

            modelBuilder.Entity("cldv6211TheRideYouRent.Models.Rental", b =>
                {
                    b.Property<string>("RentalNo")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("Rental_no");

                    b.Property<string>("CarNo")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("DriverId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Driver_ID");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("InspectorNo")
                        .IsRequired()
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("Inspector_no");

                    b.Property<decimal>("RentalFee")
                        .HasColumnType("decimal(8,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("RentalNo")
                        .HasName("PK__Rental__9D208995B2480FB1");

                    b.HasIndex("CarNo");

                    b.HasIndex("DriverId");

                    b.HasIndex("InspectorNo");

                    b.ToTable("Rental");
                });

            modelBuilder.Entity("cldv6211TheRideYouRent.Models.ReturnCar", b =>
                {
                    b.Property<string>("ReturnId")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("Return_id");

                    b.Property<int>("ElapsedDate")
                        .HasColumnType("int");

                    b.Property<double?>("Fine")
                        .HasColumnType("float");

                    b.Property<string>("InspectorNo")
                        .IsRequired()
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("Inspector_no");

                    b.Property<string>("RentalNo")
                        .IsRequired()
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("Rental_no");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("date");

                    b.HasKey("ReturnId")
                        .HasName("PK__ReturnCa__0F4E406EA5064E40");

                    b.HasIndex("InspectorNo");

                    b.HasIndex("RentalNo");

                    b.ToTable("ReturnCar");
                });

            modelBuilder.Entity("cldv6211TheRideYouRent.Models.Rental", b =>
                {
                    b.HasOne("cldv6211TheRideYouRent.Models.Car", "CarNoNavigation")
                        .WithMany("Rental")
                        .HasForeignKey("CarNo")
                        .IsRequired()
                        .HasConstraintName("FK__Rental__CarNo__6D0D32F4");

                    b.HasOne("cldv6211TheRideYouRent.Models.Driver", "Driver")
                        .WithMany("Rental")
                        .HasForeignKey("DriverId")
                        .IsRequired()
                        .HasConstraintName("FK__Rental__Driver_I__6EF57B66");

                    b.HasOne("cldv6211TheRideYouRent.Models.Inspector", "InspectorNoNavigation")
                        .WithMany("Rental")
                        .HasForeignKey("InspectorNo")
                        .IsRequired()
                        .HasConstraintName("FK__Rental__Inspecto__6E01572D");

                    b.Navigation("CarNoNavigation");

                    b.Navigation("Driver");

                    b.Navigation("InspectorNoNavigation");
                });

            modelBuilder.Entity("cldv6211TheRideYouRent.Models.ReturnCar", b =>
                {
                    b.HasOne("cldv6211TheRideYouRent.Models.Inspector", "InspectorNoNavigation")
                        .WithMany("ReturnCar")
                        .HasForeignKey("InspectorNo")
                        .IsRequired()
                        .HasConstraintName("FK__ReturnCar__Inspe__70DDC3D8");

                    b.HasOne("cldv6211TheRideYouRent.Models.Rental", "RentalNoNavigation")
                        .WithMany("ReturnCar")
                        .HasForeignKey("RentalNo")
                        .IsRequired()
                        .HasConstraintName("FK__ReturnCar__Renta__6FE99F9F");

                    b.Navigation("InspectorNoNavigation");

                    b.Navigation("RentalNoNavigation");
                });

            modelBuilder.Entity("cldv6211TheRideYouRent.Models.Car", b =>
                {
                    b.Navigation("Rental");
                });

            modelBuilder.Entity("cldv6211TheRideYouRent.Models.Driver", b =>
                {
                    b.Navigation("Rental");
                });

            modelBuilder.Entity("cldv6211TheRideYouRent.Models.Inspector", b =>
                {
                    b.Navigation("Rental");

                    b.Navigation("ReturnCar");
                });

            modelBuilder.Entity("cldv6211TheRideYouRent.Models.Rental", b =>
                {
                    b.Navigation("ReturnCar");
                });
#pragma warning restore 612, 618
        }
    }
}
