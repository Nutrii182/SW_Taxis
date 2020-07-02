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
        public List<ChoferDto> GetChofers()
        {
            try
            {
                var chofers = context.Chofer.Include(x => x.TipoSangre).Include(x => x.Status)
                    .Include(x => x.PagoList).Include(x => x.UnidadLink).ThenInclude(x => x.Unidad).ToList();

                var chofersDto = mapper.Map<List<Chofer>, List<ChoferDto>>(chofers);
                return chofersDto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public ChoferDto GetChofer(Guid id)
        {
            try
            {
                var chofer = context.Chofer.Include(x => x.TipoSangre).Include(x => x.Status)
                    .Include(x => x.PagoList).Include(x => x.UnidadLink).ThenInclude(x => x.Unidad).FirstOrDefault(c => c.ChoferId == id);

                if (chofer == null)
                    return null;

                var choferDto = mapper.Map<Chofer, ChoferDto>(chofer);
                return choferDto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}