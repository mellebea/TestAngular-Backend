using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend2.Models
{
    public class PrendasEntrgadas
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public string NombrePrenda { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
