using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Domain.Contracts;
using SistemaDeProdutividade.Domain.Repositories.Produtividade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Application.UseCases.Produtividade.BuscarTodosCargos;
public class BuscarTodosCargosProdutividadeUseCase : IBuscarTodosCargosProdutividadeUseCase
{
    private readonly IProdutividadeReadOnlyRepository _readOnlyRepository;
    public BuscarTodosCargosProdutividadeUseCase(IProdutividadeReadOnlyRepository readOnlyRepository)
    {
        _readOnlyRepository = readOnlyRepository;
    }
    public CargosResponseJson Execute()
    {
        var cargos = _readOnlyRepository.BuscarCargos();

        return cargos;
    }
}
