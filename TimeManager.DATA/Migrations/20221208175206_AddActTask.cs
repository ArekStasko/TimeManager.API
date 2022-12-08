using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeManager.DATA.Migrations
{
    public partial class AddActTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ActTasks");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "ActTasks",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ActTasks",
                newName: "CategoryName");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ActTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActTasksNum = table.Column<int>(type: "int", nullable: false),
                    AvgProductivity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
        }
    }
}
