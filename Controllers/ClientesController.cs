using CamioncitoAPI.Data;
using CamioncitoAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamioncitoAPI.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ClientesController(ApplicationDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Obtiene el listado de clientes registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Clientes> Get()
        {
            return _context.Clientes.ToList();
        }

        /// <summary>
        /// Obtiene un cliente especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Clientes Get(int id)
        {
            var cliente = _context.Clientes.Find(id);
            return cliente;
        }

        /// <summary>
        /// Inserta un cliente
        /// </summary>
        /// <param name="clientes"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(Clientes clientes)
        {
            try
            {
                clientes.fechaCreacion = DateTime.Now;
                _context.Clientes.Add(clientes);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Modifica un cliente/se envia el id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clientes"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, Clientes clientes)
        {
            if (clientes.idCliente == id)
            {
                _context.Clientes.Update(clientes);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Elimina un cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Put(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
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
