using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class CartdIdAdedToOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItems_Carts_CartId",
                table: "OrderedItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "OrderedItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItems_Carts_CartId",
                table: "OrderedItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItems_Carts_CartId",
                table: "OrderedItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "OrderedItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItems_Carts_CartId",
                table: "OrderedItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
