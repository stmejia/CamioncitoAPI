using CamioncitoAPI.Data;
using CamioncitoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamioncitoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public VehiculosController(ApplicationDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Obtiene el listado de vehiculos registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Vehiculos> Get()
        {
            return _context.Vehiculos.ToList();
        }

        /// <summary>
        /// Obtiene un vehiculo especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Vehiculos Get(int id)
        {
            var vehiculo = _context.Vehiculos.Find(id);
            return vehiculo;
        }

        /// <summary>
        /// Inserta un vehiculo
        /// </summary>
        /// <param name="vehiculos"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(Vehiculos vehiculos)
        {
            try
            {
                vehiculos.fechaCreacion = DateTime.Now;
                _context.Vehiculos.Add(vehiculos);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Modifica un vehiculo/se envia el id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vehiculos"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, Vehiculos vehiculos)
        {
            if (vehiculos.idVehiculo == id)
            {
                _context.Vehiculos.Update(vehiculos);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Elimina un vehiculo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Put(int id)
        {
            var vehiculo = _context.Vehiculos.Find(id);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
