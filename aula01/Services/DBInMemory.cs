using System.Collections.Generic;
using System.Linq;
using curso_aspnet.Models;

public class DBInMemory : IContextDB
{
    private List<Usuario> _usuarios = new List<Usuario>();
    public void AdicionarUsuario(Usuario newUsuario)
    {
        _usuarios.Add(newUsuario);
    }

    public int ObterProximoUsuarioID()
    {
        var ultimoUsuario = _usuarios.OrderByDescending(u => u.Id).FirstOrDefault();
        return (ultimoUsuario != null ? ultimoUsuario.Id : 0) + 1;
    }

    public IEnumerable<Usuario> ObterUsuarios()
    {
        return _usuarios.ToList();
    }
}
