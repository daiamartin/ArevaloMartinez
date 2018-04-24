using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public abstract class Usuario
    {

       // public long Id { get; set; }

        public String NombreUsuario { get; set; }

        public String Contrasena { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime Registro { get; set; }

        public DateTime UltimoIngreso { get; set; }

        public override String ToString()
        {
            return this.NombreUsuario;
        }
    }
}