using SistemaDeProdutividade.Communication.ViewModel.Atividades;

namespace SistemaDeProdutividade.Communication.ViewModel.Produtividades;
public class MapaProdutividadeVM
{
    public string Cargo { get; set; } = string.Empty;
    public decimal ValorProd { get; set; }
    public List<AtividadeVM> Atividades { get; set; } = [];
    public MapaProdutividadeVM(string cargo, decimal valorProd)
    {
        Cargo = cargo;
        ValorProd = valorProd;
    }
    public void AddAtividade(AtividadeVM atividade) 
    {
        Atividades.Add(atividade);
    }

}
