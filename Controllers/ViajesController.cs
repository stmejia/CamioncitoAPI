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
    public class ViajesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ViajesController(ApplicationDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Obtiene el listado de viajes registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Viajes> Get()
        {
            return _context.Viajes.ToList();
        }

        /// <summary>
        /// Obtiene un viaje especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Viajes Get(int id)
        {
            var viaje = _context.Viajes.Find(id);
            return viaje;
        }

        /// <summary>
        /// Inserta un viaje
        /// </summary>
        /// <param name="viajes"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(Viajes viajes)
        {
            try
            {
                viajes.fechaCreacion = DateTime.Now;
                _context.Viajes.Add(viajes);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Modifica un viaje/se envia el id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="viajes"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, Viajes viajes)
        {
            if (viajes.idViaje == id)
            {
                _context.Viajes.Update(viajes);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Elimina un viaje
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Put(int id)
        {
            var viaje = _context.Viajes.Find(id);
            if (viaje != null)
            {
                _context.Viajes.Remove(viaje);
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
