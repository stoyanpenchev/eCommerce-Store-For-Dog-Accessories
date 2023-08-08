using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class SeedUsersBuyedProductsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7c30903-a582-4d96-b5ed-51d17c6a35c1", "AQAAAAEAACcQAAAAEMuMukqDtjS5gEuHCfWbaSrrUjrdZ4az8/SwjdTvk9uAJHB6xOuL/CmNmNB/np8mfw==", "3bcd3169-0a5f-452c-8944-7157c4a99438" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da542898-7186-4d1b-a026-5e85f1ce84a0", "AQAAAAEAACcQAAAAEOvFBbO5+ZaXwOwCxHS3RhsCGyBzQi+pgfktRh8uTv5HJqcUb48iKRHrr+0dbeK3OA==", "33fb5d4d-9a63-4f31-91d1-8023d8ece301" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "baaa3358-786d-4051-b038-0d7271f995b7", "AQAAAAEAACcQAAAAEDG8O+tEHkoUmUN/C5EgiAnefdn4CCom7PoPBdyPNF4n1myLt1eyCXkiI9ilkq7HWQ==", "bdcfc149-5ae6-478c-bc4b-1aa52faa7801" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("07d0b51a-bf10-4bae-8e3f-268d08b4f715"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 719, DateTimeKind.Utc).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 719, DateTimeKind.Utc).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 726, DateTimeKind.Utc).AddTicks(2533));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 726, DateTimeKind.Utc).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 726, DateTimeKind.Utc).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 726, DateTimeKind.Utc).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 726, DateTimeKind.Utc).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 726, DateTimeKind.Utc).AddTicks(2679));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 726, DateTimeKind.Utc).AddTicks(2683));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 726, DateTimeKind.Utc).AddTicks(2687));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 726, DateTimeKind.Utc).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 726, DateTimeKind.Utc).AddTicks(2719));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 726, DateTimeKind.Utc).AddTicks(2724));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 7, 20, 11, 23, 726, DateTimeKind.Utc).AddTicks(2728));

            migrationBuilder.InsertData(
                table: "UsersBuyedProducts",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { new Guid("2a00f9ca-8b95-487f-9bcb-41588ab9c532"), new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"), 12, 1, new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e") },
                    { new Guid("96a247b6-51a7-4f42-800f-3150b014358c"), new Guid("07d0b51a-bf10-4bae-8e3f-268d08b4f715"), 8, 1, new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e") },
                    { new Guid("d7c7a078-a1af-42f3-b271-403d7cd05444"), new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"), 11, 2, new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersBuyedProducts",
                keyColumn: "Id",
                keyValue: new Guid("2a00f9ca-8b95-487f-9bcb-41588ab9c532"));

            migrationBuilder.DeleteData(
                table: "UsersBuyedProducts",
                keyColumn: "Id",
                keyValue: new Guid("96a247b6-51a7-4f42-800f-3150b014358c"));

            migrationBuilder.DeleteData(
                table: "UsersBuyedProducts",
                keyColumn: "Id",
                keyValue: new Guid("d7c7a078-a1af-42f3-b271-403d7cd05444"));

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

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("07d0b51a-bf10-4bae-8e3f-268d08b4f715"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 623, DateTimeKind.Utc).AddTicks(453));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 7, 20, 3, 5, 623, DateTimeKind.Utc).AddTicks(465));

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
    }
}
