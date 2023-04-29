using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion1
{
    public partial class pictureBox2 : Form
    {
        public pictureBox2()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable Datos = NTrabajador.Login(txtUsu.Text,txtPass.Text);

            if (Datos.Rows.Count == 0)
                MessageBox.Show("No tiene acceso al sistema", "SENATI", MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            {
                frmCategoria frm=new frmCategoria();
                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Load(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
