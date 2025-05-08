namespace ProjetosLivros.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        public string NomeCategoria { get; set; }

        //Navegação  
        public List<Livro> Livros { get; set; } = new();  //new, pois mesmo que nao tenho nenhum livro dessa categoria, ele me retorna uma lista vazia e nâo null
    }
}
