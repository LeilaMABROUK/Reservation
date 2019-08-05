using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationApi.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameClient = table.Column<string>(nullable: false),
                    PrenomClient = table.Column<string>(nullable: false),
                    tel = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    IdClub = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameClub = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Tel = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Heure_Ouverture = table.Column<DateTime>(nullable: false),
                    Heure_Fermeture = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.IdClub);
                });

            migrationBuilder.CreateTable(
                name: "Terrains",
                columns: table => new
                {
                    IdTerrain = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameTerrain = table.Column<string>(nullable: false),
                    Nb_place = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    IdClub = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terrains", x => x.IdTerrain);
                    table.ForeignKey(
                        name: "FK_Terrains_Clubs_IdClub",
                        column: x => x.IdClub,
                        principalTable: "Clubs",
                        principalColumn: "IdClub",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    IdReservation = table.Column<int>(nullable: false),
                    IdClient = table.Column<int>(nullable: false),
                    IdTerrain = table.Column<int>(nullable: false),
                    NbPlace_Reserve = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => new { x.IdClient, x.IdTerrain });
                    table.UniqueConstraint("AK_Reservation_IdReservation", x => x.IdReservation);
                    table.ForeignKey(
                        name: "FK_Reservation_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Terrains_IdTerrain",
                        column: x => x.IdTerrain,
                        principalTable: "Terrains",
                        principalColumn: "IdTerrain",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdTerrain",
                table: "Reservation",
                column: "IdTerrain");

            migrationBuilder.CreateIndex(
                name: "IX_Terrains_IdClub",
                table: "Terrains",
                column: "IdClub");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Terrains");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
