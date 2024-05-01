using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineCourseReviews.Reviews.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Reviews");

            migrationBuilder.CreateTable(
                name: "Reviews",
                schema: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    IsRecommended = table.Column<bool>(type: "bit", nullable: false),
                    IsCourseCompleted = table.Column<bool>(type: "bit", nullable: false),
                    PricePaid = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    DiscountCodeUsed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Reviews",
                table: "Reviews",
                columns: new[] { "Id", "CourseId", "CreatedAt", "DiscountCodeUsed", "IsCourseCompleted", "IsRecommended", "IsVisible", "PricePaid", "Rating", "ReviewText", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-00000000000c"), new DateTime(2024, 5, 1, 2, 21, 4, 686, DateTimeKind.Utc).AddTicks(720), null, true, true, false, 9.99m, 5, "Great course!", "sean@schwabenlander.com" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-00000000000c"), new DateTime(2024, 5, 1, 2, 21, 4, 686, DateTimeKind.Utc).AddTicks(730), "DISCOUNT1", false, false, false, 27.00m, 1, "Not worth the money.", "sean@schwabenlander.com" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-00000000000c"), new DateTime(2024, 5, 1, 2, 21, 4, 686, DateTimeKind.Utc).AddTicks(750), null, true, true, false, 44.00m, 4, "I learned a lot.", "sean@schwabenlander.com" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000000c"), new DateTime(2024, 5, 1, 2, 21, 4, 686, DateTimeKind.Utc).AddTicks(750), "DISCOUNT2", false, false, false, 14.75m, 2, "I didn't learn anything.", "sean@schwabenlander.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews",
                schema: "Reviews");
        }
    }
}
