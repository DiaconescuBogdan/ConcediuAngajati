using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConcediuAngajati.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Angajati",
                columns: table => new
                {
                    AngajatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true),
                    Prenume = table.Column<string>(nullable: true),
                    DataNastere = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajati", x => x.AngajatId);
                });

            migrationBuilder.CreateTable(
                name: "Concedii",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipConcediu = table.Column<string>(nullable: true),
                    NrZile = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concedii", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Functii",
                columns: table => new
                {
                    FunctieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipFunctie = table.Column<string>(nullable: true),
                    Descriere = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functii", x => x.FunctieId);
                });

            migrationBuilder.CreateTable(
                name: "CereriConcediu",
                columns: table => new
                {
                    CerereId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descriere = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    AngajatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CereriConcediu", x => x.CerereId);
                    table.ForeignKey(
                        name: "FK_CereriConcediu_Angajati_AngajatId",
                        column: x => x.AngajatId,
                        principalTable: "Angajati",
                        principalColumn: "AngajatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AngajatiConcedii",
                columns: table => new
                {
                    AngajatConcediuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AngajatId = table.Column<int>(nullable: false),
                    ConcediuId = table.Column<int>(nullable: false),
                    ZileConcediuDisponibile = table.Column<int>(nullable: false),
                    ZileConcediuUtilizate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AngajatiConcedii", x => x.AngajatConcediuId);
                    table.ForeignKey(
                        name: "FK_AngajatiConcedii_Angajati_AngajatId",
                        column: x => x.AngajatId,
                        principalTable: "Angajati",
                        principalColumn: "AngajatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AngajatiConcedii_Concedii_ConcediuId",
                        column: x => x.ConcediuId,
                        principalTable: "Concedii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AngajatiFunctii",
                columns: table => new
                {
                    AngajatFunctieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AngajatId = table.Column<int>(nullable: false),
                    FunctieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AngajatiFunctii", x => x.AngajatFunctieId);
                    table.ForeignKey(
                        name: "FK_AngajatiFunctii_Angajati_AngajatId",
                        column: x => x.AngajatId,
                        principalTable: "Angajati",
                        principalColumn: "AngajatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AngajatiFunctii_Functii_FunctieId",
                        column: x => x.FunctieId,
                        principalTable: "Functii",
                        principalColumn: "FunctieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AngajatiConcedii_AngajatId",
                table: "AngajatiConcedii",
                column: "AngajatId");

            migrationBuilder.CreateIndex(
                name: "IX_AngajatiConcedii_ConcediuId",
                table: "AngajatiConcedii",
                column: "ConcediuId");

            migrationBuilder.CreateIndex(
                name: "IX_AngajatiFunctii_AngajatId",
                table: "AngajatiFunctii",
                column: "AngajatId");

            migrationBuilder.CreateIndex(
                name: "IX_AngajatiFunctii_FunctieId",
                table: "AngajatiFunctii",
                column: "FunctieId");

            migrationBuilder.CreateIndex(
                name: "IX_CereriConcediu_AngajatId",
                table: "CereriConcediu",
                column: "AngajatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AngajatiConcedii");

            migrationBuilder.DropTable(
                name: "AngajatiFunctii");

            migrationBuilder.DropTable(
                name: "CereriConcediu");

            migrationBuilder.DropTable(
                name: "Concedii");

            migrationBuilder.DropTable(
                name: "Functii");

            migrationBuilder.DropTable(
                name: "Angajati");
        }
    }
}
