using Projeto_Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Listar todos os tipos de usuario
        /// </summary>
        /// <returns></returns>
        List<TipoUsuario> Listar();

        
    }
}
