using Backend2.Data;
using Backend2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend2.Services
{
    public class PrendaPedidaService
    {
        private readonly AplicationDbContext _context;

        public PrendaPedidaService(AplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<EmpleadoPrendaPedida>> ObtenerPrendaPedidasEmpleado()
        {
            var prendaPedida = await _context.EmpleadoPrendaPedidas
                                            .FromSqlRaw("Exec ObtenerPrendasPedidas")
                                            .ToListAsync();
            return prendaPedida;
        }
    }
}
