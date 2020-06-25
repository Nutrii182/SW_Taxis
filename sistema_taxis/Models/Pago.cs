﻿using System;
using System.Collections.Generic;

namespace sistema_taxis.Models
{
    public partial class Pago
    {
        public Guid PagoId { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaPago { get; set; }
        public Guid ChoferId { get; set; }

        public virtual Chofer Chofer { get; set; }
    }
}
