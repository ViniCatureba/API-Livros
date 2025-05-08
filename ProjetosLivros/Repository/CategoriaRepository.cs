using Microsoft.EntityFrameworkCore;
using ProjetosLivros.Context;
using ProjetosLivros.Interface;
using ProjetosLivros.Models;

namespace ProjetosLivros.Repository
{
    // 1 - Herdar e implementar a interface
  
    public class CategoriaRepository : ICategoriaRepository
    {
        // 2 - Injetar o contexto
        private readonly LivrosContext _context;

        public CategoriaRepository(LivrosContext context)
        {
            _context = context;
        }
        public Categoria? Atualizar(int id, Categoria categoria)
        {
            //find so funciona com primary key
            var encontrarCategoria = _context.Categorias.Find(id);
            if (encontrarCategoria == null) { return null; }
            encontrarCategoria.NomeCategoria = categoria.NomeCategoria;
            _context.SaveChanges();
            return encontrarCategoria;
        }

        public List<Categoria> BuscarCategoriaPorId(int id)
        {
            var listaClienteId = _context.Categorias.Where(c => c.CategoriaId ==id).ToList();
            return listaClienteId;
        }

        public List<Categoria> BuscarCategoriaPorNome(string nome)
        {
            var listaCategoriaNome = _context.Categorias.Where(c => c.NomeCategoria == nome).ToList();
            return listaCategoriaNome;
        }

        public void Cadastrar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public Categoria? Deletar(int id)
        {
            //1- Procuro quem vou apagar
            
         //find so funciona com primary key
            var encontrarCategoria = _context.Categorias.Find(id);
            //2 - Se nao achar, retorna nulo, ou erro
            if (encontrarCategoria == null) return null;
            //3- Se achei apago
            _context.Categorias.Remove(encontrarCategoria);
            _context.SaveChanges();
            return encontrarCategoria;
        }

        public List<Categoria> ListarTodos()
        { //orderby ordem alfabetica
            return _context.Categorias.OrderBy(c => c.NomeCategoria).ToList();
        }

        public async Task<List<Categoria>> ListarTodosAsync()
        {
            return await _context.Categorias.OrderBy(c=> c.NomeCategoria).ToListAsync();
        }
    }
}
