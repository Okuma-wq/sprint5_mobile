using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Projeto_Roman.WebApi.Domains
{
    public partial class Tema
    {
        public Tema()
        {
            ProjetoTemas = new HashSet<ProjetoTema>();
        }

        public int? IdTema { get; set; }

        [Required(ErrorMessage = "Tema obrigatório")]
        public string Tema1 { get; set; }

        public virtual ICollection<ProjetoTema> ProjetoTemas { get; set; }
    }
}
