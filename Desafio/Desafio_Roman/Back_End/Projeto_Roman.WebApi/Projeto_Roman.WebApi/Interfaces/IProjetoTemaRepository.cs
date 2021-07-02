using Projeto_Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Interfaces
{
    interface IProjetoTemaRepository
    {
        /// <summary>
        /// Listar todos os Projetos
        /// </summary>
        /// <returns></returns>
        List<ProjetoTema> Listar();

        /// <summary>
        /// Buscar um Projeto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProjetoTema BuscarPorIdProjeto(int id);

        void Cadastrar(ProjetoTema novoProjeto);
    }
}
