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
                    { new Guid("181cf613-44f4-48c5-baac-5c97fbb74a15"), new Guid("00000000-0000-0000-0000-00000000000c"), new DateTime(2024, 4, 26, 2, 51, 0, 385, DateTimeKind.Utc).AddTicks(3000), null, true, true, false, 9.99m, 5, "Great course!", "sean@schwabenlander.com" },
                    { new Guid("24fe50eb-871f-45af-bed9-8e2b39a6299c"), new Guid("00000000-0000-0000-0000-00000000000c"), new DateTime(2024, 4, 26, 2, 51, 0, 385, DateTimeKind.Utc).AddTicks(3020), null, true, true, false, 44.00m, 4, "I learned a lot.", "sean@schwabenlander.com" },
                    { new Guid("438e15fd-5920-4d66-9ff6-5f61bcd2598d"), new Guid("00000000-0000-0000-0000-00000000000c"), new DateTime(2024, 4, 26, 2, 51, 0, 385, DateTimeKind.Utc).AddTicks(3010), "DISCOUNT1", false, false, false, 27.00m, 1, "Not worth the money.", "sean@schwabenlander.com" },
                    { new Guid("ad5a14c5-36f1-4c0f-b33b-1e5f32d9ca41"), new Guid("00000000-0000-0000-0000-00000000000c"), new DateTime(2024, 4, 26, 2, 51, 0, 385, DateTimeKind.Utc).AddTicks(3020), "DISCOUNT2", false, false, false, 14.75m, 2, "I didn't learn anything.", "sean@schwabenlander.com" }
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
