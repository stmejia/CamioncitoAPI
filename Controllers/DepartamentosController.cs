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
    public class DepartamentosController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public DepartamentosController(ApplicationDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Obtiene el listado de departamentos registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Departamentos> Get()
        {
            return _context.Departamentos.ToList();
        }

        /// <summary>
        /// Obtiene un departamento especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Departamentos Get(int id)
        {
            var departamento = _context.Departamentos.Find(id);
            return departamento;
        }

        /// <summary>
        /// Inserta un departamento
        /// </summary>
        /// <param name="departamentos"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(Departamentos departamentos)
        {
            try
            {
                departamentos.fechaCreacion = DateTime.Now;
                _context.Departamentos.Add(departamentos);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Modifica un departamento/se envia el id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="departamentos"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, Departamentos departamentos)
        {
            if (departamentos.idDepartamento == id)
            {
                _context.Departamentos.Update(departamentos);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Elimina un departamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Put(int id)
        {
            var departamento = _context.Departamentos.Find(id);
            if (departamento != null)
            {
                _context.Departamentos.Remove(departamento);
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
