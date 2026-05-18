using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blazor26.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MonthName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Desktops" },
                    { 2, "Printers" },
                    { 3, "Display Tables" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Image", "Name", "Price", "description" },
                values: new object[,]
                {
                    { 1, 1, null, "HP PRo", 892.99f, "Big desktop PC" },
                    { 2, 1, null, "Dell X100", 140.99f, "Not a laptop" },
                    { 3, 2, null, "HP 450x", 1200.99f, "bad colour printer" },
                    { 4, 2, null, "HP Meezie", 12500.99f, "Good colour printer" },
                    { 5, 3, null, "Gala Table", 12123.99f, "Very Big Table" },
                    { 6, 3, null, "DreamTop", 900.99f, "Big Table" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "MonthName", "ProductID", "SalesAmount" },
                values: new object[,]
                {
                    { 1, "January", 1, 1200m },
                    { 2, "February", 1, 1300m },
                    { 3, "March", 1, 1400m },
                    { 4, "April", 1, 1500m },
                    { 5, "May", 1, 1600m },
                    { 6, "June", 1, 1700m },
                    { 7, "July", 1, 1800m },
                    { 8, "August", 1, 1900m },
                    { 9, "September", 1, 2000m },
                    { 10, "October", 1, 2100m },
                    { 11, "November", 1, 2200m },
                    { 12, "December", 1, 2300m },
                    { 13, "January", 2, 1400m },
                    { 14, "February", 2, 1500m },
                    { 15, "March", 2, 1600m },
                    { 16, "April", 2, 1700m },
                    { 17, "May", 2, 1800m },
                    { 18, "June", 2, 1900m },
                    { 19, "July", 2, 2000m },
                    { 20, "August", 2, 2100m },
                    { 21, "September", 2, 2200m },
                    { 22, "October", 2, 2300m },
                    { 23, "November", 2, 2400m },
                    { 24, "December", 2, 2500m },
                    { 25, "January", 3, 1600m },
                    { 26, "February", 3, 1700m },
                    { 27, "March", 3, 1800m },
                    { 28, "April", 3, 1900m },
                    { 29, "May", 3, 2000m },
                    { 30, "June", 3, 2100m },
                    { 31, "July", 3, 2200m },
                    { 32, "August", 3, 2300m },
                    { 33, "September", 3, 2400m },
                    { 34, "October", 3, 2500m },
                    { 35, "November", 3, 2600m },
                    { 36, "December", 3, 2700m },
                    { 37, "January", 4, 1800m },
                    { 38, "February", 4, 1900m },
                    { 39, "March", 4, 2000m },
                    { 40, "April", 4, 2100m },
                    { 41, "May", 4, 2200m },
                    { 42, "June", 4, 2300m },
                    { 43, "July", 4, 2400m },
                    { 44, "August", 4, 2500m },
                    { 45, "September", 4, 2600m },
                    { 46, "October", 4, 2700m },
                    { 47, "November", 4, 2800m },
                    { 48, "December", 4, 2900m },
                    { 49, "January", 5, 2000m },
                    { 50, "February", 5, 2100m },
                    { 51, "March", 5, 2200m },
                    { 52, "April", 5, 2300m },
                    { 53, "May", 5, 2400m },
                    { 54, "June", 5, 2500m },
                    { 55, "July", 5, 2600m },
                    { 56, "August", 5, 2700m },
                    { 57, "September", 5, 2800m },
                    { 58, "October", 5, 2900m },
                    { 59, "November", 5, 3000m },
                    { 60, "December", 5, 3100m },
                    { 61, "January", 6, 2200m },
                    { 62, "February", 6, 2300m },
                    { 63, "March", 6, 2400m },
                    { 64, "April", 6, 2500m },
                    { 65, "May", 6, 2600m },
                    { 66, "June", 6, 2700m },
                    { 67, "July", 6, 2800m },
                    { 68, "August", 6, 2900m },
                    { 69, "September", 6, 3000m },
                    { 70, "October", 6, 3100m },
                    { 71, "November", 6, 3200m },
                    { 72, "December", 6, 3300m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductID",
                table: "Sales",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
