using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend2.Models
{
    public class PrendasEntrgadas
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
	    public int PrendaId { get; set; }
	    public DateTime FechaEntrega { get; set; }
    }
}
