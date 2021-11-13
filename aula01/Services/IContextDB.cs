using System.Collections.Generic;
using curso_aspnet.Models;

public interface IContextDB
{
    void AdicionarUsuario(Usuario newUsuario);
    IEnumerable<Usuario> ObterUsuarios();
    int ObterProximoUsuarioID();
}