using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaDeVideojuegosWebApi.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Carritos_CarritoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CarritoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Carritos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_UsuarioId",
                table: "Carritos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioId",
                table: "Carritos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioId",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Carritos_UsuarioId",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Carritos");

            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CarritoId",
                table: "Usuarios",
                column: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Carritos_CarritoId",
                table: "Usuarios",
                column: "CarritoId",
                principalTable: "Carritos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
