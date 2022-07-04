using Microsoft.EntityFrameworkCore.Migrations;

namespace Joyle.Accounts.Infra.Migrations
{
    public partial class ALTER_USER_TABLE_NAME : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "JoyleUser");

            migrationBuilder.RenameIndex(
                name: "IX_User_Username",
                table: "JoyleUser",
                newName: "IX_JoyleUser_Username");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JoyleUser",
                table: "JoyleUser",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JoyleUser",
                table: "JoyleUser");

            migrationBuilder.RenameTable(
                name: "JoyleUser",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_JoyleUser_Username",
                table: "User",
                newName: "IX_User_Username");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");
        }
    }
}
