using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteca1.Models
{
    [Table("Endereco")]
    public class Endereco
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Usuário")]
        public int UsuarioID { get; set; }


        public string Rua { get; set; }

        public int? Numero { get; set; }

        [StringLength(50)]
        public string Complemento { get; set; }

        [StringLength(8)]
        public string CEP { get; set; }

        [StringLength(50)]
        public string Bairro { get; set; }

        public string Cidade { get; set; }

        [StringLength(2)]
        public string Estado { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}