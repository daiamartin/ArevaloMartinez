using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using Xunit;
namespace Test
{
    class ProductoPrueba
    {

        private FachadaGuiSistema fachadaGuiSistema;

        [Theory]
        [InlineData("Descripcion", 0, 0, 0)]
        public void ingresarProducto(String nombre, int costoProduccion, int precioVenta, int minutosEnFabricar)
        {

            fachadaGuiSistema.agregarProducto(nombre, costoProduccion, precioVenta, minutosEnFabricar);

            Producto producto = fachadaGuiSistema.obtenerProducto(nombre);

            Assert.Equal(1, producto.Id);
            Assert.Equal("NombreProducto", producto.Nombre);
            Assert.Equal(0, producto.CostoProduccion);
            Assert.Equal(0, producto.PrecioVenta);
            Assert.Equal(0, producto.MinutosEnFabricar);

        }

        [Fact]
        public void algo()
         {
             Producto p = new Producto();
             int a = 3;
             int b = 5;
             Assert.Equal(9, p.suma(a, b));
         }
    }
}
