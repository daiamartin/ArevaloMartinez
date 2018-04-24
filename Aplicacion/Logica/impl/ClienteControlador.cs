using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Dominio;
using System.Data.Entity;

namespace Logica
{
    public class ClienteControlador : ICliente
    {
        private Contexto context;

        private Validacion validacion;

        private ClienteDB clienteDB;

        public ClienteControlador(Contexto contexto)
        {
            this.context = contexto;
        }

        public ClienteControlador()
        {
            Inicializar(out validacion, out clienteDB);
        }

        public void AgregarCliente(string nombreUsuario, string contrasena, string nombre, string apellido, string direccion, string documento)
        {

            if (validacion.CamposCorrectosCliente(nombreUsuario, contrasena,nombre, apellido,  direccion, documento))
            {
                Cliente cliente = CrearCliente(nombreUsuario, contrasena, nombre, apellido, direccion, documento);
                
                clienteDB.AgregarCliente(cliente);
            }
            else
            {
                throw new ExcepcionMensaje("Error. Faltan campos.");
            }
        }

        private Cliente CrearCliente(string nombreUsuario, string contrasena, string nombre, string apellido, string direccion, string documento)
        {
            if (validacion.CamposCorrectosCliente(nombreUsuario,contrasena,nombre,apellido,direccion,documento))
            {
                if (!clienteDB.existeCliente(nombreUsuario))
                {
                    Cliente cliente = new Cliente();

                    cliente.NombreUsuario = nombreUsuario;
                    cliente.Contrasena = contrasena;
                    cliente.Nombre = nombre;
                    cliente.Apellido = apellido;
                    cliente.Direccion = direccion;
                    cliente.Documento = documento;

                    return cliente;

                }
                else
                {
                    throw new ExcepcionMensaje("El cliente ya existe.");
                }
            }
            else
                throw new ExcepcionMensaje("Error.Faltan campos.");

        }

        public void EliminarCliente(string nombreUsuario)
        {
            try
            {
                Contexto contexo = new Contexto();
                if (validacion.HayClientes(contexo.Clientes))
                {
                    if (clienteDB.existeCliente(nombreUsuario))
                    {

                        if (!clienteDB.clienteEstaEnPlano(nombreUsuario))
                        {
                            clienteDB.EliminarCliente(nombreUsuario);
                        }
                        else
                        {
                            throw new ExcepcionMensaje("El cliente seleccinado no se puede eliminar debido a que ya realizo un pedido.");
                        }
                    }
                    else
                    {
                        throw new ExcepcionMensaje("Error. No existe Cliente.");
                    }
                }
                else
                {
                    throw new ExcepcionMensaje("Error. No existe Cliente.");
                }
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void ModificarCliente(string nombreUsuario, string contrasena, string nombre, string apellido, string direccion, string documento)
        {
            try
            {
                Contexto contexo = new Contexto();
                if (validacion.HayClientes(contexo.Clientes))
                {
                    if (clienteDB.existeCliente(nombreUsuario))
                    {
                        clienteDB.ModificarCliente(nombreUsuario, contrasena, nombre, apellido, direccion, documento);
                    }
                    else
                    {
                        throw new ExcepcionMensaje("Error. No se pudo modificar Cliente.");
                    }
                }
                else
                {
                    throw new ExcepcionMensaje("Error. No hay Cliente.");
                }
            }
            catch
            {
                throw new ExcepcionMensaje("Error. No se pudo modificar Cliente.");
            }
        }

        public Cliente ObtenerCliente(String nombreUsuario) {
            return clienteDB.ObtenerCliente(nombreUsuario);
        }

        /*public List<string> ObtenerCedulaClientes()
        {
            return clienteDB.ObtenerCedulaClientes(); 
        }*/

        public List<Cliente> ObtenerClientes()
        {
            return clienteDB.ObtenerClientes();
        }

        private long ClienteObtenerId(Cliente cliente)
        {
            return 0;
          
        }

       
        private static void Inicializar(out Validacion validacion, out ClienteDB clienteDB)
        {
            validacion = new Validacion();
            Contexto contexo = new Contexto();
            clienteDB = new ClienteDB(contexo);
        }

    }
}



