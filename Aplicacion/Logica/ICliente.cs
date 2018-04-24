using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Logica
{
    public interface ICliente
    {
        void AgregarCliente(string nombreUsuario, string contrasena, string nombre, string apellido, string direccion, string documento);

        void EliminarCliente(string nombreUsuario);

        void ModificarCliente(string nombreUsuario, string contrasena, string nombre, string apellido, string direccion, string documento);

        //List<string> ObtenerCedulaClientes();

        List<Cliente> ObtenerClientes();

        Cliente ObtenerCliente(String nombreUsuario);
    }
}
