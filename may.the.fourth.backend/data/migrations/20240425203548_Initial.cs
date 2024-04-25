using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace may.the.fourth.backend.data.migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Episode = table.Column<int>(type: "INT", nullable: true),
                    OpeningCrawl = table.Column<string>(type: "TEXT", nullable: true),
                    Director = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    Producer = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Model = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Manufacturer = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    CostInCredits = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Length = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    MaxSpeed = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Crew = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Passengers = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CargoCapacity = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    HyperdriveRating = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Mglt = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Consumables = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Class = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Episode", "OpeningCrawl", "Producer", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "George Lucas", 4, "", "Gary Kurtz, Rick McCallum", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "A New Hope" },
                    { 2, "Irvin Kershner", 5, "", "Gary Kurtz, Rick McCallum", new DateTime(1980, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Empire Strikes Back" },
                    { 3, "Richard Marquand", 6, "", "Howard G. Kazanjian, George Lucas, Rick McCallum", new DateTime(1983, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Return of the Jedi" },
                    { 4, "George Lucas", 1, "", "Rick McCallum", new DateTime(1999, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Phantom Menace" },
                    { 5, "George Lucas", 2, "", "Rick McCallum", new DateTime(2002, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Attack of the Clones" },
                    { 6, "George Lucas", 3, "", "Rick McCallum", new DateTime(2005, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Revenge of the Sith" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Starships");
        }
    }
}
