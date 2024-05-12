using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vaka.Migrations
{
    /// <inheritdoc />
    public partial class WhereIsProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14b60be2-31f8-4534-b967-23449c00491b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d91f184e-77fc-4223-9928-cac4cfbd685b");

            migrationBuilder.CreateTable(
                name: "ProductRoom",
                columns: table => new
                {
                    ProductRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRoom", x => x.ProductRoomId);
                    table.ForeignKey(
                        name: "FK_ProductRoom_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ProductStore",
                columns: table => new
                {
                    ProductStoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStore", x => x.ProductStoreId);
                    table.ForeignKey(
                        name: "FK_ProductStore_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserId" },
                values: new object[,]
                {
                    { "af7e4799-34ff-4fa2-8e90-f2ba2d7dbcbf", null, "Admin", "ADMIN", null },
                    { "e061c079-3b6d-437e-9856-1f85bde8465d", null, "User", "USER", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRoom_ProductId",
                table: "ProductRoom",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStore_ProductId",
                table: "ProductStore",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRoom");

            migrationBuilder.DropTable(
                name: "ProductStore");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af7e4799-34ff-4fa2-8e90-f2ba2d7dbcbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e061c079-3b6d-437e-9856-1f85bde8465d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserId" },
                values: new object[,]
                {
                    { "14b60be2-31f8-4534-b967-23449c00491b", null, "Admin", "ADMIN", null },
                    { "d91f184e-77fc-4223-9928-cac4cfbd685b", null, "User", "USER", null }
                });
        }
    }
}
