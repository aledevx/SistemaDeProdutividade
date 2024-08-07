﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeProdutividade.Infrastructure.DataAccess;

#nullable disable

namespace SistemaDeProdutividade.API.Migrations
{
    [DbContext(typeof(ProdContext))]
    [Migration("20240430060506_Teste")]
    partial class Teste
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.Assinatura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("DataAssinatura")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("ProdutividadeFeitaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProdutividadeFeitaId");

                    b.ToTable("Assinaturas");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.Atividade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pontuacao")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProdutividadeId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProdutividadeId1");

                    b.ToTable("Atividades");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.AtividadePontuada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DescricaoAtividade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PontuacaoAtividade")
                        .HasColumnType("int");

                    b.Property<Guid>("ProdutividadeFeitaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QtdRealizada")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutividadeFeitaId");

                    b.ToTable("AtividadesPontuadas");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.HistoricoMovimentacaoProd", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataMovimentacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProdutividadeFeitaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StatusProdutividade")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProdutividadeFeitaId");

                    b.ToTable("HistMovimentacoes");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.Lotacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CargoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataLotacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SetorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioQueLotouId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Lotacoes");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.Produtividade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CargoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ValorProdId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("ValorProdId");

                    b.ToTable("Produtividades");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.ProdutividadeFeita", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CargoUsuario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<bool>("FaltasNaoJustificadas")
                        .HasColumnType("bit");

                    b.Property<string>("MatriculaUsuario")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("SemAssinaturaServidor")
                        .HasColumnType("bit");

                    b.Property<string>("SetorLotado")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ProdutividadesFeitas");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.Setor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssinanteResponsavelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChefeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<Guid?>("SetorSuperiorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipoSetor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChefeId");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.ValorProd", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("ValoresProd");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.Assinatura", b =>
                {
                    b.HasOne("SistemaDeProdutividade.Domain.Entities.ProdutividadeFeita", null)
                        .WithMany("Assinaturas")
                        .HasForeignKey("ProdutividadeFeitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.Atividade", b =>
                {
                    b.HasOne("SistemaDeProdutividade.Domain.Entities.Produtividade", "Produtividade")
                        .WithMany("Atividades")
                        .HasForeignKey("ProdutividadeId1");

                    b.Navigation("Produtividade");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.AtividadePontuada", b =>
                {
                    b.HasOne("SistemaDeProdutividade.Domain.Entities.ProdutividadeFeita", null)
                        .WithMany("Atividades")
                        .HasForeignKey("ProdutividadeFeitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.HistoricoMovimentacaoProd", b =>
                {
                    b.HasOne("SistemaDeProdutividade.Domain.Entities.ProdutividadeFeita", null)
                        .WithMany("Historico")
                        .HasForeignKey("ProdutividadeFeitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.Produtividade", b =>
                {
                    b.HasOne("SistemaDeProdutividade.Domain.Entities.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeProdutividade.Domain.Entities.ValorProd", "ValorProd")
                        .WithMany()
                        .HasForeignKey("ValorProdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("ValorProd");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.ProdutividadeFeita", b =>
                {
                    b.HasOne("SistemaDeProdutividade.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Produtividades")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.Setor", b =>
                {
                    b.HasOne("SistemaDeProdutividade.Domain.Entities.Usuario", "Chefe")
                        .WithMany()
                        .HasForeignKey("ChefeId");

                    b.Navigation("Chefe");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.Produtividade", b =>
                {
                    b.Navigation("Atividades");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.ProdutividadeFeita", b =>
                {
                    b.Navigation("Assinaturas");

                    b.Navigation("Atividades");

                    b.Navigation("Historico");
                });

            modelBuilder.Entity("SistemaDeProdutividade.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Produtividades");
                });
#pragma warning restore 612, 618
        }
    }
}
