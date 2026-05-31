using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesCRUD.DataMigrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    genreId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    genre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.genreId);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    genreId = table.Column<int>(type: "INTEGER", nullable: true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.id);
                    table.ForeignKey(
                        name: "FK_games_genre_genreId",
                        column: x => x.genreId,
                        principalTable: "genre",
                        principalColumn: "genreId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_games_genreId",
                table: "games",
                column: "genreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "genre");
        }
    }
}
