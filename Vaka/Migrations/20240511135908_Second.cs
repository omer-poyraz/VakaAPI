using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vaka.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36e4ac79-7a6d-445b-a73c-a0d32f5b08f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90865320-a395-42b9-9a88-21a2fc82486a");

            migrationBuilder.DropColumn(
                name: "IsExit",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserId" },
                values: new object[,]
                {
                    { "14b60be2-31f8-4534-b967-23449c00491b", null, "Admin", "ADMIN", null },
                    { "d91f184e-77fc-4223-9928-cac4cfbd685b", null, "User", "USER", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14b60be2-31f8-4534-b967-23449c00491b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d91f184e-77fc-4223-9928-cac4cfbd685b");

            migrationBuilder.AddColumn<bool>(
                name: "IsExit",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserId" },
                values: new object[,]
                {
                    { "36e4ac79-7a6d-445b-a73c-a0d32f5b08f7", null, "User", "USER", null },
                    { "90865320-a395-42b9-9a88-21a2fc82486a", null, "Admin", "ADMIN", null }
                });
        }
    }
}
