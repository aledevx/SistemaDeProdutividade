using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
    [HttpPost("login")]
    [ProducesResponseType(typeof(UsuarioResponseJson),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        ///TODO: CRIAR UM RESPONSE PARA O LOGIN, RETORNANDO CPF,FIRSTNAME, LASTNAME  DO USUÁRIO LOGADO 


        //return Ok(new UsuarioResponseJson(result.Cpf, result.Nome, result.Perfil));


        return Ok(new Response<UsuarioResponseJson>(new UsuarioResponseJson(result.Cpf, result.Nome, result.Perfil), 200, "Logado com sucesso"));

    }
    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Logout([FromServices] Autenticador tiaIdentity)
    {

        await tiaIdentity.LogoutAsync();

        return Ok("Deslogado com sucesso");
    }
    [HttpGet("verificar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult VerificaSeEstaLogado()
    {
        var cpfDoUsuario = this.User.CPF();
        if (!cpfDoUsuario.IsNullOrEmpty()) 
        {
            return Ok(new { IsAuthenticated = true });
        }

        return Ok(new { IsAuthenticated = false });
    }
}
