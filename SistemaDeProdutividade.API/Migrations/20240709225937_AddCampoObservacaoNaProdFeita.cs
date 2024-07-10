using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeProdutividade.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCampoObservacaoNaProdFeita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssinanteResponsavelId",
                table: "Setores");

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "ProdutividadesFeitas",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "ProdutividadesFeitas");

            migrationBuilder.AddColumn<Guid>(
                name: "AssinanteResponsavelId",
                table: "Setores",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
