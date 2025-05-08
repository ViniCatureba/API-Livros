using ProjetosLivros.Context;
using ProjetosLivros.Interface;
using ProjetosLivros.Models;

namespace ProjetosLivros.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly LivrosContext _context;

        public LivroRepository(LivrosContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Livro livro)
        {
            var procurarId = _context.Livros.Find(id);
            if (procurarId == null) { throw new ArgumentNullException("Cliente nao encontrado"); }
            procurarId.Titulo = livro.Titulo;   
            procurarId.Autor = livro.Autor;
            procurarId.DataPublicacao = livro.DataPublicacao;
            procurarId.Descricao = livro.Descricao;
            procurarId.CategoriaId = livro.CategoriaId;

            _context.SaveChanges();
        }


        public void Cadastrar(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Livro> ListarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Livro> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
