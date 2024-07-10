using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Entities;
public class Atividade
{
    public Guid Id { get; }
    public string Descricao { get; } = string.Empty;
    public int Pontuacao { get; }
    public Guid ProdutividadeId { get; }
    public Produtividade? Produtividade { get; set; }
    public Atividade(string descricao, int pontuacao)
    {
        Descricao = descricao;
        Pontuacao = pontuacao;
    }
}
