using Microsoft.AspNetCore.Mvc;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Requests.Usuarios;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Usuarios;
using SistemaDeProdutividade.Domain.Contracts;

namespace SistemaDeProdutividade.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    [HttpPost("cadastrar")]
    [ProducesResponseType(typeof(MensagemSucessoCadastroResponseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ListErrorsResponseJson),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastrar([FromServices] ICadastrarUsuarioUseCase useCase, [FromBody] CadastrarUsuarioRequestJson request) 
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }
    [HttpGet("index")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
    public IActionResult VisualizarTodos([FromServices] IBuscarUsuariosUseCase useCase)
    {
        var result = useCase.Execute();

        return Ok(new Response<UsuariosResponseJson>(result, 200, "teste"));
    }
    [HttpPut("perfil/{id}")]
    [ProducesResponseType(typeof(Response<PerfilUsuarioResponseJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<ListErrorsResponseJson>), StatusCodes.Status400BadRequest)]
    public IActionResult Perfil([FromRoute] Guid id, 
        [FromServices] IBuscarPerfilCompletoUsuarioUseCase useCase, [FromBody] string cpfUsuarioLogado)
    {
        var result = useCase.Execute(cpfUsuarioLogado, id);
        return Ok(new Response<PerfilUsuarioResponseJson>(result.Result, 200, ""));
    }
    [HttpPost("lotar/{id}")]
    [ProducesResponseType(typeof(Response<LotarUsuarioRequestJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<ListErrorsResponseJson>), StatusCodes.Status400BadRequest)]
    public IActionResult Lotar([FromRoute] Guid id,
    [FromServices] ILotarUsuarioUseCase useCase, [FromBody] LotarUsuarioRequestJson request)
    {
        var result = useCase.Execute(id ,request).Result;

        return Ok(new Response<PerfilUsuarioResponseJson>(null, 201, result.Mensagem));
    }
}
