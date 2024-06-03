using Microsoft.AspNetCore.Mvc;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Contracts;

namespace SistemaDeProdutividade.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SetorController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(MensagemSucessoCadastroResponseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ListErrorsResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Criar([FromServices] ICriarSetorUseCase useCase, [FromBody] CriarSetorRequestJson requestJson)
    {
        var result = await useCase.Execute(requestJson);

        return Created(string.Empty, result);
    }    

    [HttpPost]
    [ProducesResponseType(typeof(MensagemSucessoCadastroResponseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ListErrorsResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Editar([FromServices] IEditarSetorUseCase useCase, [FromBody] EditarSetorRequestJson requestJson)
    {
        var result = await useCase.Execute(requestJson);

        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ListErrorsResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Visualizar([FromServices] IVisualizarSetorUseCase useCase, Guid id)
    {
        var setor = await useCase.Execute(id);

        if (setor == null)
            return NotFound();

        return Ok(setor);
    }
}
