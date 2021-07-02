using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Roman.WebApi.Domains;
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
    public class ProjetoTemaController : ControllerBase
    {
        private IProjetoTemaRepository _projetoTemaRepository { get; set; }

        public ProjetoTemaController()
        {
            _projetoTemaRepository = new ProjetoTemaRepository();
        }
        /// <summary>
        /// Cadastra um novo ProjetoTema
        /// </summary>
        /// <param name="novoTema"></param>
        /// <returns></returns>
        //[Authorize(Roles = "2"]
        [HttpPost]
        public IActionResult Post(ProjetoTema novoProjetoTema)
        {
            try
            {
                _projetoTemaRepository.Cadastrar(novoProjetoTema);

                return StatusCode(201);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);

            }

        }
    }
}
