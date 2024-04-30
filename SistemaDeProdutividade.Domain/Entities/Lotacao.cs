namespace SistemaDeProdutividade.Domain.Entities;
public class Lotacao
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid SetorId { get; set; }
    public Guid CargoId { get; set; }
    public DateTime DataLotacao { get; set; } = DateTime.Now;
    public Guid UsuarioQueLotouId { get; set; }
}
