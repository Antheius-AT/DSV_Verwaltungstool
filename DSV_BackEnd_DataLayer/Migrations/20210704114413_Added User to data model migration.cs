using Microsoft.EntityFrameworkCore.Migrations;

namespace DSV_BackEnd_DataLayer.Migrations
{
    public partial class AddedUsertodatamodelmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Images_ImageName",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Images_ImageName",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ImageName",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ImageName",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ImageName",
                table: "Books",
                column: "ImageName");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageName",
                table: "Articles",
                column: "ImageName");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Images_ImageName",
                table: "Articles",
                column: "ImageName",
                principalTable: "Images",
                principalColumn: "ImageName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Images_ImageName",
                table: "Books",
                column: "ImageName",
                principalTable: "Images",
                principalColumn: "ImageName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
