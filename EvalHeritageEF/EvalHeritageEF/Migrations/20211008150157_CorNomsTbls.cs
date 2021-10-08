using Microsoft.EntityFrameworkCore.Migrations;

namespace EvalHeritageEF.Migrations
{
    public partial class CorNomsTbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Voiture",
                table: "Voiture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bateau",
                table: "Bateau");

            migrationBuilder.RenameTable(
                name: "Voiture",
                newName: "VoitureA");

            migrationBuilder.RenameTable(
                name: "Bateau",
                newName: "BateauA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoitureA",
                table: "VoitureA",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BateauA",
                table: "BateauA",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VoitureA",
                table: "VoitureA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BateauA",
                table: "BateauA");

            migrationBuilder.RenameTable(
                name: "VoitureA",
                newName: "Voiture");

            migrationBuilder.RenameTable(
                name: "BateauA",
                newName: "Bateau");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voiture",
                table: "Voiture",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bateau",
                table: "Bateau",
                column: "Id");
        }
    }
}
