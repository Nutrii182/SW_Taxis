using Microsoft.AspNetCore.Identity;
using sistema_taxis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_taxis
{
    public class UsuarioPrueba
    {
        public static async Task InsertarData(SistemaTaxisContext context, UserManager<Usuario> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new Usuario { NombreCompleto = "Martin Ruiz", UserName = "Nutrii182", Email = "nutrii182@gmail.com" };
                await userManager.CreateAsync(user, "Nutrii182$");
            }
        }
    }
}
