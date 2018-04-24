using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ExcepcionMensaje : System.Exception
    {
        String msg;
        public ExcepcionMensaje(String mensaje)
            : base(mensaje)
        {
            msg = mensaje;
        }

        public override string Message
        {
            get
            {
                string msg = base.Message;
                return msg;
            }
        }
    }
}