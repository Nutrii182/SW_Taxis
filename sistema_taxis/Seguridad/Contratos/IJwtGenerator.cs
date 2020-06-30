using sistema_taxis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_taxis.Seguridad.Contratos
{
    public interface IJwtGenerator
    {
        string CrearToken(Usuario usuario);
    }
}
