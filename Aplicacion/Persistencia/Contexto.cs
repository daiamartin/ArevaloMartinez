using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Persistencia
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
       // public DbSet<Plano> Planos { get; set; }
       // public DbSet<Disenador> Disenadores { get; set; }
        //public DbSet<Planificacion> Planificaciones { get; set; }
       
    }
}