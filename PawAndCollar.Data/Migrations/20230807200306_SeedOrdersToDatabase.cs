using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class SeedOrdersToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3befa185-afa5-4443-835a-0db6c255f522", "AQAAAAEAACcQAAAAENWJBBVjVLt1jAYR2qw9AE+NGntkCHvKpvzphDsl57wt7FftGOV6SjhxxK7ggA8b9g==", "fd944bba-d216-4370-821c-0efef6e2665e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87c74660-3d41-4d91-9acd-5bc63d02adbd", "AQAAAAEAACcQAAAAEF6lwOQglWJ1CjFKVjkH0aqjSmRwx3bydOS+4Zz0zd26zbRAq0F6nmsTWcwYiCnvjg==", "2cf7295d-7041-4b80-8b08-d937263a8a20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08b918ed-b97a-4842-a0e0-2d9ba15e75d1", "AQAAAAEAACcQAAAAEBtlegmdnZVoLcyUym+MH3gXG0qgKQb1CcTY7yyXQafEASzeJCZoOq0/8HaggiJf6g==", "24c5dc75-d129-430d-b461-44b8faa38a86" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "CustomerName", "OrderDate", "OrderNumber", "PaymentMethod", "Phone", "ShippingAddress", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("07d0b51a-bf10-4bae-8e3f-268d08b4f715"), new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"), "Dogy Lover", new DateTime(2023, 8, 7, 20, 3, 5, 623, DateTimeKind.Utc).AddTicks(453), new Guid("32c557e6-7ec5-4f8c-8924-3f263c936ed5"), 1, "+359885179143", "Velcho Atanasov 56", 2, 62.00m },
                    { new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"), new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"), "Dogy Lover", new DateTime(2023, 8, 7, 20, 3, 5, 623, DateTimeKind.Utc).AddTicks(465), new Guid("2452c95c-8f69-4bb3-ae5c-203c95ea6d01"), 1, "+359885179143", "Velcho Atanasov 56", 2, 132.00m }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 628, DateTimeKind.Utc).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 628, DateTimeKind.Utc).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 628, DateTimeKind.Utc).AddTicks(4460));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 628, DateTimeKind.Utc).AddTicks(4462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 628, DateTimeKind.Utc).AddTicks(4465));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 628, DateTimeKind.Utc).AddTicks(4471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 628, DateTimeKind.Utc).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 628, DateTimeKind.Utc).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 628, DateTimeKind.Utc).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 628, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 628, DateTimeKind.Utc).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 628, DateTimeKind.Utc).AddTicks(4490));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("07d0b51a-bf10-4bae-8e3f-268d08b4f715"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"));

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
    }
}
