using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiBooks_DataAccess.Migrations
{
    public partial class mdfNickname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyNickName",
                table: "AspNetUsers",
                newName: "NickName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "AspNetUsers",
                newName: "MyNickName");
        }
    }
}
