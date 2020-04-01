using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Locadora.API
{
    public class Program
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public Program(IUsuarioRepository usuarioRepository)
        {

            Usuario usuario = new Usuario();
            usuario.Nome = "Ricardo Albino";
            usuario.Telefone = "9733011843";
            usuario.email = "cadu@gmail.com";

            _usuarioRepository = usuarioRepository;
            _usuarioRepository.adicionarAsync(usuario);


        }

        public static void Main(string[] args)
        {


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
