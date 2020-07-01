using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace sistema_taxis.Models
{
    public partial class Status
    {
        public Status()
        {
            Chofer = new HashSet<Chofer>();
            Unidad = new HashSet<Unidad>();
        }

        public int StatusId { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Chofer> Chofer { get; set; }
        public virtual ICollection<Unidad> Unidad { get; set; }
    }
}
