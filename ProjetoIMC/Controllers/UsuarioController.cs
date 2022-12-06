using System.Collections.Generic;
using System.Linq;
using API_Imc.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly Context _context;
        public UsuarioController(Context context) =>
            _context = context;

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            _context.usuarios.Add(usuario);
            _context.SaveChanges();
            return Created("", usuario);
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            List<Usuario> Usuarios = _context.usuarios.ToList();
            return Usuarios.Count != 0 ? Ok(Usuarios) : NotFound();
        }

    }
}