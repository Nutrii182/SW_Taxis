﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sistema_taxis.Models;

namespace sistema_taxis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadController : Controller
    {
        private SistemaTaxisContext _context;
        public UnidadController(SistemaTaxisContext context)
        {
            _context = context;
        }

    }
}