using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineCourseReviews.Courses.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Courses");

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Courses",
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "Description", "Instructor", "IsVisible", "Price", "SchoolId", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000000c"), new DateTime(2024, 5, 7, 1, 48, 24, 770, DateTimeKind.Utc).AddTicks(6600), "Learn the basics of programming.", "Nick Chapsas", false, 69.99m, new Guid("00000000-0000-0000-0000-000000000010"), "Introduction to Programming", "https://example.com/courses/intro-to-programming" },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), new DateTime(2024, 5, 7, 1, 48, 24, 770, DateTimeKind.Utc).AddTicks(6610), "Take your programming skills to the next level.", "Nick Chapsas", false, 99.99m, new Guid("00000000-0000-0000-0000-000000000010"), "Advanced Programming", "https://example.com/courses/advanced-programming" },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new DateTime(2024, 5, 7, 1, 48, 24, 770, DateTimeKind.Utc).AddTicks(6610), "Learn how to build websites.", "Nick Chapsas", false, 49.99m, new Guid("00000000-0000-0000-0000-000000000010"), "Introduction to Web Development", "https://example.com/courses/intro-to-web-dev" },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), new DateTime(2024, 5, 7, 1, 48, 24, 770, DateTimeKind.Utc).AddTicks(6610), "Learn how to build advanced websites.", "Nick Chapsas", false, 79.99m, new Guid("00000000-0000-0000-0000-000000000010"), "Advanced Web Development", "https://example.com/courses/advanced-web-dev" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses",
                schema: "Courses");
        }
    }
}
