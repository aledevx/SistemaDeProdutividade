namespace SistemaDeProdutividade.Communication.Responses.Usuarios;
public class LotacaoAtualUsuarioResponseJson 
{
    public Guid UserId { get; set; }
    public string CargoNome { get; set; } = string.Empty;
    public string SetorNome { get; set; } = string.Empty;
    public LotacaoAtualUsuarioResponseJson()
    {
        
    }
    public LotacaoAtualUsuarioResponseJson(Guid userId, string cargoNome, string setorNome)
    {
        UserId = userId;
        CargoNome = cargoNome;
        SetorNome = setorNome;
    }
}
