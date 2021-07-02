using Microsoft.EntityFrameworkCore;
using Projeto_Roman.WebApi.Context;
using Projeto_Roman.WebApi.Domains;
using Projeto_Roman.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Repositories
{
    public class TemaRepository : ITemaRepository
    {
        RomanContext ctx = new RomanContext();

        /// <summary>
        /// Atualiza um Tema pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="temaAtualizado"></param>
        public void Atualizar(int id, Tema temaAtualizado)
        {
            Tema temaBuscado = ctx.Temas.Find(id);

            if (temaAtualizado.Tema1 != null)
            {
                temaBuscado.Tema1 = temaAtualizado.Tema1;
            }

            ctx.Temas.Update(temaBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Tema pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tema BuscarPorId(int id)
        {
            return ctx.Temas
                .FirstOrDefault(c => c.IdTema == id);
        }

        /// <summary>
        /// Cadastra um novo Tema
        /// </summary>
        /// <param name="novoTema"></param>
        public void Cadastrar(Tema novoTema)
        {
            ctx.Temas.Add(novoTema);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Temas
        /// </summary>
        /// <returns></returns>
        public List<Tema> Listar()
        {
            return ctx.Temas
                .ToList();
        }
    }
}
