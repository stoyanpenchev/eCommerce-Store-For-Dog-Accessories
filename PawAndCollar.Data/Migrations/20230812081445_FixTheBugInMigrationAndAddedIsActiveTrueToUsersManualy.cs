using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class FixTheBugInMigrationAndAddedIsActiveTrueToUsersManualy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "652fed0f-ec12-4148-9cb8-0c7cf0d6ccf3", true, "AQAAAAEAACcQAAAAEITgHm0O3alhQypaO4VgMI7mMpw88a9gnn1LLmzX65Jxwb1vy746YB9TZhMJkeIH4g==", "25ee2c47-719d-4000-ad3b-d262944ef262" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a476738-c473-46ad-9e23-4180b826d31a", true, "AQAAAAEAACcQAAAAENF6BUwgnervsHeTlxCSRvzuwc8E0k4qn/dmayzHBcvZqQ4LLKbpI5hxmx4RQHBWdg==", "8574cb06-0277-4829-a822-ff59b96a974c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc828acc-8d8c-4a9c-9b2c-a5fb952c38ae", true, "AQAAAAEAACcQAAAAEGOjYoqXVXv0LBv0bKciobyQW1QNkPwBkwEznDnjKaDZf1EKRQRTHYzmySbGo/ZmbQ==", "c5017370-f7fe-48c1-8959-f6734fc6a443" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePosted",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(1773));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePosted",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("07d0b51a-bf10-4bae-8e3f-268d08b4f715"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(1526));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ad8f6d52-9e4d-463a-b240-723c2e37ac2b"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(306));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(322));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(342));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c290529-132b-42c9-b8a9-c80d94308ba6", null, "AQAAAAEAACcQAAAAEGxetxotX1lpwL9qACvzG2G4NDj2oG8mjDNfU6e1FQzRn2ym9rFg5GG1SllUSo0RPQ==", "bb298fe1-393f-49ab-9c23-50df848b4657" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "437b6ef0-b8d0-488a-b8e9-d5fcc1506a49", null, "AQAAAAEAACcQAAAAEIbDv5X4GjHfZW+G1qtN5FrPLmUMs9gmt5xwEV5ZjRSWvzHBpxOzD1R+cUX6CPkU6w==", "1afdd5dd-da44-4d6e-85a5-9c02834dd026" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e59a9be0-2ad3-48e5-b586-8825d1211ffb", null, "AQAAAAEAACcQAAAAEODfrI6TnPkHMhroglNvMp5+BB3pibqgqdMg5LeZC1T82j39N3xxZtbE48rEy9GDTQ==", "d86eb8a9-e5e6-44f6-9210-de9ac9cc615a" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePosted",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePosted",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("07d0b51a-bf10-4bae-8e3f-268d08b4f715"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ad8f6d52-9e4d-463a-b240-723c2e37ac2b"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(3934));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(2983));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(2995));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(3012));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(3168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(3172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(3176));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 7, 59, 53, 793, DateTimeKind.Utc).AddTicks(3179));
        }
    }
}
