using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sistema_taxis.Models;
using sistema_taxis.Seguridad.Contratos;

namespace sistema_taxis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private SistemaTaxisContext context;
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;
        private readonly IJwtGenerator jwtGenerator;
        public LoginController(SistemaTaxisContext _context, UserManager<Usuario> _userManager, SignInManager<Usuario> _signInManager, IJwtGenerator _jwtGenerator)
        {
            context = _context;
            userManager = _userManager;
            signInManager = _signInManager;
            jwtGenerator = _jwtGenerator;
        }

        [HttpPost("[action]")]
        public async Task<UsuarioDto> IniciarSesion(UsuarioDto u)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(u.Email);

                if (user == null)
                    return null;

                var result = await signInManager.CheckPasswordSignInAsync(user, u.Password, false);

                if (result.Succeeded)
                {
                    return new UsuarioDto
                    {
                        NombreCompleto = user.NombreCompleto,
                        Email = user.Email,
                        Token = jwtGenerator.CrearToken(user),
                        NombreUsuario = user.UserName,
                        Telefono = user.PhoneNumber,
                        Foto = user.Foto
                    };
                }
                    
                return null;

            }catch(Exception e)
            {
                throw e;
            }
        }

    }
}