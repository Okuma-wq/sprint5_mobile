using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Projeto_Roman.WebApi.Domains
{
    public partial class Projeto
    {
        public Projeto()
        {
            ProjetoTemas = new HashSet<ProjetoTema>();
        }

        public int? IdProjeto { get; set; }

        [Required(ErrorMessage = "Id do professor obrigatório")]
        public int? IdProfessor { get; set; }

        [Required(ErrorMessage = "Nome do projeto obrigatório")]
        public string Projeto1 { get; set; }

        public virtual Professor IdProfessorNavigation { get; set; }
        public virtual ICollection<ProjetoTema> ProjetoTemas { get; set; }
    }
}
