using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sistema_taxis.Models;

namespace sistema_taxis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private SistemaTaxisContext context;
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;
        public LoginController(SistemaTaxisContext _context, UserManager<Usuario> _userManager, SignInManager<Usuario> _signInManager)
        {
            context = _context;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpPost("[action]")]
        public async Task<Usuario> IniciarSesion(UsuarioLogin u)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(u.Email);

                if (user == null)
                    return null;

                var result = await signInManager.CheckPasswordSignInAsync(user, u.Password, false);

                if (result.Succeeded)
                    return user;

                return null;

            }catch(Exception e)
            {
                throw e;
            }
        }

    }
}