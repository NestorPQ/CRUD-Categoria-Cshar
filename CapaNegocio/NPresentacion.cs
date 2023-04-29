using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NPresentacion
    {
        // Método que se encarga de llamar al metod Mostrar()
        public static DataTable MostrarP()
        {
            return new DPresentacion().MostrarP();
        }

        // Método que se encarga de llamar al metodo Insertar()
        public static string InsertarP(string nombre, string descripcion)
        {
            DPresentacion Cat = new DPresentacion();
            Cat.Nombre = nombre;
            Cat.Descripcion = descripcion;
            return Cat.InsertarP(Cat);
        }

        // Método para llamar al metodo modificar
        public static string EditarP(int idpresentacion, string nombre, string descripcion)
        {
            DPresentacion Cat = new DPresentacion();
            Cat.IdPresentacion = idpresentacion;
            Cat.Nombre = nombre;
            Cat.Descripcion = descripcion;
            return Cat.EditarP(Cat);
        }
    }
}
