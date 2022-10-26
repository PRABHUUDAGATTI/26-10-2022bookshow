using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Show_DAL.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgPoster = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "userDetails",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhoneNo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userDetails", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "theater",
                columns: table => new
                {
                    TheatreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theater", x => x.TheatreId);
                    table.ForeignKey(
                        name: "FK_theater_location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "showTiming",
                columns: table => new
                {
                    ShowTimingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TheatreId = table.Column<int>(type: "int", nullable: false),
                    ShowTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_showTiming", x => x.ShowTimingId);
                    table.ForeignKey(
                        name: "FK_showTiming_movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_showTiming_theater_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "theater",
                        principalColumn: "TheatreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookShow",
                columns: table => new
                {
                    BookShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowTimingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NoOfTickets = table.Column<int>(type: "int", nullable: false),
                    TicketCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookShow", x => x.BookShowId);
                    table.ForeignKey(
                        name: "FK_bookShow_showTiming_ShowTimingId",
                        column: x => x.ShowTimingId,
                        principalTable: "showTiming",
                        principalColumn: "ShowTimingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookShow_userDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "userDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookShow_ShowTimingId",
                table: "bookShow",
                column: "ShowTimingId");

            migrationBuilder.CreateIndex(
                name: "IX_bookShow_UserId",
                table: "bookShow",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_showTiming_MovieId",
                table: "showTiming",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_showTiming_TheatreId",
                table: "showTiming",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_theater_LocationId",
                table: "theater",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookShow");

            migrationBuilder.DropTable(
                name: "showTiming");

            migrationBuilder.DropTable(
                name: "userDetails");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "theater");

            migrationBuilder.DropTable(
                name: "location");
        }
    }
}
