using System;
using System.Linq;
using Dominio;
using Logica;
using Xunit;

namespace TestUnitario
{
    public class ClienteTest
    {

        private FabricaControlador fabricaControlador;
        //De Las 9 pruebas,7 tienen que dar error.
        [Theory]
        [InlineData("dmartinez", "pass", "Daiana", "Martinez", "Cuareim 357", "2.213.755-9")]//check:ingreso correcto
        public void AgregarCliente(string nombreUsuario, string contrasena, string nombre, string apellido, string direccion, string documento)
        {
            try
            {

                fabricaControlador = FabricaControlador.getFabrica();
                fabricaControlador.getICliente().AgregarCliente(nombreUsuario, contrasena, nombre, apellido, direccion, documento);

                Cliente cliente = fabricaControlador.getICliente().ObtenerCliente(nombreUsuario);

                ValidarCliente(nombreUsuario, contrasena, nombre, apellido, direccion, documento, cliente);
            }
            catch (Exception e)
            {
                try
                {
                    Assert.Contains("Error", e.Message.ToString());
                }
                catch (Exception ex)
                {

                    Assert.Contains("El cliente ya existe", ex.Message.ToString());
                }


            }

        }
        [Theory]
        [InlineData("dmartinez", "pass", "Daiana", "Martinez", "Cuareim 357", "2.213.755-9")]//check:ingreso correcto
        public void EliminarCliente(string nombreUsuario, string contrasena, string nombre, string apellido, string direccion, string documento)
        {
            fabricaControlador = FabricaControlador.getFabrica();
            fabricaControlador.getICliente().AgregarCliente(nombreUsuario: nombreUsuario, contrasena: contrasena, nombre: nombre, apellido: apellido, direccion: direccion, documento: documento);

            fabricaControlador.getICliente().EliminarCliente(nombreUsuario);
            Cliente cliente = fabricaControlador.getICliente().ObtenerCliente(nombreUsuario);
            Assert.Equal(cliente, null);

        }
        [Theory]
        [InlineData("dmartinez", "pass", "Daiana", "Martinez", "Cuareim 357", "2.213.755-9")]//check:ingreso correcto
        public void EliminarClienteConError(string nombreUsuario, string contrasena, string nombre, string apellido, string direccion, string documento)
        {
            try
            {
                fabricaControlador = FabricaControlador.getFabrica();

                fabricaControlador.getICliente().EliminarCliente(nombreUsuario);
                Cliente cliente = fabricaControlador.getICliente().ObtenerCliente(nombreUsuario);
                Assert.Equal(cliente, null);
            }
            catch (ExcepcionMensaje exception)
            {

                Assert.Contains("Error. No existe Cliente.", exception.ToString());
            }

        }
        [Theory]
        [InlineData("dmartinez", "pass", "Daiana", "Martinez", "Cuareim 357", "2.213.755-9", "nuevaPass", "Ana", "Calo", "Mercedes 987", "3.333.755-9")]//check:ingreso correcto
        public void ModificarCliente(string nombreUsuario, string contrasena, string nombre, string apellido, string direccion, string documento, string nuevaCcontrasena, string nuevoNombre, string nuevoAapellido, string nuevaDireccion, string nuevoDocumento)
        {
            try
            {
                fabricaControlador = FabricaControlador.getFabrica();
                fabricaControlador.getICliente().AgregarCliente(nombreUsuario: nombreUsuario, contrasena: contrasena, nombre: nombre, apellido: apellido, direccion: direccion, documento: documento);


                fabricaControlador.getICliente().ModificarCliente(nombreUsuario, nuevaCcontrasena, nuevoNombre, nuevoAapellido, nuevaDireccion, nuevoDocumento);
                Cliente cliente = fabricaControlador.getICliente().ObtenerCliente(nombreUsuario);

                ValidarCliente(nombreUsuario, nuevaCcontrasena, nuevoNombre, nuevoAapellido, nuevaDireccion, nuevoDocumento, cliente);

            }
            catch (Exception e)
            {
                fabricaControlador.getICliente().ModificarCliente(nombreUsuario, contrasena, nombre, apellido, direccion, documento);
                Cliente cliente = fabricaControlador.getICliente().ObtenerCliente(nombreUsuario);

                ValidarCliente(nombreUsuario, contrasena, nombre, apellido, direccion, documento, cliente);

                // Assert.Contains("El cliente Ya existe", e.Message.ToString());
            }
        }
        [Theory]
        [InlineData("dmartinez", "pass", "Daiana", "Martinez", "Cuareim 357", "2.213.755-9", "nuevaPass", "Ana", "Calo", "Mercedes 987", "3.333.755-9")]//check:ingreso correcto
        public void ModificarClienteQueNoExiste(string nombreUsuario, string contrasena, string nombre, string apellido, string direccion, string documento, string nuevaCcontrasena, string nuevoNombre, string nuevoAapellido, string nuevaDireccion, string nuevoDocumento)
        {
            try
            {

                fabricaControlador = FabricaControlador.getFabrica();

                fabricaControlador.getICliente().ModificarCliente(nombreUsuario, nuevaCcontrasena, nuevoNombre, nuevoAapellido, nuevaDireccion, nuevoDocumento);
                Cliente cliente = fabricaControlador.getICliente().ObtenerCliente(nombreUsuario);

                Assert.Equal(cliente, null);
            }
            catch (Exception e)
            {
                Assert.Contains("Error", e.ToString());

            }
        }

        private static void ValidarCliente(string nombreUsuario, string contrasena, string nombre, string apellido, string direccion, string documento, Cliente cliente)
        {
            Assert.Equal(nombreUsuario, cliente.NombreUsuario);
            Assert.Equal(contrasena, cliente.Contrasena);
            Assert.Equal(nombre, cliente.Nombre);
            Assert.Equal(apellido, cliente.Apellido);
            Assert.Equal(direccion, cliente.Direccion);
            Assert.Equal(documento, cliente.Documento);
        }

        /***********************BORRAR DE ACA PARA ABAJO****************************/
        /*


        [Theory]
        [InlineData("3.333.385-1", "Dora", "Exploradora", "2708 4851", 10)]//check:ingreso correcto
        public void EliminarClienteEnPedido(string cedula, string nombre, string apellido, string telefono, int prioridad)
        {
            try
            {
                fabricaControlador = FabricaControlador.getFabrica();

                fabricaControlador.getICliente().EliminarCliente(cedula);
                Cliente cliente = fabricaControlador.getICliente().ObtenerCliente(cedula);
                Assert.Equal(null, null);
            }
            catch (ExcepcionMensaje exception)
            {

                Assert.Contains("Error", exception.Message.ToString());
            }

        }
        //De Las 9 pruebas,7 tienen que dar error.
        [Theory]
        [InlineData("3.919.585-1", "Alejandro", "Frankenstein", "2708 4851", 10)]//check:ingreso correcto
        [InlineData("2.213.755-9", "Daiana", "Martinez", "2401 4545", 1)]//check:ingreso correcto
        [InlineData("3.919.585-7", "Juan Pablo", "Piano", "2708 4851", 10)]//check:ingreso correcto
        [InlineData("3.919.585-1", "Alejandro", "Frankenstein", "2708 4851", 10)]//check:cliente ya existe(igual cedula)
        [InlineData("", "Juan", "Perez", "4554 4014", 5)]//check:falta campo cedula
        [InlineData("1.018.784-0", "", "Perez", "4554 4014", 5)]//check: falta campo nombre
        [InlineData("1.018.784-0", "Juan", "", "4554 4014", 5)]//check:falta campo apellido
        [InlineData("1.018.784-0", "Juan", "Perez", "", 5)]//check: falta campo telefono
        [InlineData("1.018.784-0", "Juan", "Perez", "4554 4014", 0)]//check:prioridad fuera de rango minimo
        [InlineData("1.018.784-0", "Juan", "Perez", "4554 4014", 11)]//check:pioridad fuera de rango maximo
        public void IngresarCliente(string cedula, string nombre, string apellido, string telefono, int prioridad)
        {
            try
            {

                fabricaControlador = FabricaControlador.getFabrica();
                fabricaControlador.getICliente().AgregarCliente(cedula, nombre, apellido, telefono, prioridad);

                Cliente cliente = fabricaControlador.getICliente().ObtenerCliente(cedula);

                ValidarCliente(cedula, nombre, apellido, telefono, prioridad, cliente);
            }
            catch (Exception e)
            {
                try
                {
                    Assert.Contains("Error", e.Message.ToString());
                }
                catch (Exception ex)
                {

                    Assert.Contains("El cliente ya existe", ex.Message.ToString());
                }


            }

        }

        [Theory]
        [InlineData("", "", "", "", 2)]
        [InlineData("3.919.585-8", "Alejandro", "Frankenstein", "2708 4851", 10)]
        [InlineData("2.213.755-9", "Daiana", "Martinez", "2401 4545", 1)]
        [InlineData("1.018.784-3", "Juan", "Perez", "4554 4014", 5)]
        [InlineData("3.919.585-1", "Alejandro", "Frankenstein", "2708 4851", 10)]//check:ingreso correcto
        [InlineData("2.213.755-9", "Daiana", "Martinez", "2401 4545", 1)]//check:cliente ya existe(igual cedula)
        [InlineData("3.919.585-1", "Alejandro", "Frankenstein", "2708 4851", 10)]//check:cliente ya existe(igual cedula)
        [InlineData("", "Juan", "Perez", "4554 4014", 5)]//check:falta campo cedula
        [InlineData("1.018.784-0", "", "Perez", "4554 4014", 5)]//check: falta campo nombre
        [InlineData("1.018.784-0", "Juan", "", "4554 4014", 5)]//check:falta campo apellido
        [InlineData("1.018.784-0", "Juan", "Perez", "", 5)]//check: falta campo telefono
        [InlineData("1.018.784-0", "Juan", "Perez", "4554 4014", 0)]//check:prioridad fuera de rango minimo
        [InlineData("1.018.784-0", "Juan", "Perez", "4554 4014", 11)]//check:pioridad fuera de rango maximo
        public void CrearCliente(string cedula, string nombre, string apellido, string telefono, int prioridad)
        {
            /*   fabricaControlador = FabricaControlador.getFabrica().getICliente();
                 fabricaControlador.getICliente().
                 fachadaGuiSistema = FachadaGuiSistema.getFachada();
                 Cliente cliente = fachadaGuiSistema.crearCliente(cedula, nombre, apellido, telefono, prioridad);
                 validarCliente(cedula, nombre, apellido, telefono, prioridad, cliente);
    }
    */



    }
}
