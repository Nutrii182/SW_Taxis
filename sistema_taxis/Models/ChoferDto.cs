using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_taxis.Models
{
    public class ChoferDto
    {
        public Guid ChoferId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public byte[] Ine { get; set; }
        public byte[] Curp { get; set; }
        public byte[] Licencia { get; set; }
        public long? Telefono { get; set; }
        public long? Celular { get; set; }
        public ICollection<UnidadDto> Unidades { get; set; }
        public TipoSangreDto TipoSangre { get; set; }
        public StatusDto Status { get; set; }
        public ICollection<PagoDto> Pagos { get; set; }
    }
}
