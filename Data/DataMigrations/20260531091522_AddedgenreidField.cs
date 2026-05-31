using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesCRUD.DataMigrations
{
    /// <inheritdoc />
    public partial class AddedgenreidField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_games_genre_genreId",
                table: "games");

            migrationBuilder.DropIndex(
                name: "IX_games_genreId",
                table: "games");

            migrationBuilder.AlterColumn<int>(
                name: "genreId",
                table: "games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "genreId",
                table: "games",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_games_genreId",
                table: "games",
                column: "genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_games_genre_genreId",
                table: "games",
                column: "genreId",
                principalTable: "genre",
                principalColumn: "genreId");
        }
    }
}
