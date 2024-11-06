using Backend2.Data;
using Backend2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Backend2.Services
{
    public class PedidoService
    {
        private readonly AplicationDbContext _context;

        public PedidoService(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task InsertarPedidoConPrendas(PedidoConPrendas pedido)
        {
            try
            {


                var prendasTable = new DataTable();

                prendasTable.Columns.Add("PrendaId", typeof(int));
                prendasTable.Columns.Add("Talle", typeof(string));
                prendasTable.Columns.Add("Cantidad", typeof(int));

                foreach (var prenda in pedido.PrendasPedidas)
                {
                    Console.WriteLine($"PrendaId: {prenda.PrendaId}, Talle: {prenda.Talle}, Cantidad: {prenda.Cantidad}");
                    prendasTable.Rows.Add(prenda.PrendaId, prenda.Talle, prenda.Cantidad);
                }


                var prendasParam = new SqlParameter("@PrendasPedidas", prendasTable)
                {
                    SqlDbType = SqlDbType.Structured,
                    TypeName = "dbo.PrendaPedidoTableType"
                };

                // Otros parámetros del stored procedure
                var empleadoIdParam = new SqlParameter("@EmpleadoId", pedido.EmpleadoId);
                var fechaPedidoParam = new SqlParameter("@FechaPedido", pedido.FechaPedido);

                // Ejecutar el stored procedure usando ExecuteSqlRawAsync
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC [dbo].[InsertarPedidoConPrendas] @EmpleadoId, @FechaPedido, @PrendasPedidas",
                    empleadoIdParam, fechaPedidoParam, prendasParam);

            }
            catch (SqlException ex)
            {
                // Registrar la excepción
                Console.WriteLine("Error al insertar el pedido: " + ex.Message);
                //return (500, new { message = "Error al insertar el pedido", details = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inesperado: " + ex.Message);
                //return StatusCode(500, new { message = "Error inesperado", details = ex.Message });
            }
            //catch (Exception ex)
            //{

            //    throw new Exception($"Error al insertar el pedido con listado de prendas: {ex.Message}");
            //}


        }
    }
}
