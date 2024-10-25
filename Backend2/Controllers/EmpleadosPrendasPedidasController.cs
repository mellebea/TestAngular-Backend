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
    public class EmpleadosPrendasPedidasController : ControllerBase
    {
        private readonly PrendaPedidaService _prendaPedidaService;

        public EmpleadosPrendasPedidasController(PrendaPedidaService prendaPedidaService)
        {
            _prendaPedidaService = prendaPedidaService;
        }
    

        // GET: api/<EmpleadosPrendasPedidasController>
        [HttpGet]
        public async Task<ActionResult<List<EmpleadoPrendaPedida>>> Get()
        {
            var empleadoPrendaPedida = await _prendaPedidaService
                                            .ObtenerPrendaPedidasEmpleado();
            return empleadoPrendaPedida;
            
        }

        //// GET api/<EmpleadosPrendasPedidasController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<EmpleadosPrendasPedidasController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<EmpleadosPrendasPedidasController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<EmpleadosPrendasPedidasController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
