using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Communication.ViewModel;
public record IndexUsuarioVM(Guid Id, string Nome, string Cpf, string Matricula);
