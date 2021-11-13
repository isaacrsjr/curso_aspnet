using System.Collections.Generic;
using curso_aspnet.Models;

public interface IContextDB
{
    void AdicionarUsuario(Usuario newUsuario);
    IEnumerable<Usuario> ObterUsuarios();
    int ObterProximoUsuarioID();

    void AdicionarTurma(Turma newTurma);
    IEnumerable<Turma> ObterTurmas();
    int ObterProximoTurmaID();
}