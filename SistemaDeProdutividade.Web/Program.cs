using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SistemaDeProdutividade.Web;
using SistemaDeProdutividade.Web.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(WebConfiguration.BackendUrl) });

builder.Services.AddTransient<UsuarioHandler>();
builder.Services.AddScoped<AuthHandler>();


await builder.Build().RunAsync();
