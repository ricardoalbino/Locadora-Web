using Locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        Task<IEnumerable<Filme>> ObterFilmePorDataDeLancamento(DateTime data);

        Task<IEnumerable<Filme>> ObterFilmePorGenero(string genero);

        Task<IEnumerable<Filme>> ObterFilmeComUsuario();


        Task<IEnumerable<Filme>> ObterFilmePorGeneroEDataDeLancamento(string genero,DateTime? data);


    }
}
