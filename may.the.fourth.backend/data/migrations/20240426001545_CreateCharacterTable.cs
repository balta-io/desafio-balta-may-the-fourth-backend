using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace may.the.fourth.backend.data.migrations
{
    /// <inheritdoc />
    public partial class CreateCharacterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Height = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Weight = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    HairColor = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    SkinColor = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    EyeColor = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    BirthYear = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Gender = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    PlanetID = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterID);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterID", "BirthYear", "EyeColor", "Gender", "HairColor", "Height", "Name", "PlanetID", "SkinColor", "Weight" },
                values: new object[,]
                {
                    { 1, "19BBY", "blue", "male", "blond", "172", "Luke Skywalker", 1, "fair", "77" },
                    { 2, "112BBY", "yellow", "n/a", "n/a", "167", "C-3PO", 1, "gold", "75" },
                    { 3, "33BBY", "red", "n/a", "n/a", "96", "R2-D2", 8, "white, blue", "32" },
                    { 4, "41.9BBY", "yellow", "male", "none", "202", "Darth Vader", 1, "white", "136" },
                    { 5, "19BBY", "brown", "female", "brown", "150", "Leia Organa", 2, "light", "49" },
                    { 6, "52BBY", "blue", "male", "brown, grey", "178", "Owen Lars", 1, "light", "120" },
                    { 7, "47BBY", "blue", "female", "brown", "165", "Beru Whitesun lars", 1, "light", "75" },
                    { 8, "unknown", "red", "n/a", "n/a", "97", "R5-D4", 1, "white, red", "32" },
                    { 9, "24BBY", "brown", "male", "black", "183", "Biggs Darklighter", 1, "light", "84" },
                    { 10, "57BBY", "blue-gray", "male", "auburn, white", "182", "Obi-Wan Kenobi", 20, "fair", "77" },
                    { 11, "41.9BBY", "blue", "male", "blond", "188", "Anakin Skywalker", 1, "fair", "84" }
                });

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "FilmeID",
                keyValue: 9,
                column: "Titulo",
                value: "Voyager's Endgame");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "FilmeID",
                keyValue: 9,
                column: "Titulo",
                value: "Voyager''s Endgame");
        }
    }
}
