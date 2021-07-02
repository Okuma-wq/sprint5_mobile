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
    public class EquipeRepository : IEquipeRepository
    {
        RomanContext ctx = new RomanContext();

        /// <summary>
        /// Atualiza uma equipe pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="equipeAtualizado"></param>
        public void Atualizar(int id, Equipe equipeAtualizado)
        {
            Equipe equipeBuscado = ctx.Equipes.Find(id);

            if (equipeAtualizado.Equipe1 != null)
            {
                equipeBuscado.Equipe1 = equipeAtualizado.Equipe1;
            }

            ctx.Equipes.Update(equipeBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma equipe pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Equipe BuscarPorId(int id)
        {
            return ctx.Equipes
                .Include(e => e.Professors)
                .FirstOrDefault(e => e.IdEquipe == id);
        }

        /// <summary>
        /// Cadastra uma nova equipe
        /// </summary>
        /// <param name="novoEquipe"></param>
        public void Cadastrar(Equipe novoEquipe)
        {
            ctx.Equipes.Add(novoEquipe);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma equipe pelo id
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            ctx.Equipes.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as equipes
        /// </summary>
        /// <returns></returns>
        public List<Equipe> Listar()
        {
            return ctx.Equipes
                .Include(p => p.Professors)
                .ToList();
        }
    }
}
