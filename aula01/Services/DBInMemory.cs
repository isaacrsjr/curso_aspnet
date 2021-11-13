using System.Collections.Generic;
using System.Linq;
using curso_aspnet.Models;

public class DBInMemory : IContextDB
{
    private List<Usuario> _usuarios = new List<Usuario>();
    private List<Turma> _turmas = new List<Turma>();

    public void AdicionarTurma(Turma newTurma)
    {
        _turmas.Add(newTurma);
    }

    public void AdicionarUsuario(Usuario newUsuario)
    {
        _usuarios.Add(newUsuario);
    }

    public int ObterProximoTurmaID()
    {
        var ultimaTurma = _turmas.OrderByDescending(u => u.Id).FirstOrDefault();
        return (ultimaTurma != null ? ultimaTurma.Id : 0) + 1;
    }

    public int ObterProximoUsuarioID()
    {
        var ultimoUsuario = _usuarios.OrderByDescending(u => u.Id).FirstOrDefault();
        return (ultimoUsuario != null ? ultimoUsuario.Id : 0) + 1;
    }

    public IEnumerable<Turma> ObterTurmas()
    {
        return _turmas.ToList();
    }

    public IEnumerable<Usuario> ObterUsuarios()
    {
        return _usuarios.ToList();
    }
}
