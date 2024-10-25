using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend2.Models
{
    public class PrendasPedidas
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int PrendaId { get; set; }
        public string Talle { get; set; }
        public int Cantidad { get; set; }

    }
}

