using Backend2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend2.Data
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Prendas> Prendas { get; set; }
        public DbSet<PrendasPedidas> PrendasPedidas { get; set; }
        public DbSet<EmpleadoPrendaPedida> EmpleadoPrendaPedidas { get; set; }
        public DbSet<InsertarPedidoPrenda> InsertarPedidoPrenda { get; set; }
        public DbSet<PedidoConPrendas> PedidoConPrendas { get; set; }
        public DbSet<PrendaPedido> PrendaPedido { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuraciones adicionales, si son necesarias

            modelBuilder.Entity<UsuariosRoles>()
                .HasKey(ur => new { ur.UsuarioId, ur.RolId }); // Clave compuesta

            modelBuilder.Entity<EmpleadoPrendaPedida>().HasNoKey(); // Para modelos sin clave primaria
           
            modelBuilder.Entity<InsertarPedidoPrenda>().HasNoKey();  // Configura la entidad como sin clave

            modelBuilder.Entity<PedidoConPrendas>().HasNoKey(); // Para modelos sin clave primaria

            modelBuilder.Entity<PrendaPedido>().HasNoKey(); // Para modelos sin clave primaria


        }



    }


}
