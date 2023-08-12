using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class FixCommentsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30aae390-18bd-4c62-bb5c-6e33774efbde", "AQAAAAEAACcQAAAAEACnrpXYS66lsJCj7Mh97pF8+hWdMq4jC9JXQuHihGTvmAGEuZh9ONherW2cUsK59Q==", "29c16f9e-ee29-4fa5-b59c-025689756556" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d5ed3c6-bdb2-4be3-b11a-734c90f7c0e3", "AQAAAAEAACcQAAAAEJaZwaOsla/HRzUbPtyKAsJlSs8cTri2Wuasx0S+JuYFM4JprwupcH2Fl4e3cxXE6A==", "76a194ae-8cf6-442b-8db4-fad7166a15cc" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CustomerId", "DatePosted", "RatingType", "ReviewId" },
                values: new object[,]
                {
                    { 1, "Very Nice Product! I am pleased with it:)", new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"), new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(7599), 5, 1 },
                    { 2, "Test from Admin. The test is looking goood!", new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"), new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(7605), 5, 1 },
                    { 3, "Test with one star! It seems okay!", new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"), new DateTime(2023, 8, 12, 6, 30, 10, 366, DateTimeKind.Utc).AddTicks(7607), 1, 1 }
                });

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
    }
}
