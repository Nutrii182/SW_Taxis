using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_taxis.Models
{
    public class UsuarioDto
    {
        public string UsuarioId { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NombreUsuario { get; set; }
        public string Telefono { get; set; }
        public byte[] Foto { get; set; }
        public string Token { get; set; }
    }
}
