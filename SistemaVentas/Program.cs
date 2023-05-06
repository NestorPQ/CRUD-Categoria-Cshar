using CapaPresentacion1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentas
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(frmProducto.GetInstancia());
            //Application.Run(new CapaPresentacion1.frmReporte());


            //Application.Run(new CapaPresentacion1.frmCategoria());
            //Application.Run(new CapaPresentacion1.frmVistaCategoria());
            //Application.Run(new CapaPresentacion1.pictureBox2());
            //Application.Run(new CapaPresentacion1.frmProducto());
            //Application.Run(new CapaPresentacion1.formRegistroProd());


        }
    }
}
