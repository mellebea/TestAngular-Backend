using Backend2.Data;
using Backend2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend2.Services
{
    public class InsertarPedidoSerivce
    {
        private readonly AplicationDbContext _context;

        public InsertarPedidoSerivce (AplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertarPedido(int empleadoId, DateTime fechaPedido, int prendaId,string talle, int cantidad)
        {
            try
            {
                var fechaPedidoValue = DateTime.Now; // Asignar fecha actual si es nulo
                

                var empleadoIdParam = new SqlParameter("@EmpleadoId", empleadoId);
                var fechaPedidoParam = new SqlParameter("@FechaPedido", fechaPedidoValue);
                var prendaIdParam = new SqlParameter("@IdPrenda", prendaId);
                var talleParam = new SqlParameter("@Talle", talle);
                var cantidadParam = new SqlParameter("@Cantidad", cantidad);
                Console.WriteLine();
                await _context.Database.ExecuteSqlRawAsync
                     ("exec InsertarPedidoEmpleado @EmpleadoId,@FechaPedido, @IdPrenda, @Talle, @Cantidad",
                     empleadoIdParam, fechaPedidoParam, prendaIdParam, talleParam, cantidadParam);


            }
            catch (Exception ex)
            {

                throw new Exception($"Error al insertar el pedido: {ex.Message}");
            }
            
        }
    }
}
