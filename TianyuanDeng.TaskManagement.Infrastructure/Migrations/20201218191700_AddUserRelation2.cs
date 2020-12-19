using Microsoft.EntityFrameworkCore.Migrations;

namespace TianyuanDeng.TaskManagement.Infrastructure.Migrations
{
    public partial class AddUserRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "TasksHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "usersId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TasksHistory_UsersId",
                table: "TasksHistory",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_usersId",
                table: "Tasks",
                column: "usersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_usersId",
                table: "Tasks",
                column: "usersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TasksHistory_Users_UsersId",
                table: "TasksHistory",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_usersId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksHistory_Users_UsersId",
                table: "TasksHistory");

            migrationBuilder.DropIndex(
                name: "IX_TasksHistory_UsersId",
                table: "TasksHistory");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_usersId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "TasksHistory");

            migrationBuilder.DropColumn(
                name: "usersId",
                table: "Tasks");
        }
    }
}
