using Microsoft.EntityFrameworkCore;
using ProjetosLivros.Models;

namespace ProjetosLivros.Context
{
    public class LivrosContext : DbContext //Todo contex deve herdar da DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<TipoUsuario> TipoUsuarios { get; set; }

        public DbSet<Assinatura> Assinaturas { get; set; }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public LivrosContext(DbContextOptions<LivrosContext>options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string do banco de dados
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//configurar as colunas da tabelas com informacoes de tipo e quantidade
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(
                //Representacao da tabela
                entity =>
                {
                    // Definir tudo das colunas
                    //Primary Key
                    entity.HasKey(u => u.UsuarioId);

                    //Property, seleciona um campo para configurar     //IsRequired é obrigatorio  //HasMaxLenght o maximo de caracteres
                    entity.Property(u => u.NomeCompleto).IsRequired().HasMaxLength(150).IsUnicode(false);//Unicode para aceitar somente alfabeto normal

                    entity.Property(u => u.Email).IsRequired().HasMaxLength(150).IsUnicode(false);

                    //Obrigar o Email é unico
                    entity.HasIndex(u => u.Email).IsUnique();

                    entity.Property(u => u.Senha).IsRequired().HasMaxLength(255).IsUnicode(false);

                    entity.Property(u => u.Telefone).IsRequired().HasMaxLength(15).IsUnicode(false);

                    entity.Property(u => u.DataCadastro).IsRequired();

                    entity.Property(u => u.DataAtualizacao).IsRequired();

                    //Relacionamento 1 para muitos entre 1 tipo de usuario pode ter muitos usuarios
                    entity.HasOne(u => u.TipoUsuario).WithMany(t => t.Usuarios).HasForeignKey(u => u.TipoUsuarioId).OnDelete(DeleteBehavior.Cascade);
                    // O Cascate, se apagar o tipo admin, todos os users admin vao apagar
                    // SetNull, ele muda o tipo do user para Null, nao apaga os users


                });


            modelBuilder.Entity<TipoUsuario>(entity =>  //toda tabela comeca assim
            {
                entity.HasKey(t => t.TipoUsuarioId);

                
                
                entity.Property(t => t.DescricaoTipo).IsRequired().HasMaxLength(100).IsUnicode(false);
                //Descricao nao pode se repetir
                //TODO campo UNIQUE é um indice
                entity.HasIndex(t => t.DescricaoTipo).IsUnique();

            }           
                );


            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(l => l.LivroId);

                entity.Property(l => l.Titulo).IsRequired().HasMaxLength(200).IsUnicode(false);

                entity.Property(l => l.Autor).IsRequired().HasMaxLength(200).IsUnicode(false);

                entity.Property(l => l.Descricao).HasMaxLength(255).IsUnicode(false);

                entity.Property(l => l.DataPublicacao).IsRequired();

                //Relacionamento
                //Livro tem categoria
                // 1 - n
                // livro tem categoria, e categorias rtem muitos livros
                entity.HasOne(l => l.Categoria).WithMany(c => c.Livros).HasForeignKey(l => l.CategoriaId).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Categoria>(entity => { 
                entity.HasKey(c => c.CategoriaId);
                entity.Property(c => c.NomeCategoria).IsRequired().HasMaxLength(150).IsUnicode(false);       
            
            });
            modelBuilder.Entity<Assinatura>(entity => { 
            
                entity.HasKey(a => a.AssinaturaId);
                entity.Property(a=>a.DataInicio).IsRequired();
                entity.Property(a=>a.DataFim).IsRequired();
                entity.Property(a=>a.Status).IsRequired().HasMaxLength(20).IsUnicode(false);

                //Assinatura - Usuario

                entity.HasOne(a=>a.Usuario).WithMany().HasForeignKey(a=>a.UsuarioId).OnDelete(DeleteBehavior.Cascade);
            
            
            
            });
        }

        
    }
}
