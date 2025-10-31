using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ListElementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListAccesses",
                columns: table => new
                {
                    ShoppingListId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListAccesses", x => new { x.ShoppingListId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ListAccesses_ShoppingList_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsPurchased = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ShoppingListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListElements_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListElements_ShoppingList_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListElements_ProductId",
                table: "ListElements",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ListElements_ShoppingListId",
                table: "ListElements",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListAccesses");

            migrationBuilder.DropTable(
                name: "ListElements");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingList");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
