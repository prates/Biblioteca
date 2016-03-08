namespace Biblioteca1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Text.RegularExpressions;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        [StringLength(50)]
        public string senha { get; set; }

        public bool IsValid(string email, string password)
        {
            ModelBiblioteca db = new ModelBiblioteca();
            string SenhaCriptografada = Helpers.SHA1.Encode(password);
            Usuario usuario =  db.Usuario.Where(u => u.email == email && u.senha == SenhaCriptografada).FirstOrDefault();
          
            return usuario != null;
        }

        public bool ValidateEmail()
        {
            string email = this.email;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }


    }
}
