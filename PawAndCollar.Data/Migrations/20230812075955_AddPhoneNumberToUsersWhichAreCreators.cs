using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class AddPhoneNumberToUsersWhichAreCreators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c290529-132b-42c9-b8a9-c80d94308ba6", "AQAAAAEAACcQAAAAEGxetxotX1lpwL9qACvzG2G4NDj2oG8mjDNfU6e1FQzRn2ym9rFg5GG1SllUSo0RPQ==", "bb298fe1-393f-49ab-9c23-50df848b4657" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "437b6ef0-b8d0-488a-b8e9-d5fcc1506a49", "AQAAAAEAACcQAAAAEIbDv5X4GjHfZW+G1qtN5FrPLmUMs9gmt5xwEV5ZjRSWvzHBpxOzD1R+cUX6CPkU6w==", "+359884156182", "1afdd5dd-da44-4d6e-85a5-9c02834dd026" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "e59a9be0-2ad3-48e5-b586-8825d1211ffb", "AQAAAAEAACcQAAAAEODfrI6TnPkHMhroglNvMp5+BB3pibqgqdMg5LeZC1T82j39N3xxZtbE48rEy9GDTQ==", "+359884562194", "d86eb8a9-e5e6-44f6-9210-de9ac9cc615a" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9337dd42-5df1-4b1b-815e-9b637b6fadb8", "AQAAAAEAACcQAAAAELM9EZL6Zgi7FThVOWAgm+EoDkZk4PIwoOaACAqTGJl/CX+oYS5xnlN3BF+5vc04aw==", "62dfb9d4-7f1c-4811-bf17-3a72529a2390" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "30aae390-18bd-4c62-bb5c-6e33774efbde", "AQAAAAEAACcQAAAAEACnrpXYS66lsJCj7Mh97pF8+hWdMq4jC9JXQuHihGTvmAGEuZh9ONherW2cUsK59Q==", null, "29c16f9e-ee29-4fa5-b59c-025689756556" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "6d5ed3c6-bdb2-4be3-b11a-734c90f7c0e3", "AQAAAAEAACcQAAAAEJaZwaOsla/HRzUbPtyKAsJlSs8cTri2Wuasx0S+JuYFM4JprwupcH2Fl4e3cxXE6A==", null, "76a194ae-8cf6-442b-8db4-fad7166a15cc" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePosted",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePosted",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("07d0b51a-bf10-4bae-8e3f-268d08b4f715"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ad8f6d52-9e4d-463a-b240-723c2e37ac2b"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(6501));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(6529));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(6532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(6536));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(6538));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(6540));
        }
    }
}
