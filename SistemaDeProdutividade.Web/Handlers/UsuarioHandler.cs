using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Web.Requests;
using SistemaDeProdutividade.Web.Responses;
using System.Net.Http.Json;

namespace SistemaDeProdutividade.Web.Handlers;

public class UsuarioHandler
{

    private readonly HttpClient _client;
    public UsuarioHandler(HttpClient client)
    {
        _client = client;
    }
    public async Task<Communication.Responses.Response<MensagemSucessoCadastroResponseJson>> CadastrarAsync(InserirUsuarioRequestJson request)
    {
        var result = await _client.PostAsJsonAsync("api/usuarios", request);

        return await result.Content.ReadFromJsonAsync<Communication.Responses.Response<MensagemSucessoCadastroResponseJson>>() ?? new Communication.Responses.Response<MensagemSucessoCadastroResponseJson>(null, 400, "Falha ao criar categoria");

    }
}
