using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLDVTwo.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarServiceDate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeRegion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeePostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeAge = table.Column<int>(type: "int", nullable: false),
                    EmployeeCount = table.Column<int>(type: "int", nullable: false),
                    EmployeeJobDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
