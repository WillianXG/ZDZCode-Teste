using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace APITeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        public static List<Categoria> CategoriaLista = new List<Categoria>();

        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return CategoriaLista.ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            categoria.Id = CategoriaLista.Count > 0 ? CategoriaLista.Max(c => c.Id) + 1 : 1;
            CategoriaLista.Add(categoria);
            return CreatedAtAction(nameof(Get), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Categoria categoria)
        {
            var existingCategoria = CategoriaLista.FirstOrDefault(c => c.Id == id);
            if (existingCategoria == null)
            {
                return NotFound();
            }

            existingCategoria.Nome = categoria.Nome;
            existingCategoria.Descricao = categoria.Descricao;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoria = CategoriaLista.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            CategoriaLista.Remove(categoria);
            return NoContent();
        }
    }
}
