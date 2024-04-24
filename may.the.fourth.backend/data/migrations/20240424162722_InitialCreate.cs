using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace may.the.fourth.backend.data.migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    FilmeID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Episodio = table.Column<int>(type: "INT", nullable: true),
                    TextoAbertura = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    Diretor = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    Produtor = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.FilmeID);
                });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "FilmeID", "DataLancamento", "Diretor", "Episodio", "Produtor", "TextoAbertura", "Titulo" },
                values: new object[,]
                {
                    { 1, new DateTime(2028, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jana Doe", 10, "Leo Smith", "After the fall of the Empire, the galaxy face", "The Rise of the Jedi" },
                    { 2, null, null, null, null, null, "The Battle of the Stars" },
                    { 3, null, null, null, null, null, "Return of the Light" },
                    { 4, null, null, null, null, null, "Warriors of the Shadow Realm" },
                    { 5, null, null, null, null, null, "The Galactic Quest" },
                    { 6, null, null, null, null, null, "Rise of the Planetara" },
                    { 7, null, null, null, null, null, "Echoes of the Stars" },
                    { 8, null, null, null, null, null, "The Return of the Voyager" },
                    { 9, null, null, null, null, null, "Voyager''s Endgame" },
                    { 10, null, null, null, null, null, "Galactic Odyssey" },
                    { 11, null, null, null, null, null, "The Edge of the Universe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
