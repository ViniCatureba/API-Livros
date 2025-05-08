using ProjetosLivros.Models;

namespace ProjetosLivros.Interface
{
    public interface ILivroRepository
    {
        void Cadastrar(Livro livro);

        void Atualizar(int id, Livro livro);

        void Deletar(int id);

        List<Livro> ListarTodos();

        List<Livro> ListarPorId(int id);
    }
}
