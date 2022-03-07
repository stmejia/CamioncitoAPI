using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CamioncitoAPI.Models
{
    public class Clientes
    {
        [Key]
        public int idCliente { get; set; }

        public string nombres { get; set; }

        public string nit { get; set; }

        public int telefono { get; set; }

        public string email { get; set; }

        public DateTime? fechaCreacion { get; set; }
    }
}
