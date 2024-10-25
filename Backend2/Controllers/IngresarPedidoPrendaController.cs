using Backend2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresarPedidoPrendaController : ControllerBase
    {
        private readonly InsertarPedidoSerivce _insertarPedidoSerivce;
        public IngresarPedidoPrendaController(InsertarPedidoSerivce insertarPedidoSerivce)
        {
            _insertarPedidoSerivce = insertarPedidoSerivce;
        }

        // GET: api/<IngresarPedidoPrendaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<IngresarPedidoPrendaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<IngresarPedidoPrendaController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // POST api/<IngresarPedidoPrendaController>
        [HttpPost]
        public async Task<IActionResult> InsertarPedido(int empleadoId, DateTime fechaPedido, int prendaId,string talle, int cantidad)
        {
            try
            {
                await _insertarPedidoSerivce.InsertarPedido(empleadoId, fechaPedido, prendaId, talle, cantidad);
                return Ok("Insertado con Exito ...!!");
            }
            catch (Exception ex)
            {

                return BadRequest($"Error al insertar el pedido: {ex.Message}");
            }
        }

        // PUT api/<IngresarPedidoPrendaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IngresarPedidoPrendaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
