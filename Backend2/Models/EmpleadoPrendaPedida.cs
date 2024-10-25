using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend2.Models
{
    public class EmpleadoPrendaPedida
    {
        public DateTime FechaPedido { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombrePrenda { get; set; }
        public int Cantidad { get; set; }
    }
}
