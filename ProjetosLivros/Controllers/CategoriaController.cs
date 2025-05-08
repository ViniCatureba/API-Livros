using System.Data;
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

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Categoria categoria)
        {
            _repository.Cadastrar(categoria);
            return Created();
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            _repository.Deletar(id);
            return NoContent();
        }

        [HttpPut("atualizar/{id}")]
        public IActionResult atualizar(int id, Categoria categoria) 
        {
            _repository.Atualizar(id, categoria);
            return Ok();
        }

        [HttpGet("Listartodos/")]
        public IActionResult ListarTodos()
        {
            var catergorias = _repository.ListarTodos();
            return Ok(catergorias);
        }

        [HttpGet("buscarcategoriaporid/{id}")]
        public IActionResult BuscarCategoriaPorId(int id)
        {
            _repository.BuscarCategoriaPorId(id);
            return Ok();
        }

        [HttpGet("BuscarCategoriaPorNome/{nome}")]
        public IActionResult BuscarCategoriaPorNome(string nome)
        {
            _repository.BuscarCategoriaPorNome(nome);
            return Ok();
        }

        [HttpGet("ListarTodosAsync")]
        public async Task<IActionResult> ListarTodosAsync()
        {
            var categorias = await _repository.ListarTodosAsync();
            return Ok(categorias);
        }




    }
}


