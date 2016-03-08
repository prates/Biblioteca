namespace Biblioteca1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Emprestimo")]
    public partial class Emprestimo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Livro")]
        public int LivroID { get; set; }

        [DisplayName("Status")]
        public int StatusEmprestimoID { get; set; }

        [DisplayName("Data do Emprestimo")]
        [Column(TypeName = "date")]
        public DateTime? DataEmprestimo { get; set; }

        [DisplayName("Data de Devolução")]
        [Column(TypeName = "date")]
        public DateTime? DataDevolucao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Prazo { get; set; }

        public double? Multa { get; set; }

        [DisplayName("Usuário")]
        [Required]
        [StringLength(128)]
        public string UsuarioID { get; set; }

        public virtual Livro Livro { get; set; }

        public virtual StatusEmprestimo StatusEmprestimo { get; set; }
    }
}
