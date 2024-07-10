using SistemaDeProdutividade.Communication.ViewModel.Setores;

namespace SistemaDeProdutividade.Communication.Responses.Setores;
public class SetoresResponseJson 
{
    public List<SetorIndexVM> Setores { get; set; } = [];
    public SetoresResponseJson(List<SetorIndexVM> setores)
    {
        Setores = setores;
    }

}
