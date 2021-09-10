using Microsoft.EntityFrameworkCore.Migrations;

namespace DSV_BackEnd_DataLayer.Migrations
{
    public partial class AddedImageDataDirectlyToAssetMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Books",
                newName: "ImageDataBase64Encoded");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Articles",
                newName: "ImageDataBase64Encoded");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageDataBase64Encoded",
                table: "Books",
                newName: "ImageName");

            migrationBuilder.RenameColumn(
                name: "ImageDataBase64Encoded",
                table: "Articles",
                newName: "ImageName");
        }
    }
}
