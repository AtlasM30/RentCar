using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_placa",
                table: "Vehicles",
                column: "placa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_nomeUsuario",
                table: "Users",
                column: "nomeUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_placa",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Users_nomeUsuario",
                table: "Users");
        }
    }
}
