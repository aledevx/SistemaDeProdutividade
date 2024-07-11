using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.DTOs.Atividades;
using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Web.Handlers;
using System.Globalization;

namespace SistemaDeProdutividade.Web.Pages;

public partial class CadastrarProdutividadePage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public CultureInfo _br = CultureInfo.GetCultureInfo("pt-BR");
    public int numContador = 0;
    public string newTaskDescription = string.Empty;
    public int newTaskQuantity = 1;
    public string Cargo = string.Empty;
    public decimal ValorProd;
    public List<AtividadeDTO> todoAtividades = new List<AtividadeDTO>();
    #endregion


    #region Services

    [Inject]
    public ProdutividadeHandler Handler { get; set; } = null!;
    [Inject]
    public AuthHandler authHandler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var inputData = new CadastrarProdutividadeRequestJson(Cargo, ValorProd, todoAtividades);
            var result = await Handler.CadastrarMapaAsync(inputData);
            if (result.IsSuccess)
            {
                Snackbar.Add("Mapa de produtividade cadastrado com sucesso!", Severity.Success);
                NavigationManager.NavigateTo("/produtividades/mapas");
            }
            else
            {
                var errors = result.Data as ListErrorsResponseJson;
                foreach (var error in errors!.Errors)
                {
                    Snackbar.Add(error, Severity.Error);
                }
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }
    public void AddTask()
    {
        if (!string.IsNullOrWhiteSpace(newTaskDescription) && newTaskQuantity >= 1)
        {
            numContador++;
            todoAtividades.Add(new AtividadeDTO(newTaskDescription, newTaskQuantity));
            newTaskDescription = string.Empty;
            newTaskQuantity = 1;
        }
    }

    public void RemoveTask(AtividadeDTO atividade)
    {
        todoAtividades.Remove(atividade);
    }

    public async void Voltar()
    {
        await authHandler.Voltar();
    }

    #endregion

}
