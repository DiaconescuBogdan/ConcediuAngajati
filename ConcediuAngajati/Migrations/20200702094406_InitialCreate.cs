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
                    Nume = table.Column<string>(nullable: false),
                    Prenume = table.Column<string>(nullable: false),
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
                    TipConcediu = table.Column<string>(nullable: false),
                    NrZile = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concedii", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusCereri",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: false),
                    Descriere = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCereri", x => x.StatusId);
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
                name: "CereriConcediu",
                columns: table => new
                {
                    CerereId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descriere = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StatusCerereStatusId = table.Column<int>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_CereriConcediu_StatusCereri_StatusCerereStatusId",
                        column: x => x.StatusCerereStatusId,
                        principalTable: "StatusCereri",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_CereriConcediu_AngajatId",
                table: "CereriConcediu",
                column: "AngajatId");

            migrationBuilder.CreateIndex(
                name: "IX_CereriConcediu_StatusCerereStatusId",
                table: "CereriConcediu",
                column: "StatusCerereStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AngajatiConcedii");

            migrationBuilder.DropTable(
                name: "CereriConcediu");

            migrationBuilder.DropTable(
                name: "Concedii");

            migrationBuilder.DropTable(
                name: "Angajati");

            migrationBuilder.DropTable(
                name: "StatusCereri");
        }
    }
}
