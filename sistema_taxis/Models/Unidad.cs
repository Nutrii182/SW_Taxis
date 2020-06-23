using System;
using System.Collections.Generic;

namespace sistema_taxis.Models
{
    public partial class Unidad
    {
        public Unidad()
        {
            Chofer = new HashSet<Chofer>();
        }

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
        public int Status { get; set; }

        public virtual Status StatusNavigation { get; set; }
        public virtual ICollection<Chofer> Chofer { get; set; }
    }
}
