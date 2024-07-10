using Microsoft.AspNetCore.Mvc;
using SistemaDeProdutividade.Communication.Requests.Assinaturas;
using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Domain.Contracts;

namespace SistemaDeProdutividade.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProdutividadesController : ControllerBase
{
    [HttpPost("cadastrar")]
    [ProducesResponseType(typeof(MensagemSucessoCadastroResponseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastrar([FromServices] ICadastrarMapaProdutividadeUseCase useCase,
        [FromBody] CadastrarProdutividadeRequestJson request)
    {
        var result = await useCase.Execute(request);

        return Ok(new Response<MensagemSucessoCadastroResponseJson>(null, 201, result.Mensagem));
    }
    [HttpGet("/api/buscar-cargos")]
    [ProducesResponseType(typeof(Response<CargosResponseJson>), StatusCodes.Status200OK)]
    public IActionResult BuscarTodos([FromServices] IBuscarTodosCargosProdutividadeUseCase useCase)
    {
        var result = useCase.Execute();

        return Ok(new Response<CargosResponseJson>(result, 200, ""));
    }
    [HttpPut("pontuar")]
    [ProducesResponseType(typeof(ProdutividadeFeitaResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Pontuar([FromServices] IVisualizarParaPontuarProdutividadeUseCase useCase,
        [FromBody] string cpfUsuarioLogado)
    {
        var result = await useCase.Execute(cpfUsuarioLogado);

        return Ok(new Response<ProdutividadeFeitaResponseJson>(result, 200, "Prod para pontuar foi gerada com sucesso"));
    }
    [HttpPost("pontuar")]
    [ProducesResponseType(typeof(MensagemSucessoCadastroResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Pontuar([FromServices] ICadastrarProdutividadePontuadaUseCase useCase,
    [FromBody] ProdutividadeFeitaResponseJson request)
    {
       var result = await useCase.Execute(request);

        return Ok(new Response<MensagemSucessoCadastroResponseJson>(null, 201, result.Mensagem));
    }
    [HttpPut("recebido")]
    [ProducesResponseType(typeof(ProdsFeitasResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Recebido([FromServices] IVisualizarProdutividadesRecebidasUseCase useCase,
    [FromBody] string cpfUsuarioLogado)
    {
        var result = await useCase.Execute(cpfUsuarioLogado);

        return Ok(new Response<ProdsFeitasResponseJson>(result, 200, ""));
    }
    [HttpGet("visualizar/{id}")]
    [ProducesResponseType(typeof(Response<ProdutividadeFeitaResponseJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Visualizar([FromRoute] Guid id, [FromServices] IVisualizarProdutividadeFeitaUseCase useCase)
    {
        var result = await useCase.Execute(id);

        return Ok(new Response<ProdutividadeFeitaResponseJson>(result, 200, ""));
    }
    [HttpPost("assinar")]
    [ProducesResponseType(typeof(MensagemSucessoResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Assinar([FromServices] IAssinarProdutividadeUseCase useCase, 
        [FromBody] AssinarProdutividadeRequestJson request)
    {
        var result = await useCase.Execute(request);

        return Ok(new Response<MensagemSucessoResponseJson>(null, 201, result.Mensagem));
    }
    [HttpPut("finalizar")]
    [ProducesResponseType(typeof(MensagemSucessoResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Finalizar([FromServices] IFinalizarProdutividadeUseCase useCase,
    [FromBody] FinalizarProdutividadeRequestJson request)
    {
        var result = await useCase.Execute(request);

        return Ok(new Response<MensagemSucessoResponseJson>(null, 201, result.Mensagem));
    }
    [HttpPut]
    [ProducesResponseType(typeof(ProdsFeitasResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Index([FromServices] IIndexProdutividadesFeitasUseCase useCase,
    [FromBody] string cpfUsuarioLogado)
    {
        var result = await useCase.Execute(cpfUsuarioLogado);

        return Ok(new Response<ProdsFeitasResponseJson>(result, 200, ""));
    }
    [HttpPut("minhas")]
    [ProducesResponseType(typeof(ProdsFeitasResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Minhas([FromServices] IMinhasProdutividadeUseCase useCase,
    [FromBody] string cpfUsuarioLogado)
    {
        var result = await useCase.Execute(cpfUsuarioLogado);

        return Ok(new Response<ProdsFeitasResponseJson>(result, 200, ""));
    }
    [HttpGet("mapas")]
    [ProducesResponseType(typeof(MapasProdResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<ErrorResponseJson>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Mapas([FromServices] IMapasProdutividadeUseCase useCase)
    {
        var result = await useCase.Execute();

        return Ok(new Response<MapasProdResponseJson>(result, 200, ""));
    }
}
