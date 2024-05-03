using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Exception.ExceptionsBase;
public class ErrorOnValidationException : SistemaProdutividadeException
{
    public IList<string> ErrorMessages { get; set; }
    public ErrorOnValidationException(IList<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}
