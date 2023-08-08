using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class SeedCommentsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0c10f5a-0eb0-40fc-9382-6754a0c6b25d", "AQAAAAEAACcQAAAAENbRGUPYwOZ9CHDyUA+TFSzKUIdM3fEjYVnZKkCQSZ9PQmCcRaoUgMgzHOVonZKuSg==", "1095c1a5-a7f9-44f6-8705-bd2997319572" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f986958-00d0-4b7b-ae8c-2ca7d959a3f8", "AQAAAAEAACcQAAAAEFqHgvPqr9S1ZuWupANOE6xyHCUfvs54JG/omsJH1mdgUUTUgyK9gL5p0XtyHj28hQ==", "37598ecc-fafc-4162-b888-caee63543ee3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cf8bc9d-428d-45d0-884b-8462b536789b", "AQAAAAEAACcQAAAAEP3uN5DkULUlZE2tbZ+s3xejLD50vHYJnW/mEvC47D1hMJDaLoSkdMgcpc6D9PrlDQ==", "5285f9dc-b5b5-4331-83f2-3c2eabdbf7fe" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CustomerId", "DatePosted", "RatingType", "ReviewId" },
                values: new object[,]
                {
                    { 1, "Very Nice Product! I am pleased with it:)", new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"), new DateTime(2023, 8, 8, 11, 1, 3, 349, DateTimeKind.Utc).AddTicks(7063), 5, 1 },
                    { 2, "Test from Admin. The test is looking goood!", new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"), new DateTime(2023, 8, 8, 11, 1, 3, 349, DateTimeKind.Utc).AddTicks(7074), 5, 1 },
                    { 3, "Test with one star! It seems okay!", new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"), new DateTime(2023, 8, 8, 11, 1, 3, 349, DateTimeKind.Utc).AddTicks(7077), 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("07d0b51a-bf10-4bae-8e3f-268d08b4f715"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 349, DateTimeKind.Utc).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 349, DateTimeKind.Utc).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ad8f6d52-9e4d-463a-b240-723c2e37ac2b"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 349, DateTimeKind.Utc).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 355, DateTimeKind.Utc).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 355, DateTimeKind.Utc).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 355, DateTimeKind.Utc).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 355, DateTimeKind.Utc).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 355, DateTimeKind.Utc).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 355, DateTimeKind.Utc).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 355, DateTimeKind.Utc).AddTicks(3083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 355, DateTimeKind.Utc).AddTicks(3087));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 355, DateTimeKind.Utc).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 355, DateTimeKind.Utc).AddTicks(3175));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 355, DateTimeKind.Utc).AddTicks(3179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 8, 11, 1, 3, 355, DateTimeKind.Utc).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "AverageScore",
                value: 3.6666666666666701);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "AverageScore",
                value: 0.0);
        }
    }
}
