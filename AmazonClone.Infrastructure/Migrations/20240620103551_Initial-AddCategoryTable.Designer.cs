﻿// <auto-generated />
using AmazonClone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AmazonClone.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240620103551_Initial-AddCategoryTable")]
    partial class InitialAddCategoryTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AmazonClone.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("HasSize")
                        .HasColumnType("bit");

                    b.Property<string>("IconString")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HasSize = false,
                            IconString = "bi bi-tv",
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            HasSize = true,
                            IconString = "bi bi-shirt",
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 3,
                            HasSize = false,
                            IconString = "bi bi-book",
                            Name = "Books"
                        },
                        new
                        {
                            Id = 4,
                            HasSize = false,
                            IconString = "bi bi-house",
                            Name = "Home & Kitchen"
                        },
                        new
                        {
                            Id = 5,
                            HasSize = false,
                            IconString = "bi bi-basketball",
                            Name = "Sports & Outdoors"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
