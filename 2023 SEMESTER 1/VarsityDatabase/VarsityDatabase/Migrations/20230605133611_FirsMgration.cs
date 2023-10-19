using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VarsityDatabase.Migrations
{
    /// <inheritdoc />
    public partial class FirsMgration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    Campus_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campus_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Campus_Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.Campus_ID);
                });

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    Lecturer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lecturer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lecturer_Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lecturer_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lecturer_Module = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.Lecturer_ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Year = table.Column<int>(type: "int", nullable: false),
                    Student_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Student_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "Lecturer");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
