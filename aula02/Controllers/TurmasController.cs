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
    public class TurmasController : ControllerBase
    {
        private readonly IContextDB _contextDB;

        public TurmasController(IContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        [HttpPost]
        public ActionResult Cadastrar([FromBody] PostNewTurmaDTO newTurma)
        {
            Turma turma = new Turma(){
                Id = _contextDB.ObterProximoTurmaID(),
                Descricao = newTurma.Descricao,
                QuantidadeVagas = newTurma.QuantidadeVagas,
                ModalidadeEsportiva = newTurma.ModalidadeEsportiva
            };
            _contextDB.AdicionarTurma(turma);
            return Ok(turma);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Turma>> Get()
        {
            return Ok(_contextDB.ObterTurmas());
        }
    }
}