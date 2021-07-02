using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Projeto_Roman.WebApi.Domains
{
    public partial class ProjetoTema
    {
        public int IdProjetoTema { get; set; }

        [Required(ErrorMessage = "Id do projeto obrigatório")]
        public int? IdProjeto { get; set; }

        [Required(ErrorMessage = "Id do tema obrigatório")]
        public int? IdTema { get; set; }

        public virtual Projeto IdProjetoNavigation { get; set; }
        public virtual Tema IdTemaNavigation { get; set; }
    }
}
