using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonReviewAppp.Migrations
{
    /// <inheritdoc />
    public partial class Actualizando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Owners");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Pokemon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Pokemon");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
