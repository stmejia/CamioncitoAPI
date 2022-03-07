using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CamioncitoAPI.Models
{
    public class Departamentos
    {
        [Key]
        public int idDepartamento { get; set; }

        public string nombre { get; set; }

        public DateTime fechaCreacion { get; set; }
    }
}
