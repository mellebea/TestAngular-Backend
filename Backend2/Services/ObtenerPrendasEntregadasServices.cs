using Backend2.Data;
using Backend2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend2.Services
{
    public class ObtenerPrendasEntregadasServices
    {
        private readonly AplicationDbContext _context;

        public ObtenerPrendasEntregadasServices(AplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<PrendasEntrgadas>> ObtenerPrendasEntregadas(string nombre, string apellido)
        {
            var PrendasEntrgadas = await _context.PrendasEntrgadas
                                   .FromSqlInterpolated($"EXEC ObtenerPrendasEntregadas @nombre={nombre}, @apellido={apellido}")
                                   .ToListAsync();
            return PrendasEntrgadas;
        }
    }
}
