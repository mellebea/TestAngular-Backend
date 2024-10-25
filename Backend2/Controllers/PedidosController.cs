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
    public class PedidosController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public PedidosController(AplicationDbContext context) 
        {
            _context = context;
        }
        // GET: api/<PedidosController> --- OBTENGO EL LISTADO DE PEDIDOS
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listadoPedido = await _context.Pedidos.ToListAsync();
                return Ok(listadoPedido);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<PedidosController>/5 --- OBTENGO UN PEDIDO EN ESPECIFICO
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pedido = await _context.Pedidos.FindAsync(id);
                if (pedido == null) 
                {
                    return NotFound();
                }
                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<PedidosController> --- INGRESO UN PEDIDO
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pedidos pedidos)
        {
            try
            {
                _context.Add(pedidos);
                _context.SaveChangesAsync();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PedidosController>/5 --- ACTUALIZA EN PEDIDO
        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, [FromBody] Pedidos pedidos)
        {
            try
            {
                if (id != pedidos.Id)
                {
                    return NotFound();
                }
                _context.Pedidos.Update(pedidos);
                _context.SaveChangesAsync();
                return Ok(new { Message="Actualizado con exito..." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }

        // DELETE api/<PedidosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pedidos = await _context.Pedidos.FindAsync(id);
                if (pedidos == null) 
                {
                    return NotFound();
                }
                _context.Pedidos.Remove(pedidos);
                _context.SaveChangesAsync();
                return Ok(new { Message = "Eliminado con exito...!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
