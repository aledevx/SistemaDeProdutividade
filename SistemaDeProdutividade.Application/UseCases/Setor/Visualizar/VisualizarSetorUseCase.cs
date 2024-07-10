using SistemaDeProdutividade.Communication.Responses.Setores;
using SistemaDeProdutividade.Communication.ViewModel.Setores;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Setor;
using SistemaDeProdutividade.Domain.Repositories.Usuario;

namespace SistemaDeProdutividade.Application.UseCases.Setor.Visualizar;
public class VisualizarSetorUseCase : IVisualizarSetorUseCase
{
    private readonly ISetorReadOnlyRepository _setorReadOnlyRepository;
    private readonly IUsuarioReadOnlyRepository _usuarioReadOnlyRepository;
    public VisualizarSetorUseCase(ISetorReadOnlyRepository setorReadOnlyRepository,
        IUsuarioReadOnlyRepository usuarioReadOnlyRepository)
    {
        _setorReadOnlyRepository = setorReadOnlyRepository;
        _usuarioReadOnlyRepository = usuarioReadOnlyRepository;
    }
    public async Task<SetorResponseJson> Execute(Guid id)
    {
        var setor = await _setorReadOnlyRepository.BuscarSetor(id);

        var result = new SetorResponseJson(setor.Id, setor.Nome, setor.TipoSetor);

        var lotacoes = await _usuarioReadOnlyRepository.Lotacoes();

        var lotacoesDoSetor = lotacoes.Where(l => l.SetorId == setor.Id).ToList();

        foreach (var lotSetor in lotacoesDoSetor) 
        {
            for (int x =0; x<= lotacoes.Count() -1; x++) 
            {
                if (lotSetor.UsuarioId == lotacoes[x].UsuarioId &&
                    lotSetor.SetorId != lotacoes[x].SetorId &&
                    lotSetor.DataLotacao < lotacoes[x].DataLotacao) 
                {
                    lotacoesDoSetor.Remove(lotSetor);
                }
            }
        }

        var usersIdLotadoSetor = lotacoesDoSetor.Select(l => l.UsuarioId).ToList();

        foreach (var item in usersIdLotadoSetor) 
        {
            var usuario = await _usuarioReadOnlyRepository.BuscarPerfilCompletoSemProd(item);
            result.AddUsuario(new IndexUsuarioSetorVM(usuario.Id, usuario.Nome, usuario.Cargo, usuario.Matricula));
        }


        if (setor.Chefe != null) 
        {
           result.AddChefe(setor.Chefe.Nome);
        }

        if (setor.SetorSuperiorId != null) 
        {
            var setorChefe = await _setorReadOnlyRepository.BuscarSetor(setor.SetorSuperiorId!.Value);

            result.AddSetorChefe(setorChefe.Nome);
        }


        return result;
    }
}
