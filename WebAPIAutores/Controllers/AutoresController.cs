using Microsoft.AspNetCore.Mvc;
using WebAPIAutores.Common.Entities;

namespace WebAPIAutores.Controllers
{

    public class AutoresController : BaseApiController
    {
        public AutoresController()
        { }
        [HttpGet]
        public async Task<ActionResult<List<Autor>>> GetAutor()
        {
           return new List<Autor>() { 
             new Autor{ Id = 1, Nombre="Draco"},
             new Autor{ Id = 2, Nombre="Master"},
             new Autor{ Id = 3, Nombre="Balder"},
             new Autor{ Id = 4, Nombre="Draco Master"},

           };
        }
    }
}
