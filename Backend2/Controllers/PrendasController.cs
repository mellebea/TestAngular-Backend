using Backend2.Data;
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
    public class PrendasController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public PrendasController(AplicationDbContext context) 
        {
            _context = context;
        }
        // GET: api/<PrendasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listadoPrendas = await _context.Prendas.ToListAsync();
                return Ok(listadoPrendas);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<PrendasController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PrendasController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PrendasController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PrendasController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
