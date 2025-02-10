using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaDeVideojuegosWebApi.Migrations
{
    /// <inheritdoc />
    public partial class n2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CarritoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Juegos");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CarritoId",
                table: "Usuarios",
                column: "CarritoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CarritoId",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Juegos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CarritoId",
                table: "Usuarios",
                column: "CarritoId",
                unique: true);
        }
    }
}
