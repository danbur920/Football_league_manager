using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamStatId",
                table: "FootballerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FootballerStats_TeamStatId",
                table: "FootballerStats",
                column: "TeamStatId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerStats_TeamStats_TeamStatId",
                table: "FootballerStats",
                column: "TeamStatId",
                principalTable: "TeamStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballerStats_TeamStats_TeamStatId",
                table: "FootballerStats");

            migrationBuilder.DropIndex(
                name: "IX_FootballerStats_TeamStatId",
                table: "FootballerStats");

            migrationBuilder.DropColumn(
                name: "TeamStatId",
                table: "FootballerStats");
        }
    }
}
