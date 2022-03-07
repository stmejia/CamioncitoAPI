using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CamioncitoAPI.Models
{
    public class Viajes
    {
        [Key]
        public int idViaje { get; set; }

        public int idCliente { get; set; }

        public int idVehiculo { get; set; }

        public int idDepartamento { get; set; }

        public string direccionRecepcionCarga { get; set; }

        public string direccionEntregaCarga { get; set; }

        public string documentacionRequerida { get; set; }

        public int porcentajeCargoAplicado { get; set; }

        public int costoTotal { get; set; }

        public DateTime fechaCreacion { get; set; }
    }
}
