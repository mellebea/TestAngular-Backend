using Backend2.Models;
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
    public class PedidoConPrendaController : ControllerBase
    {

        private readonly PedidoService _pedidoService;

        public PedidoConPrendaController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }


        [HttpPost]
        [Route("InsertarPedidoConPrendas")]
        public async Task<IActionResult> InsertarPedidoConPrendas([FromBody] PedidoConPrendas pedido)
        {
            try
            {
                await _pedidoService.InsertarPedidoConPrendas(pedido);
                return Ok(new { Message = "Pedido insertado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error al insertar el pedido", Details = ex.Message });
            }
        }

        //// GET: api/<PedidoConPrendaController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<PedidoConPrendaController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PedidoConPrendaController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PedidoConPrendaController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PedidoConPrendaController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
