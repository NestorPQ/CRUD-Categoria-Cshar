using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
// Comunicarse con la capa negocio
using CapaNegocio;

namespace CapaPresentacion1
{
    public partial class frmPresentacion : Form
    {
        // Variable que indica si vamos a insertar una categoria
        private bool IsNuevo = false;
        // Variable que indica si vamos a modificar una categoria
        private bool IsModificar = false;
        public frmPresentacion()
        {
            InitializeComponent();
        }
        private void frmPresentacion_Load(object sender, EventArgs e)
        {
            this.MostrarP();
            this.BotonesP();
            this.HabilitarP(false);
        }
        private void LimpiarP()
        {
            this.txtCodP.Text = string.Empty;
            this.txtNomP.Text = string.Empty;
            this.txtDesP.Text = string.Empty;
        }

        private void HabilitarP(bool valor)
        {
            this.txtCodP.ReadOnly = !valor;
            this.txtNomP.ReadOnly = !valor;
            this.txtDesP.ReadOnly = !valor;
        }

        private void BotonesP()
        {
            if (this.IsNuevo || this.IsModificar)
            {
                this.HabilitarP(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.HabilitarP(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.BotonesP();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.BotonesP();
            this.LimpiarP();
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas SENATI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas SENATI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MostrarP()
        {
            this.dataListadoP.DataSource = NPresentacion.MostrarP();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String Rpta = "";
            if (this.txtNomP.Text == string.Empty)
            {
                MensajeError("Falta ingresar datos");
            }
            else
            {
                if (this.IsNuevo)
                {
                    Rpta = NPresentacion.InsertarP(this.txtNomP.Text.Trim(), this.txtDesP.Text.Trim());
                }
                else
                {
                    Rpta = NPresentacion.EditarP(Convert.ToInt32(this.txtCodP.Text), this.txtNomP.Text.Trim(), this.txtDesP.Text.Trim());
                }
                if (Rpta.Equals("OK"))
                {
                    if (this.IsNuevo)
                        this.MensajeOk("Se inserto correctamente");
                    else
                        this.MensajeOk("Se modifico correctamente");
                }
                else
                {
                    this.MensajeError(Rpta);
                }
            }

            this.MostrarP();
            this.LimpiarP();
        }

      

        private void dataListadoP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtCodP.Text = Convert.ToString(this.dataListadoP.CurrentRow.Cells["idpresentacion"].Value);
            this.txtNomP.Text = Convert.ToString(this.dataListadoP.CurrentRow.Cells["nombre"].Value);
            this.txtDesP.Text = Convert.ToString(this.dataListadoP.CurrentRow.Cells["descripcion"].Value);
            this.tabControl1.SelectedIndex = 1;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Si no ha seleccionado una categoria, no puedes modificar
            if (!this.txtCodP.Text.Equals(""))
            {
                this.IsModificar = true;
                this.BotonesP();

            }
            else
            {
                this.MensajeError("Debe buscar un nuevo registro para editar");
            }
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

       
    }
}
