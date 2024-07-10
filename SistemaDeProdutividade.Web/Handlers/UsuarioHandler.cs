using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Requests.Usuarios;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Usuarios;
using System.Net;
using System.Net.Http.Json;

namespace SistemaDeProdutividade.Web.Handlers;

public class UsuarioHandler
{
    private readonly HttpClient _client;
    public UsuarioHandler(HttpClient client)
    {
        _client = client;
    }
    public async Task<Response<MensagemSucessoCadastroResponseJson>> InserirAsync(InsetirUsuarioRequestJson request)
    {
        var result = await _client.PostAsJsonAsync("api/usuarios/cadastrar", request);

        return await result.Content.ReadFromJsonAsync<Response<MensagemSucessoCadastroResponseJson>>() ?? new Communication.Responses.Response<MensagemSucessoCadastroResponseJson>(null, 400, "Falha ao inserir usuário");
    }
    public async Task<Response<object>> CadastrarAsync(CadastrarUsuarioRequestJson request)
    {
        var response = await _client.PostAsJsonAsync("api/usuarios/cadastrar", request);

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
    public async Task<Response<UsuariosResponseJson>> BuscarTodos() 
    {
        var result = await _client.GetFromJsonAsync<Response<UsuariosResponseJson>>("api/usuarios/index");

        return result ?? new Response<UsuariosResponseJson>(null, 400, "Não foi possível obter os usuários");
    }
    public async Task<Response<object>> PerfilAsync(Guid id, string cpf)
    {
        var response = await _client.PutAsJsonAsync($"api/usuarios/perfil/{id}", cpf);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<Response<PerfilUsuarioResponseJson>>();
            return new Response<object>(result!.Data, (int)response.StatusCode, "");
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
    public async Task<Response<object>> LotarAsync(Guid id, LotarUsuarioRequestJson request)
    {
        var response = await _client.PostAsJsonAsync($"api/usuarios/lotar/{id}", request);

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
}
