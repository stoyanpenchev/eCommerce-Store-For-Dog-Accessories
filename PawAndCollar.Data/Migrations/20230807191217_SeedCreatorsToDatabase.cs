using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class SeedCreatorsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8991987f-2523-4cd0-a765-71689fdb75f0", "AQAAAAEAACcQAAAAEJUuFXuN9tXV2NRDpE2e1cxGxy42UjY0pZG8CtDa+v36FRHd28uZXt7LJC4FpgI3Eg==", "634ad513-ff5e-4749-bdbe-c0f3b902b72b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db93d729-3f71-4953-9b2c-ce8379e78b7d", "AQAAAAEAACcQAAAAEHWpkIm03WrxbztmyPOvltyHD+Mf5oVhQ9dpypZlPG1+fajZZY4U8HwjsY6jvEmRcw==", "94668889-ce94-4aa7-83d5-ebe3fa50636f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e58aab7-1f36-41ea-8815-22ce9c2e0442", "AQAAAAEAACcQAAAAEH+3DFnkFQQLdljxmtHGqdMmmI8ZXl/A3zldJg6PcYCRQ7+Af3sJxhRREMIc9wh5rQ==", "f7587707-23f7-447a-a10e-d9ff48ba5b73" });

            migrationBuilder.InsertData(
                table: "Creators",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { new Guid("20b110ec-107c-4b88-9bd4-56f4d297b179"), "+359884562194", new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27") },
                    { new Guid("3cb1a657-3d82-483c-8932-f53cd637bd11"), "+359884156182", new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Creators",
                keyColumn: "Id",
                keyValue: new Guid("20b110ec-107c-4b88-9bd4-56f4d297b179"));

            migrationBuilder.DeleteData(
                table: "Creators",
                keyColumn: "Id",
                keyValue: new Guid("3cb1a657-3d82-483c-8932-f53cd637bd11"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b908450e-67ac-4f8a-add2-a12f67d3cdff", "AQAAAAEAACcQAAAAEEYJtSFrXHD0sKUzueIKcFQR9m6BgXjvorDPVKtMPZiG9j1e6nU7Pl/7LuwOOyn8KA==", "5c75cfba-35e3-485b-9b6d-c12240c93bc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d61c775d-a817-46da-8928-47b4a1ce265f", "AQAAAAEAACcQAAAAEH/L5MIaZAuBBg+qMkRa0xLQEFXBA5ZlRzl5imx7y2r/sGYNcBwMuiyu6uByLwc0KQ==", "fdf36440-1930-414c-8f71-100b34bec110" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d972c31-9a7e-4ef4-9aa5-ef1cc993af27", "AQAAAAEAACcQAAAAEAWQU4IdOPmjJFqIXZyTZVH8uxGr73R6CLHPRLyolNJIQrd8cz6+fIQYU8R8zhCLhg==", "f82ca3d2-32f5-48bd-a16f-13fe0845d03d" });
        }
    }
}
