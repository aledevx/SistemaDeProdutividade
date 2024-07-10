using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Communication.ViewModel.Produtividades;
public class CargoIndexVM
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public CargoIndexVM(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}
