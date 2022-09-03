using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeManager.API.Migrations
{
    public partial class addPriorityProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Activities");
        }
    }
}
