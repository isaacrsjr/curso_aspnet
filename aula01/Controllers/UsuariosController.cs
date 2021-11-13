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
            Usuario usr = new Usuario(){
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
    }
}