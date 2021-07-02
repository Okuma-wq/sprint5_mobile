using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Projeto_Roman.WebApi.Domains
{
    public partial class Professor
    {
        public Professor()
        {
            Projetos = new HashSet<Projeto>();
        }

        public int IdProfessor { get; set; }

        [Required(ErrorMessage ="Id do usuario necessario")]
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Id da equipe necessario")]
        public int? IdEquipe { get; set; }

        [Required(ErrorMessage ="Nome do professor obrigatório")]
        public string Nome { get; set; }

        public virtual Equipe IdEquipeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
