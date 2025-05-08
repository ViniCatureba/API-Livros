using ProjetosLivros.Models;

namespace ProjetosLivros.Interface
{
    public interface ICategoriaRepository
    {

        // Assincrono - Task (Tarefa)
        void Cadastrar(Categoria categoria);

        Categoria? Deletar(int id);

        Categoria? Atualizar(int id,  Categoria categoria);

        List<Categoria> BuscarCategoriaPorNome(string nome);

        List<Categoria> BuscarCategoriaPorId(int id);

        List<Categoria> ListarTodos();

        Task<List<Categoria>> ListarTodosAsync();
    }
}
