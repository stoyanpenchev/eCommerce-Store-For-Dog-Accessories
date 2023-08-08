using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class SeedCartsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "083e419b-56c8-4fcb-87fa-c46d574af33a", "AQAAAAEAACcQAAAAENPZwJvYjNhrQm6Ew9EJY/0EwlsTByqBw++ONYcjj5diSOur5sIUpjRGszrVcPEQvQ==", "3941896c-8893-42f9-beaa-a64c5a14b832" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6dc301e5-4cfc-4901-957c-1af8031c7c31", "AQAAAAEAACcQAAAAEDx4dY+COQWvrkKCUooBAulqZ/lpGB9zkLUYnN2CQO9MgJsxlua2fKPpu+ZnwMw4uQ==", "e972d234-7ccb-4315-9430-e7ddda0dc29f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5291836a-942e-4a1a-80b0-72c3215f9c03", "AQAAAAEAACcQAAAAEJ9I8crSOUfMn+YSofqRSDoMKdDYBL3tx69Z4M8tx1knz2lcRu+WZFrah78ZIhpWIw==", "132e7004-c340-4c94-9d8b-518703089522" });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { new Guid("36f85cb2-39e3-4d82-bc1d-bfddb6b3f13f"), 0m, new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e") },
                    { new Guid("f91f214b-123d-47f1-9bdc-e97dfadc431b"), 0m, new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27") }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 50, 35, 996, DateTimeKind.Utc).AddTicks(690));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 50, 35, 996, DateTimeKind.Utc).AddTicks(709));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 50, 35, 996, DateTimeKind.Utc).AddTicks(714));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 50, 35, 996, DateTimeKind.Utc).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 50, 35, 996, DateTimeKind.Utc).AddTicks(722));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 50, 35, 996, DateTimeKind.Utc).AddTicks(738));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 50, 35, 996, DateTimeKind.Utc).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 50, 35, 996, DateTimeKind.Utc).AddTicks(751));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 50, 35, 996, DateTimeKind.Utc).AddTicks(754));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 50, 35, 996, DateTimeKind.Utc).AddTicks(761));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 50, 35, 996, DateTimeKind.Utc).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 50, 35, 996, DateTimeKind.Utc).AddTicks(770));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("36f85cb2-39e3-4d82-bc1d-bfddb6b3f13f"));

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("f91f214b-123d-47f1-9bdc-e97dfadc431b"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebfb8fe3-87ba-4374-a837-a66cef27bd04", "AQAAAAEAACcQAAAAEOSsfiepc4cDQnCEqCwkUmQSIYD7dRsrDy1cXZxDtaST5eZB2xfnDgVMK3eEwl+4gQ==", "01bb1413-9ff1-4911-912e-569cfd9bf989" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93826849-450d-4e53-9f73-47b2b08395b6", "AQAAAAEAACcQAAAAEJX6LNVLwzr7XUmDGhk0dmFqdmAZw4PHgtlR3TWLdzRv12eNjYjuD/FiX13INHsHgw==", "905721e0-bfd4-4bd7-bda7-7b426be7aac2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37fc37b9-3fce-499a-91f9-b5c88545c245", "AQAAAAEAACcQAAAAEChNYKr0y3mFMcohmw7kjondYY9AZZSeowBfqJ21wy3S2rl1GJoOrpmIS6skskY0Dw==", "0756dd47-08b0-4a96-8659-6bcd994fada1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7116));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7131));
        }
    }
}
