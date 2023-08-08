using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class AddUsersToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RatingType",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CartId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserBuyedProductsId", "UserName" },
                values: new object[] { new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"), 0, null, "b908450e-67ac-4f8a-add2-a12f67d3cdff", "doglover@abv.bg", false, false, null, "DOGLOVER@ABV.BG", "DOGLOVER@ABV.BG", "AQAAAAEAACcQAAAAEEYJtSFrXHD0sKUzueIKcFQR9m6BgXjvorDPVKtMPZiG9j1e6nU7Pl/7LuwOOyn8KA==", null, false, "5c75cfba-35e3-485b-9b6d-c12240c93bc2", false, null, "doglover@abv.bg" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CartId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserBuyedProductsId", "UserName" },
                values: new object[] { new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"), 0, null, "d61c775d-a817-46da-8928-47b4a1ce265f", "creator@abv.bg", false, false, null, "CREATOR@ABV.BG", "CREATOR@ABV.BG", "AQAAAAEAACcQAAAAEH/L5MIaZAuBBg+qMkRa0xLQEFXBA5ZlRzl5imx7y2r/sGYNcBwMuiyu6uByLwc0KQ==", null, false, "fdf36440-1930-414c-8f71-100b34bec110", false, null, "creator@abv.bg" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CartId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserBuyedProductsId", "UserName" },
                values: new object[] { new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"), 0, null, "2d972c31-9a7e-4ef4-9aa5-ef1cc993af27", "Admin@abv.bg", false, false, null, "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAEAACcQAAAAEAWQU4IdOPmjJFqIXZyTZVH8uxGr73R6CLHPRLyolNJIQrd8cz6+fIQYU8R8zhCLhg==", null, false, "f82ca3d2-32f5-48bd-a16f-13fe0845d03d", false, null, "Admin@abv.bg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"));

            migrationBuilder.AlterColumn<int>(
                name: "RatingType",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
