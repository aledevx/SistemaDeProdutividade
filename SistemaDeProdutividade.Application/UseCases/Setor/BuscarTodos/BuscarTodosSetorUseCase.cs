using SistemaDeProdutividade.Communication.Responses.Setores;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Setor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Application.UseCases.Setor.BuscarTodos;
public class BuscarTodosSetorUseCase : IBuscarTodosSetorUseCase
{
    private readonly ISetorReadOnlyRepository _readOnlyRepository;
    public BuscarTodosSetorUseCase(ISetorReadOnlyRepository readOnlyRepository)
    {
        _readOnlyRepository = readOnlyRepository;
    }
    public SetoresResponseJson Execute()
    {
        var setores = _readOnlyRepository.GetAll();

        return setores.Result;
    }
}
