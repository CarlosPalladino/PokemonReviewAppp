using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonReviewAppp.Migrations
{
    /// <inheritdoc />
    public partial class ActualizandoPoke : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Debilidad",
                table: "Pokemon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Pokemon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Debilidad",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Pokemon");
        }
    }
}
