using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RK_A11.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ProductSchema");

            migrationBuilder.CreateTable(
                name: "CategoryInfo",
                schema: "ProductSchema",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryInfo", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductInfo",
                schema: "ProductSchema",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInfo", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductInfo_CategoryInfo_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "ProductSchema",
                        principalTable: "CategoryInfo",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "ProductSchema",
                table: "CategoryInfo",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Consumables" });

            migrationBuilder.InsertData(
                schema: "ProductSchema",
                table: "CategoryInfo",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Electronics" });

            migrationBuilder.InsertData(
                schema: "ProductSchema",
                table: "CategoryInfo",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Decorations" });

            migrationBuilder.InsertData(
                schema: "ProductSchema",
                table: "ProductInfo",
                columns: new[] { "ProductId", "CategoryId", "Manufacture", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, "Pizza Hut", "Pizza" },
                    { 2, 2, "Apple", "Airpods" },
                    { 3, 1, "Red Bull", "Red bull Energy Drink" },
                    { 4, 3, "IKEA", "Curtain" },
                    { 5, 2, "Bose", "Bose QC 35 II" },
                    { 6, 3, "Seiko", "Wall Clock" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfo_CategoryId",
                schema: "ProductSchema",
                table: "ProductInfo",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInfo",
                schema: "ProductSchema");

            migrationBuilder.DropTable(
                name: "CategoryInfo",
                schema: "ProductSchema");
        }
    }
}
