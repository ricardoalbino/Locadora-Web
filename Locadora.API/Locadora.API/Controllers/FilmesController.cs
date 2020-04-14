using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.API.Controllers
{
    [ApiController]
    [Route("api/locadora/[controller]")]
    public class FilmesController : Controller
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmesController(IFilmeRepository filmeRepository)
        {

            _filmeRepository = filmeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Filme>> ObterTodos()
        {
            var usuario = await _filmeRepository.ObterTodos();

            return usuario;
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Filme>> ObterPorId(Guid id)
        {
            var filme = await _filmeRepository.ObterPorId(id);

            if (filme == null) NotFound();


            return filme;
        }


        ////https://localhost:44353/api/locadora/Filmes/GetPor
        //[HttpGet, Route("GetPor/{genero}")]
        //public string ObterFilmePorGeneroOuDataOuNome2(string genero)
        //{

        //    return "GetPor Ok!" + genero;
        //}

        //https://localhost:44353/api/locadora/Filmes/GetPor/
        [HttpGet,Route("GetPor/{genero}/{dataLancamento:DateTime}")]
       
        public async Task<IEnumerable<Filme>> ObterFilmePorGeneroOuDataOuNome(string genero, DateTime? dataLancamento)
        {
            var filme = await _filmeRepository.ObterFilmePorGeneroEDataDeLancamento(genero, dataLancamento);

            if (filme == null) NotFound();

            //2012-10-23 09:23
            return filme;
        }
        // POST: Usuario/Create
        [HttpPost]
        public ActionResult<Usuario> Create(Filme filme)
        {

            if (!ModelState.IsValid) return BadRequest();

            string resultado = _filmeRepository.adicionarAsync(filme).ToString();

            if (resultado == null) BadRequest();

            return Ok();
        }




        //https://localhost:44353/api/locadora/Usuarios/5
        [HttpDelete("{id:Guid}")]
        public ActionResult Delete(Guid id)
        {
            var filme = _filmeRepository.ObterPorId(id);
            if (filme == null) return NotFound();

            var result = _filmeRepository.Remover(id);

            if (result == null) return BadRequest();

            return Ok(filme);
        }
    }
}