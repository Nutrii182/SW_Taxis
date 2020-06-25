using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sistema_taxis.Models;

namespace sistema_taxis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoferController : Controller
    {
        private SistemaTaxisContext context;
        public ChoferController(SistemaTaxisContext _context)
        {
            context = _context;
        }

        [HttpGet("[action]")]
        public List<Chofer> ObtenerChoferes()
        {
            try
            {
                var listChofer = (from c in context.Chofer
                                  select new Chofer
                                  {
                                      ChoferId = c.ChoferId,
                                      Nombre = c.Nombre,
                                      Direccion = c.Direccion,
                                      TipoSangre = c.TipoSangre,
                                      Ine = c.Ine,
                                      Curp = c.Curp,
                                      Licencia = c.Licencia,
                                      Telefono = c.Telefono,
                                      Celular = c.Celular,
                                      Status = c.Status
                                  }).ToList();
                return listChofer;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}