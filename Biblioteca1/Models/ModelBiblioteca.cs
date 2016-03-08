namespace Biblioteca1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;
    public partial class ModelBiblioteca : DbContext
    {
        public ModelBiblioteca()
            : base("name=ModelBiblioteca")
        {
        }

        public virtual DbSet<Emprestimo> Emprestimo { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }
        public virtual DbSet<StatusEmprestimo> StatusEmprestimo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<GeneroLivro> GeneroLivro { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {    
            modelBuilder.Entity<Genero>()
                .Property(e => e.Label)
                .IsFixedLength();

            modelBuilder.Entity<Livro>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Livro>()
                .Property(e => e.Autor)
                .IsUnicode(false);

            modelBuilder.Entity<Livro>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<Livro>()
                .Property(e => e.Editora)
                .IsUnicode(false);

            modelBuilder.Entity<Livro>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Livro>()
                .HasMany(e => e.Emprestimo)
                .WithRequired(e => e.Livro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatusEmprestimo>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<StatusEmprestimo>()
                .HasMany(e => e.Emprestimo)
                .WithRequired(e => e.StatusEmprestimo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Rua)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Complemento)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.senha)
                .IsUnicode(false);
        }
    }
}
