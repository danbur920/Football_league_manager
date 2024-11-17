using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class eighteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AwayTeamRedCards",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamYellowCards",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamRedCards",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamYellowCards",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayTeamRedCards",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AwayTeamYellowCards",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeamRedCards",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeamYellowCards",
                table: "Matches");
        }
    }
}
