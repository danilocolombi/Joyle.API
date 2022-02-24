using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Joyle.Accounts.Infra.Migrations
{
    public partial class User_Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRegistration_Email",
                table: "UserRegistration");

            migrationBuilder.DropIndex(
                name: "IX_UserRegistration_Username",
                table: "UserRegistration");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserRegistration",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30)");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    FullName = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserRegistration",
                type: "VARCHAR(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegistration_Email",
                table: "UserRegistration",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegistration_Username",
                table: "UserRegistration",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }
    }
}
