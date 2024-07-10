using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeProdutividade.API.Migrations
{
    /// <inheritdoc />
    public partial class AddColunaValorProd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaltasNaoJustificadas",
                table: "ProdutividadesFeitas");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorDaProdutividade",
                table: "ProdutividadesFeitas",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorDaProdutividade",
                table: "ProdutividadesFeitas");

            migrationBuilder.AddColumn<bool>(
                name: "FaltasNaoJustificadas",
                table: "ProdutividadesFeitas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
