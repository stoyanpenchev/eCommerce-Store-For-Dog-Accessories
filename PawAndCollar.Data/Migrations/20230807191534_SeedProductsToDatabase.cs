using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class SeedProductsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b724b4e-70ea-42bc-5992-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebfb8fe3-87ba-4374-a837-a66cef27bd04", "AQAAAAEAACcQAAAAEOSsfiepc4cDQnCEqCwkUmQSIYD7dRsrDy1cXZxDtaST5eZB2xfnDgVMK3eEwl+4gQ==", "01bb1413-9ff1-4911-912e-569cfd9bf989" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f8a1988-0d6f-48cf-5993-08db77f1f68e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93826849-450d-4e53-9f73-47b2b08395b6", "AQAAAAEAACcQAAAAEJX6LNVLwzr7XUmDGhk0dmFqdmAZw4PHgtlR3TWLdzRv12eNjYjuD/FiX13INHsHgw==", "905721e0-bfd4-4bd7-bda7-7b426be7aac2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9caf16d5-298e-406a-a3da-69dcda2e5e27"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37fc37b9-3fce-499a-91f9-b5c88545c245", "AQAAAAEAACcQAAAAEChNYKr0y3mFMcohmw7kjondYY9AZZSeowBfqJ21wy3S2rl1GJoOrpmIS6skskY0Dw==", "0756dd47-08b0-4a96-8659-6bcd994fada1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "Color", "CreatedOn", "CreatorId", "Description", "ImageUrl", "IsActive", "Material", "Name", "Price", "Quantity", "ReviewId", "Size" },
                values: new object[,]
                {
                    { 1, null, 1, "Pink", new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7034), new Guid("3cb1a657-3d82-483c-8932-f53cd637bd11"), "Soft and sustainable fabric on the outside & inside, so even the most sensitive pups can stay comfortable all day long.\r\nCozy Fleece Vest: Machine wash cold on delicate cycle or hand wash. Air dry.", "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/DSC03178-1-148760_720x.jpg?v=1679180307", true, "Cotton", "Checker Pink Collar", 52.00m, 10, null, 5 },
                    { 2, null, 1, "Anemone", new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7045), new Guid("3cb1a657-3d82-483c-8932-f53cd637bd11"), "In the meadows of Europe, North America, and Japan, where secrets whisper on gentle breezes, the anemone dances, an ethereal wildflower.\r\n\r\nSymbolizing understated allure, this fragile blossom enchants hearts, its subtle loveliness imbuing floral tapestries with a touch of quiet power.", "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/DSC06736-1_d5aa7dd9-1769-47a1-affb-98d78ba9fb86-812247_720x.jpg?v=1687945201", true, "Cotton", "Anemone Collar", 52.00m, 2, null, 1 },
                    { 3, null, 1, "Brown", new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7100), new Guid("3cb1a657-3d82-483c-8932-f53cd637bd11"), "A part of our boho collection including Suns, Stars, Rainbows, and lightnings. This collection is perfect for the boho, minimalist, and chic pups. Seamless Sun on lovely shade of terracotta-orange background.", "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/cute-dog-collars-girl_c89dd21c-4f50-4bf3-9dd4-32198ee0737a-429779_720x.jpg?v=1669923706", true, "Cotton", "Suns Collar", 52.00m, 15, null, 5 },
                    { 4, null, 5, "Midnight", new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7103), new Guid("3cb1a657-3d82-483c-8932-f53cd637bd11"), "Midnight Floral brings out a lovely serenity. Featuring an abundance of lively flowers on a bold black background, this print is sure to stand out on any color of fur. 100% cotton fabric with the perfect touch of rose gold metal hardware.", "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/DSC07134-1-181634_720x.jpg?v=1683713614", true, "Cotton", "Midnight Floral Collar", 52.00m, 3, null, 5 },
                    { 5, null, 3, "Pink", new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7107), new Guid("3cb1a657-3d82-483c-8932-f53cd637bd11"), "One of our bestselling designs of all time. Crafted with care and attention to detail, this stunning design features an abundance of lively flowers that will add a touch of  nature's beauty to your furry friend's wardrobe.", "https://sniffandbark.com.co/cdn/shop/products/Cute-dog-harness-for-large-dogs_652c3b45-bf4f-4d1f-9532-f34971c4eff9-714245_720x.jpg?v=1669533905", true, "Cotton", "Morning Floral Harness", 81.00m, 6, null, 1 },
                    { 6, null, 3, "Darky", new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7113), new Guid("3cb1a657-3d82-483c-8932-f53cd637bd11"), "Give your pup the gift of coziness with our Cozy Christmas design! This dark navy blue print is filled with adorable holiday elements that will have your furry friend feeling warm and snug, making it the perfect addition to their winter wardrobe.", "https://sniffandbark.com.co/cdn/shop/products/cutest-harness-for-puppy-418532_720x.jpg?v=1669533830", true, "Cotton", "Cozy Christmas Harness", 81.00m, 6, null, 6 },
                    { 7, null, 3, "Peachy Pink", new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7116), new Guid("3cb1a657-3d82-483c-8932-f53cd637bd11"), "One of our most loved prints of all time. This delicious peach print will make your pup's cuteness irresistible. Featuring seamless Juicy peaches on a lovely peach-pink background.", "https://sniffandbark.com.co/cdn/shop/products/Best-dog-harnesses-490084_720x.jpg?v=1669620377", true, "Cotton", "Peach Harness", 81.00m, 8, null, 7 },
                    { 8, null, 6, "English Green", new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7119), new Guid("20b110ec-107c-4b88-9bd4-56f4d297b179"), "This is a true showstopper. With its timeless tartan pattern, our Gentleman design is the epitome of sophisticated style for your pup. ", "https://sniffandbark.com.co/cdn/shop/products/Cute-dog-collars-girl-999347_720x.jpg?v=1669663616", true, "Cotton", "Gentleman Bow Tie Collar", 62.00m, 5, null, 2 },
                    { 9, null, 6, "English Green", new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7122), new Guid("20b110ec-107c-4b88-9bd4-56f4d297b179"), "Classic polka dot with bright striking red background. The Versatility is perfect for any occasion and will always make sure your pup stands out from the crowd. One of our most loved designs of all time.", "https://sniffandbark.com.co/cdn/shop/products/bowtie-collars-for-large-dogs-509429_720x.jpg?v=1669836746", true, "Cotton", "Red Polka Dot Bow Tie Collar", 62.00m, 5, null, 2 },
                    { 10, null, 8, "Purple", new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7126), new Guid("20b110ec-107c-4b88-9bd4-56f4d297b179"), "Made with premium waterproof shell on one side, and 360° reflective material on the other. You've got functionality and adorableness - all in one.", "https://sniffandbark.com.co/cdn/shop/products/ZoomiesRainvest_1-512091_720x.jpg?v=1677154390", true, "Cotton", "Purple Daisy Reversible Zoomies Rain Vest", 91.00m, 15, null, 3 },
                    { 11, null, 7, "Green", new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7128), new Guid("20b110ec-107c-4b88-9bd4-56f4d297b179"), "Beautifully illustrated by Vancouver local artist @hye.joy. This print brings out the liveliness of a spring playground with unique line illustrations, paired with a beautiful shade of olive background.", "https://sniffandbark.com.co/cdn/shop/products/DSC00043-1-238909_720x.jpg?v=1687529058", true, "Cotton", "Playground Bandana", 44.00m, 15, null, 3 },
                    { 12, null, 7, "Christmas", new DateTime(2023, 8, 7, 19, 15, 33, 853, DateTimeKind.Utc).AddTicks(7131), new Guid("20b110ec-107c-4b88-9bd4-56f4d297b179"), "Give your pup the gift of coziness with our Cozy Christmas design! This dark navy blue print is filled with adorable holiday elements that will have your furry friend feeling warm and snug, making it the perfect addition to their winter wardrobe.", "https://sniffandbark.com.co/cdn/shop/products/Bandanas-for-dogs_7aad35d9-b940-49bd-8895-9f8bb74dc6dd-759894_720x.jpg?v=1668643303", true, "Cotton", "Cozy Christmas Bandana", 44.00m, 15, null, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

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
        }
    }
}
