using SistemaDeProdutividade.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Entities;
public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Perfil { get; set; } = string.Empty;
    public IList<ProdutividadeFeita> Produtividades { get; set; } = [];

    public Usuario(string nome, string matricula, string cpf, string perfil)
    {
        Nome = nome;
        Matricula = matricula;
        Cpf = cpf;
        Perfil = perfil;
    }
}
