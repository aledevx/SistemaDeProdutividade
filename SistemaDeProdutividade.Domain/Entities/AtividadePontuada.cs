using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Entities;
public class AtividadePontuada
{
    public Guid Id { get; set; }
    public string DescricaoAtividade { get; set; } = string.Empty;
    public int PontuacaoAtividade { get; set; }
    public int QtdRealizada { get; set; }
    public Guid ProdutividadeFeitaId { get; set; }
    public AtividadePontuada(string descricao, int pontuacao, int qtd)
    {
        DescricaoAtividade = descricao;
        PontuacaoAtividade = pontuacao;
        QtdRealizada = qtd;
    }
    public AtividadePontuada()
    {
        
    }
}
