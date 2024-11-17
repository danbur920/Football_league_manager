using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class seventeen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoulsCalled",
                table: "RefereeStats");

            migrationBuilder.AddColumn<int>(
                name: "TotalPenaltiesAwarded",
                table: "Referees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalRedCardsGiven",
                table: "Referees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalRefereedMatches",
                table: "Referees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalYellowCardsGiven",
                table: "Referees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamSubstitutions",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamSubstitutions",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartingAppearances",
                table: "FootballerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubstituteAppearances",
                table: "FootballerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPenaltiesAwarded",
                table: "Referees");

            migrationBuilder.DropColumn(
                name: "TotalRedCardsGiven",
                table: "Referees");

            migrationBuilder.DropColumn(
                name: "TotalRefereedMatches",
                table: "Referees");

            migrationBuilder.DropColumn(
                name: "TotalYellowCardsGiven",
                table: "Referees");

            migrationBuilder.DropColumn(
                name: "AwayTeamSubstitutions",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeamSubstitutions",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "StartingAppearances",
                table: "FootballerStats");

            migrationBuilder.DropColumn(
                name: "SubstituteAppearances",
                table: "FootballerStats");

            migrationBuilder.AddColumn<int>(
                name: "FoulsCalled",
                table: "RefereeStats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
