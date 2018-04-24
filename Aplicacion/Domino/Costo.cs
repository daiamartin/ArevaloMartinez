namespace Dominio
{
    public class Costo
    {
        public long CostoPorDefecto { get; set; }

        public long PrecioPorDefecto { get; set; }

        public long ObtenerCostoMaterial()
        {

            return (CostoPorDefecto / PrecioPorDefecto);
        }

        /*        

        public long CostoProduccion { get; set; }

        public long CostoProduccionParcial { get; set; }

        public long PrecioParcial { get; set; }

        public long PrecioTotal { get; set; }*/


    }
}