using Microsoft.EntityFrameworkCore.Migrations;

namespace DSV_BackEnd_DataLayer.Migrations
{
    public partial class Addedimagemodelmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Base64EncodedImageData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleAssetID = table.Column<int>(type: "int", nullable: true),
                    BookAssetID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageName);
                    table.ForeignKey(
                        name: "FK_Images_Articles_ArticleAssetID",
                        column: x => x.ArticleAssetID,
                        principalTable: "Articles",
                        principalColumn: "AssetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_Books_BookAssetID",
                        column: x => x.BookAssetID,
                        principalTable: "Books",
                        principalColumn: "AssetID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ArticleAssetID",
                table: "Images",
                column: "ArticleAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_BookAssetID",
                table: "Images",
                column: "BookAssetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
