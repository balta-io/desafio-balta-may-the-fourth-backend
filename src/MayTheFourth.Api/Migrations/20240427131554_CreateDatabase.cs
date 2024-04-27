using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MayTheFourth.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpisodeId = table.Column<int>(type: "INT", nullable: false),
                    OpeningCrawl = table.Column<string>(type: "NVARCHAR(1500)", maxLength: 1500, nullable: false),
                    Director = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    Producer = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Url = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Edited = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diameter = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    RotationPeriod = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    OrbitalPeriod = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Gravity = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Population = table.Column<string>(type: "NVARCHAR(15)", maxLength: 15, nullable: false),
                    Climate = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    Terrain = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    SurfaceWater = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Edited = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    StarshipClass = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Manufacturer = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    CostInCredits = table.Column<int>(type: "INT", nullable: false),
                    Length = table.Column<decimal>(type: "DECIMAL(38,17)", nullable: false),
                    Crew = table.Column<int>(type: "INT", nullable: false),
                    Passengers = table.Column<int>(type: "INT", nullable: false),
                    MaxAtmospheringSpeed = table.Column<int>(type: "INT", nullable: false),
                    HyperdriveRating = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    MGLT = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    CargoCapacity = table.Column<int>(type: "INT", nullable: false),
                    Consumables = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "NVARChAR(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Edited = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    NVARCHAR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Manufacturer = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    Length = table.Column<int>(type: "INT", nullable: false),
                    CostInCredits = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    Crew = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Passengers = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    MaxAtmospheringSpeed = table.Column<int>(type: "INT", nullable: false),
                    CargoCapacity = table.Column<int>(type: "INT", nullable: false),
                    Consumables = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Edited = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmPlanet",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmPlanet = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmPlanet", x => new { x.FilmId, x.FilmPlanet });
                    table.ForeignKey(
                        name: "FK_FilmPlanet_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmPlanet_Planets_FilmPlanet",
                        column: x => x.FilmPlanet,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthYear = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false),
                    EyeColor = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    HairColor = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Height = table.Column<int>(type: "INT", nullable: false),
                    Mass = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false),
                    SkinColor = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Url = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Edited = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    HomeworldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Planets_HomeworldId",
                        column: x => x.HomeworldId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Designation = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    AverageHeight = table.Column<int>(type: "INT", nullable: false),
                    AverageLifespan = table.Column<int>(type: "INT", nullable: false),
                    EyeColors = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    HairColors = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    SkinColors = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Language = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Edited = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    HomeworldId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_Planets_HomeworldId",
                        column: x => x.HomeworldId,
                        principalTable: "Planets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilmStarship",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StarshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmStarship", x => new { x.FilmId, x.StarshipId });
                    table.ForeignKey(
                        name: "FK_FilmStarship_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmStarship_Starships_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmVehicle",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmVehicle", x => new { x.FilmId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_FilmVehicle_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmVehicle_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmCharacter",
                columns: table => new
                {
                    FilmCharacter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCharacter", x => new { x.FilmCharacter, x.FilmId });
                    table.ForeignKey(
                        name: "FK_FilmCharacter_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmCharacter_Person_FilmCharacter",
                        column: x => x.FilmCharacter,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonStarship",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StarshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonStarship", x => new { x.PersonId, x.StarshipId });
                    table.ForeignKey(
                        name: "FK_PersonStarship_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonStarship_Starships_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonVehicle",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonVehicle", x => new { x.PersonId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_PersonVehicle_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonVehicle_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmSpecies",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpeciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmSpecies", x => new { x.FilmId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_FilmSpecies_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonSpecies",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpeciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSpecies", x => new { x.PersonId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_PersonSpecies_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmCharacter_FilmId",
                table: "FilmCharacter",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmPlanet_FilmPlanet",
                table: "FilmPlanet",
                column: "FilmPlanet");

            migrationBuilder.CreateIndex(
                name: "IX_FilmSpecies_SpeciesId",
                table: "FilmSpecies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmStarship_StarshipId",
                table: "FilmStarship",
                column: "StarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmVehicle_VehicleId",
                table: "FilmVehicle",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_HomeworldId",
                table: "Person",
                column: "HomeworldId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSpecies_SpeciesId",
                table: "PersonSpecies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonStarship_StarshipId",
                table: "PersonStarship",
                column: "StarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonVehicle_VehicleId",
                table: "PersonVehicle",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_HomeworldId",
                table: "Species",
                column: "HomeworldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmCharacter");

            migrationBuilder.DropTable(
                name: "FilmPlanet");

            migrationBuilder.DropTable(
                name: "FilmSpecies");

            migrationBuilder.DropTable(
                name: "FilmStarship");

            migrationBuilder.DropTable(
                name: "FilmVehicle");

            migrationBuilder.DropTable(
                name: "PersonSpecies");

            migrationBuilder.DropTable(
                name: "PersonStarship");

            migrationBuilder.DropTable(
                name: "PersonVehicle");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Starships");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
