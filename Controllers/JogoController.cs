using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Prova.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Prova.Controllers
{
    [Route("api/jogos")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        //injeção de dependecia
        private readonly DataContext _context;
        public JogoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return Ok(_context.Jogos.Include(j => j.CategoriadeJogo).ToList());

        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Jogo jogo)
        {
            _context.Jogos.Add(jogo);
            _context.SaveChanges();
            return Created("", jogo);
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int Id)
        {

            foreach (Jogo jogo in _context.Jogos.ToList())
            {
                if (jogo.Id == Id)
                {
                    return Ok(jogo);
                }
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public IActionResult Excluir([FromRoute] int id)
        {
            foreach (var jogo in _context.Jogos.ToList())
            {
                if (jogo.Id == id)
                {
                    _context.Jogos.Remove(jogo);
                    _context.SaveChanges();
                    return Ok(jogo);
                }

            }

            return NotFound();
        }

        [HttpPatch]
        [Route("editar")]
        public IActionResult Editar([FromBody] Jogo jogo)
        {
            foreach (var jogo_cadastrado in _context.Jogos.ToList())
            {
                if (jogo_cadastrado.Id == jogo.Id)
                {
                    jogo_cadastrado.Nome = jogo.Nome;
                    jogo_cadastrado.Desenvolvedor = jogo.Desenvolvedor;
                    jogo_cadastrado.Preco = jogo.Preco;
                    jogo_cadastrado.CategoriadeJogoId = jogo.CategoriadeJogoId;
                    _context.Jogos.Update(jogo_cadastrado);
                    _context.SaveChanges();
                    return Ok(jogo_cadastrado);
                }

            }

            return NotFound();
        }

    }

}