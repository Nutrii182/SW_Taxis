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
                    throw new Exception("No se encontro el Chofer");

                var choferDto = mapper.Map<Chofer, ChoferDto>(chofer);
                return choferDto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("[action]")]
        [Authorize]
        public Chofer NewChofer(Chofer c)
        {
            try
            {
                var existe = context.Chofer.Where(ch => ch.Nombre == c.Nombre && ch.Direccion == c.Direccion && ch.TipoSangreId == c.TipoSangreId).FirstOrDefault();

                if (existe != null)
                    return null;

                Guid _choferId = Guid.NewGuid();
                var chofer = new Chofer
                {
                    ChoferId = _choferId,
                    Nombre = c.Nombre,
                    Direccion = c.Direccion,
                    TipoSangreId = c.TipoSangreId,
                    Ine = c.Ine,
                    Curp = c.Curp,
                    Licencia = c.Licencia,
                    Telefono = c.Telefono,
                    Celular = c.Celular,
                    StatusId = c.StatusId,
                    ListUnidad = c.ListUnidad
                };

                context.Chofer.Add(chofer);

                if (c.ListUnidad != null)
                {
                    foreach (var id in c.ListUnidad)
                    {
                        var choferUnidad = new ChoferUnidad
                        {
                            ChoferId = _choferId,
                            UnidadId = id
                        };
                        context.ChoferUnidad.Add(choferUnidad);
                    }
                }

                var cambios = context.SaveChanges();

                if (cambios > 0)
                    return chofer;
                return null;

            }catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public bool EditarChofer(Guid id, Chofer ch)
        {
            var chofer = context.Chofer.Find(id);

            if (chofer == null)
                return false;

            chofer.Nombre = ch.Nombre;
            chofer.Direccion = ch.Direccion;
            chofer.TipoSangreId = ch.TipoSangreId;
            chofer.Ine = ch.Ine;
            chofer.Curp = ch.Curp;
            chofer.Licencia = ch.Licencia;
            chofer.Telefono = ch.Telefono;
            chofer.Celular = ch.Celular;
            chofer.StatusId = ch.StatusId;

            if(ch.ListUnidad != null)
            {
                if(ch.ListUnidad.Count > 0)
                {
                    var UnidadDB = context.ChoferUnidad.Where(x => x.ChoferId == ch.ChoferId);

                    foreach (var chof in UnidadDB)
                        context.ChoferUnidad.Remove(chof);

                    foreach(var idUni in ch.ListUnidad)
                    {
                        var newUnidad = new ChoferUnidad
                        {
                            ChoferId = ch.ChoferId,
                            UnidadId = idUni
                        };
                        context.ChoferUnidad.Add(newUnidad);
                    }
                }
            }

            var result = context.SaveChanges();
            if (result > 0)
                return true;
            return false;
        }

        [HttpDelete("{id}")]
        [Authorize]
        public bool EliminaChofer(Guid id)
        {

            var unidadDB = context.ChoferUnidad.Where(c => c.ChoferId == id);
            foreach (var unidad in unidadDB)
                context.ChoferUnidad.Remove(unidad);

            var pagoDB = context.Pago.Where(p => p.ChoferId == id);
            foreach (var pago in pagoDB)
                context.Pago.Remove(pago);

            var curso = context.Chofer.Find(id);

            if (curso == null)
                throw new Exception("No se encontro el curso");

            context.Chofer.Remove(curso);

            var result = context.SaveChanges();

            if (result > 0)
                return true;
            return false;
        }
    }
}