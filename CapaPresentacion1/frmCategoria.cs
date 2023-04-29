using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Comunicarse con la capa negocio
using CapaNegocio;
namespace CapaPresentacion1
{
    public partial class frmCategoria : Form

    {
        public string IdTrabajador = "";
        public string Apellidos = "";
        public string Nombres = "";
        public string Acceso = "";

        // Variable que indica si vamos a insertar una categoria
        private bool IsNuevo = false;
        // Variable que indica si vamos a modificar una categoria
        private bool IsModificar = false;
        public frmCategoria()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNom, "Ingresar el nombre de la categoría");
            this.ttMensaje.SetToolTip(this.txtDes, "Ingresar descripción de la categoria");
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Botones();
            this.Habilitar(false);
        }
        private void Limpiar()
        {
            this.txtCod.Text = string.Empty;
            this.txtNom.Text = string.Empty;
            this.txtDes.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {
            this.txtCod.ReadOnly = !valor;
            this.txtNom.ReadOnly = !valor;
            this.txtDes.ReadOnly = !valor;
        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsModificar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsModificar = false;
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje,"Sistema Ventas SENATI",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas SENATI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Mostrar() 
        {
            this.dataListado.DataSource = NCategoria.Mostrar();
            OcultarColumnas();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String Rpta = "";
            if(this.txtNom.Text == string.Empty)
            {
                MensajeError ("Falta ingresar datos");
                error.SetError(txtNom,"Ingresar nombre");
            }
            else
            {
                if (this.IsNuevo)
                {
                    Rpta = NCategoria.Insertar(this.txtNom.Text.Trim(), this.txtDes.Text.Trim());
                }
                else
                {
                    Rpta = NCategoria.Editar(Convert.ToInt32(this.txtCod.Text), this.txtNom.Text.Trim(), this.txtDes.Text.Trim());
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
            
            this.Mostrar();
            this.Limpiar();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtCod.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
            this.txtNom.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDes.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            this.tabControl1.SelectedIndex = 1;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Si no ha seleccionado una categoria, no puedes modificar
            if(!this.txtCod.Text.Equals(""))
            {
                this.IsModificar = true;
                this.Botones();

            }
            else 
            {
                this.MensajeError("Debe buscar un nuevo registro para editar");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            // this.dataListado.Columns[1].Visible = false;
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCategoria.BuscarNombre(this.textBuscar.Text);
            this.OcultarColumnas();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEliminar.Checked)
                this.dataListado.Columns[0].Visible=true;
            else
                this.dataListado.Columns[0].Visible = false;
        }

        private void txtEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar los registros?", "SENATI",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string codigo;
                    string rpta = "";
                    foreach(DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NCategoria.eliminar(Convert.ToInt32(codigo));

                            if (rpta.Equals("OK"))
                                this.MensajeOk("Se eliminó de manera conrrecta");
                            else
                                this.MensajeError(rpta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
