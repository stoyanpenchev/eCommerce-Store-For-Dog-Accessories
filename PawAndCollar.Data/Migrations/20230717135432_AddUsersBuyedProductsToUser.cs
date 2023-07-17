using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class AddUsersBuyedProductsToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "UserBuyedProductsId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersBuyedProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersBuyedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersBuyedProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserBuyedProductsId",
                table: "AspNetUsers",
                column: "UserBuyedProductsId",
                unique: true,
                filter: "[UserBuyedProductsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsersBuyedProducts_ProductId",
                table: "UsersBuyedProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UsersBuyedProducts_UserBuyedProductsId",
                table: "AspNetUsers",
                column: "UserBuyedProductsId",
                principalTable: "UsersBuyedProducts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UsersBuyedProducts_UserBuyedProductsId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UsersBuyedProducts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserBuyedProductsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserBuyedProductsId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
