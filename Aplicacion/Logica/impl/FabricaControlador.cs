using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;

namespace Logica
{
    public class FabricaControlador
    {

        private static FabricaControlador fabrica = null;

        public static FabricaControlador getFabrica()
        {
            if (fabrica == null)
            {
                fabrica = new FabricaControlador();
                
            }
            return fabrica;
        }

        public ICliente getICliente() {
            ICliente iCliente = new ClienteControlador();
            return iCliente;
        }

        public IAdministrador getIAdministrador()
        {
            IAdministrador iAdministrador = new AdministradorControlador();
            return iAdministrador;
        }

        public IPlano getIPlano()
        {
            IPlano iPlano = new PlanoControlador();
            return iPlano;
        }

      
        
    }
}
