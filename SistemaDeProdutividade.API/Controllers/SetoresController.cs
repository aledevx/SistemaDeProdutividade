using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Requests.Setores;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Communication.Responses.Setores;
using SistemaDeProdutividade.Domain.Contracts;

namespace SistemaDeProdutividade.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SetoresController : ControllerBase
{
    [HttpPost("cadastrar")]
    [ProducesResponseType(typeof(MensagemSucessoCadastroResponseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ListErrorsResponseJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastrar([FromServices] ICadastrarSetorUseCase useCase, [FromBody] CadastrarSetorRequestJson request)
    {
        var result = await useCase.Execute(request);

        return Ok(new Response<MensagemSucessoCadastroResponseJson>(null, 201, result.Mensagem));
    }
    [HttpGet("buscar-todos")]
    [ProducesResponseType(typeof(Response<SetoresResponseJson>), StatusCodes.Status200OK)]
    public IActionResult BuscarTodos([FromServices] IBuscarTodosSetorUseCase useCase)
    {
        var result = useCase.Execute();

        return Ok(new Response<SetoresResponseJson>(result, 200, ""));
    }
    [HttpGet("visualizar/{id}")]
    [ProducesResponseType(typeof(Response<SetorResponseJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<ErrorResponseJson>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Visualizar([FromRoute] Guid id, [FromServices] IVisualizarSetorUseCase useCase)
    {
        var result = await useCase.Execute(id);

        return Ok(new Response<SetorResponseJson>(result, 200, ""));
    }
}
