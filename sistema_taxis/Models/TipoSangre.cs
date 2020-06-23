using System;
using System.Collections.Generic;

namespace sistema_taxis.Models
{
    public partial class TipoSangre
    {
        public TipoSangre()
        {
            Chofer = new HashSet<Chofer>();
        }

        public int SangreId { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Chofer> Chofer { get; set; }
    }
}
