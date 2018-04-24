using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Validacion
    {

        public Boolean EsCampoVacio(string texto)
        {
            return texto.Length == 0;
        }

        public bool CamposCorrectosCliente(string nombreUsuario, string contrasena, string nombre, string apellido, string direccion, string documento)
        {
            return !EsCampoVacio(nombreUsuario) && !EsCampoVacio(contrasena) && !EsCampoVacio(nombre) && !EsCampoVacio(apellido) && !EsCampoVacio(direccion) && !EsCampoVacio(documento);

        }

        public bool HayClientes(DbSet<Cliente> clientes)
        {
            if (clientes == null)
            {
                return false;
            }
            return true;


        }
    }
}
