using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class ProfileImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "RestaurantsImages");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Restaurants");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "RestaurantsImages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
