using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class SeedReviewsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df8f87f2-1082-44fb-bb8f-105b47a40aa9", "AQAAAAEAACcQAAAAEJe2wgsyWaad33W6yckzTbkubB61szkUDCyJkvutlba0LAxdQla4YKDJLFkiPqLSCQ==", "1403ff6a-5927-4a8b-ac37-b7fd249d42de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5ff1e31-9866-4ef4-b63d-418602a3f3d4", "AQAAAAEAACcQAAAAENQ4sNuzxk8bdJDsc3wsoNPBGXW+Cwaxelq5qoArmdRlhWliXltytht/ecCi42ruoQ==", "c4fd0f5a-3e44-46eb-b323-d50c5dc88f89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f486ad36-d3c7-4674-a345-74e69fc82577", "AQAAAAEAACcQAAAAEHxaGBTIgZpzOmO8eZtcx0tr5890Zvf2+uJeQm7R7wRCJst/qduzGRAS3rK//Owntg==", "bc2db056-a637-4a3f-8aea-80822954f4c8" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("07d0b51a-bf10-4bae-8e3f-268d08b4f715"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 614, DateTimeKind.Utc).AddTicks(184));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 614, DateTimeKind.Utc).AddTicks(204));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ad8f6d52-9e4d-463a-b240-723c2e37ac2b"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 614, DateTimeKind.Utc).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 620, DateTimeKind.Utc).AddTicks(202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 620, DateTimeKind.Utc).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 620, DateTimeKind.Utc).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 620, DateTimeKind.Utc).AddTicks(224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 620, DateTimeKind.Utc).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 620, DateTimeKind.Utc).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 620, DateTimeKind.Utc).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 620, DateTimeKind.Utc).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 620, DateTimeKind.Utc).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 620, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 620, DateTimeKind.Utc).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 10, 59, 7, 620, DateTimeKind.Utc).AddTicks(252));

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AverageScore", "ProductId" },
                values: new object[,]
                {
                    { 1, 0.0, 11 },
                    { 2, 0.0, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ad8f6d52-9e4d-463a-b240-723c2e37ac2b"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 8, 10, 55, 58, 824, DateTimeKind.Utc).AddTicks(6632));

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
        }
    }
}
