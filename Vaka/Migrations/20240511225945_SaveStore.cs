using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vaka.Migrations
{
    /// <inheritdoc />
    public partial class SaveStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af7e4799-34ff-4fa2-8e90-f2ba2d7dbcbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e061c079-3b6d-437e-9856-1f85bde8465d");

            migrationBuilder.CreateTable(
                name: "SaveStore",
                columns: table => new
                {
                    SaveStoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    IsEntrance = table.Column<bool>(type: "bit", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    StructureId = table.Column<int>(type: "int", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveStore", x => x.SaveStoreId);
                    table.ForeignKey(
                        name: "FK_SaveStore_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_SaveStore_Rooms_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId");
                    table.ForeignKey(
                        name: "FK_SaveStore_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId");
                    table.ForeignKey(
                        name: "FK_SaveStore_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "StructureId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserId" },
                values: new object[,]
                {
                    { "16635fef-7d6b-4cbe-ae82-8ee21ce0e002", null, "Admin", "ADMIN", null },
                    { "49e92955-b722-44d1-8231-7ec5fadd480e", null, "User", "USER", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaveStore_ProductId",
                table: "SaveStore",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaveStore_StoreId",
                table: "SaveStore",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SaveStore_StructureId",
                table: "SaveStore",
                column: "StructureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaveStore");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16635fef-7d6b-4cbe-ae82-8ee21ce0e002");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49e92955-b722-44d1-8231-7ec5fadd480e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserId" },
                values: new object[,]
                {
                    { "af7e4799-34ff-4fa2-8e90-f2ba2d7dbcbf", null, "Admin", "ADMIN", null },
                    { "e061c079-3b6d-437e-9856-1f85bde8465d", null, "User", "USER", null }
                });
        }
    }
}
