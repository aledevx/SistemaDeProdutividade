using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Web.DTOs;
using SistemaDeProdutividade.Web.Requests;
using SistemaDeProdutividade.Web.Responses;
using System.Net.Http.Json;

namespace SistemaDeProdutividade.Web.Handlers;

public class AuthHandler
{
    private readonly HttpClient _client;
    private readonly IJSRuntime _jsRuntime;
    public AuthHandler(HttpClient client, IJSRuntime jsRuntime)
    {
        _client = client;
        _jsRuntime = jsRuntime;
    }
    public async Task<Response<LoginResponseJson>> LoginAsync(LoginRequestJson request) 
    {
        await DeleteCoookie();

        var response = await _client.PostAsJsonAsync("api/autenticacao/login", request);

        if (response.IsSuccessStatusCode)
        {
            var user = await response.Content.ReadFromJsonAsync<Response<LoginResponseJson>>();

            var nameParts = user!.Data!.Nome.Split(' ');
            var firstName = nameParts.First();
            var lastName = nameParts.Length > 1 ? nameParts.Last() : string.Empty;

            var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1) };

            await _jsRuntime.InvokeVoidAsync("blazorExtensions.writeCookie", "FirstName", firstName, cookieOptions.Expires);
            await _jsRuntime.InvokeVoidAsync("blazorExtensions.writeCookie", "LastName", lastName, cookieOptions.Expires);
            await _jsRuntime.InvokeVoidAsync("blazorExtensions.writeCookie", "Cpf", user.Data.Cpf, cookieOptions.Expires);
            await _jsRuntime.InvokeVoidAsync("blazorExtensions.writeCookie", "Perfil", user.Data.Perfil, cookieOptions.Expires);


            return new Response<LoginResponseJson>(null, 200, user.Message);
        }

        return new Response<LoginResponseJson>(null, 400, "Erro ao efetuar login");
    }
    public async Task<bool> LogoutAsync()
    {
        var response = await _client.PostAsync("api/autenticacao/logout", null);

        if (response.IsSuccessStatusCode)
        {
            await DeleteCoookie();

            return true;
        }

        return false;
    }
    public async Task<UsuarioDto?> GetUserAsync()
    {
        var result = await _jsRuntime.InvokeAsync<string>("eval", "document.cookie");
        var userDto = new UsuarioDto();
        //TRATAR CASO VENHA NULL
        if (string.IsNullOrEmpty(result))
        {
            userDto.FirstName = "";
            userDto.LastName = "";
            userDto.Perfil = "";
            userDto.Cpf = "";
            return userDto;
        }
        else 
        {
            var cookies = result.Split(';');

            foreach (var cookie in cookies)
            {
                var parts = cookie.Split('=');
                var key = parts[0].Trim();
                var value = parts[1].Trim();

                switch (key)
                {
                    case "FirstName":
                        userDto.FirstName = value;
                        break;
                    case "LastName":
                        userDto.LastName = value;
                        break;
                    case "Perfil":
                        userDto.Perfil = value;
                        break;
                    case "Cpf":
                        userDto.Cpf =value;
                        break;
                }
            }

            return userDto;
        }
    }
    public async Task<Response<VerificaAutenticacaoResponseJson>> GetAuthenticationStateAsync()
    {
        var response = await _client.PostAsync("api/autenticacao/verificar", null);

        var status = await response.Content.ReadFromJsonAsync<Response<VerificaAutenticacaoResponseJson>>();

        var isAuthenticated = status!.Data!.IsAuthenticated;

        if (!isAuthenticated)
        {
            await DeleteCoookie();

            return status;
        }

        return status;
    }
    public async Task DeleteCoookie() 
    {
        await _jsRuntime.InvokeVoidAsync("blazorExtensions.deleteCookie", "FirstName");
        await _jsRuntime.InvokeVoidAsync("blazorExtensions.deleteCookie", "LastName");
        await _jsRuntime.InvokeVoidAsync("blazorExtensions.deleteCookie", "Cpf");
        await _jsRuntime.InvokeVoidAsync("blazorExtensions.deleteCookie", "Perfil");
    }
    public async Task Voltar() 
    {
        await _jsRuntime.InvokeVoidAsync("blazorExtensions.navigateBack");
    }
}
