using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MayTheFourth.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class CharWithOnePlanet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterPlanet");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanetId",
                table: "Characters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlanetId",
                table: "Characters",
                column: "PlanetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Planets_PlanetId",
                table: "Characters",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Planets_PlanetId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_PlanetId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "Characters");

            migrationBuilder.CreateTable(
                name: "CharacterPlanet",
                columns: table => new
                {
                    CharactersId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanetsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterPlanet", x => new { x.CharactersId, x.PlanetsId });
                    table.ForeignKey(
                        name: "FK_CharacterPlanet_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterPlanet_Planets_PlanetsId",
                        column: x => x.PlanetsId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPlanet_PlanetsId",
                table: "CharacterPlanet",
                column: "PlanetsId");
        }
    }
}
