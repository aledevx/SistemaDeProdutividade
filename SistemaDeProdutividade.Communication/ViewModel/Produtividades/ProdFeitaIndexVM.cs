using SistemaDeProdutividade.Domain.Enums;

namespace SistemaDeProdutividade.Communication.ViewModel.Produtividades;
public record ProdFeitaIndexVM(Guid Id,
    int Numero,
    string Codigo,
    string NomeUsuario,
    string Cargo,
    string Matricula,
    string Lotacao,
    DateTime DataCriacao,
    StatusProdutividade Status,
    Guid UsuarioId);
