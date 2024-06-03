using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace APITeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        public CategoriaController()
        {

        }


    
        [HttpPost()]
        public Categoria Get([FromBody] Categoria categoria)
        {
            return categoria;
        }
    }
}
