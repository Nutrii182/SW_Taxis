using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistema_taxis.Models;
using sistema_taxis.Seguridad.Contratos;

namespace sistema_taxis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private SistemaTaxisContext context;
        private readonly IJwtGenerator jwtGenerator;
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;
        private readonly IPasswordHasher<Usuario> passwordHasher;
        public LoginController(SistemaTaxisContext _context, UserManager<Usuario> _userManager, SignInManager<Usuario> _signInManager, IJwtGenerator _jwtGenerator, IPasswordHasher<Usuario> _passwordHasher)
        {
            context = _context;
            userManager = _userManager;
            signInManager = _signInManager;
            jwtGenerator = _jwtGenerator;
            passwordHasher = _passwordHasher;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<UsuarioDto> IniciarSesion(UsuarioDto u)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(u.Email);

                if (user == null)
                    return null;

                var result = await signInManager.CheckPasswordSignInAsync(user, u.Password, false);
                var Roles = await userManager.GetRolesAsync(user);
                var listRoles = new List<string>(Roles);

                if (result.Succeeded)
                {
                    return new UsuarioDto
                    {
                        NombreCompleto = user.NombreCompleto,
                        Email = user.Email,
                        Token = jwtGenerator.CrearToken(user, listRoles),
                        NombreUsuario = user.UserName,
                        Telefono = user.PhoneNumber,
                        Foto = user.Foto
                    };
                }

                return null;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<UsuarioDto> NewUsuario(UsuarioDto us)
        {
            try
            {
                var user = await context.Users.Where(u => u.Email == us.Email || u.UserName == us.NombreUsuario).AnyAsync();

                if (user)
                    throw new Exception("El usuario ya existe");

                var newUser = new Usuario
                {
                    NombreCompleto = us.NombreCompleto,
                    Email = us.Email,
                    UserName = us.NombreUsuario,
                    PhoneNumber = us.Telefono,
                    Foto = null,
                };

                var result = await userManager.CreateAsync(newUser, us.Password);

                if (result.Succeeded)
                {
                    return new UsuarioDto
                    {
                        NombreCompleto = newUser.NombreCompleto,
                        Email = newUser.Email,
                        NombreUsuario = newUser.UserName,
                        Telefono = newUser.PhoneNumber,
                        Foto = newUser.Foto,
                        Token = jwtGenerator.CrearToken(newUser, null)
                    };
                }

                throw new Exception("No se pudo crear el usuario");

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<UsuarioDto> EditaUsuario(Guid id, UsuarioDto us)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id.ToString());

                if (user == null)
                    throw new Exception("No se encontro el Usuario");

                var userExist = await context.Users.Where(u => u.Email == us.Email && u.UserName != us.NombreUsuario).AnyAsync();

                user.NombreCompleto = us.NombreCompleto;
                user.Email = us.Email;
                user.PasswordHash = passwordHasher.HashPassword(user, us.Password);
                user.UserName = us.NombreUsuario;
                user.PhoneNumber = us.Telefono;
                user.Foto = us.Foto;

                var result = await userManager.UpdateAsync(user);

                var roles = await userManager.GetRolesAsync(user);
                var listRoles = new List<string>(roles);

                if (result.Succeeded)
                {
                    return new UsuarioDto
                    {
                        NombreCompleto = user.NombreCompleto,
                        Email = user.Email,
                        NombreUsuario = user.UserName,
                        Telefono = user.PhoneNumber,
                        Foto = user.Foto,
                        Token = jwtGenerator.CrearToken(user, listRoles)
                    };
                }

                throw new Exception("No se puedo actualizar el Usuario");

            }catch(Exception e)
            {
                throw e;
            }
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public List<UsuarioDto> GetUsuarios()
        {
            try
            {
                var usersDto = new List<UsuarioDto>();
                var users = context.Users.ToList();

                foreach (var u in users)
                {
                    var newUser = new UsuarioDto
                    {
                        UsuarioId = u.Id,
                        NombreCompleto = u.NombreCompleto,
                        Email = u.Email,
                        NombreUsuario = u.UserName,
                        Telefono = u.PhoneNumber,
                        Foto = u.Foto
                    };
                    usersDto.Add(newUser);
                }
                return usersDto;
            }
            catch(Exception e)
            {
                throw e;
            }

        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<UsuarioDto> GetUsuario(Guid id)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id.ToString());

                if (user == null)
                    throw new Exception("No se encontro el Usuario");

                var usuario = new UsuarioDto
                {
                    UsuarioId = user.Id,
                    NombreCompleto = user.NombreCompleto,
                    Email = user.Email,
                    NombreUsuario = user.UserName,
                    Telefono = user.PhoneNumber,
                    Foto = user.Foto
                };

                return usuario;
            }catch(Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> EliminaUsuario(Guid id)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id.ToString());

                if (user == null)
                    throw new Exception("No se encontro el Usuario");

                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                    return true;
                return false;
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}