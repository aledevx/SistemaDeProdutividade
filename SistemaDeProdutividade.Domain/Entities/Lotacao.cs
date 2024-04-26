namespace SistemaDeProdutividade.Domain.Entities;
public class Lotacao
{
    public Guid Id { get; set; }
    public Guid? UsuarioId { get; private set; }
    public Guid SetorId { get; private set; }
    public Guid CargoId { get; private set; }
    public DateTime DataLotacao { get; set; } = DateTime.Now;
    public Guid UsuarioQueLotouId { get; private set; }
}
