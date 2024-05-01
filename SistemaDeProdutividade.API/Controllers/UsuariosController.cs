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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastrar([FromServices] ICadastrarUsuarioUseCase useCase, [FromBody] CadastrarUsuarioRequestJson request) 
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }
    public IActionResult Editar()
    {
        return Ok();
    }
    public IActionResult Visualizar()
    {
        return Ok();
    }
}
