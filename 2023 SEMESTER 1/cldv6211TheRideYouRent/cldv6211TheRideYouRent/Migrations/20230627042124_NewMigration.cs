using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cldv6211TheRideYouRent.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarNo = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    Car_Make = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Model = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    BodyType = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Kilometres_Travelled = table.Column<int>(type: "int", nullable: true),
                    Service_kilometres = table.Column<int>(type: "int", nullable: true),
                    Avaliable = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Car__68A00DDDD9F8C0AF", x => x.CarNo);
                });

            migrationBuilder.CreateTable(
                name: "Car_BodyType",
                columns: table => new
                {
                    Car_BodyTypeID = table.Column<int>(type: "int", nullable: false),
                    BodyType_Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_BodyType", x => x.Car_BodyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Car_Make",
                columns: table => new
                {
                    Car_MakeID = table.Column<int>(type: "int", nullable: false),
                    Make_Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_Make", x => x.Car_MakeID);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Driver_ID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    DriverName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DriverAddress = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DriverEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DriverContactNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Driver_ID);
                });

            migrationBuilder.CreateTable(
                name: "Inspector",
                columns: table => new
                {
                    Inspector_no = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    InspectorName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    InspectorEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    InspectorMobile = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inspecto__F49FBEAF2C10A3C3", x => x.Inspector_no);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    Rental_no = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    RentalFee = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    CarNo = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    Inspector_no = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Driver_ID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rental__9D208995B2480FB1", x => x.Rental_no);
                    table.ForeignKey(
                        name: "FK__Rental__CarNo__6D0D32F4",
                        column: x => x.CarNo,
                        principalTable: "Car",
                        principalColumn: "CarNo");
                    table.ForeignKey(
                        name: "FK__Rental__Driver_I__6EF57B66",
                        column: x => x.Driver_ID,
                        principalTable: "Driver",
                        principalColumn: "Driver_ID");
                    table.ForeignKey(
                        name: "FK__Rental__Inspecto__6E01572D",
                        column: x => x.Inspector_no,
                        principalTable: "Inspector",
                        principalColumn: "Inspector_no");
                });

            migrationBuilder.CreateTable(
                name: "ReturnCar",
                columns: table => new
                {
                    Return_id = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Rental_no = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Inspector_no = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "date", nullable: false),
                    ElapsedDate = table.Column<int>(type: "int", nullable: false),
                    Fine = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ReturnCa__0F4E406EA5064E40", x => x.Return_id);
                    table.ForeignKey(
                        name: "FK__ReturnCar__Inspe__70DDC3D8",
                        column: x => x.Inspector_no,
                        principalTable: "Inspector",
                        principalColumn: "Inspector_no");
                    table.ForeignKey(
                        name: "FK__ReturnCar__Renta__6FE99F9F",
                        column: x => x.Rental_no,
                        principalTable: "Rental",
                        principalColumn: "Rental_no");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CarNo",
                table: "Rental",
                column: "CarNo");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_Driver_ID",
                table: "Rental",
                column: "Driver_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_Inspector_no",
                table: "Rental",
                column: "Inspector_no");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnCar_Inspector_no",
                table: "ReturnCar",
                column: "Inspector_no");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnCar_Rental_no",
                table: "ReturnCar",
                column: "Rental_no");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car_BodyType");

            migrationBuilder.DropTable(
                name: "Car_Make");

            migrationBuilder.DropTable(
                name: "ReturnCar");

            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Inspector");
        }
    }
}
