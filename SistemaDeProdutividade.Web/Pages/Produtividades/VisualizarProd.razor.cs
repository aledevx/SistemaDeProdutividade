using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaDeProdutividade.Communication.DTOs.Assinaturas;
using SistemaDeProdutividade.Communication.Requests.Assinaturas;
using SistemaDeProdutividade.Communication.Requests.Produtividades;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Communication.Responses.Produtividades;
using SistemaDeProdutividade.Web.Components;
using SistemaDeProdutividade.Web.DTOs;
using SistemaDeProdutividade.Web.DTOs.Atividades;
using SistemaDeProdutividade.Web.Handlers;

namespace SistemaDeProdutividade.Web.Pages;

public partial class VisualizarProdPage : ComponentBase
{
    #region Properties
    [Parameter] public Guid Id { get; set; }
    public bool IsBusy { get; set; } = false;
    public UsuarioDto? usuarioLogado;
    public string? observacaoRecebida;
    public int selectedPercentual;
    public int[] percentualValues = { 30, 50, 70, 100 };
    public ProdutividadeFeitaResponseJson ProdFeita { get; set; } = new();
    public List<AtividadePontuadaWebDTO> Atividades { get; set; } = [];
    public List<AssinaturaDTO> Assinaturas { get; set; } = [];
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
    protected override async Task OnInitializedAsync()
    {

        try
        {
            usuarioLogado = await authHandler.GetUserAsync();
            var result = await prodHandler.BuscarProdFeita(Id);
            if (result.IsSuccess)
            {
                var data = result.Data as ProdutividadeFeitaResponseJson;
                ProdFeita = data!;
                if (!(string.IsNullOrEmpty(data!.Observacao))) 
                {
                    ProdFeita.AddObservacao(data.Observacao);
                }
                Atividades = ProdFeita.Atividades
                    .Select(a => new AtividadePontuadaWebDTO(NumAtv++, a.Descricao, a.Pontuacao, a.Qtd))
                    .ToList();
                Assinaturas = ProdFeita.Assinaturas.Select(a => new AssinaturaDTO(a.NomeAssinante,
                    a.CargoAssinante,
                    a.DataAssinatura)).ToList();
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    public async Task ChefeAssinarProdSubmit()
    {
        IsBusy = true;

        try
        {
            var request = new AssinarProdutividadeRequestJson(Id, usuarioLogado!.Cpf, selectedPercentual);
            var result = await prodHandler.AssinarProdAsync(request);
            if (result.IsSuccess)
            {
                Snackbar.Add("Produtividade assinada com sucesso!", Severity.Success);
                navigationManager.NavigateTo("/produtividades/recebido");
            }
            else
            {
                var error = result.Data as MensagemSucessoResponseJson;
                
                Snackbar.Add(error!.Mensagem, Severity.Error);
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
    public async Task DevolverProdSubmit()
    {
        try
        {
            var request = new FinalizarProdutividadeRequestJson(Id, observacaoRecebida, usuarioLogado!.Cpf, Domain.Enums.StatusProdutividade.Devolvida);
            var response = await prodHandler.FinalizarProdAsync(request);
            if (response.IsSuccess)
            {
                Snackbar.Add(response.Message, Severity.Success);
                navigationManager.NavigateTo("/produtividades/recebido");
            }
            else
            {
                Snackbar.Add(response.Message, Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    public async Task FinalizarProdSubmit()
    {
        try
        {
            var request = new FinalizarProdutividadeRequestJson(Id, null, usuarioLogado!.Cpf, Domain.Enums.StatusProdutividade.Finalizada);
            var response = await prodHandler.FinalizarProdAsync(request);
            if (response.IsSuccess)
            {
                Snackbar.Add(response.Message, Severity.Success);
                navigationManager.NavigateTo("/produtividades/recebido");
            }
            else
            {
                Snackbar.Add(response.Message, Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    public async Task OpenDialogAssinar()
    {
        var parameters = new DialogParameters();
        var dialog = DialogService.Show<AssinarProdDialog>("Atenção!", parameters);
        var result = await dialog.Result;

        if (!result.Canceled && (bool)result.Data == true)
        {
            await ChefeAssinarProdSubmit();
        }
    }
    public async Task OpenDialogFinalizar()
    {
        var parameters = new DialogParameters();
        var dialog = DialogService.Show<FinalizarProdDialog>("Atenção!", parameters);
        var result = await dialog.Result;

        if (!result.Canceled && (bool)result.Data == true)
        {
            await FinalizarProdSubmit();
        }
    }
    public async Task OpenDialogDevolver()
    {
        var parameters = new DialogParameters();
        parameters.Add("OnConfirm", EventCallback.Factory.Create<string>(this, OnConfirm));

        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };
        var dialog = DialogService.Show<DevolverProdDialog>("Atenção!", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await DevolverProdSubmit();
        }
    }
    public Task OnConfirm(string observacao)
    {
        observacaoRecebida = observacao;
        return Task.CompletedTask;
    }
    public async void Voltar() 
    {
        await authHandler.Voltar();
    }
    #endregion
}
