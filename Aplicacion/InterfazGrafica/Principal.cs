using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Logica;

namespace InterfazGrafica
{
    public partial class Principal : Form
    {

        private FabricaControlador fabrica;


        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteForm ingresoCliente = new ClienteForm();
            ingresoCliente.Show();
        }

        private void moificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no era requisito para esta instancia", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void eliminarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no era requisito para esta instancia", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void modificarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no era requisito para esta instancia", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void eliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no era requisito para esta instancia", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }




        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteForm ventana = new ClienteForm();
            ventana.Show();
        }


        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClienteForm ventana = new ClienteForm();
            ventana.Show();
        }
    }
}
