using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeManager.DATA.Migrations
{
    public partial class deleteViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActTasksNum",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvgProductivity",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "ActTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActTasksNum",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AvgProductivity",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "ActTasks");
        }
    }
}
