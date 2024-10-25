using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend2.Models
{
    public class HistorialAcceso
    {
       public int Id {get; set;}
       public int  UsuarioId  {get; set;}
       public DateTime FechaAcceso  {get; set;}
       public string  IP  {get; set;}
    }
}
