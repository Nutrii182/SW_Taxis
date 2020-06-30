﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_taxis.Models
{
    public class Usuario : IdentityUser
    {
        public string NombreCompleto { get; set; }
        public byte[] Foto { get; set; }

    }
}
