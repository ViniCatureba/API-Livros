namespace ProjetosLivros.Models
{
    public class Livro
    {
        public int LivroId { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string? Descricao { get; set; } // A ? diz que pode ser null

        public DateTime DataPublicacao { get; set; }

        public int CategoriaId { get; set; }

        //Navegacao -
        public Categoria? Categoria { get; set; }
    }
}
