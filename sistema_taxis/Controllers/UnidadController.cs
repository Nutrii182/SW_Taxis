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
    public class UnidadController : Controller
    {
        private SistemaTaxisContext context;
        private readonly IMapper mapper;
        public UnidadController(SistemaTaxisContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpGet("[action]")]
        [Authorize]
        public List<UnidadDto> GetUnidades()
        {
            try
            {
                var unidades = context.Unidad.Include(x => x.Status).ToList();
                var unidadesDto = mapper.Map<List<Unidad>, List<UnidadDto>>(unidades);
                return unidadesDto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public UnidadDto GetUnidad(Guid id)
        {
            try
            {
                var unidad = context.Unidad.Include(x => x.Status).Where(u => u.UnidadId == id).FirstOrDefault();

                if (unidad == null)
                    throw new Exception("No se encontro la Unidad");

                var unidadDto = mapper.Map<Unidad, UnidadDto>(unidad);
                return unidadDto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("[action]")]
        [Authorize]
        public Unidad NewUnidad(Unidad uni)
        {
            try
            {
                var existe = context.Unidad.Where(u => u.NumUnidad == uni.NumUnidad || u.NumSerie == uni.NumSerie || u.Nss == uni.Nss).FirstOrDefault();

                if (existe != null)
                    return null;

                var unidad = new Unidad
                {
                    UnidadId = Guid.NewGuid(),
                    NumUnidad = uni.NumUnidad,
                    Vehiculo = uni.Vehiculo,
                    Marca = uni.Marca,
                    Linea = uni.Linea,
                    Modelo = uni.Modelo,
                    NumSerie = uni.NumSerie,
                    NumMotor = uni.NumMotor,
                    Nss = uni.Nss,
                    InicioSeguro = uni.InicioSeguro,
                    FinSeguro = uni.FinSeguro,
                    StatusId = uni.StatusId,
                };

                context.Unidad.Add(unidad);
                var result = context.SaveChanges();

                if (result > 0)
                    return unidad;
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public bool EditaUnidad(Guid id, Unidad uni)
        {
            try
            {
                var unidad = context.Unidad.Find(id);

                if (unidad == null)
                    return false;

                unidad.NumUnidad = uni.NumUnidad;
                unidad.Vehiculo = uni.Vehiculo;
                unidad.Marca = uni.Marca;
                unidad.Linea = uni.Linea;
                unidad.Modelo = uni.Modelo;
                unidad.NumSerie = uni.NumSerie;
                unidad.NumMotor = uni.NumMotor;
                unidad.Nss = uni.Nss;
                unidad.InicioSeguro = uni.InicioSeguro;
                unidad.FinSeguro = uni.FinSeguro;
                unidad.StatusId = uni.StatusId;

                var result = context.SaveChanges();
                if (result > 0)
                    return true;
                return false;
            }catch(Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public bool EliminaUnidad(Guid id)
        {
            var unidadesDb = context.ChoferUnidad.Where(u => u.UnidadId == id);
            foreach (var unidad in unidadesDb)
                context.ChoferUnidad.Remove(unidad);

            var uni = context.Unidad.Find(id);

            if (uni == null)
                throw new Exception("No se encontro la Unidad");

            context.Unidad.Remove(uni);
            var result = context.SaveChanges();

            if (result > 0)
                return true;
            return false;
        }
    }
}