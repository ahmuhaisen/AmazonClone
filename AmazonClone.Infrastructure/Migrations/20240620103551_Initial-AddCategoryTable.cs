using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialAddCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IconString = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HasSize = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "HasSize", "IconString", "Name" },
                values: new object[,]
                {
                    { 1, false, "bi bi-tv", "Electronics" },
                    { 2, true, "bi bi-shirt", "Clothing" },
                    { 3, false, "bi bi-book", "Books" },
                    { 4, false, "bi bi-house", "Home & Kitchen" },
                    { 5, false, "bi bi-basketball", "Sports & Outdoors" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
