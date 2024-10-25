using Backend2.Data;
using Backend2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrendasPedidasController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public PrendasPedidasController(AplicationDbContext context) 
        {
            _context = context;
        }
        // GET: api/<PrendasPedidasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listadoSP_PrendasPedidas = await _context.PrendasPedidas.ToListAsync();
                return Ok(listadoSP_PrendasPedidas);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<PrendasPedidasController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PrendasPedidasController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PrendasPedidasController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PrendasPedidasController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
