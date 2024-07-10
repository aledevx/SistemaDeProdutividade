using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Entities;
public class Produtividade
{
    public Guid Id { get; private set; }
    public Guid CargoId { get; private set; }
    public Cargo? Cargo { get; private set; }
    public Guid ValorProdId { get; private set; }
    public ValorProd? ValorProd { get; private set; }
    public List<Atividade> Atividades { get; set; } = [];
    public Produtividade()
    {
        Cargo = null;
        ValorProd = null;
    }
    public Produtividade(Cargo cargo, ValorProd valorProd)
    {
        Cargo = cargo;
        ValorProd = valorProd;
    }
    public void AddAtividade(Atividade atividade) 
    {
        Atividades.Add(atividade);
    }
}
