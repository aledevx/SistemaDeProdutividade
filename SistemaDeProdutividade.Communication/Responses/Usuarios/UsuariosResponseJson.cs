using SistemaDeProdutividade.Communication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Communication.Responses.Usuarios;
public class UsuariosResponseJson 
{
    public IList<IndexUsuarioVM> Usuarios { get; set; } = [];
    public UsuariosResponseJson(IList<IndexUsuarioVM> usuarios)
    {
        Usuarios = usuarios;
    }
}
