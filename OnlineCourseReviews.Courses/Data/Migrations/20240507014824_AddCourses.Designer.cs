﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineCourseReviews.Courses.Data;

#nullable disable

namespace OnlineCourseReviews.Courses.Data.Migrations
{
    [DbContext(typeof(CoursesDbContext))]
    [Migration("20240507014824_AddCourses")]
    partial class AddCourses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Courses")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineCourseReviews.Courses.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses", "Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-00000000000c"),
                            CreatedAt = new DateTime(2024, 5, 7, 1, 48, 24, 770, DateTimeKind.Utc).AddTicks(6600),
                            Description = "Learn the basics of programming.",
                            Instructor = "Nick Chapsas",
                            IsVisible = false,
                            Price = 69.99m,
                            SchoolId = new Guid("00000000-0000-0000-0000-000000000010"),
                            Title = "Introduction to Programming",
                            Url = "https://example.com/courses/intro-to-programming"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-00000000000d"),
                            CreatedAt = new DateTime(2024, 5, 7, 1, 48, 24, 770, DateTimeKind.Utc).AddTicks(6610),
                            Description = "Take your programming skills to the next level.",
                            Instructor = "Nick Chapsas",
                            IsVisible = false,
                            Price = 99.99m,
                            SchoolId = new Guid("00000000-0000-0000-0000-000000000010"),
                            Title = "Advanced Programming",
                            Url = "https://example.com/courses/advanced-programming"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-00000000000e"),
                            CreatedAt = new DateTime(2024, 5, 7, 1, 48, 24, 770, DateTimeKind.Utc).AddTicks(6610),
                            Description = "Learn how to build websites.",
                            Instructor = "Nick Chapsas",
                            IsVisible = false,
                            Price = 49.99m,
                            SchoolId = new Guid("00000000-0000-0000-0000-000000000010"),
                            Title = "Introduction to Web Development",
                            Url = "https://example.com/courses/intro-to-web-dev"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-00000000000f"),
                            CreatedAt = new DateTime(2024, 5, 7, 1, 48, 24, 770, DateTimeKind.Utc).AddTicks(6610),
                            Description = "Learn how to build advanced websites.",
                            Instructor = "Nick Chapsas",
                            IsVisible = false,
                            Price = 79.99m,
                            SchoolId = new Guid("00000000-0000-0000-0000-000000000010"),
                            Title = "Advanced Web Development",
                            Url = "https://example.com/courses/advanced-web-dev"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
