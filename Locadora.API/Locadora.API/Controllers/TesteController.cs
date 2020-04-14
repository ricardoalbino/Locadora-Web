using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.API.Controllers
{
    [ApiController]
    [Route("api/locadora/[controller]")]
    public class TesteController : ControllerBase
    {
        // GET: api/Teste
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Teste/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Teste
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Teste/5
        [HttpPut,  Route("put/{id}")]
        public string Put(int id)
        {
            return "Put Ok - > " + id;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
