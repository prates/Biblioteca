namespace Biblioteca1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Livro")]
    public partial class Livro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Livro()
        {
            Emprestimo = new HashSet<Emprestimo>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Título")]
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Autor { get; set; }

        [StringLength(15)]
        public string ISBN { get; set; }

        [StringLength(50)]
        public string Editora { get; set; }

        public int? Ano { get; set; }

        [DisplayName("Descrição")]
        [Column(TypeName = "text")]
        public string Descricao { get; set; }

        [DisplayName("Quantidade")]
        public int QuantidadeTotal { get; set; }

        [DisplayName("Quantidade Disponível")]
        public int QuantidadeDisponivel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emprestimo> Emprestimo { get; set; }
    }
}
