using Microsoft.EntityFrameworkCore.Migrations;

namespace TianyuanDeng.TaskManagement.Infrastructure.Migrations
{
    public partial class FixeUserType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TasksHistory_UserId",
                table: "TasksHistory");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_userid",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_TasksHistory_UserId",
                table: "TasksHistory",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_userid",
                table: "Tasks",
                column: "userid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TasksHistory_UserId",
                table: "TasksHistory");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_userid",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_TasksHistory_UserId",
                table: "TasksHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_userid",
                table: "Tasks",
                column: "userid");
        }
    }
}
