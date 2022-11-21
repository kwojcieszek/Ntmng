using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ntmng.DataService.Migrations.SqlServer
{
    /// <inheritdoc />
    public partial class _20221121 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    TokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecretKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.TokenId);
                });

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 11, 21, 8, 17, 48, 728, DateTimeKind.Local).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 11, 21, 8, 17, 48, 728, DateTimeKind.Local).AddTicks(4226));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 11, 21, 8, 3, 23, 310, DateTimeKind.Local).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 11, 21, 8, 3, 23, 310, DateTimeKind.Local).AddTicks(3613));
        }
    }
}
