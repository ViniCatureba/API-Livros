namespace ProjetosLivros.Models
{
    public class TipoUsuario
    {

        //como usarmos abaixo <NomeDaTabela+ID> ele já entende que é uma key
        public int TipoUsuarioId { get; set; }

        public string DescricaoTipo { get; set; }

        public List<Usuario> Usuarios { get; set; } = new();


    }
}
