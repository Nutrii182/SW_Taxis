using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sistema_taxis.Models;

namespace sistema_taxis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly SistemaTaxisContext context;
        private readonly UserManager<Usuario> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(SistemaTaxisContext _context, RoleManager<IdentityRole> _roleManager, UserManager<Usuario> _userManager)
        {
            context = _context;
            userManager = _userManager;
            roleManager = _roleManager;
        }

        [HttpPost("crear")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> CrearRole(Role r)
        {
            try
            {
                var role = await roleManager.FindByNameAsync(r.Nombre);

                if (role != null)
                    throw new Exception("El Role ya existe");

                var result = await roleManager.CreateAsync(new IdentityRole(r.Nombre));

                if (result.Succeeded)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("eliminar")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> EliminaRole(Role r)
        {
            try
            {
                var role = await roleManager.FindByNameAsync(r.Nombre);

                if (role == null)
                    throw new Exception("No se encontro el Role");

                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("lista")]
        [Authorize(Roles = "Admin")]
        public List<IdentityRole> GetRoles()
        {
            try
            {
                var roles = context.Roles.ToList();
                return roles;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("agregarRoleUsuario")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> AgregarRoleUsuario(UsuarioRole ur)
        {
            try
            {
                var role = await roleManager.FindByNameAsync(ur.Role);

                if (role == null)
                    throw new Exception("El Role no existe");

                var user = await userManager.FindByNameAsync(ur.Username);

                if (user == null)
                    throw new Exception("El Usuario no existe");

                var result = await userManager.AddToRoleAsync(user, ur.Role);

                if (result.Succeeded)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("eliminarRoleUsuario")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> EliminarRoleUsuario(UsuarioRole ur)
        {
            try
            {
                var role = await roleManager.FindByNameAsync(ur.Role);

                if (role == null)
                    throw new Exception("El Role no existe");

                var user = await userManager.FindByNameAsync(ur.Username);

                if (user == null)
                    throw new Exception("El Usuario no existe");

                var result = await userManager.RemoveFromRoleAsync(user, ur.Role);

                if (result.Succeeded)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<List<string>> GetRolesUsuario(string username)
        {
            try
            {
                var user = await userManager.FindByNameAsync(username);

                if (user == null)
                    throw new Exception("No se encontro el usuario");

                var result = await userManager.GetRolesAsync(user);
                return result.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}