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
        public int UsuarioID { get; set; }

        public virtual Livro Livro { get; set; }

        public virtual StatusEmprestimo StatusEmprestimo { get; set; }

        public virtual Usuario Usuario { get; set; }

        public void calcularMulta() {
            int dias = 0;
            if (DataDevolucao == null)
            {
                dias = DateTime.Now.Subtract(Convert.ToDateTime(Prazo.ToString())).Days;
            }
            else
            {
                dias = Convert.ToDateTime(DataDevolucao.ToString()).Subtract(Convert.ToDateTime(Prazo.ToString())).Days;
            }

            Multa = dias > 0 ? dias * 0.5 : 0;
        }
    }
}
