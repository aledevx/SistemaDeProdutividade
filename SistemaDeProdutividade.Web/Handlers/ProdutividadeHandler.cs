using SistemaDeProdutividade.Communication.Requests.Assinaturas;
using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Web.Responses;
using System.Net;
using System.Net.Http.Json;

namespace SistemaDeProdutividade.Web.Handlers;

public class ProdutividadeHandler
{
    private readonly HttpClient _client;
    public ProdutividadeHandler(HttpClient client)
    {
        _client = client;
    }
    public async Task<Response<object>> CadastrarMapaAsync(CadastrarProdutividadeRequestJson request)
    {
        var response = await _client.PostAsJsonAsync("api/produtividades/cadastrar", request);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<Response<MensagemSucessoCadastroResponseJson>>();
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
    public async Task<Response<CargosResponseJson>> BuscarCargos()
    {
        var result = await _client.GetFromJsonAsync<Response<CargosResponseJson>>("api/buscar-cargos");

        return result ??
            new Response<CargosResponseJson>(null, 400, "Falha ao buscar os cargos");
    }
    public async Task<Response<MapasProdResponseJson>> BuscarMapas()
    {
        var result = await _client.GetFromJsonAsync<Response<MapasProdResponseJson>>("api/produtividades/mapas");

        return result ??
            new Response<MapasProdResponseJson>(null, 400, "Falha ao buscar os mapas de produtividade");
    }
    public async Task<Response<object>> DataProdParaPontuarAsync(string cpf)
    {
        var response = await _client.PutAsJsonAsync($"api/produtividades/pontuar", cpf);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<Response<ProdutividadeFeitaResponseJson>>();
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
    public async Task<Response<object>> PontuarProdutividadeAsync(ProdutividadeFeitaResponseJson request)
    {
        var response = await _client.PostAsJsonAsync($"api/produtividades/pontuar", request);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<Response<MensagemSucessoResponseJson>>();
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
    public async Task<Response<ProdsFeitasResponseJson>> BuscarProdsRecebidas(string cpfUsuarioLogado)
    {
        var response = await _client.PutAsJsonAsync($"api/produtividades/recebido", cpfUsuarioLogado);

        if (response.IsSuccessStatusCode) 
        {
            var result = await response.Content.ReadFromJsonAsync<Response<ProdsFeitasResponseJson>>();
            return result;
        }

        return new Response<ProdsFeitasResponseJson>(null, 404, "Não foi possível obter as produtividades");
    }
    public async Task<Response<ProdutividadeFeitaResponseJson>> BuscarProdFeita(Guid id)
    {
        var response = await _client.GetFromJsonAsync<Response<ProdutividadeFeitaResponseJson>>($"api/produtividades/visualizar/{id}");

        if (response!.IsSuccess)
        {
            return response;
        }

        return new Response<ProdutividadeFeitaResponseJson>(null, 404, "Produtividade não foi encontrada");
    }
    public async Task<Response<MensagemSucessoResponseJson>> AssinarProdAsync(AssinarProdutividadeRequestJson request)
    {
        var response = await _client.PostAsJsonAsync("api/produtividades/assinar", request);

        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadFromJsonAsync<Response<MensagemSucessoResponseJson>>().Result;
            return result;
        }

        return new Response<MensagemSucessoResponseJson>(null, 404, "Não foi possível assinar a produtividade");
    }
    public async Task<Response<MensagemSucessoResponseJson>> FinalizarProdAsync(FinalizarProdutividadeRequestJson request)
    {
        var response = await _client.PutAsJsonAsync("api/produtividades/finalizar", request);

        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadFromJsonAsync<Response<MensagemSucessoResponseJson>>().Result;
            return result;
        }

        return new Response<MensagemSucessoResponseJson>(null, 404, "Ocorreu algum erro, verifique com a equipe de desenvolvimento");
    }
    public async Task<Response<ProdsFeitasResponseJson>> BuscarTodasProdutividadesFeitas(string cpfUsuarioLogado)
    {
        var response = await _client.PutAsJsonAsync($"api/produtividades", cpfUsuarioLogado);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<Response<ProdsFeitasResponseJson>>();
            return result;
        }

        return new Response<ProdsFeitasResponseJson>(null, 404, "Não foi possível obter as produtividades");
    }
    public async Task<Response<ProdsFeitasResponseJson>> MinhasProdutividadesAsync(string cpfUsuarioLogado)
    {
        var response = await _client.PutAsJsonAsync($"api/produtividades/minhas", cpfUsuarioLogado);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<Response<ProdsFeitasResponseJson>>();
            return result;
        }

        return new Response<ProdsFeitasResponseJson>(null, 404, "Não foi possível obter as produtividades");
    }
}
