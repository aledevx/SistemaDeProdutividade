using Microsoft.AspNetCore.Mvc;
using SistemaDeProdutividade.Application.Interfaces;
using SistemaDeProdutividade.Application.Models;
using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Domain.Contracts;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SetorController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Criar([FromServices] ICriarSetorUseCase useCase, [FromBody] CriarSetorRequestJson requestJson)
    {
        var result = await useCase.Execute(requestJson);

        return Created(string.Empty, result);
    }    

    [HttpPut("{id}")]
    public async Task<IActionResult> Editar()
    {
        // Validate the input data
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Visualizar(int id)
    {
        // Call the service method to get the setor by id
        var setor = await _setorService.GetSetorById(id);

        if (setor == null)
            return NotFound();

        return Ok(setor);
    }
}
