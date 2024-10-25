using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend2.Models
{
	public class Usuarios
	{
		public int Id {get; set;}
		public string NombreUsuario { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public DateTime FechaCreacion { get; set; }
		public DateTime UltimoAcceso { get; set; }
    }
}
