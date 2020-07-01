using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistema_taxis.Models;

namespace sistema_taxis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoferController : Controller
    {
        private SistemaTaxisContext context;
        private readonly IMapper mapper;
        public ChoferController(SistemaTaxisContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpGet("[action]")]
        [Authorize]
        public List<ChoferDto> ObtenerChoferes()
        {
            try
            {
                //var listChofer = (from c in context.Chofer
                //                  select new Chofer
                //                  {
                //                      ChoferId = c.ChoferId,
                //                      Nombre = c.Nombre,
                //                      Direccion = c.Direccion,
                //                      TipoSangre = c.TipoSangre,
                //                      Ine = c.Ine,
                //                      Curp = c.Curp,
                //                      Licencia = c.Licencia,
                //                      Telefono = c.Telefono,
                //                      Celular = c.Celular,
                //                      Status = c.Status
                //                  }).ToList();
                //return listChofer;
                var chofers = context.Chofer.Include(x => x.TipoSangre).Include(x => x.Status).Include(x => x.UnidadLink).ThenInclude(x => x.Unidad).ToList();

                var choferDto = mapper.Map<List<Chofer>, List<ChoferDto>>(chofers);
                return choferDto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}