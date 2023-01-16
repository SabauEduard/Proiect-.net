using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.net.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PenaltyTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenaltyTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PenaltyTable_UsersTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PenaltyReceiptTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaidAmount = table.Column<int>(type: "int", nullable: false),
                    PenaltyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenaltyReceiptTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PenaltyReceiptTable_PenaltyTable_PenaltyId",
                        column: x => x.PenaltyId,
                        principalTable: "PenaltyTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PenaltyReceiptTable_PenaltyId",
                table: "PenaltyReceiptTable",
                column: "PenaltyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PenaltyTable_UserId",
                table: "PenaltyTable",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PenaltyReceiptTable");

            migrationBuilder.DropTable(
                name: "PenaltyTable");
        }
    }
}
