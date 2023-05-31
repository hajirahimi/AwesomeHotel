using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AwesomeHotel_HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHotelTableAllRows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 31, 11, 21, 23, 814, DateTimeKind.Local).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 31, 11, 21, 23, 814, DateTimeKind.Local).AddTicks(106));

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "UpdatedDate" },
                values: new object[,]
                {
                    { 3, "Air condition, free coffee", 50, new DateTime(2023, 5, 31, 11, 21, 23, 814, DateTimeKind.Local).AddTicks(111), "Best room for large familes", "www.awesomehotels.com/Penthouse.jpg", "Penthouse", 5, 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Air condition, free drink, extra security", 50, new DateTime(2023, 5, 31, 11, 21, 23, 814, DateTimeKind.Local).AddTicks(115), "Most exclusive room", "www.awesomehotels.com/Presidential.jpg", "Presidential", 3, 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 31, 11, 20, 7, 436, DateTimeKind.Local).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 31, 11, 20, 7, 436, DateTimeKind.Local).AddTicks(7502));
        }
    }
}
