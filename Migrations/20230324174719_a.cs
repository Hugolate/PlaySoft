using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlaySoftBeta.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    songID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    songName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publicationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.songID);
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

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "songID", "publicationDate", "songName" },
                values: new object[,]
                {
                    { 1, new DateTime(2015, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "pumbaPumba" },
                    { 2, new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Temardo bien de guapo" },
                    { 3, new DateTime(1015, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "AngryBirdsSongTheme" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistLines_songID",
                table: "PlaylistLines",
                column: "songID");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_userUKID",
                table: "Playlists",
                column: "userUKID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistLines");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
