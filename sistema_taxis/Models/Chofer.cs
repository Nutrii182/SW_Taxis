using System;
using System.Collections.Generic;

namespace sistema_taxis.Models
{
    public partial class Chofer
    {
        public Chofer()
        {
            Pago = new HashSet<Pago>();
        }

        public Guid ChoferId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int? TipoSangre { get; set; }
        public byte[] Ine { get; set; }
        public byte[] Curp { get; set; }
        public byte[] Licencia { get; set; }
        public long Telefono { get; set; }
        public long Celular { get; set; }
        public int Status { get; set; }
        public Guid Unidad { get; set; }

        public virtual Status StatusNavigation { get; set; }
        public virtual TipoSangre TipoSangreNavigation { get; set; }
        public virtual Unidad UnidadNavigation { get; set; }
        public virtual ICollection<Pago> Pago { get; set; }
    }
}
