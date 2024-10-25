using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend2.Models
{
    public class InsertarPedidoPrenda
    {
        public int EmpleadoId { get; set; }
        public DateTime FechaPedido { get; set; }
        public int IdPrenda { get; set; }
        public string Talle { get; set; }
        public int  Cantidad { get; set; }
    }
}
