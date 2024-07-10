using SistemaDeProdutividade.Communication.ViewModel.Produtividades;

namespace SistemaDeProdutividade.Communication.Responses.Usuarios;
public class PerfilUsuarioResponseJson
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public string Setor { get; set; } = string.Empty;
    public List<ProdutividadeFinalizadaIndexVM>? ProdutividadesFinalizadas { get; set; } = [];
    public PerfilUsuarioResponseJson()
    {
        
    }
    public PerfilUsuarioResponseJson(Guid id, string nome, string matricula, string cpf)
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
        Matricula = matricula;
    }
    public void AddProds(List<ProdutividadeFinalizadaIndexVM>? produtividades) 
    {
        ProdutividadesFinalizadas = produtividades;
    }
    public void AddCargoESetor(string cargo, string setor) 
    {
        Cargo = cargo;
        Setor = setor;
    }
}
