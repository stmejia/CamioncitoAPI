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
    public class PilotosController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PilotosController(ApplicationDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Obtiene el listado de pilotos registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Pilotos> Get()
        {
            return _context.Pilotos.ToList();
        }

        /// <summary>
        /// Obtiene un piloto especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Pilotos Get(int id)
        {
            var piloto = _context.Pilotos.Find(id);
            return piloto;
        }

        /// <summary>
        /// Inserta un piloto
        /// </summary>
        /// <param name="pilotos"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(Pilotos pilotos)
        {
            try
            {
                pilotos.fechaCreacion = DateTime.Now;
                _context.Pilotos.Add(pilotos);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Modifica un piloto/se envia el id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pilotos"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, Pilotos pilotos)
        {
            if (pilotos.idPiloto == id)
            {
                _context.Pilotos.Update(pilotos);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Elimina un piloto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Put(int id)
        {
            var piloto = _context.Pilotos.Find(id);
            if (piloto != null)
            {
                _context.Pilotos.Remove(piloto);
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
