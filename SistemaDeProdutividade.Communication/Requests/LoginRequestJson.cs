using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Communication.Requests;
public record LoginRequestJson(string Cpf, string Senha);
