using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_taxis.Models
{
    public class PagoDto
    {
        public Guid PagoId { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaPago { get; set; }
        public Guid ChoferId { get; set; }
    }
}
