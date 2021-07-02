using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Roman.WebApi.Domains;
using Projeto_Roman.WebApi.DTO;
using Projeto_Roman.WebApi.Interfaces;
using Projeto_Roman.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private IProjetoRepository _projetoRepository { get; set; }
        private IProjetoTemaRepository _projetoTemaRepository { get; set; }

        public ProjetoController()
        {
            _projetoRepository = new ProjetoRepository();
            _projetoTemaRepository = new ProjetoTemaRepository();
        }

        /// <summary>
        /// Lista todos os Projetos
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_projetoTemaRepository.Listar().OrderBy(c => c.IdProjeto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo Projeto
        /// </summary>
        /// <param name="novoProjeto"></param>
        /// <returns></returns>
        //[Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(ProjetoTemaDTO novoProjetoTemaDTO)
        {
            try
            {
                var novoProjeto = new Projeto
                {
                    IdProfessor = novoProjetoTemaDTO.IdProfessor,
                    Projeto1 = novoProjetoTemaDTO.Projeto1
                };

                novoProjeto = _projetoRepository.Cadastrar(novoProjeto);

                var novoProjetoTema = new ProjetoTema
                {
                    IdProjeto = novoProjeto.IdProjeto,
                    IdTema = novoProjetoTemaDTO.IdTema
                };

                _projetoTemaRepository.Cadastrar(novoProjetoTema);

                return Created("", novoProjeto);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);

            }

        }

        /// <summary>
        /// Busca um Projeto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_projetoRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um Projeto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projetoAtualizado"></param>
        /// <returns></returns>
        //[Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, Projeto projetoAtualizado)
        {
            try
            {
                _projetoRepository.Atualizar(id, projetoAtualizado);

                return StatusCode(200);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }
    }
}
