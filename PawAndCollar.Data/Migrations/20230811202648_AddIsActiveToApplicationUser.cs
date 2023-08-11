using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class AddIsActiveToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c556ca1-54ea-4076-8881-a64707f676d3", "AQAAAAEAACcQAAAAEJLi/6CArdraKC4h5xmjA4hhyQE8Ziy8fmId2Hc4GlKPQyf1zkdZHgl4qs691QUZLQ==", "1985aa6d-af22-4d44-9e7d-da65cf9b4c7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ceb9fe5d-eda6-4143-8eae-e1a39a73a5a3", "AQAAAAEAACcQAAAAELpnqRG4WaRtc971JLY6xGow8qpJgxJmQDn96HlhvUEtIEF4xfhuUEVWZRmviwGUQw==", "55321304-9698-4bca-b1fa-4b48d0ac41f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c27c8c5a-9574-43cc-a43e-d20b6779608b", "AQAAAAEAACcQAAAAEKDprZFzdiqqfr8c1mCgewE9tno2ECa/fpwWySLN3oUk6MnOnVOOlrfBnnwhwyLUXg==", "96afcecd-17c5-41c4-8ec8-3ec44c1cea6c" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("07d0b51a-bf10-4bae-8e3f-268d08b4f715"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ad8f6d52-9e4d-463a-b240-723c2e37ac2b"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(9537));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(8518));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(8522));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(8526));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(8554));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 11, 20, 26, 47, 557, DateTimeKind.Utc).AddTicks(8562));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

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
        }
    }
}
