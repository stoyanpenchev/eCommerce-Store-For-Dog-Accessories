using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class AddAdditionalOrderAndUserBuyedProductToTheSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e6e41c7-58f8-4547-8a4d-1ebbffb7168f", "AQAAAAEAACcQAAAAEG6QTqqn1jK/2F0S//xolGSsNHoic7foKXhI0IK4xd71/8QQ0U58McRdgISdQO988g==", "d7153aa3-75bd-4006-ad3e-6a553e39c54e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5bf5b6b-4e84-47a5-8eea-be22eb64683f", "AQAAAAEAACcQAAAAEMu7h1w8PMhMKDSZj3x0Os9NWkpbJn3i0xKIdMcJCzZxx/afDfdvOiZ72TH12aWUUQ==", "289784e1-3a42-4c20-8714-455552cb592c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a572af08-4712-4607-91aa-1d356048b397", "AQAAAAEAACcQAAAAECCcXqgU2FT7KPPKDpHazfzCOUN45ElDd5wd7qSi+3Q+S1QJSBGq+9ndvH4m0yjl6A==", "bfe0dad9-473f-4ab2-9376-19c5cede972a" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("07d0b51a-bf10-4bae-8e3f-268d08b4f715"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 824, DateTimeKind.Utc).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 824, DateTimeKind.Utc).AddTicks(6625));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "CustomerName", "OrderDate", "OrderNumber", "PaymentMethod", "Phone", "ShippingAddress", "Status", "TotalAmount" },
                values: new object[] { new Guid("ad8f6d52-9e4d-463a-b240-723c2e37ac2b"), new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"), "Admin Adminov", new DateTime(2023, 8, 8, 10, 55, 58, 824, DateTimeKind.Utc).AddTicks(6632), new Guid("43cdad61-ecb3-488e-a378-f5674399eaa4"), 2, "+359884123154", "Sofia Bulgaria", 3, 104.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 829, DateTimeKind.Utc).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 829, DateTimeKind.Utc).AddTicks(5138));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 829, DateTimeKind.Utc).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 829, DateTimeKind.Utc).AddTicks(5144));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 829, DateTimeKind.Utc).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 829, DateTimeKind.Utc).AddTicks(5152));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 829, DateTimeKind.Utc).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 829, DateTimeKind.Utc).AddTicks(5159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 829, DateTimeKind.Utc).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 829, DateTimeKind.Utc).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 829, DateTimeKind.Utc).AddTicks(5168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 829, DateTimeKind.Utc).AddTicks(5171));

            migrationBuilder.InsertData(
                table: "UsersBuyedProducts",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UserId" },
                values: new object[] { new Guid("0d5ff8a7-c4e0-4db5-89df-2801a2cd945f"), new Guid("ad8f6d52-9e4d-463a-b240-723c2e37ac2b"), 1, 2, new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersBuyedProducts",
                keyColumn: "Id",
                keyValue: new Guid("0d5ff8a7-c4e0-4db5-89df-2801a2cd945f"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ad8f6d52-9e4d-463a-b240-723c2e37ac2b"));

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
        }
    }
}
