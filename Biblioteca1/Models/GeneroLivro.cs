namespace Biblioteca1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GeneroLivro")]
    public partial class GeneroLivro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Livro")]
        public int LivroID { get; set; }

        [DisplayName("Gênero Literario")]
        public int GeneroID { get; set; }

        public virtual Genero Genero { get; set; }
        public virtual Livro Livro { get; set; }
    }
}
