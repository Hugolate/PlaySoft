using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaySoftBeta.Migrations
{
    /// <inheritdoc />
    public partial class database1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumLines_Artist_artistID",
                table: "AlbumLines");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumLines_Songs_songID",
                table: "AlbumLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlbumLines",
                table: "AlbumLines");

            migrationBuilder.RenameTable(
                name: "AlbumLines",
                newName: "ArtistSongs");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumLines_artistID",
                table: "ArtistSongs",
                newName: "IX_ArtistSongs_artistID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistSongs",
                table: "ArtistSongs",
                columns: new[] { "songID", "artistID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSongs_Artist_artistID",
                table: "ArtistSongs",
                column: "artistID",
                principalTable: "Artist",
                principalColumn: "artistID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSongs_Songs_songID",
                table: "ArtistSongs",
                column: "songID",
                principalTable: "Songs",
                principalColumn: "songID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSongs_Artist_artistID",
                table: "ArtistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSongs_Songs_songID",
                table: "ArtistSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistSongs",
                table: "ArtistSongs");

            migrationBuilder.RenameTable(
                name: "ArtistSongs",
                newName: "AlbumLines");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistSongs_artistID",
                table: "AlbumLines",
                newName: "IX_AlbumLines_artistID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlbumLines",
                table: "AlbumLines",
                columns: new[] { "songID", "artistID" });

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumLines_Artist_artistID",
                table: "AlbumLines",
                column: "artistID",
                principalTable: "Artist",
                principalColumn: "artistID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumLines_Songs_songID",
                table: "AlbumLines",
                column: "songID",
                principalTable: "Songs",
                principalColumn: "songID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
