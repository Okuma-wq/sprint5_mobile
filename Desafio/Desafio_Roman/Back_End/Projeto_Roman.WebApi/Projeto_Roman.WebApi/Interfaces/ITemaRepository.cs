using Projeto_Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Interfaces
{
    interface ITemaRepository
    {
        /// <summary>
        /// Listar todos os Temas
        /// </summary>
        /// <returns></returns>
        List<Tema> Listar();

        /// <summary>
        /// Buscar um Tema por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Tema BuscarPorId(int id);

        /// <summary>
        /// Cadastrar um novo Tema
        /// </summary>
        /// <param name="novoTema"></param>
        void Cadastrar(Tema novoTema);

        /// <summary>
        /// Atualiza um Tema pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="temaAtualizado"></param>
        void Atualizar(int id, Tema temaAtualizado);
    }
}
