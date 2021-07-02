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
    public class UsuarioRepository : IUsuarioRepository
    {
        RomanContext ctx = new RomanContext();

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios
                .Include(u => u.IdTipoNavigation)
                .FirstOrDefault(c => c.IdUsuario == id);
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios
                .Include(u => u.IdTipoNavigation)
                .ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
