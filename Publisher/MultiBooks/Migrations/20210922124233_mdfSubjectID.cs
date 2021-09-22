using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiBooks.Migrations
{
    public partial class mdfSubjectID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Subject_SubjectId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_SubjectId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Book");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Book",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "Subject_Id",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_Subject_Id",
                table: "Book",
                column: "Subject_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Subject_Subject_Id",
                table: "Book",
                column: "Subject_Id",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Subject_Subject_Id",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_Subject_Id",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Subject_Id",
                table: "Book");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Book",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_SubjectId",
                table: "Book",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Subject_SubjectId",
                table: "Book",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
