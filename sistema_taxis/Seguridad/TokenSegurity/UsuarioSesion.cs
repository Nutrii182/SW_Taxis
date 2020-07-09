using Microsoft.AspNetCore.Http;
using sistema_taxis.Seguridad.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace sistema_taxis.Seguridad.TokenSegurity
{
    public class UsuarioSesion : IUsuarioSesion
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UsuarioSesion(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public string ObtenerUsuarioSesion()
        {
            var userName = httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return userName;
        }
    }
}
