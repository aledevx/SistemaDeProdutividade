using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeProdutividade.API.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lotacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SetorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataLotacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioQueLotouId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Matricula = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValoresProd",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValoresProd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutividadesFeitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NomeUsuario = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    MatriculaUsuario = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CargoUsuario = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    SetorLotado = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    FaltasNaoJustificadas = table.Column<bool>(type: "bit", nullable: false),
                    SemAssinaturaServidor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutividadesFeitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutividadesFeitas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    TipoSetor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetorSuperiorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChefeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssinanteResponsavelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setores_Usuarios_ChefeId",
                        column: x => x.ChefeId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produtividades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorProdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtividades_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtividades_ValoresProd_ValorProdId",
                        column: x => x.ValorProdId,
                        principalTable: "ValoresProd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assinaturas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Cargo = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutividadeFeitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAssinatura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assinaturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assinaturas_ProdutividadesFeitas_ProdutividadeFeitaId",
                        column: x => x.ProdutividadeFeitaId,
                        principalTable: "ProdutividadesFeitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtividadesPontuadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DescricaoAtividade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PontuacaoAtividade = table.Column<int>(type: "int", nullable: false),
                    QtdRealizada = table.Column<int>(type: "int", nullable: false),
                    ProdutividadeFeitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadesPontuadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadesPontuadas_ProdutividadesFeitas_ProdutividadeFeitaId",
                        column: x => x.ProdutividadeFeitaId,
                        principalTable: "ProdutividadesFeitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistMovimentacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutividadeFeitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusProdutividade = table.Column<int>(type: "int", nullable: false),
                    DataMovimentacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistMovimentacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistMovimentacoes_ProdutividadesFeitas_ProdutividadeFeitaId",
                        column: x => x.ProdutividadeFeitaId,
                        principalTable: "ProdutividadesFeitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pontuacao = table.Column<int>(type: "int", nullable: false),
                    ProdutividadeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividades_Produtividades_ProdutividadeId1",
                        column: x => x.ProdutividadeId1,
                        principalTable: "Produtividades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assinaturas_ProdutividadeFeitaId",
                table: "Assinaturas",
                column: "ProdutividadeFeitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_ProdutividadeId1",
                table: "Atividades",
                column: "ProdutividadeId1");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadesPontuadas_ProdutividadeFeitaId",
                table: "AtividadesPontuadas",
                column: "ProdutividadeFeitaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistMovimentacoes_ProdutividadeFeitaId",
                table: "HistMovimentacoes",
                column: "ProdutividadeFeitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtividades_CargoId",
                table: "Produtividades",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtividades_ValorProdId",
                table: "Produtividades",
                column: "ValorProdId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutividadesFeitas_UsuarioId",
                table: "ProdutividadesFeitas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Setores_ChefeId",
                table: "Setores",
                column: "ChefeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assinaturas");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "AtividadesPontuadas");

            migrationBuilder.DropTable(
                name: "HistMovimentacoes");

            migrationBuilder.DropTable(
                name: "Lotacoes");

            migrationBuilder.DropTable(
                name: "Setores");

            migrationBuilder.DropTable(
                name: "Produtividades");

            migrationBuilder.DropTable(
                name: "ProdutividadesFeitas");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "ValoresProd");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
