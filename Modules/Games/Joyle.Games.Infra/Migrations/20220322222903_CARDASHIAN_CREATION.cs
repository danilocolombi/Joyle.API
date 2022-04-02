using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Joyle.Games.Infra.Migrations
{
    public partial class CARDASHIAN_CREATION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cardashian",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardashian", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardashianCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Position = table.Column<byte>(type: "TINYINT", nullable: false),
                    CardashianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardashianCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardashianCard_Cardashian_CardashianId",
                        column: x => x.CardashianId,
                        principalTable: "Cardashian",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardashianCard_CardashianId",
                table: "CardashianCard",
                column: "CardashianId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardashianCard");

            migrationBuilder.DropTable(
                name: "Cardashian");
        }
    }
}
