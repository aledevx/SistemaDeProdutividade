using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaDeProdutividade.Domain.Constants;
using SistemaDeProdutividade.Domain.Entities;
using SistemaDeProdutividade.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Infrastructure.DataAccess;
public class ProdContext : DbContext
{
    public ProdContext(DbContextOptions options)
        : base(options) 
    {
    }

    public DbSet<Produtividade> Produtividades { get; set; }
    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<Atividade> Atividades { get; set; }
    public DbSet<ValorProd> ValoresProd { get; set; }
    public DbSet<ProdutividadeFeita> ProdutividadesFeitas { get; set; }
    public DbSet<AtividadePontuada> AtividadesPontuadas { get; set; }
    public DbSet<Assinatura> Assinaturas { get; set; }
    public DbSet<HistoricoMovimentacaoProd> HistMovimentacoes { get; set; }
    public DbSet<Setor> Setores { get; set; }
    public DbSet<Lotacao> Lotacoes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ProdContext).Assembly);

        base.OnModelCreating(builder);

        builder.Entity<Produtividade>().HasKey(c => c.Id);
        builder.Entity<Produtividade>().HasOne(p => p.Cargo);
        builder.Entity<Produtividade>().Property(p => p.CargoId).IsRequired();
        builder.Entity<Produtividade>().HasOne(p => p.ValorProd);
        builder.Entity<Produtividade>().Property(p => p.ValorProdId).IsRequired();
        builder.Entity<Produtividade>().HasMany(p => p.Atividades).WithOne(a => a.Produtividade);


        builder.Entity<Cargo>().HasKey(c => c.Id);
        builder.Entity<Cargo>().Property(c => c.Nome).IsUnicode(false).HasMaxLength(250).IsRequired();


        builder.Entity<Atividade>().HasKey(a => a.Id);
        builder.Entity<Atividade>().Property(a => a.Descricao).IsRequired();
        builder.Entity<Atividade>().Property(a => a.Pontuacao).IsRequired();
        builder.Entity<Atividade>().Property(a => a.ProdutividadeId).IsRequired();
        builder.Entity<Atividade>().HasOne(a => a.Produtividade).WithMany(p => p.Atividades);


        builder.Entity<ValorProd>().HasKey(v => v.Id);
        builder.Entity<ValorProd>().Property(v => v.Valor).HasColumnType("decimal(10,2)").IsRequired();


        builder.Entity<ProdutividadeFeita>().HasKey(p => p.Id);
        builder.Entity<ProdutividadeFeita>().Property(p => p.Codigo).IsUnicode(false).HasMaxLength(10).IsRequired();
        builder.Entity<ProdutividadeFeita>().Property(p => p.NomeUsuario).IsUnicode(false).HasMaxLength(250).IsRequired();
        builder.Entity<ProdutividadeFeita>().Property(p => p.MatriculaUsuario).IsUnicode(false).HasMaxLength(20).IsRequired();
        builder.Entity<ProdutividadeFeita>().Property(p => p.CargoUsuario).IsUnicode(false).HasMaxLength(150).IsRequired();
        builder.Entity<ProdutividadeFeita>().Property(p => p.SetorLotado).IsUnicode(false).HasMaxLength(250).IsRequired();
        builder.Entity<ProdutividadeFeita>().Property(p => p.DataInicio).IsRequired();
        builder.Entity<ProdutividadeFeita>().Property(p => p.DataFim).IsRequired();
        builder.Entity<ProdutividadeFeita>().HasOne(p => p.Usuario).WithMany(u => u.Produtividades);
        builder.Entity<ProdutividadeFeita>().Property(p => p.UsuarioId).IsRequired();
        builder.Entity<ProdutividadeFeita>().Property(p => p.DataCriacao).IsRequired();
        builder.Entity<ProdutividadeFeita>().Property(p => p.Status).HasConversion(v => v.ToString(), v => (StatusProdutividade)Enum.Parse(typeof(StatusProdutividade), v)).IsRequired();
        builder.Entity<ProdutividadeFeita>().Property(p => p.Ativo).IsRequired();
        builder.Entity<ProdutividadeFeita>().Property(p => p.FaltasNaoJustificadas).IsRequired();
        builder.Entity<ProdutividadeFeita>().Property(p => p.SemAssinaturaServidor).IsRequired();
        builder.Entity<ProdutividadeFeita>().HasMany(p => p.Assinaturas);
        builder.Entity<ProdutividadeFeita>().HasMany(p => p.Atividades);
        builder.Entity<ProdutividadeFeita>().HasMany(p => p.Historico);


        builder.Entity<AtividadePontuada>().HasKey(a => a.Id);
        builder.Entity<AtividadePontuada>().Property(a => a.DescricaoAtividade).IsRequired();
        builder.Entity<AtividadePontuada>().Property(a => a.PontuacaoAtividade).IsRequired();
        builder.Entity<AtividadePontuada>().Property(a => a.QtdRealizada).IsRequired();
        builder.Entity<AtividadePontuada>().Property(a => a.ProdutividadeFeitaId).IsRequired();


        builder.Entity<Assinatura>().HasKey(a => a.Id);
        builder.Entity<Assinatura>().Property(a => a.Nome).IsUnicode(false).HasMaxLength(250).IsRequired();
        builder.Entity<Assinatura>().Property(a => a.Cargo).IsUnicode(false).HasMaxLength(150).IsRequired();
        builder.Entity<Assinatura>().Property(a => a.UsuarioId).IsRequired();
        builder.Entity<Assinatura>().Property(a => a.ProdutividadeFeitaId).IsRequired();
        builder.Entity<Assinatura>().Property(a => a.DataAssinatura).IsRequired();
        builder.Entity<Assinatura>().Property(a => a.Ativo).IsRequired();


        builder.Entity<HistoricoMovimentacaoProd>().HasKey(h => h.Id);
        builder.Entity<HistoricoMovimentacaoProd>().Property(h => h.ProdutividadeFeitaId).IsRequired();
        builder.Entity<HistoricoMovimentacaoProd>().Property(h => h.UsuarioId).IsRequired();
        builder.Entity<HistoricoMovimentacaoProd>().Property(h => h.StatusProdutividade).IsRequired();
        builder.Entity<HistoricoMovimentacaoProd>().Property(h => h.DataMovimentacao).IsRequired();
        builder.Entity<HistoricoMovimentacaoProd>().Property(h => h.Observacao).IsRequired();


        builder.Entity<Setor>().HasKey(s => s.Id);
        builder.Entity<Setor>().Property(s => s.Nome).IsUnicode(false).HasMaxLength(250).IsRequired();
        builder.Entity<Setor>().Property(s => s.TipoSetor).HasConversion(v => v.ToString(), v => (TipoSetor)Enum.Parse(typeof(TipoSetor), v)).IsRequired();


        builder.Entity<Lotacao>().HasKey(l => l.Id);
        builder.Entity<Lotacao>().Property(l => l.UsuarioId).IsRequired();
        builder.Entity<Lotacao>().Property(l => l.SetorId).IsRequired();
        builder.Entity<Lotacao>().Property(l => l.CargoId).IsRequired();
        builder.Entity<Lotacao>().Property(l => l.DataLotacao).IsRequired();
        builder.Entity<Lotacao>().Property(l => l.UsuarioQueLotouId).IsRequired();


        builder.Entity<Usuario>().HasKey(u => u.Id);
        builder.Entity<Usuario>().Property(u => u.Nome).IsUnicode(false).HasMaxLength(250).IsRequired();
        builder.Entity<Usuario>().Property(u => u.Matricula).IsUnicode(false).HasMaxLength(20).IsRequired();
        builder.Entity<Usuario>().Property(u => u.Cpf).IsUnicode(false).HasMaxLength(20).IsRequired();
        builder.Entity<Usuario>().Property(u => u.Perfil).IsUnicode(false).HasMaxLength(25).IsRequired();
        builder.Entity<Usuario>().HasMany(u => u.Produtividades).WithOne(p => p.Usuario);

    }
}
