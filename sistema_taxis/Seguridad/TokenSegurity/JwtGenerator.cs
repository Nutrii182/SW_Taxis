using Microsoft.IdentityModel.Tokens;
using sistema_taxis.Models;
using sistema_taxis.Seguridad.Contratos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace sistema_taxis.Seguridad.TokenSegurity
{
    public class JwtGenerator : IJwtGenerator
    {
        public string CrearToken(Usuario usuario, List<string> roles)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.NameId, usuario.UserName)
            };

            if(roles != null)
            {
                foreach(var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi Palabra Secreta"));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = credenciales
            };
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
