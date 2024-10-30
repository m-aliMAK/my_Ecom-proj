using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class editingProductsColoumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_StoreSnaps_StoreSnapId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StoreSnaps",
                keyColumn: "StoreSnapId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StoreSnaps",
                keyColumn: "StoreSnapId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StoreSnaps",
                keyColumn: "StoreSnapId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StoreSnaps",
                keyColumn: "StoreSnapId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StoreSnaps",
                keyColumn: "StoreSnapId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "StoreSnapId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StoreSnaps_StoreSnapId",
                table: "Products",
                column: "StoreSnapId",
                principalTable: "StoreSnaps",
                principalColumn: "StoreSnapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_StoreSnaps_StoreSnapId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "StoreSnapId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "292e0ac8-39cb-418c-b57f-f69334d49297", "customer1@example.com", false, "Alice", "Wonder", false, null, null, null, null, null, false, "56a1dc76-ab8d-4feb-83ff-dde8975ebada", false, "customer1" },
                    { "2", 0, "79660192-3e22-4656-859c-d56f88462fee", "customer2@example.com", false, "Bob", "Builder", false, null, null, null, null, null, false, "a00ce256-20fd-40d5-bc2c-e538225d00fe", false, "customer2" },
                    { "3", 0, "a7a95433-e16a-4ddb-8433-132b7741d6c4", "customer3@example.com", false, "Charlie", "Chaplin", false, null, null, null, null, null, false, "d729e52e-234f-4212-9654-3d8e976ca108", false, "customer3" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "CustomerId" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" },
                    { 3, "3" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Description", "OwnerId", "StoreName" },
                values: new object[,]
                {
                    { 1, "First Store", "1", "Store One" },
                    { 2, "Second Store", "2", "Store Two" },
                    { 3, "Third Store", "3", "Store Three" },
                    { 4, "Fourth Store", "1", "Store Four" },
                    { 5, "Fifth Store", "2", "Store Five" }
                });

            migrationBuilder.InsertData(
                table: "StoreSnaps",
                columns: new[] { "StoreSnapId", "ImageUrl", "StoreId" },
                values: new object[,]
                {
                    { 1, "https://example.com/store1snap1.jpg", 1 },
                    { 2, "https://example.com/store1snap2.jpg", 1 },
                    { 3, "https://example.com/store2snap1.jpg", 2 },
                    { 4, "https://example.com/store3snap1.jpg", 3 },
                    { 5, "https://example.com/store4snap1.jpg", 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Price", "ProductName", "Quantity", "StoreSnapId" },
                values: new object[,]
                {
                    { 1, "First Product", 10.99m, "Product A", 100, 1 },
                    { 2, "Second Product", 15.50m, "Product B", 50, 1 },
                    { 3, "Third Product", 20.00m, "Product C", 150, 2 },
                    { 4, "Fourth Product", 30.99m, "Product D", 200, 3 },
                    { 5, "Fifth Product", 40.99m, "Product E", 75, 4 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "CartItemId", "CartId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 1, 3, 1 },
                    { 3, 2, 2, 3 },
                    { 4, 2, 5, 2 },
                    { 5, 3, 4, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StoreSnaps_StoreSnapId",
                table: "Products",
                column: "StoreSnapId",
                principalTable: "StoreSnaps",
                principalColumn: "StoreSnapId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
