using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetosLivros.Interface;
using ProjetosLivros.Models;

namespace ProjetosLivros.Control
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        //inejtar o repository
        private readonly ICategoriaRepository _repository;

        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var catergorias = _repository.ListarTodos();
            return Ok(catergorias);
        }

        [HttpPost]
        public IActionResult Cadastrar(Categoria categoria)
        {
            _repository.Cadastrar(categoria);
            return Created();
        }

    }
}
