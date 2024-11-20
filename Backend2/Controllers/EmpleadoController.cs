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
    public class EmpleadoController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public EmpleadoController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<EmpleadoController> -- Obtiene el listado de empleados
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listadoEmpleado = await _context.Empleados.ToListAsync();
                return Ok(listadoEmpleado);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //Para filtra por nombre o apellido
        [HttpGet("Filtrar")]
        public async Task<IActionResult> FiltrarEmpleado([FromQuery] string nombre, [FromQuery] string apellido)
        {
            try
            {
                var empleados = await _context.Empleados
                    .FromSqlInterpolated($"EXEC FiltrarEmpleado @nombre = {nombre}, @apellido = {apellido}")
                    .ToListAsync();

                if (empleados == null || empleados.Count == 0)
                {
                    return NotFound();
                }

                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST api/<EmpleadoController> Ingresa un Empleados
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Empleados empleados)
        {
            if (!ModelState.IsValid)
            {
                // Registrar el ModelState para ver si algún campo no está validado correctamente
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                return BadRequest(new { Message = "Error de validación", Errors = errors });
            }

            try
            {
                if (empleados == null)
                    return BadRequest("El empleado no puede ser nulo");

                _context.Add(empleados);
                await _context.SaveChangesAsync();
                return Ok(empleados);
            }
            catch (DbUpdateException dbEx)
            {
                var innerMessage = dbEx.InnerException?.Message ?? dbEx.Message;
                return BadRequest($"Error al guardar el empleado: {innerMessage}");
            }
            catch (Exception ex)
            {

                return BadRequest($"{ ex.Message}");
            }
        }

        // PUT api/<EmpleadoController>/5 Actualiza un empleado en especifico
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Empleados empleados)
        {
            try
            {
                if (id != empleados.Id) 
                {
                    return BadRequest("El ID de la URL no coincide con el ID del objeto.");
                }
                //var existingEmpleado = await _context.Empleados.FindAsync(id);
                //if (existingEmpleado == null)
                //{
                //    return NotFound("El empleado no existe.");
                //}
                //existingEmpleado.Nombre = empleados.Nombre;
                //existingEmpleado.Apellido = empleados.Apellido;
                //existingEmpleado.Email = empleados.Email;
                //existingEmpleado.TallePredeterminado = empleados.TallePredeterminado;
                _context.Update(empleados);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Registro Actualizado con Exito ...!!!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EmpleadoController>/5 Elimina un empleado
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var empleados = await _context.Empleados.FindAsync(id);
                if (empleados==null) 
                {
                    return NotFound();
                }
                _context.Empleados.Remove(empleados);
                _context.SaveChangesAsync();
                return Ok(new { message = "Registro eliminado con Exito ... !!!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("{id}")] 
        // GET api/<EmpleadoController>/5 -- Obtiene un empleado en especifico
        //public async Task<IActionResult> Get(int id)
        //{
        //    try
        //    {
        //        var empleados = await _context.Empleados.FindAsync(id);
        //        if (empleados == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(empleados);
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }

        //}
    }
}
