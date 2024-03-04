using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class changedimageanemonecollar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4489d2cb-2940-4647-993b-9bf9482e7372", "AQAAAAEAACcQAAAAEJW+It2DNN02CNI8LCSPKlQ5go9IFzINir7MFVYgO1umUOXHtW7HuVrTW8YEdXmiUw==", "ee3e2f23-eed6-4643-a3ae-38c4d201c0b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44c87ed6-03c7-4726-9159-38def4d7d301", "AQAAAAEAACcQAAAAEGomcgP4I1as9qtjXO3P/kxlC+fAWuRqRJ05D4MNguGnkbDdWq8IpObjIP2R0LeMwg==", "d9cf79f2-d5d3-4c2d-b2bb-57c841ae808d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b43b9ffa-daf3-4d4d-aa35-b15139b3b682", "AQAAAAEAACcQAAAAEFRIr7PWZLhVrjA9zdaw/aXXf1Jx6Cqp5LANbUncgT5vsSOweY/70GVUWIpiGlR9PQ==", "942711b6-f1b1-489d-97d7-1d727e4a61d6" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePosted",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePosted",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("07d0b51a-bf10-4bae-8e3f-268d08b4f715"),
                column: "OrderDate",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(4352));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4d9c7a77-9295-4a6e-907a-96fe2905de0e"),
                column: "OrderDate",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ad8f6d52-9e4d-463a-b240-723c2e37ac2b"),
                column: "OrderDate",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(3377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(3386), "https://sniffandbark.com.co/cdn/shop/files/luxury_best_dog_collars-Personalized_with_namer_metal_buckle_gif_720x.jpg?v=1709060653" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(3389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(3395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(3404));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(3412));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(3415));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(3421));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 9, 30, 28, 729, DateTimeKind.Utc).AddTicks(3423));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "652fed0f-ec12-4148-9cb8-0c7cf0d6ccf3", "AQAAAAEAACcQAAAAEITgHm0O3alhQypaO4VgMI7mMpw88a9gnn1LLmzX65Jxwb1vy746YB9TZhMJkeIH4g==", "25ee2c47-719d-4000-ad3b-d262944ef262" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a476738-c473-46ad-9e23-4180b826d31a", "AQAAAAEAACcQAAAAENF6BUwgnervsHeTlxCSRvzuwc8E0k4qn/dmayzHBcvZqQ4LLKbpI5hxmx4RQHBWdg==", "8574cb06-0277-4829-a822-ff59b96a974c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc828acc-8d8c-4a9c-9b2c-a5fb952c38ae", "AQAAAAEAACcQAAAAEGOjYoqXVXv0LBv0bKciobyQW1QNkPwBkwEznDnjKaDZf1EKRQRTHYzmySbGo/ZmbQ==", "c5017370-f7fe-48c1-8959-f6734fc6a443" });

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
                columns: new[] { "CreatedOn", "ImageUrl" },
                values: new object[] { new DateTime(2023, 8, 12, 8, 14, 44, 230, DateTimeKind.Utc).AddTicks(306), "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/DSC06736-1_d5aa7dd9-1769-47a1-affb-98d78ba9fb86-812247_720x.jpg?v=1687945201" });

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
    }
}
