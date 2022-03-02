using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Joyle.Accounts.Infra.Migrations
{
    public partial class ALTER_USER_TABLE_INACTIVATION_DATE_CREATION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InactivationDate",
                table: "User",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InactivationDate",
                table: "User");
        }
    }
}
