using Microsoft.AspNetCore.Mvc;
using SistemaDeProdutividade.API.Extensions;
using SistemaDeProdutividade.Application.Services.AD;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Domain.Contracts;
using TiaIdentity;

namespace SistemaDeProdutividade.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ListErrorsResponseJson),StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login([FromServices] ADService ad, Autenticador tiaIdentity, ILogarUsuarioUseCase useCase,
        [FromBody] LoginRequestJson request)
    {
        // if (!ad.LoginValido(loginDto.Cpf, loginDto.Senha))
        // {
        //     return Unauthorized(new { status = "error", message = "Cpf ou senha incorretos"});
        // }
        //VERIFICA NO AD SE AS INFORMAÇÕES DESSE USUÁRIOS SÃO VÁLIDAS

        var result = useCase.Execute(request).Result; 

        await tiaIdentity.LoginAsync(result.Cpf, result.Nome, lembrar: true, result.Perfil);

        var cpfUsuarioLogado = this.User.CPF();

        return Ok(new { Message = "Logado com sucesso", CpfUserLogado = cpfUsuarioLogado });

    }
}
