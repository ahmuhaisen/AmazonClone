using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsTblWithARelationshipWithCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountPercentage", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Samsung Galaxy S23 5G Smartphone, 128GB, Phantom Black", 10.0, "https://image.samsung.com/au/smartphones/galaxy-s23/buy/s23_pc.png", "Samsung Galaxy S23", 799.99000000000001 },
                    { 2, 2, "Men's Levi's 501 Original Fit Jeans, Medium Stonewash", 20.0, "https://cdn.levis.com.au/media/catalog/product/cache/bf9c1236dce8d5003d3a5e90e1989ff1/0/0/005010114-standard-f.jpg", "Levi's 501 Original Jeans", 59.990000000000002 },
                    { 3, 3, "Atomic Habits: An Easy & Proven Way to Build Good Habits & Break Bad Ones by James Clear", 15.0, "https://images-na.ssl-images-amazon.com/images/I/91bYsX41DVL.jpg", "Atomic Habits", 11.99 },
                    { 4, 4, "Instant Pot Duo 7-in-1 Electric Pressure Cooker, 6 Quart, Stainless Steel", 5.0, "https://m.media-amazon.com/images/I/61aTYtlfuyL._AC_SL1500_.jpg", "Instant Pot Duo 7-in-1", 89.989999999999995 },
                    { 5, 5, "Nike Men's Air Zoom Pegasus 39 Running Shoes, White/Black", 12.0, "https://images.nike.com/is/image/DotCom/CW7358_100?$SNKRS_COVER_WD$&align=0,1", "Nike Air Zoom Pegasus 39", 119.98999999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
