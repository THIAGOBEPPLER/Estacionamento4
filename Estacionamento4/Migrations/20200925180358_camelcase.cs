using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamento4.Migrations
{
    public partial class camelcase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patios_Veiculos_veiculoPlaca",
                table: "Patios");

            migrationBuilder.RenameColumn(
                name: "modelo",
                table: "Veiculos",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "marca",
                table: "Veiculos",
                newName: "Marca");

            migrationBuilder.RenameColumn(
                name: "cor",
                table: "Veiculos",
                newName: "Cor");

            migrationBuilder.RenameColumn(
                name: "placa",
                table: "Veiculos",
                newName: "Placa");

            migrationBuilder.RenameColumn(
                name: "veiculoPlaca",
                table: "Patios",
                newName: "VeiculoPlaca");

            migrationBuilder.RenameColumn(
                name: "valor",
                table: "Patios",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "tempo",
                table: "Patios",
                newName: "Tempo");

            migrationBuilder.RenameColumn(
                name: "dataInicio",
                table: "Patios",
                newName: "DataInicio");

            migrationBuilder.RenameColumn(
                name: "dataFim",
                table: "Patios",
                newName: "DataFim");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Patios",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Patios_veiculoPlaca",
                table: "Patios",
                newName: "IX_Patios_VeiculoPlaca");

            migrationBuilder.AddForeignKey(
                name: "FK_Patios_Veiculos_VeiculoPlaca",
                table: "Patios",
                column: "VeiculoPlaca",
                principalTable: "Veiculos",
                principalColumn: "Placa",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patios_Veiculos_VeiculoPlaca",
                table: "Patios");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Veiculos",
                newName: "modelo");

            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Veiculos",
                newName: "marca");

            migrationBuilder.RenameColumn(
                name: "Cor",
                table: "Veiculos",
                newName: "cor");

            migrationBuilder.RenameColumn(
                name: "Placa",
                table: "Veiculos",
                newName: "placa");

            migrationBuilder.RenameColumn(
                name: "VeiculoPlaca",
                table: "Patios",
                newName: "veiculoPlaca");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Patios",
                newName: "valor");

            migrationBuilder.RenameColumn(
                name: "Tempo",
                table: "Patios",
                newName: "tempo");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "Patios",
                newName: "dataInicio");

            migrationBuilder.RenameColumn(
                name: "DataFim",
                table: "Patios",
                newName: "dataFim");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Patios",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Patios_VeiculoPlaca",
                table: "Patios",
                newName: "IX_Patios_veiculoPlaca");

            migrationBuilder.AddForeignKey(
                name: "FK_Patios_Veiculos_veiculoPlaca",
                table: "Patios",
                column: "veiculoPlaca",
                principalTable: "Veiculos",
                principalColumn: "placa",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
