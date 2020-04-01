using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Context;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Locadora.Test
{

    class TestCrudUsuario
    {
        private readonly DataContext _context;
        private  IUsuarioRepository _usuarioRepository;


       // UsuarioRepository usuarioRepository = new UsuarioRepository(_usuarioRepository);

        Usuario usuario = null;

        public TestCrudUsuario(IUsuarioRepository usuarioRepository)
        {

            _usuarioRepository = usuarioRepository;
        }

        public TestCrudUsuario()
        {

        }

        [SetUp]
        public void Setup()
        {
        }



        [Test]
        public void addUsuario()
        {


            Usuario usuario = new Usuario();

           

            usuario.Nome = "Testando 1";
            usuario.Telefone = "1173301843";
            usuario.email = "ca@gmail.com";

            var resultado  = _usuarioRepository.adicionarAsync(usuario);

            NUnit.Framework.Assert.Equals(false, resultado);

           
        }

        [Test]
        public  async Task filtrarPorId()
        {
            
            Guid id = new Guid("FB0F9D03-A283-49EF-8716-5EE07E5ED167");

            var resultado =  await _usuarioRepository.ObterPorId(id);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Equals(true, resultado);

        }
    }
}