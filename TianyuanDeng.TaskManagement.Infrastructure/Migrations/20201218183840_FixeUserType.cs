using Microsoft.EntityFrameworkCore.Migrations;

namespace TianyuanDeng.TaskManagement.Infrastructure.Migrations
{
    public partial class FixeUserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_usersId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksHistory_Users_usersId",
                table: "TasksHistory");

            migrationBuilder.RenameColumn(
                name: "usersId",
                table: "TasksHistory",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_TasksHistory_usersId",
                table: "TasksHistory",
                newName: "IX_TasksHistory_UsersId");

            migrationBuilder.RenameColumn(
                name: "usersId",
                table: "Tasks",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_usersId",
                table: "Tasks",
                newName: "IX_Tasks_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UsersId",
                table: "Tasks",
                column: "UsersId",
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
                name: "FK_Tasks_Users_UsersId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksHistory_Users_UsersId",
                table: "TasksHistory");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "TasksHistory",
                newName: "usersId");

            migrationBuilder.RenameIndex(
                name: "IX_TasksHistory_UsersId",
                table: "TasksHistory",
                newName: "IX_TasksHistory_usersId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Tasks",
                newName: "usersId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_UsersId",
                table: "Tasks",
                newName: "IX_Tasks_usersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_usersId",
                table: "Tasks",
                column: "usersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TasksHistory_Users_usersId",
                table: "TasksHistory",
                column: "usersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
