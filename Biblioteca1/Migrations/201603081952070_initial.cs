namespace Biblioteca1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emprestimo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LivroID = c.Int(nullable: false),
                        StatusEmprestimoID = c.Int(nullable: false),
                        DataEmprestimo = c.DateTime(storeType: "date"),
                        DataDevolucao = c.DateTime(storeType: "date"),
                        Prazo = c.DateTime(storeType: "date"),
                        Multa = c.Double(),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Livro", t => t.LivroID)
                .ForeignKey("dbo.StatusEmprestimo", t => t.StatusEmprestimoID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.LivroID)
                .Index(t => t.StatusEmprestimoID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, unicode: false),
                        Autor = c.String(nullable: false, unicode: false),
                        ISBN = c.String(maxLength: 15, unicode: false),
                        Editora = c.String(maxLength: 50, unicode: false),
                        Ano = c.Int(),
                        Descricao = c.String(unicode: false, storeType: "text"),
                        QuantidadeTotal = c.Int(nullable: false),
                        QuantidadeDisponivel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusEmprestimo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        CPF = c.String(nullable: false, maxLength: 11, unicode: false),
                        email = c.String(nullable: false, unicode: false),
                        Telefone = c.String(nullable: false, unicode: false),
                        senha = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        Rua = c.String(unicode: false),
                        Numero = c.Int(),
                        Complemento = c.String(maxLength: 50, unicode: false),
                        CEP = c.String(maxLength: 8, unicode: false),
                        Bairro = c.String(maxLength: 50, unicode: false),
                        Cidade = c.String(unicode: false),
                        Estado = c.String(maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeneroLivro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LivroID = c.Int(nullable: false),
                        GeneroID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genero", t => t.GeneroID, cascadeDelete: true)
                .ForeignKey("dbo.Livro", t => t.LivroID, cascadeDelete: true)
                .Index(t => t.LivroID)
                .Index(t => t.GeneroID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneroLivro", "LivroID", "dbo.Livro");
            DropForeignKey("dbo.GeneroLivro", "GeneroID", "dbo.Genero");
            DropForeignKey("dbo.Endereco", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Emprestimo", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Emprestimo", "StatusEmprestimoID", "dbo.StatusEmprestimo");
            DropForeignKey("dbo.Emprestimo", "LivroID", "dbo.Livro");
            DropIndex("dbo.GeneroLivro", new[] { "GeneroID" });
            DropIndex("dbo.GeneroLivro", new[] { "LivroID" });
            DropIndex("dbo.Endereco", new[] { "UsuarioID" });
            DropIndex("dbo.Emprestimo", new[] { "UsuarioID" });
            DropIndex("dbo.Emprestimo", new[] { "StatusEmprestimoID" });
            DropIndex("dbo.Emprestimo", new[] { "LivroID" });
            DropTable("dbo.GeneroLivro");
            DropTable("dbo.Genero");
            DropTable("dbo.Endereco");
            DropTable("dbo.Usuario");
            DropTable("dbo.StatusEmprestimo");
            DropTable("dbo.Livro");
            DropTable("dbo.Emprestimo");
        }
    }
}
