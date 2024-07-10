namespace SistemaDeProdutividade.Web.Models;

public class UsuarioIndex
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Matricula { get; set; }
    public int Numero { get; set; }
    public UsuarioIndex(Guid id, string nome, string cpf, string matricula, int numero)
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
        Matricula = matricula;
        Numero = numero;
    }
}
