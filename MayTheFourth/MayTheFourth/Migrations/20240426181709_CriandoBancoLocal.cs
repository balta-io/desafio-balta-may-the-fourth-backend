using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MayTheFourth.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBancoLocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "NVARCHAR", maxLength: 100, nullable: false),
                    Episodio = table.Column<int>(type: "NVARCHAR", maxLength: 100, nullable: false),
                    Diretor = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Produtor = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "NVARCHAR", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NavesEstelares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Modelo = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    Fabricante = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    Custo = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    Comprimento = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    VelocidadeMaxima = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    Tripulacao = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    Passageiros = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    CapacidadeCarga = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    ClassificacaoHiperdrive = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    Mglt = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    Consumiveis = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    Classe = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavesEstelares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    PeriodoRotacao = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    PeriodoOrbital = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Diametro = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Clima = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Gravidade = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Terreno = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    SuperficieAquatica = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Populacao = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planeta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Modelo = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Fabricante = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Custo = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Comprimento = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    VelocidadeMaxima = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Tripulacao = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Passageiros = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    CapacidadeCarga = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Consumiveis = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Classe = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NavesEstelaresFilme",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "INTEGER", nullable: false),
                    NavesEstelaresId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavesEstelaresFilme", x => new { x.FilmeId, x.NavesEstelaresId });
                    table.ForeignKey(
                        name: "FK_FilmeNavesEstelaresId_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NavesEstelares_NavesEstelaresId",
                        column: x => x.NavesEstelaresId,
                        principalTable: "NavesEstelares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemNavesEstelares",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "INTEGER", nullable: false),
                    NavesEstelaresId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemNavesEstelares", x => new { x.FilmeId, x.NavesEstelaresId });
                    table.ForeignKey(
                        name: "FK_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NavesEstelaresFilme_NavesEstelaresId",
                        column: x => x.NavesEstelaresId,
                        principalTable: "NavesEstelares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "NVARCHAR", maxLength: 100, nullable: false),
                    Altura = table.Column<string>(type: "NVARCHAR", maxLength: 100, nullable: false),
                    Peso = table.Column<string>(type: "NVARCHAR", maxLength: 100, nullable: false),
                    CorCabelo = table.Column<string>(type: "NVARCHAR", maxLength: 100, nullable: false),
                    CorPele = table.Column<string>(type: "NVARCHAR", maxLength: 100, nullable: false),
                    CorOlhos = table.Column<string>(type: "NVARCHAR", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "NVARCHAR", maxLength: 60, nullable: false),
                    Genero = table.Column<string>(type: "NVARCHAR", maxLength: 100, nullable: false),
                    PlanetaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planeta_Personagem",
                        column: x => x.PlanetaId,
                        principalTable: "Planeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanetaFilme",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanetaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetaFilme", x => new { x.FilmeId, x.PlanetaId });
                    table.ForeignKey(
                        name: "FK_FilmePlaneta_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planeta_PlanetaId",
                        column: x => x.PlanetaId,
                        principalTable: "Planeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmePlaneta",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanetaId = table.Column<int>(type: "INTEGER", nullable: false),
                    VeiculoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmePlaneta", x => new { x.FilmeId, x.PlanetaId });
                    table.ForeignKey(
                        name: "FK_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanetaFilme_PlanetaId",
                        column: x => x.PlanetaId,
                        principalTable: "Planeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeiculoFilme_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VeiculoFilme",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "INTEGER", nullable: false),
                    VeiculoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoFilme", x => new { x.FilmeId, x.VeiculoId });
                    table.ForeignKey(
                        name: "FK_FilmeVeiculo_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmePersonagem",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonagemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmePersonagem", x => new { x.FilmeId, x.PersonagemId });
                    table.ForeignKey(
                        name: "FK_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemFilme_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemFilme",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonagemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemFilme", x => new { x.FilmeId, x.PersonagemId });
                    table.ForeignKey(
                        name: "FK_FilmePersonagem_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personagem_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmePersonagem_PersonagemId",
                table: "FilmePersonagem",
                column: "PersonagemId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmePlaneta_PlanetaId",
                table: "FilmePlaneta",
                column: "PlanetaId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmePlaneta_VeiculoId",
                table: "FilmePlaneta",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_NavesEstelaresFilme_NavesEstelaresId",
                table: "NavesEstelaresFilme",
                column: "NavesEstelaresId");

            migrationBuilder.CreateIndex(
                name: "IX_Personagem_PlanetaId",
                table: "Personagem",
                column: "PlanetaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemFilme_PersonagemId",
                table: "PersonagemFilme",
                column: "PersonagemId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemNavesEstelares_NavesEstelaresId",
                table: "PersonagemNavesEstelares",
                column: "NavesEstelaresId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanetaFilme_PlanetaId",
                table: "PlanetaFilme",
                column: "PlanetaId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoFilme_VeiculoId",
                table: "VeiculoFilme",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmePersonagem");

            migrationBuilder.DropTable(
                name: "FilmePlaneta");

            migrationBuilder.DropTable(
                name: "NavesEstelaresFilme");

            migrationBuilder.DropTable(
                name: "PersonagemFilme");

            migrationBuilder.DropTable(
                name: "PersonagemNavesEstelares");

            migrationBuilder.DropTable(
                name: "PlanetaFilme");

            migrationBuilder.DropTable(
                name: "VeiculoFilme");

            migrationBuilder.DropTable(
                name: "Personagem");

            migrationBuilder.DropTable(
                name: "NavesEstelares");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Planeta");
        }
    }
}
