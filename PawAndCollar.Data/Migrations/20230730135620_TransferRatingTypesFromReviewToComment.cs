using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class TransferRatingTypesFromReviewToComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingType",
                table: "Reviews");

            migrationBuilder.AddColumn<double>(
                name: "AverageScore",
                table: "Reviews",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "RatingType",
                table: "Comments",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageScore",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "RatingType",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "RatingType",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
