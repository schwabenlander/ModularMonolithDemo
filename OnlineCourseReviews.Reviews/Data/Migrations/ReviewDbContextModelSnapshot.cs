﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineCourseReviews.Reviews.Data;

#nullable disable

namespace OnlineCourseReviews.Reviews.Data.Migrations
{
    [DbContext(typeof(ReviewsDbContext))]
    partial class ReviewDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Reviews")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineCourseReviews.Reviews.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiscountCodeUsed")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsCourseCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRecommended")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<decimal?>("PricePaid")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Reviews", "Reviews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            CourseId = new Guid("00000000-0000-0000-0000-00000000000c"),
                            CreatedAt = new DateTime(2024, 5, 8, 2, 36, 0, 194, DateTimeKind.Utc).AddTicks(1950),
                            IsCourseCompleted = true,
                            IsRecommended = true,
                            IsVisible = false,
                            PricePaid = 9.99m,
                            Rating = 5,
                            ReviewText = "Great course!",
                            UserId = "sean@schwabenlander.com"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            CourseId = new Guid("00000000-0000-0000-0000-00000000000c"),
                            CreatedAt = new DateTime(2024, 5, 8, 2, 36, 0, 194, DateTimeKind.Utc).AddTicks(1960),
                            DiscountCodeUsed = "DISCOUNT1",
                            IsCourseCompleted = false,
                            IsRecommended = false,
                            IsVisible = false,
                            PricePaid = 27.00m,
                            Rating = 1,
                            ReviewText = "Not worth the money.",
                            UserId = "sean@schwabenlander.com"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            CourseId = new Guid("00000000-0000-0000-0000-00000000000c"),
                            CreatedAt = new DateTime(2024, 5, 8, 2, 36, 0, 194, DateTimeKind.Utc).AddTicks(1960),
                            IsCourseCompleted = true,
                            IsRecommended = true,
                            IsVisible = false,
                            PricePaid = 44.00m,
                            Rating = 4,
                            ReviewText = "I learned a lot.",
                            UserId = "sean@schwabenlander.com"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000004"),
                            CourseId = new Guid("00000000-0000-0000-0000-00000000000c"),
                            CreatedAt = new DateTime(2024, 5, 8, 2, 36, 0, 194, DateTimeKind.Utc).AddTicks(1960),
                            DiscountCodeUsed = "DISCOUNT2",
                            IsCourseCompleted = false,
                            IsRecommended = false,
                            IsVisible = false,
                            PricePaid = 14.75m,
                            Rating = 2,
                            ReviewText = "I didn't learn anything.",
                            UserId = "sean@schwabenlander.com"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
