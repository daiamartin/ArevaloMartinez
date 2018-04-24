using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Dominio;
using Logica;

namespace TestUnitario
{
    public class PlanoTest
    {
        private FabricaControlador fabricaControlador;


        [Theory]
        [InlineData("toresComercial")]
        public void EliminarPlanoQueNoExiste(string nombre)
        {
            try
            {
                fabricaControlador = FabricaControlador.getFabrica();
                fabricaControlador.getIPlano().EliminarPlano(nombre);


            }
            catch (Exception e)
            {

                Assert.Contains("Referencia ", e.Message.ToString());
            }


        }
        //[Theory]
        //[InlineData("3.100.585-8", "Cuaderno", 1550)]
        ////  [InlineData("4.592.372-4", "Paquete", 25, DateTime.Now.AddDays(25))]
        //public void EliminiarPedidoExistente(string cedulaCliente, string nombreProducto, int cantidad)
        //{

        //    fabricaControlador = FabricaControlador.getFabrica();
        //    fabricaControlador.getICliente().AgregarCliente(cedulaCliente, "Emilse", "Rodriguez", "23053264", 3);
        //    fabricaControlador.getIProducto().AgregarProducto(nombreProducto, 500, 560, 20, "Es un producto de alta calidad");
        //    long idPedido = fabricaControlador.getIPedido().AgregarPedido(cedulaCliente, nombreProducto, cantidad, DateTime.Now);

        //    fabricaControlador.getIPedido().EliminarPedido(idPedido);

        //    Pedido pedido = fabricaControlador.getIPedido().ObtenerPedido(idPedido);

        //    Assert.Equal(null, pedido);


        //}


        ///*   [Theory]
        // [InlineData(1, 200, "2015/12/31", "2015/11/01", "2015/11/20", true)]
        // [InlineData(2, 10, "2015/12/31", "2015/11/01", "", false)]
        // [InlineData(3, 22, "2016/12/1", "2016/10/12", "2016/11/15", true)]
        // public void crearPedido(string cedulaCliente, string nombreProducto, int cantidad, DateTime fechaEntrega)
        // {

        //    DateTime entrega = conviertoStringToDateTime(fechaAEntregar);
        //      DateTime inicio = conviertoStringToDateTime(fechaInicio);
        //      DateTime fin = conviertoStringToDateTime(fechaFin);

        //      Pedido pedido = new Pedido();
        //      pedido.Id = id;
        //      pedido.Cantidad = cantidad;
        //      pedido.FechaAEntregar = entrega;
        //      pedido.FechaInicio = inicio;
        //      pedido.FechaFin = fin;
        //      pedido.Planificado = completado;
        //      pedido.Cliente = retornaCliente();
        //      pedido.Producto = retornaProducto();

        //      Assert.Equal(id, pedido.Id);
        //      Assert.Equal(cantidad, pedido.Cantidad);
        //      Assert.Equal(entrega, pedido.FechaAEntregar);
        //      Assert.Equal(inicio, pedido.FechaInicio);
        //      Assert.Equal(fin, pedido.FechaFin);
        //      Assert.Equal(completado, pedido.Planificado);
        //      Assert.Equal(retornaCliente().Cedula, pedido.obtenerSolicitante());
        //      Assert.Equal(retornaProducto().Nombre, pedido.obtenerTipoProducto());

        // }*/

        //[Theory]
        //[InlineData("3.919.335-8", "Cuadernolas", 1550)]

        //public void IngresarPedido(string cedulaCliente, string nombreProducto, int cantidad)
        //{

        //    fabricaControlador = FabricaControlador.getFabrica();
        //    fabricaControlador.getICliente().AgregarCliente(cedulaCliente, "Emilse", "Rodriguez", "23053264", 3);
        //    fabricaControlador.getIProducto().AgregarProducto(nombreProducto, 500, 560, 20, "Es un producto de alta calidad");
        //    long idPedido = fabricaControlador.getIPedido().AgregarPedido(cedulaCliente, nombreProducto, cantidad, DateTime.Now);

        //    Pedido pedido = fabricaControlador.getIPedido().ObtenerPedido(idPedido);
        //    ValidarPedido(cedulaCliente, nombreProducto, cantidad, DateTime.Now, idPedido, pedido);
        //}

        //[Theory]
        //[InlineData("3.919.585-8", "Cuadernito", 1550, "Pollos", 600)]
        ////  [InlineData("4.592.372-4", "Paquete", 25, DateTime.Now.AddDays(25))]
        //public void ModificarPedido(string cedulaCliente, string nombreProducto, int cantidad, string cambioProducto, int cant)
        //{


        //    fabricaControlador = FabricaControlador.getFabrica();
        //    fabricaControlador.getICliente().AgregarCliente(cedulaCliente, "Emilse", "Rodriguez", "23053264", 3);
        //    fabricaControlador.getIProducto().AgregarProducto(nombreProducto, 500, 560, 20, "Es un producto de alta calidad");
        //    fabricaControlador.getIProducto().AgregarProducto(cambioProducto, 500, 560, 20, "Es un producto gordito");
            
        //    long idPedido = fabricaControlador.getIPedido().AgregarPedido(cedulaCliente, nombreProducto, cantidad, DateTime.Now);

        //    fabricaControlador.getIPedido().ModificarPedido(idPedido, cedulaCliente, cambioProducto, 600, DateTime.Now);
        //    Pedido pedido = fabricaControlador.getIPedido().ObtenerPedido(idPedido);
        //    var nombreC = pedido.Cliente.Cedula;
        //    var nombreP = pedido.Producto.Nombre;
        //    Assert.Equal(idPedido, pedido.Id);
        //    Assert.Equal(cedulaCliente, nombreC);
        //    Assert.Equal(cambioProducto, nombreP);
        //    Assert.Equal(cant, pedido.Cantidad);
        //    Assert.Equal(DateTime.Now, pedido.FechaAEntregar);

        //}

       /* private static void ValidarPedido(string cedulaCliente, string nombreProducto, int cantidad, DateTime fechaEntrega, long idPedido, Pedido pedido)
        {
            Assert.Equal(idPedido, pedido.Id);
            Assert.Equal(cedulaCliente, pedido.Cliente.Cedula);
            Assert.Equal(nombreProducto, pedido.Producto.Nombre);
            Assert.Equal(cantidad, pedido.Cantidad);
            Assert.Equal(fechaEntrega, pedido.FechaAEntregar);

        }*/

//#region METODOS PRIVADOS
//        private DateTime conviertoStringToDateTime(string fechaAConvertir)
//        {
//            try
//            {
//                return DateTime.Parse(fechaAConvertir);
//            }
//            catch (Exception e)
//            {
//                return DateTime.MaxValue;
//            }
//        }

//        private Cliente retornaCliente()
//        {
//            Cliente cliente = new Cliente();

//            cliente.Id = 9999;
//            cliente.Cedula = "3.919.585-8";
//            cliente.Nombre = "Alejandro";
//            cliente.Apellido = "Frankenstein";
//            cliente.Telefono = "2708 4851";
//            cliente.Prioridad = 10;

//            return cliente;
//        }

//        private Producto retornaProducto()
//        {

//            Producto producto = new Producto();
//            producto.Id = 9999;
//            producto.Nombre = "Bicicleta";
//            producto.CostoProduccion = 177;
//            producto.PrecioVenta = 477;
//            producto.MinutosEnFabricar = 90;

//            return producto;
//        }

//        #endregion

  }
}
