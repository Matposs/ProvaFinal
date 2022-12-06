using System.Collections.Generic;
using System.Linq;
using API_Imc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Utils;

namespace api.Controllers
{
    [ApiController]
    [Route("api/imc")]
    public class ImcController : ControllerBase
    {
        private readonly Context _context;
        public ImcController(Context context) =>
            _context = context;

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Imc imc)
        {
            imc.ResultadoImc = 
            Calculos.CalcularImc
            (imc.altura, imc.peso);
            _context.imcs.Add(imc);
            _context.SaveChanges();
            return Created("", imc);
        }

        [HttpPut]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] Imc imc)
        {
            _context.imcs.Update(imc);
            _context.SaveChanges();
            return Created("", imc);
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            List<Imc> Imcs = _context.imcs.ToList();
            return Imcs.Count != 0 ? Ok(Imcs) : NotFound();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            Imc imc = _context.imcs.
                Include(x => x.Id).
                FirstOrDefault(
                    x => x.Id.Equals(id)
                );
            return imc != null ? Ok(imc) : NotFound();
        }

    }
}