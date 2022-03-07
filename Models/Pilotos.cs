using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CamioncitoAPI.Models
{
    public class Pilotos
    {
        [Key]
        public int idPiloto { get; set; }

        public string nombre { get; set; }

        public string licenciaTipo { get; set; }

        public bool disponible { get; set; }

        public string viaticosAsignados { get; set; }

        public string gastosAdicionales { get; set; }

        public DateTime? fechaDisponible { get; set; }

        public DateTime fechaCreacion { get; set; }
    }
}
