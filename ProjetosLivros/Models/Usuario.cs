﻿namespace ProjetosLivros.Models
{
    public class Usuario
    {

        public int UsuarioId { get; set; }

        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAtualizacao { get; set; }

        // Chave estrangeira
        public int TipoUsuarioId { get; set; }

        //Navegacao, ao listar o usuario, ver o tipo dele
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
