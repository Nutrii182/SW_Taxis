using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema_taxis.Models
{
    public partial class Chofer
    {
        public Chofer()
        {
            UnidadLink = new HashSet<ChoferUnidad>();
            PagoList = new HashSet<Pago>();
            //UnidadList = new HashSet<Unidad>();
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
        [NotMapped]
        public List<Guid> ListUnidad { get; set; }

        public virtual Status Status { get; set; }
        public virtual TipoSangre TipoSangre { get; set; }
        public virtual ICollection<ChoferUnidad> UnidadLink { get; set; }
        public virtual ICollection<Pago> PagoList { get; set; }
        //public virtual ICollection<Unidad> UnidadList { get; set; }
    }
}
