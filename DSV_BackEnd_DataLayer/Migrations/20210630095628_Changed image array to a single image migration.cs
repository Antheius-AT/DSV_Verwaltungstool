using Microsoft.EntityFrameworkCore.Migrations;

namespace DSV_BackEnd_DataLayer.Migrations
{
    public partial class Changedimagearraytoasingleimagemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Articles_ArticleAssetID",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Books_BookAssetID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ArticleAssetID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_BookAssetID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ArticleAssetID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "BookAssetID",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "ArticleAssetID",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookAssetID",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ArticleAssetID",
                table: "Images",
                column: "ArticleAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_BookAssetID",
                table: "Images",
                column: "BookAssetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Articles_ArticleAssetID",
                table: "Images",
                column: "ArticleAssetID",
                principalTable: "Articles",
                principalColumn: "AssetID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Books_BookAssetID",
                table: "Images",
                column: "BookAssetID",
                principalTable: "Books",
                principalColumn: "AssetID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
