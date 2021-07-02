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
    public class ProjetoTemaRepository : IProjetoTemaRepository
    {
        RomanContext ctx = new RomanContext();

        /// <summary>
        /// Lista todos os Projetos
        /// </summary>
        /// <returns></returns>
        public List<ProjetoTema> Listar()
        {
            return ctx.ProjetoTemas
                .Include(p => p.IdProjetoNavigation)
                .Include(p => p.IdTemaNavigation)
                .Select(p => new ProjetoTema ()
                {
                    IdProjetoNavigation = new Projeto()
                    {
                        IdProjeto = p.IdProjeto,
                        Projeto1 = p.IdProjetoNavigation.Projeto1,
                        IdProfessor = p.IdProjetoNavigation.IdProfessor,

                        IdProfessorNavigation = new Professor()
                        {
                            Nome = p.IdProjetoNavigation.IdProfessorNavigation.Nome
                        }
                    },

                    IdTemaNavigation = new Tema()
                    { 
                        IdTema = p.IdTemaNavigation.IdTema,
                        Tema1 = p.IdTemaNavigation.Tema1
                    }
                })
                .ToList();
        }

        /// <summary>
        /// Busca um Projeto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProjetoTema BuscarPorIdProjeto(int id)
        {
            return ctx.ProjetoTemas
                .Include(t => t.IdProjetoNavigation)
                .Include(p => p.IdTemaNavigation)
                .Select(p => new ProjetoTema()
                {
                    IdProjetoNavigation = new Projeto()
                    {
                        IdProjeto = p.IdProjeto,
                        Projeto1 = p.IdProjetoNavigation.Projeto1,
                        IdProfessor = p.IdProjetoNavigation.IdProfessor,

                        IdProfessorNavigation = new Professor()
                        {
                            Nome = p.IdProjetoNavigation.IdProfessorNavigation.Nome
                        }
                    },

                    IdTemaNavigation = new Tema()
                    {
                        IdTema = p.IdTemaNavigation.IdTema,
                        Tema1 = p.IdTemaNavigation.Tema1
                    }
                })
                .FirstOrDefault(c => c.IdProjeto == id);
        }

        public void Cadastrar(ProjetoTema novoProjeto)
        {
            ctx.ProjetoTemas.Add(novoProjeto);

            ctx.SaveChanges();
        }
    }
}
