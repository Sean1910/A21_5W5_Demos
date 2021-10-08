using Microsoft.EntityFrameworkCore.Migrations;

namespace EvalHeritageEF.Migrations
{
    public partial class ExempleC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehiculeC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicencePlate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculeC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BateauC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NbrVoile = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BateauC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BateauC_VehiculeC_Id",
                        column: x => x.Id,
                        principalTable: "VehiculeC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VoitureC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Couleur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbrPassagers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoitureC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoitureC_VehiculeC_Id",
                        column: x => x.Id,
                        principalTable: "VehiculeC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BateauC");

            migrationBuilder.DropTable(
                name: "VoitureC");

            migrationBuilder.DropTable(
                name: "VehiculeC");
        }
    }
}
