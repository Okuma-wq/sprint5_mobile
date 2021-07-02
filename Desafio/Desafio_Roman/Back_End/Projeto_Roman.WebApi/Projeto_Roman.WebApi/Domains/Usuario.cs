using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Projeto_Roman.WebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Professores = new HashSet<Professor>();
        }

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Id do tipo de Usuario obrigatório")]
        public int? IdTipo { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoNavigation { get; set; }
        public virtual ICollection<Professor> Professores { get; set; }
    }
}
