using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Locadora.App.Controllers
{
    public class FilmeFiltrosController : Controller
    {

        private readonly IFilmeRepository _filmeRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public FilmeFiltrosController(IFilmeRepository filmeRepository, IUsuarioRepository usuarioRepositor)
        {

            _filmeRepository = filmeRepository;
            _usuarioRepository = usuarioRepositor;
        }

        [HttpGet]
        public async Task<IActionResult> Index(FiltrarFilmes filtrarFilmes)
        {


            if (filtrarFilmes.Genero == null)
            {
                ViewBag.ListarFilmes = await _filmeRepository.ObterTodos() as List<Filme>;
            }
            else
            {
                Filme _filme = new Filme();

                List<Filme> filmeList = new List<Filme>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:44353/api/locadora/Filme/" + filtrarFilmes))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        _filme = JsonConvert.DeserializeObject<Filme>(apiResponse);

                    }
                }


                ViewBag.ListarFilmes = _filme;   //_filmeRepository.ObterFilmePorGenero(filtrarFilmes.Genero, filtrarFilmes.DataLançamento) as List<Filme>;
            }



            return View();
      
        }
    }
}