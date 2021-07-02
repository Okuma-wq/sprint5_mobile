using Projeto_Roman.WebApi.Context;
using Projeto_Roman.WebApi.Domains;
using Projeto_Roman.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        RomanContext ctx = new RomanContext();

        /// <summary>
        /// Busca um Professor pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Professor BuscarPorId(int id)
        {
            return ctx.Professors
                .FirstOrDefault(c => c.IdProfessor == id);
        }

        /// <summary>
        /// Lista todos os Professors
        /// </summary>
        /// <returns></returns>
        public List<Professor> Listar()
        {
            return ctx.Professors
                .ToList();
        }
    }
}
