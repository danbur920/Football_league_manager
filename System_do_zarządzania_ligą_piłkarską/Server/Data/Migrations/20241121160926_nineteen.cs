using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class nineteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchFootballers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    FootballerId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    LeagueSeasonId = table.Column<int>(type: "int", nullable: false),
                    IsStartingPlayer = table.Column<bool>(type: "bit", nullable: false),
                    IsSubstitutePlayer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchFootballers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchFootballers_Footballers_FootballerId",
                        column: x => x.FootballerId,
                        principalTable: "Footballers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchFootballers_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchFootballers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchFootballers_FootballerId",
                table: "MatchFootballers",
                column: "FootballerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchFootballers_MatchId",
                table: "MatchFootballers",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchFootballers_TeamId",
                table: "MatchFootballers",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchFootballers");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Teams");
        }
    }
}
