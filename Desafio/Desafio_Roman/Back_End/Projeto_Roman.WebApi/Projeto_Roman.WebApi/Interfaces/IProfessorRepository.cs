using Projeto_Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Interfaces
{
    interface IProfessorRepository
    {
        /// <summary>
        /// Listar todos os Professores
        /// </summary>
        /// <returns></returns>
        List<Professor> Listar();

        /// <summary>
        /// Buscar um Professor por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Professor BuscarPorId(int id);
    }
}
