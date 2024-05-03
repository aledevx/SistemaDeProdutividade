using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Contracts;

namespace SistemaDeProdutividade.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(MensagemSucessoCadastroResponseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ListErrorsResponseJson),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastrar([FromServices] ICadastrarUsuarioUseCase useCase, [FromBody] CadastrarUsuarioRequestJson request) 
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(MensagemSucessoCadastroResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
    public IActionResult Editar([FromRoute] Guid id)
    {
        return Ok();
    }
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(MensagemSucessoCadastroResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
    public IActionResult Visualizar([FromRoute] Guid id)
    {
        return Ok();
    }
}
