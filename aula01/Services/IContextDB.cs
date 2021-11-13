using System.Collections.Generic;
using curso_aspnet.Models;

public interface IContextDB
{
    void AdicionarUsuario(Usuario newUsuario);
    IEnumerable<Usuario> ObterUsuarios();
    int ObterProximoUsuarioID();
    Usuario ObterUsuario(int id);

    void AdicionarTurma(Turma newTurma);
    IEnumerable<Turma> ObterTurmas();
    int ObterProximoTurmaID();
    Turma ObterTurma(int id);
}