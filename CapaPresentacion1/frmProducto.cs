
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//  Comunica con la capa negocio
using CapaNegocio;
namespace CapaPresentacion1
{
    public partial class frmProducto : Form
    {

        private static frmProducto _instacia;

        public static frmProducto GetInstancia()
        {
            if(_instacia == null)
                _instacia = new frmProducto();
            return _instacia;
        }

        public frmProducto()
        {
            InitializeComponent();
        }

        public void setCategoria(string idcategoria, string nombre)
        {
            this.txtCodCat.Text = idcategoria;
            this.txtCat.Text = nombre;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Categoria_Enter(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void txtCat_TextChanged(object sender, EventArgs e)
        {

        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }


        private void frmProducto_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NProducto.Mostra();
            OcultarColumnas();
;        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            frmVistaCategoria vistaCategoria = new frmVistaCategoria(); 
            vistaCategoria.ShowDialog();
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NProducto.BuscarNombre(this.textBuscar.Text);
            this.OcultarColumnas();
        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

    }

}
