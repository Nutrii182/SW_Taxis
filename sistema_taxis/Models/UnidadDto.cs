using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_taxis.Models
{
    public class UnidadDto
    {
        public Guid UnidadId { get; set; }
        public string NumUnidad { get; set; }
        public string Vehiculo { get; set; }
        public string Marca { get; set; }
        public string Linea { get; set; }
        public int Modelo { get; set; }
        public string NumSerie { get; set; }
        public string NumMotor { get; set; }
        public string Nss { get; set; }
        public DateTime InicioSeguro { get; set; }
        public DateTime FinSeguro { get; set; }
        public StatusDto Status { get; set; }
    }
}
