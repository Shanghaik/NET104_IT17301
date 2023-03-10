using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3_Asp.Net_MVC.Migrations
{
    public partial class Caythenho2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bill_UserID",
                table: "Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_UserID",
                table: "Bill",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bill_UserID",
                table: "Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_UserID",
                table: "Bill",
                column: "UserID",
                unique: true);
        }
    }
}
