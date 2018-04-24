using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.Entity;

namespace Persistencia
{
    public class ClienteDB
    {
        private Contexto contexto;

        public ClienteDB(Contexto pContexto)
        {
            this.contexto = pContexto;
        }

        public void AgregarCliente(Cliente cliente)
        {
            contexto.Clientes.Add(cliente);           
            contexto.SaveChanges();
        }

        public Cliente ObtenerCliente(String nombreUsurio)
        {
            Cliente consulta = null;
            if (this.existeCliente(nombreUsurio))
            {
                consulta = (from cliente in contexto.Clientes
                            where cliente.NombreUsuario == nombreUsurio
                            select cliente).First();
            }           
            return consulta;
        }
        /*
        public List<string> ObtenerNombreUsuarioClientes()
        {
            List<string> nombreUsuarioClientes= new List<string>();

            var consulta = from cliente in contexto.Clientes
                           select cliente.NombreUsuario;

            foreach (var item in consulta)
            {
                nombreUsuarioClientes.Add(item);
            }

            return nombreUsuarioClientes;
        }
        */
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = contexto.Clientes.ToList<Cliente>();
            clientes.Sort(delegate(Cliente unCliente, Cliente otroCliente)
            {
                // return otroCliente.Id.CompareTo(unCliente.Id);
                return otroCliente.NombreUsuario.CompareTo(unCliente.NombreUsuario);
            });
            return clientes;
        }

        public bool existeCliente(string nombreUsuario)
        {
           Cliente existe = new Cliente();
            contexto = new Contexto();
            var consulta = from cliente in contexto.Clientes
                           where cliente.NombreUsuario == nombreUsuario
                           select cliente;

            foreach (var c in consulta)
            {
                if (c.NombreUsuario == nombreUsuario)
                {
                    return true;
                }
            }
            return false;
        }

        public void EliminarCliente(string nombreUsurio)
        {
            Cliente cliente = ObtenerCliente(nombreUsurio);
            contexto.Clientes.Attach(cliente);
            contexto.Clientes.Remove(cliente);
            contexto.SaveChanges();
        }

       

        public bool clienteEstaEnPlano(string nombreUsuario)
        {
            /*      try
                  {
                      Plano consulta = (from p in contexto.Planos.Include("Cliente")
                                        where p.Cliente.NombreUsuario == nombreUsuario
                                         select p).First();

                      return consulta != null;
                  }
                  catch (Exception e)
                  {
                      return false;
                  }
                  */
            return false;// TO DO
        }

        public void ModificarCliente(string nombreUsuario, string contrasena, string nombre, string apellido, string direccion, string documento)
        {
            {
                Cliente cliente = ObtenerCliente(nombreUsuario);
                cliente.NombreUsuario=nombreUsuario;
                cliente.Contrasena = contrasena;
                cliente.Nombre = nombre;
                cliente.Apellido = apellido;
                cliente.Direccion = direccion;
                cliente.Documento = documento;

                contexto.SaveChanges();
            }
        }
    }
}