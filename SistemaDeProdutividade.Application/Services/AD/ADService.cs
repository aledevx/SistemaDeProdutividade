using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Application.Services.AD;
public class ADService
{
    public const string Dominio = "rondonia.local";
    public const string UsuarioDeDominio = "meajudati";
    public const string SenhaDeDominio = "cgti@123";

    internal bool LoginValido(string cpf, string senha)
    {
        using (var rondoniaLocal = new PrincipalContext(ContextType.Domain, Dominio, UsuarioDeDominio, SenhaDeDominio))
            return rondoniaLocal.ValidateCredentials(cpf, senha);
    }

    internal UserPrincipal BuscarUsuario(string cpf)
    {
        using (var rondoniaLocal = new PrincipalContext(ContextType.Domain, Dominio, UsuarioDeDominio, SenhaDeDominio))
            return UserPrincipal.FindByIdentity(rondoniaLocal, cpf);
    }
}
