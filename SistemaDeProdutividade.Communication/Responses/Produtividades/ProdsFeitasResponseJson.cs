using SistemaDeProdutividade.Communication.ViewModel.Produtividades;

namespace SistemaDeProdutividade.Communication.Responses.Produtividades;
public class ProdsFeitasResponseJson
{
    public List<ProdFeitaIndexVM> Prods { get; set; } = [];
    public ProdsFeitasResponseJson(List<ProdFeitaIndexVM> prods)
    {
        Prods = prods;
    }
}
