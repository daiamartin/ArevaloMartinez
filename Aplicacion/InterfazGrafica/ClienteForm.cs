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
    public partial class ClienteForm : Form
    {


        private FabricaControlador fabricaControlador;
        private Validacion validacion;
        private Conector conector;
        private ICliente icliente;


        String cedula;
        String cedulaNueva;
        String nombre;
        String apellido;
        String telefono;
        int preferencia;

        public ClienteForm()
        {
            InitializeComponent();
            inicializaVentanaCliente();
        }



        private void inicializaVentanaCliente()
        {

            fabricaControlador = FabricaControlador.getFabrica();
            icliente = new ClienteControlador();
            validacion = new Validacion();
            conector = new Conector();
            conector.cargarDataGridClientes(dataGridViewClientes, icliente.ObtenerClientes());
        }

        private void buttonAgregarCliente_Click(object sender, EventArgs e)
        { /*
            try
            {
                datosIngresadosCliente(out cedula, out nombre, out apellido, out telefono, out preferencia);

               if (validacion.CamposCorrectosCliente(cedula, nombre, apellido, telefono, preferencia))
                {
                    icliente.AgregarCliente(cedula, nombre, apellido, telefono, preferencia);     
                    conector.cargarDataGridClientes(dataGridViewClientes, icliente.ObtenerClientes());
                    txtCedula.Text = "";
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtTelefono.Text = "";
                    comboPreferencia.Value = 1;

                }
                else
                {
                    MessageBox.Show("Valores incompletos o incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ExcepcionMensaje exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception otraExcepcion)
            {
                MessageBox.Show("Error inesperado. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            */
        }

        private void datosIngresadosCliente(out String cedula, out String nombre, out String apellido, out String telefono, out int preferencia)
        {

            cedula = txtCedula.Text.Trim();
            nombre = txtNombre.Text.Trim();
            apellido = txtApellido.Text.Trim();
            telefono = txtTelefono.Text.Trim();
            preferencia = Convert.ToInt32(comboPreferencia.Value);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IngresoCliente_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewClientes.CurrentCell.OwningRow;
            cedula = row.Cells["Cedula"].Value.ToString();
            nombre = row.Cells["Nombre"].Value.ToString();
            apellido = row.Cells["Apellido"].Value.ToString();
            telefono = row.Cells["Telefono"].Value.ToString();
            preferencia = Convert.ToInt32(row.Cells["Prioridad"].Value.ToString());

            txtCedula.Text = cedula;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtTelefono.Text = telefono;
            comboPreferencia.Value = preferencia;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridViewClientes.CurrentCell.OwningRow;
                string cedula = row.Cells["Cedula"].Value.ToString();
                icliente.EliminarCliente(cedula);
                conector.cargarDataGridClientes(dataGridViewClientes, icliente.ObtenerClientes());
                txtCedula.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtTelefono.Text = "";
                comboPreferencia.Value = 1;
            }
            catch (ExcepcionMensaje excepcion)
            {
                conector.cargarDataGridClientes(dataGridViewClientes, icliente.ObtenerClientes());
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception otra)
            {
                MessageBox.Show("Imposible realizar esta accion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
                  try
              {
                  DataGridViewRow row = dataGridViewClientes.CurrentCell.OwningRow;
                  cedula = row.Cells["Cedula"].Value.ToString();
                  nombre = txtNombre.Text;
                  apellido = txtApellido.Text;
                  telefono = row.Cells["Telefono"].Value.ToString();
                  preferencia = Convert.ToInt32(comboPreferencia.Value);
                  cedulaNueva = txtCedula.Text;

                  if (validacion.CamposCorrectosCliente(cedula,nombre,apellido,telefono,preferencia))
                  {
                      icliente.ModificarCliente(cedula, cedulaNueva, nombre, apellido, telefono, preferencia);
                      conector.cargarDataGridClientes(dataGridViewClientes, icliente.ObtenerClientes());
                      txtCedula.Text = "";
                      txtNombre.Text = "";
                      txtApellido.Text = "";
                      txtTelefono.Text = "";
                      comboPreferencia.Value = 1;
                   }
                      else
                      {
                           MessageBox.Show("Valores incompletos o incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       }
               }
               catch (ExcepcionMensaje exception)
               {
                   MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
               catch (Exception otraExcepcion)
               {
                   MessageBox.Show("Error inesperado. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
           }*/
        }
    }
}
