using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeManager.DATA.Migrations
{
    public partial class addTaskSetKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActTaskSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActTaskSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActTaskSets_ActTasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "ActTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskSetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskDate_ActTaskSets_TaskSetId",
                        column: x => x.TaskSetId,
                        principalTable: "ActTaskSets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActTaskSets_TaskId",
                table: "ActTaskSets",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDate_TaskSetId",
                table: "TaskDate",
                column: "TaskSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDate");

            migrationBuilder.DropTable(
                name: "ActTaskSets");
        }
    }
}
