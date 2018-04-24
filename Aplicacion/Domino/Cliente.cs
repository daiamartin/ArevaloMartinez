using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Cliente : Usuario
    {
        public string Documento { get; set; }

        public string Telefono { get; set; }

        public String Direccion { get; set; }

    }


}
