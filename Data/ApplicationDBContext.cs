using CamioncitoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamioncitoAPI.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Pilotos> Pilotos { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Viajes> Viajes { get; set; }
    }
}
