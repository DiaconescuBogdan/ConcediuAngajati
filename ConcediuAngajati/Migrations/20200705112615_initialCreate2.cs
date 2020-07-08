using Microsoft.EntityFrameworkCore.Migrations;

namespace ConcediuAngajati.Migrations
{
    public partial class initialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CereriConcediu_Angajati_AngajatId",
                table: "CereriConcediu");

            migrationBuilder.DropForeignKey(
                name: "FK_CereriConcediu_StatusCereri_StatusCerereStatusId",
                table: "CereriConcediu");

            migrationBuilder.DropIndex(
                name: "IX_CereriConcediu_StatusCerereStatusId",
                table: "CereriConcediu");

            migrationBuilder.DropColumn(
                name: "StatusCerereStatusId",
                table: "CereriConcediu");

            migrationBuilder.AlterColumn<int>(
                name: "AngajatId",
                table: "CereriConcediu",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusCerereId",
                table: "CereriConcediu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CereriConcediu_StatusCerereId",
                table: "CereriConcediu",
                column: "StatusCerereId");

            migrationBuilder.AddForeignKey(
                name: "FK_CereriConcediu_Angajati_AngajatId",
                table: "CereriConcediu",
                column: "AngajatId",
                principalTable: "Angajati",
                principalColumn: "AngajatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CereriConcediu_StatusCereri_StatusCerereId",
                table: "CereriConcediu",
                column: "StatusCerereId",
                principalTable: "StatusCereri",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CereriConcediu_Angajati_AngajatId",
                table: "CereriConcediu");

            migrationBuilder.DropForeignKey(
                name: "FK_CereriConcediu_StatusCereri_StatusCerereId",
                table: "CereriConcediu");

            migrationBuilder.DropIndex(
                name: "IX_CereriConcediu_StatusCerereId",
                table: "CereriConcediu");

            migrationBuilder.DropColumn(
                name: "StatusCerereId",
                table: "CereriConcediu");

            migrationBuilder.AlterColumn<int>(
                name: "AngajatId",
                table: "CereriConcediu",
                type: "int",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StatusCerereStatusId",
                table: "CereriConcediu",
                type: "int",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_CereriConcediu_StatusCerereStatusId",
                table: "CereriConcediu",
                column: "StatusCerereStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CereriConcediu_Angajati_AngajatId",
                table: "CereriConcediu",
                column: "AngajatId",
                principalTable: "Angajati",
                principalColumn: "AngajatId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CereriConcediu_StatusCereri_StatusCerereStatusId",
                table: "CereriConcediu",
                column: "StatusCerereStatusId",
                principalTable: "StatusCereri",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
