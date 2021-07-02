using Projeto_Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Interfaces
{
    interface IEquipeRepository
    {
        /// <summary>
        /// Listar todas as equipes
        /// </summary>
        /// <returns></returns>
        List<Equipe> Listar();

        /// <summary>
        /// Buscar uma equipe por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Equipe BuscarPorId(int id);

        /// <summary>
        /// Cadastrar uma nova equipe
        /// </summary>
        /// <param name="novoEquipe"></param>
        void Cadastrar(Equipe novoEquipe);

        /// <summary>
        /// Atualiza uma equipe pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="equipeAtualizado"></param>
        void Atualizar(int id, Equipe equipeAtualizado);

        /// <summary>
        /// Deleta uma equipe pelo id
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
