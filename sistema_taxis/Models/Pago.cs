using System;
using System.Collections.Generic;

namespace sistema_taxis.Models
{
    public partial class Pago
    {
        public Guid PagoId { get; set; }
        public decimal Cantidad { get; set; }
        public Guid Chofer { get; set; }

        public virtual Chofer ChoferNavigation { get; set; }
    }
}
