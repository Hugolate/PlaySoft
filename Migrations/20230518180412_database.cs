using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaySoftBeta.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    albumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spotifyAlbumID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    albumName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalTracks = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    releaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.albumID);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    artistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spotifyArtistID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    artistName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.artistID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UKID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UKID);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    songID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spotifySongID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    songName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    durationMs = table.Column<int>(type: "int", nullable: false),
                    publicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.songID);
                    table.ForeignKey(
                        name: "FK_Songs_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "albumID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistAlbums",
                columns: table => new
                {
                    albumID = table.Column<int>(type: "int", nullable: false),
                    artistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistAlbums", x => new { x.albumID, x.artistID });
                    table.ForeignKey(
                        name: "FK_ArtistAlbums_Album_albumID",
                        column: x => x.albumID,
                        principalTable: "Album",
                        principalColumn: "albumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistAlbums_Artist_artistID",
                        column: x => x.artistID,
                        principalTable: "Artist",
                        principalColumn: "artistID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    playlistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playListName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    playlistDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    privacity = table.Column<bool>(type: "bit", nullable: false),
                    userUKID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.playlistID);
                    table.ForeignKey(
                        name: "FK_Playlists_Users_userUKID",
                        column: x => x.userUKID,
                        principalTable: "Users",
                        principalColumn: "UKID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSongs",
                columns: table => new
                {
                    artistID = table.Column<int>(type: "int", nullable: false),
                    songID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSongs", x => new { x.songID, x.artistID });
                    table.ForeignKey(
                        name: "FK_ArtistSongs_Artist_artistID",
                        column: x => x.artistID,
                        principalTable: "Artist",
                        principalColumn: "artistID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSongs_Songs_songID",
                        column: x => x.songID,
                        principalTable: "Songs",
                        principalColumn: "songID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistLines",
                columns: table => new
                {
                    playlistID = table.Column<int>(type: "int", nullable: false),
                    songID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistLines", x => new { x.playlistID, x.songID });
                    table.ForeignKey(
                        name: "FK_PlaylistLines_Playlists_playlistID",
                        column: x => x.playlistID,
                        principalTable: "Playlists",
                        principalColumn: "playlistID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistLines_Songs_songID",
                        column: x => x.songID,
                        principalTable: "Songs",
                        principalColumn: "songID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistAlbums_artistID",
                table: "ArtistAlbums",
                column: "artistID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSongs_artistID",
                table: "ArtistSongs",
                column: "artistID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistLines_songID",
                table: "PlaylistLines",
                column: "songID");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_userUKID",
                table: "Playlists",
                column: "userUKID");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumID",
                table: "Songs",
                column: "AlbumID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistAlbums");

            migrationBuilder.DropTable(
                name: "ArtistSongs");

            migrationBuilder.DropTable(
                name: "PlaylistLines");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Album");
        }
    }
}
