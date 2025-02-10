using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaDeVideojuegosWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CarritoJuegoADDED : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_Carritos_CarritoId",
                table: "Juegos");

            migrationBuilder.DropIndex(
                name: "IX_Juegos_CarritoId",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "Juegos");

            migrationBuilder.CreateTable(
                name: "CarritoJuegos",
                columns: table => new
                {
                    CarritoId = table.Column<int>(type: "int", nullable: false),
                    JuegoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoJuegos", x => new { x.CarritoId, x.JuegoId });
                    table.ForeignKey(
                        name: "FK_CarritoJuegos_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoJuegos_Juegos_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juegos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoJuegos_JuegoId",
                table: "CarritoJuegos",
                column: "JuegoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoJuegos");

            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_CarritoId",
                table: "Juegos",
                column: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_Carritos_CarritoId",
                table: "Juegos",
                column: "CarritoId",
                principalTable: "Carritos",
                principalColumn: "Id");
        }
    }
}
