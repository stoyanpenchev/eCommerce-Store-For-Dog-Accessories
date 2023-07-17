using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class FixTheMispelledTotalAmauntToTotalAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmaunt",
                table: "Orders",
                newName: "TotalAmount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Orders",
                newName: "TotalAmaunt");
        }
    }
}
