
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Plano
    {
        //public long Id { get; set; }

        public String Nobre { get; set; }

        public Superficie Planificado { get; set; }

        public Cliente Cliente { get; set; }

        public Disenador Disenador { get; set; }

        public Costo Costo { get; set; }

       // public Estado Estado { get; set; }

        public string ObtenerCliente()
        {
            return this.Cliente.NombreUsuario;
        }

        public string ObtenerDisenador()
        {
            return this.Disenador.NombreUsuario;
        }

        public long ObtenerCosto()
        {
            return this.Costo.CostoPorDefecto;
        }

        public long ObtenerPrecio()
        {
            return this.Costo.PrecioPorDefecto;
        }

        public long ObtenerMateriales()
        {
            return this.Costo.ObtenerCostoMaterial();
        }

        public struct Superficie
        {
            public int ancho;
            public int largo;
            public int cantidadMetrosCuadrados;


        }

    }
}
