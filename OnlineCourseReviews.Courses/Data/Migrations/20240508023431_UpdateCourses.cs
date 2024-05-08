using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCourseReviews.Courses.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                schema: "Courses",
                table: "Courses",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Review",
                schema: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Courses",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "Courses",
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000c"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 2, 34, 31, 627, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                schema: "Courses",
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000d"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 2, 34, 31, 627, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                schema: "Courses",
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 2, 34, 31, 627, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                schema: "Courses",
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000f"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 2, 34, 31, 627, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.CreateIndex(
                name: "IX_Review_CourseId",
                schema: "Courses",
                table: "Review",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review",
                schema: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                schema: "Courses",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

            migrationBuilder.UpdateData(
                schema: "Courses",
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000c"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 7, 1, 48, 24, 770, DateTimeKind.Utc).AddTicks(6600));

            migrationBuilder.UpdateData(
                schema: "Courses",
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000d"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 7, 1, 48, 24, 770, DateTimeKind.Utc).AddTicks(6610));

            migrationBuilder.UpdateData(
                schema: "Courses",
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 7, 1, 48, 24, 770, DateTimeKind.Utc).AddTicks(6610));

            migrationBuilder.UpdateData(
                schema: "Courses",
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000f"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 7, 1, 48, 24, 770, DateTimeKind.Utc).AddTicks(6610));
        }
    }
}
