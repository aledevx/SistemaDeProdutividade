using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Exception.ExceptionsBase;
public class NotFoundException : SistemaProdutividadeException
{
    public string ErrorMessage { get; set; }
    public NotFoundException(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}
