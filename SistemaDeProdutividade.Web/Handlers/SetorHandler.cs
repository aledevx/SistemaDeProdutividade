using MudBlazor;
using SistemaDeProdutividade.Communication.Requests.Setores;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Communication.Responses.Setores;
using System.Net;
using System.Net.Http.Json;

namespace SistemaDeProdutividade.Web.Handlers;

public class SetorHandler
{
    private readonly HttpClient _client;
    private readonly ISnackbar _snackbar;
    public SetorHandler(HttpClient client, ISnackbar snackbar)
    {
        _client = client;
        _snackbar = snackbar;
    }
    public async Task<Response<object>> CadastrarAsync(CadastrarSetorRequestJson request)
    {
        var response = await _client.PostAsJsonAsync("api/setores/cadastrar", request);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<Response<MensagemSucessoCadastroResponseJson>>();
            return new Response<object>(null, (int)response.StatusCode, result!.Message);
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var errors = await response.Content.ReadFromJsonAsync<ListErrorsResponseJson>();
            return new Response<object>(errors, (int)response.StatusCode, "Erro de validação");
        }
        else
        {
            return new Response<object>(null, (int)response.StatusCode, "Erro inesperado");
        }
    }
    public async Task<Response<SetoresResponseJson>> BuscarTodos()
    {
        var result = await _client.GetFromJsonAsync<Response<SetoresResponseJson>>("api/setores/buscar-todos");

        return result ??
            new Response<SetoresResponseJson>(null, 400, "Falha ao buscar os setores");
    }
    public async Task<Response<SetorResponseJson>> VisualizarAsync(Guid id)
    {
        var response = await _client.GetFromJsonAsync<Response<SetorResponseJson>>($"api/setores/visualizar/{id}");

        if (response!.IsSuccess)
        {
            return response;
        }

        return new Response<SetorResponseJson>(null, 404, "Produtividade não foi encontrada");
    }
}
