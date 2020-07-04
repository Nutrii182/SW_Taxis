using System;
using System.Collections.Generic;

namespace sistema_taxis.Models
{
    public partial class Unidad
    {
        public Unidad()
        {
            ChoferUnidad = new HashSet<ChoferUnidad>();
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
        public DateTime FinSeguro { get; set; }
        public int StatusId { get; set; }
        //public Guid ChoferId { get; set; }

        //public virtual List<Chofer> Chofer { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<ChoferUnidad> ChoferUnidad { get; set; }
    }
}
