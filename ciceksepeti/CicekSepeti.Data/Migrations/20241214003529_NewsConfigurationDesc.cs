using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CicekSepeti.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewsConfigurationDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2024, 12, 14, 3, 35, 29, 340, DateTimeKind.Local).AddTicks(9461), new Guid("ad4cb604-ce60-4151-b127-89e63e7d6049") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 12, 14, 3, 35, 29, 343, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 12, 14, 3, 35, 29, 343, DateTimeKind.Local).AddTicks(3952));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
