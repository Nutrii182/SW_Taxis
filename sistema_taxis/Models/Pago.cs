using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema_taxis.Models
{
    public partial class Pago
    {
        public Guid PagoId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Cantidad { get; set; }
        public DateTime FechaPago { get; set; }
        public Guid ChoferId { get; set; }

        public virtual Chofer Chofer { get; set; }
    }
}
