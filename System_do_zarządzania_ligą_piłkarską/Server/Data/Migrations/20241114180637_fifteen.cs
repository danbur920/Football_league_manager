using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class fifteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeagueSeasonId",
                table: "MatchEvents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefereeId",
                table: "MatchEvents",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeagueSeasonId",
                table: "MatchEvents");

            migrationBuilder.DropColumn(
                name: "RefereeId",
                table: "MatchEvents");
        }
    }
}
