using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSCommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "order_item",
                newName: "price");

            migrationBuilder.CreateTable(
                name: "tb_category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    productsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.productsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_tb_category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "tb_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_tb_product_productsId",
                        column: x => x.productsId,
                        principalTable: "tb_product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_productsId",
                table: "CategoryProduct",
                column: "productsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "tb_category");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "order_item",
                newName: "Price");
        }
    }
}
