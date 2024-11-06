using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend2.Models
{
    public class PedidoConPrendas
    {
        public int EmpleadoId { get; set; }
        public DateTime FechaPedido { get; set; }
        public List<PrendaPedido> PrendasPedidas { get; set; }
    }
}
