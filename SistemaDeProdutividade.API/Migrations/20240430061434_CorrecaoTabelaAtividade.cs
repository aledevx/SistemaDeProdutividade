using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeProdutividade.API.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoTabelaAtividade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_Produtividades_ProdutividadeId1",
                table: "Atividades");

            migrationBuilder.DropIndex(
                name: "IX_Atividades_ProdutividadeId1",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "ProdutividadeId1",
                table: "Atividades");

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutividadeId",
                table: "Atividades",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_ProdutividadeId",
                table: "Atividades",
                column: "ProdutividadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividades_Produtividades_ProdutividadeId",
                table: "Atividades",
                column: "ProdutividadeId",
                principalTable: "Produtividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_Produtividades_ProdutividadeId",
                table: "Atividades");

            migrationBuilder.DropIndex(
                name: "IX_Atividades_ProdutividadeId",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "ProdutividadeId",
                table: "Atividades");

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutividadeId1",
                table: "Atividades",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_ProdutividadeId1",
                table: "Atividades",
                column: "ProdutividadeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividades_Produtividades_ProdutividadeId1",
                table: "Atividades",
                column: "ProdutividadeId1",
                principalTable: "Produtividades",
                principalColumn: "Id");
        }
    }
}
