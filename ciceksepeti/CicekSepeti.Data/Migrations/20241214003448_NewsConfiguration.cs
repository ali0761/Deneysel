using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CicekSepeti.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewsConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(750)",
                oldMaxLength: 750,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2024, 12, 14, 3, 34, 47, 801, DateTimeKind.Local).AddTicks(4340), new Guid("c50983d8-465e-4cc5-a517-4a2581bef4e5") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 12, 14, 3, 34, 47, 804, DateTimeKind.Local).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 12, 14, 3, 34, 47, 804, DateTimeKind.Local).AddTicks(2725));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "News",
                type: "nvarchar(750)",
                maxLength: 750,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2024, 12, 10, 22, 42, 49, 450, DateTimeKind.Local).AddTicks(4917), new Guid("d483ce60-ab72-497a-8819-02bc5e527156") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 12, 10, 22, 42, 49, 453, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 12, 10, 22, 42, 49, 453, DateTimeKind.Local).AddTicks(8804));
        }
    }
}
