using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using curso_aspnet.Models;
using Newtonsoft.Json;

public class DBInMemory : IContextDB
{
    private const string objs = @"
[
  {
    'id': 1,
    'descricao': 'Turma 1',
    'quantidadeVagas': 10,
    'modalidadeEsportiva': 'Natação',
    'alunos': [
      {
        'id': 2,
        'nome': 'Isaac Jr',
        'eMail': 'user@example.com',
        'dataNascimento': '2021-11-13T18:15:29.342Z'
      },
      {
        'id': 1,
        'nome': 'ISaac',
        'eMail': 'user@example.com',
        'dataNascimento': '2021-11-13T18:15:29.342Z'
      }
    ]
  },
  {
    'id': 2,
    'descricao': 'Turma 2',
    'quantidadeVagas': 10,
    'modalidadeEsportiva': 'Natação',
    'alunos': [
      {
        'id': 1,
        'nome': 'ISaac',
        'eMail': 'user@example.com',
        'dataNascimento': '2021-11-13T18:15:29.342Z'
      },
      {
        'id': 3,
        'nome': 'ISaac',
        'eMail': 'user@example.com',
        'dataNascimento': '2021-11-13T18:15:29.342Z'
      },
      {
        'id': 4,
        'nome': 'ISaac',
        'eMail': 'user@example.com',
        'dataNascimento': '2021-11-13T18:15:29.342Z'
      }
    ]
  },
  {
    'id': 3,
    'descricao': 'Turma 3',
    'quantidadeVagas': 10,
    'modalidadeEsportiva': 'Natação',
    'alunos': []
  },
  {
    'id': 4,
    'descricao': 'Turma 4',
    'quantidadeVagas': 10,
    'modalidadeEsportiva': 'Natação',
    'alunos': []
  },
  {
    'id': 5,
    'descricao': 'Turma 4',
    'quantidadeVagas': 10,
    'modalidadeEsportiva': 'Natação',
    'alunos': []
  },
  {
    'id': 6,
    'descricao': 'Turma 6',
    'quantidadeVagas': 10,
    'modalidadeEsportiva': 'Natação',
    'alunos': []
  },
  {
    'id': 7,
    'descricao': 'Turma 7',
    'quantidadeVagas': 10,
    'modalidadeEsportiva': 'Natação',
    'alunos': []
  }
]";

    public DBInMemory()
    {
        _turmas = JsonConvert.DeserializeObject<List<Turma>>(objs);
        _usuarios = _turmas.SelectMany(t => t.Alunos).Distinct().ToList();
    }
    private List<Usuario> _usuarios;
    private List<Turma> _turmas;

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

    public Turma ObterTurma(int id)
    {
        return _turmas.Where(t => t.Id == id).SingleOrDefault();
    }

    public IEnumerable<Turma> ObterTurmas()
    {
        return _turmas.ToList();
    }

    public Usuario ObterUsuario(int id)
    {
        return _usuarios.Where(t => t.Id == id).SingleOrDefault();
    }

    public IEnumerable<Usuario> ObterUsuarios()
    {
        return _usuarios.ToList();
    }
}
