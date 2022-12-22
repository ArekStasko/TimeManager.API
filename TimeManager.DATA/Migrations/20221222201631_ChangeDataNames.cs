using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeManager.DATA.Migrations
{
    public partial class ChangeDataNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActTaskSets_ActTasks_TaskId",
                table: "ActTaskSets");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskDate_ActTaskSets_TaskSetId",
                table: "TaskDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActTaskSets",
                table: "ActTaskSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActTasks",
                table: "ActTasks");

            migrationBuilder.RenameTable(
                name: "ActTaskSets",
                newName: "TaskSets");

            migrationBuilder.RenameTable(
                name: "ActTasks",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_ActTaskSets_TaskId",
                table: "TaskSets",
                newName: "IX_TaskSets_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskSets",
                table: "TaskSets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDate_TaskSets_TaskSetId",
                table: "TaskDate",
                column: "TaskSetId",
                principalTable: "TaskSets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSets_Tasks_TaskId",
                table: "TaskSets",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDate_TaskSets_TaskSetId",
                table: "TaskDate");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskSets_Tasks_TaskId",
                table: "TaskSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskSets",
                table: "TaskSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "TaskSets",
                newName: "ActTaskSets");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "ActTasks");

            migrationBuilder.RenameIndex(
                name: "IX_TaskSets_TaskId",
                table: "ActTaskSets",
                newName: "IX_ActTaskSets_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActTaskSets",
                table: "ActTaskSets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActTasks",
                table: "ActTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActTaskSets_ActTasks_TaskId",
                table: "ActTaskSets",
                column: "TaskId",
                principalTable: "ActTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDate_ActTaskSets_TaskSetId",
                table: "TaskDate",
                column: "TaskSetId",
                principalTable: "ActTaskSets",
                principalColumn: "Id");
        }
    }
}
