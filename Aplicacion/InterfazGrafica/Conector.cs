using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Logica;

namespace InterfazGrafica
{
    public class Conector
    {
      

        public void completoCombo(ComboBox combo, List<string> listado)
        {
           combo.Items.Clear();
           foreach (string elemento in listado)
            {
                combo.Items.Add(elemento);
            }
            combo.Refresh();
        }

        public void cargarDataGridClientes(DataGridView dataGridViewClientes,List<Cliente> clientes)
        {
            
           dataGridViewClientes.DataSource = new BindingList<Cliente>(clientes);
           dataGridViewClientes.Refresh();  
        }

              
        
    }
}
