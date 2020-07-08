using Microsoft.EntityFrameworkCore.Migrations;

namespace ConcediuAngajati.Migrations
{
    public partial class ActualizareCerereConcediu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipConcediu",
                table: "CereriConcediu",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipConcediu",
                table: "CereriConcediu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
