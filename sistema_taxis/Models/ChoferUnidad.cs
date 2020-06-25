using System;
using System.Collections.Generic;

namespace sistema_taxis.Models
{
    public partial class ChoferUnidad
    {
        public Guid ChoferId { get; set; }
        public Guid UnidadId { get; set; }

        public virtual Chofer Chofer { get; set; }
        public virtual Unidad Unidad { get; set; }
    }
}
