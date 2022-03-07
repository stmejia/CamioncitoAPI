using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CamioncitoAPI.Models
{
    public class Vehiculos
    {
        [Key]
        public int idVehiculo { get; set; }

        public int idPiloto { get; set; }

        public int capacidadMetrosCubicos { get; set; }

        public string consumoCombustibleKm { get; set; }

        public string tipoCarga { get; set; }

        public int costosDepreciacionQuetzales { get; set; }

        public bool disponible { get; set; }

        public DateTime fechaDisponible { get; set; }

        public DateTime fechaCreacion { get; set; }
    }
}
