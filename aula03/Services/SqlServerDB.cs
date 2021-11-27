using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using curso_aspnet.Models;
using Microsoft.Extensions.Configuration;

namespace curso_aspnet.Services
{
    public class SqlServerDB: IContextDB
    {
        private readonly string _cs;

        public SqlServerDB(IConfiguration config)
        {
            _cs = config.GetConnectionString("curso-asp");
        }

        public void AdicionarTurma(Turma newTurma)
        {
            using (SqlConnection cn = new SqlConnection(_cs))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Turmas (Descricao, QuantidadeVagas) VALUES (@descr, @qtdVagas)", cn);
                cmd.Parameters.Add("@descr", System.Data.SqlDbType.VarChar, 50).Value = newTurma.Descricao;
                // ...
                cn.Open();
                _ = cmd.ExecuteNonQuery();
            }
        }

        public void AdicionarUsuario(Usuario newUsuario)
        {
            throw new NotImplementedException();
        }

        public int ObterProximoTurmaID()
        {
            throw new NotImplementedException();
        }

        public int ObterProximoUsuarioID()
        {
            throw new NotImplementedException();
        }

        public Turma ObterTurma(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Turma> ObterTurmas()
        {
            throw new NotImplementedException();
        }

        public Usuario ObterUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObterUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}
