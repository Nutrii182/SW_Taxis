using System;
using System.Collections.Generic;

namespace sistema_taxis.Models
{
    public partial class Chofer
    {
        public Chofer()
        {
            ChoferUnidad = new HashSet<ChoferUnidad>();
            Pago = new HashSet<Pago>();
            Unidad = new HashSet<Unidad>();
        }

        public Guid ChoferId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int TipoSangreId { get; set; }
        public byte[] Ine { get; set; }
        public byte[] Curp { get; set; }
        public byte[] Licencia { get; set; }
        public long? Telefono { get; set; }
        public long? Celular { get; set; }
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual TipoSangre TipoSangre { get; set; }
        public virtual ICollection<ChoferUnidad> ChoferUnidad { get; set; }
        public virtual ICollection<Pago> Pago { get; set; }
        public virtual ICollection<Unidad> Unidad { get; set; }
    }
}
