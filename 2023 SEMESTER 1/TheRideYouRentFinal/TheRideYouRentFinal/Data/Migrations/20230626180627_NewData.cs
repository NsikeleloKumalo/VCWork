using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRideYouRentFinal.Data.Migrations
{
    public partial class NewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
                    table.PrimaryKey("PK__Car__68A00DDD6D93A157", x => x.CarNo);
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
                    table.PrimaryKey("PK__Inspecto__F49FBEAF73587D72", x => x.Inspector_no);
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
                    table.PrimaryKey("PK__Rental__9D2089954DD7F904", x => x.Rental_no);
                    table.ForeignKey(
                        name: "FK__Rental__CarNo__4222D4EF",
                        column: x => x.CarNo,
                        principalTable: "Car",
                        principalColumn: "CarNo");
                    table.ForeignKey(
                        name: "FK__Rental__Driver_I__440B1D61",
                        column: x => x.Driver_ID,
                        principalTable: "Driver",
                        principalColumn: "Driver_ID");
                    table.ForeignKey(
                        name: "FK__Rental__Inspecto__4316F928",
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
                    table.PrimaryKey("PK__ReturnCa__0F4E406E5D54D785", x => x.Return_id);
                    table.ForeignKey(
                        name: "FK__ReturnCar__Inspe__47DBAE45",
                        column: x => x.Inspector_no,
                        principalTable: "Inspector",
                        principalColumn: "Inspector_no");
                    table.ForeignKey(
                        name: "FK__ReturnCar__Renta__46E78A0C",
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

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }
    }
}
