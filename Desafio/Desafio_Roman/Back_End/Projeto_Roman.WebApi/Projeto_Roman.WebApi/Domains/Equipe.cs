using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Projeto_Roman.WebApi.Domains
{
    public partial class Equipe
    {
        public Equipe()
        {
            Professors = new HashSet<Professor>();
        }

        public int IdEquipe { get; set; }

        [Required(ErrorMessage = "Nome da Equipe necessário")]
        public string Equipe1 { get; set; }

        public virtual ICollection<Professor> Professors { get; set; }
    }
}
