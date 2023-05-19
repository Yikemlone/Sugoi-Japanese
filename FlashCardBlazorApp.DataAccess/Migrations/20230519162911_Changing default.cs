using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCardBlazorApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Changingdefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserFlashCardOptions_UserFlashCardOptionsID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserFlashCardOptionsID",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserFlashCardOptions_UserFlashCardOptionsID",
                table: "AspNetUsers",
                column: "UserFlashCardOptionsID",
                principalTable: "UserFlashCardOptions",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserFlashCardOptions_UserFlashCardOptionsID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserFlashCardOptionsID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserFlashCardOptions_UserFlashCardOptionsID",
                table: "AspNetUsers",
                column: "UserFlashCardOptionsID",
                principalTable: "UserFlashCardOptions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
