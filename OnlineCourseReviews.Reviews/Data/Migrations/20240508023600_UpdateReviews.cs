using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCourseReviews.Reviews.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DiscountCodeUsed",
                schema: "Reviews",
                table: "Reviews",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Reviews",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 2, 36, 0, 194, DateTimeKind.Utc).AddTicks(1950));

            migrationBuilder.UpdateData(
                schema: "Reviews",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 2, 36, 0, 194, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                schema: "Reviews",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 2, 36, 0, 194, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                schema: "Reviews",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 2, 36, 0, 194, DateTimeKind.Utc).AddTicks(1960));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DiscountCodeUsed",
                schema: "Reviews",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Reviews",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 1, 2, 21, 4, 686, DateTimeKind.Utc).AddTicks(720));

            migrationBuilder.UpdateData(
                schema: "Reviews",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 1, 2, 21, 4, 686, DateTimeKind.Utc).AddTicks(730));

            migrationBuilder.UpdateData(
                schema: "Reviews",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 1, 2, 21, 4, 686, DateTimeKind.Utc).AddTicks(750));

            migrationBuilder.UpdateData(
                schema: "Reviews",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 1, 2, 21, 4, 686, DateTimeKind.Utc).AddTicks(750));
        }
    }
}
