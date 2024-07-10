using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Web.Components;
using SistemaDeProdutividade.Web.DTOs;
using SistemaDeProdutividade.Web.DTOs.Atividades;
using SistemaDeProdutividade.Web.Handlers;
using SistemaDeProdutividade.Web.Responses;

namespace SistemaDeProdutividade.Web.Pages;

public partial class PontuarProdutividadePage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public ProdutividadeFeitaResponseJson InputModel { get; set; } = new();
    public DateRange selectedDateRange;
    public DateTime today = DateTime.Now;
    public UsuarioDto? usuarioLogado;
    public List<AtividadePontuadaWebDTO> Atividades { get; set; } = [];
    public int NumAtv = 1;

    #endregion
    #region Services

    [Inject]
    public ProdutividadeHandler prodHandler { get; set; } = null!;
    [Inject]
    public AuthHandler authHandler { get; set; } = null!;
    [Inject]
    public NavigationManager navigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;

    #endregion
    #region Methods
    private void OnDateRangeChanged()
    {
        if (selectedDateRange.End.HasValue)
        {
            selectedDateRange = new DateRange(selectedDateRange.Start, today);
        }
    }

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            if (selectedDateRange.Start.HasValue && selectedDateRange.End.HasValue) 
            {
                InputModel.DataInicio = selectedDateRange!.Start!.Value.Date;
                InputModel.DataFim = selectedDateRange!.End!.Value.Date;

                InputModel.Atividades = Atividades
                    .Select(a => new Communication.DTOs.Atividades.AtividadePontuadaDTO(a.Descricao, a.Pontuacao, a.Qtd)).ToList();
                
                var result = await prodHandler.PontuarProdutividadeAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add("Produtividade pontuada com sucesso!", Severity.Success);
                    navigationManager.NavigateTo("/produtividades/");
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
    protected override async Task OnInitializedAsync()
    {

        try
        {
            usuarioLogado = await authHandler.GetUserAsync();
            var result = await prodHandler.DataProdParaPontuarAsync(usuarioLogado!.Cpf);
            if (result.IsSuccess)
            {
                var data = result.Data as ProdutividadeFeitaResponseJson;
                InputModel = data!;
                Atividades = InputModel.Atividades
                    .Select(a => new AtividadePontuadaWebDTO(NumAtv++, a.Descricao, a.Pontuacao, a.Qtd))
                    .ToList();
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    public async Task OpenDialog() 
    {
        var parameters = new DialogParameters();
        var options = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        var dialog = DialogService.Show<PontuarProdDialog>("Atenção!", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled && (bool)result.Data == true)
        {
            await OnValidSubmitAsync();
        }
    }
    public void Voltar() 
    {
        navigationManager.NavigateTo("/");
    }
    #endregion
}
