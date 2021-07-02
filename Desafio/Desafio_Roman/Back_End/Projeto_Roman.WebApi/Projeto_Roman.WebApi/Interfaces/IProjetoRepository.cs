using Projeto_Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Interfaces
{
    interface IProjetoRepository
    {
        /// <summary>
        /// Buscar um Projeto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Projeto BuscarPorId(int id);

        /// <summary>
        /// Cadastrar um novo Projeto
        /// </summary>
        /// <param name="novoProjeto"></param>
        Projeto Cadastrar(Projeto novoProjeto);

        /// <summary>
        /// Atualiza um Projeto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projetoAtualizado"></param>
        void Atualizar(int id, Projeto projetoAtualizado);

        /// <summary>
        /// Deleta um Projeto pelo id
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
