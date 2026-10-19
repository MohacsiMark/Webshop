using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerShop.Migrations
{
    /// <inheritdoc />
    public partial class asd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "Osystems",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OsId",
                table: "Computers",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_OsId",
                table: "Computers",
                column: "OsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Osystems_OsId",
                table: "Computers",
                column: "OsId",
                principalTable: "Osystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Osystems_OsId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_OsId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "OsId",
                table: "Computers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "Osystems",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
