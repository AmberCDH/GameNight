using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avondspel.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bordspellen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genre = table.Column<int>(type: "int", nullable: false),
                    foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    soortSpel = table.Column<int>(type: "int", nullable: false),
                    GebruikerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AchtienPlus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bordspellen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BordspellenAvond",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Planning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GebruikerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Straat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Huisnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AantalSpelers = table.Column<int>(type: "int", nullable: false),
                    AchtienPlus = table.Column<bool>(type: "bit", nullable: false),
                    PotLuck = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BordspellenAvond", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BordspellenLijst",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BordspelId = table.Column<int>(type: "int", nullable: false),
                    SpelAvondId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BordspellenLijst", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lactose = table.Column<bool>(type: "bit", nullable: false),
                    Notenallergie = table.Column<bool>(type: "bit", nullable: false),
                    Vega = table.Column<bool>(type: "bit", nullable: false),
                    Alcohol = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gebruiker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lactose = table.Column<bool>(type: "bit", nullable: false),
                    Notenallergie = table.Column<bool>(type: "bit", nullable: false),
                    Vega = table.Column<bool>(type: "bit", nullable: false),
                    Alcohol = table.Column<bool>(type: "bit", nullable: false),
                    OuderDanAchtien = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BordspellenAvondEten",
                columns: table => new
                {
                    BordspellenAvondenId = table.Column<int>(type: "int", nullable: false),
                    EtenLijstId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BordspellenAvondEten", x => new { x.BordspellenAvondenId, x.EtenLijstId });
                    table.ForeignKey(
                        name: "FK_BordspellenAvondEten_BordspellenAvond_BordspellenAvondenId",
                        column: x => x.BordspellenAvondenId,
                        principalTable: "BordspellenAvond",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BordspellenAvondEten_Eten_EtenLijstId",
                        column: x => x.EtenLijstId,
                        principalTable: "Eten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BordspellenAvondGebruiker",
                columns: table => new
                {
                    BordspellenAvondenId = table.Column<int>(type: "int", nullable: false),
                    GebruikersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BordspellenAvondGebruiker", x => new { x.BordspellenAvondenId, x.GebruikersId });
                    table.ForeignKey(
                        name: "FK_BordspellenAvondGebruiker_BordspellenAvond_BordspellenAvondenId",
                        column: x => x.BordspellenAvondenId,
                        principalTable: "BordspellenAvond",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BordspellenAvondGebruiker_Gebruiker_GebruikersId",
                        column: x => x.GebruikersId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BordspellenAvondEten_EtenLijstId",
                table: "BordspellenAvondEten",
                column: "EtenLijstId");

            migrationBuilder.CreateIndex(
                name: "IX_BordspellenAvondGebruiker_GebruikersId",
                table: "BordspellenAvondGebruiker",
                column: "GebruikersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bordspellen");

            migrationBuilder.DropTable(
                name: "BordspellenAvondEten");

            migrationBuilder.DropTable(
                name: "BordspellenAvondGebruiker");

            migrationBuilder.DropTable(
                name: "BordspellenLijst");

            migrationBuilder.DropTable(
                name: "Eten");

            migrationBuilder.DropTable(
                name: "BordspellenAvond");

            migrationBuilder.DropTable(
                name: "Gebruiker");
        }
    }
}
