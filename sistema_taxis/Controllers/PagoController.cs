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
    public class PagoController : Controller
    {
        private SistemaTaxisContext context;
        private readonly IMapper mapper;
        public PagoController(SistemaTaxisContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpGet("[action]")]
        [Authorize]
        public List<Pago> GetPagos()
        {
            try
            {
                var pagos = (from p in context.Pago
                             select new Pago
                             {
                                 PagoId = p.PagoId,
                                 Cantidad = p.Cantidad,
                                 FechaPago = p.FechaPago,
                                 ChoferId = p.ChoferId,
                                 Chofer = p.Chofer
                             }).ToList();

                return pagos;
            }catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost("[action]")]
        [Authorize]
        public bool NewPago(Pago p)
        {
            try
            {
                var pago = new Pago
                {
                    PagoId = Guid.NewGuid(),
                    Cantidad = p.Cantidad,
                    FechaPago = DateTime.Now,
                    Usuario = p.Usuario,
                    ChoferId = p.ChoferId
                };

                context.Pago.Add(pago);
                var result = context.SaveChanges();

                if (result > 0)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}