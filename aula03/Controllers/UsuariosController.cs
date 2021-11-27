using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using curso_aspnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace curso_aspnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IContextDB _contextDB;

        public UsuariosController(IContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        [HttpPost]
        public ActionResult Cadastrar([FromBody] PostNewUsuarioDTO newUsuario)
        {
            Usuario usr = new Usuario()
            {
                Id = _contextDB.ObterProximoUsuarioID(),
                Nome = newUsuario.Nome,
                EMail = newUsuario.EMail,
                DataNascimento = newUsuario.DataNascimento
            };
            _contextDB.AdicionarUsuario(usr);
            return Ok(usr);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            return Ok(_contextDB.ObterUsuarios());
        }

        [HttpPost("Inscrever")]
        public ActionResult<Turma> InscreverAluno(int idTurma, int idAluno)
        {
            Turma turma = _contextDB.ObterTurma(idTurma);
            if (turma == null) return BadRequest("Turma não encontrada");

            Usuario aluno = _contextDB.ObterUsuario(idAluno);
            if (aluno == null) return BadRequest("Aluno/Usuário não encontrado!");

            turma.AdicionarAluno(aluno);
            return Ok(turma);
        }
    }
}