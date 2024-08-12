using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class seventh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayTeamId",
                table: "MatchEvent");

            migrationBuilder.RenameColumn(
                name: "HomeTeamId",
                table: "MatchEvent",
                newName: "TeamId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MatchEvent",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MatchEvent");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "MatchEvent",
                newName: "HomeTeamId");

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamId",
                table: "MatchEvent",
                type: "int",
                nullable: true);
        }
    }
}
