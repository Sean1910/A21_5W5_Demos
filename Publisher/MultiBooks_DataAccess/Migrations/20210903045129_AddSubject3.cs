using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiBooks_DataAccess.Migrations
{
    public partial class AddSubject3 : Migration
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
