using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Importaciones para comunicarnos con la capa de datos
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCategoria
    {
        // Método que se encarga de llamar al metod Mostrar()
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }

        // Método que se encarga de llamar al metodo Insertar()
        public static string Insertar(string nombre,string descripcion)
        {
            DCategoria Cat = new DCategoria();
            Cat.Nombre = nombre;
            Cat.Descripcion = descripcion;
            return Cat.Insertar(Cat);
        }

        // Método para llamar al metodo modificar
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DCategoria Cat = new DCategoria();
            Cat.IdCategoria = idcategoria;
            Cat.Nombre = nombre;
            Cat.Descripcion = descripcion;
            return Cat.Editar(Cat);
        }

        public static DataTable BuscarNombre(string TextBuscar)
        {
            DCategoria Cat = new DCategoria();
            Cat.TextoBuscar = TextBuscar;
            return Cat.BuscarNombre(Cat);
        }

        public static string eliminar(int idcategoria)
        {
            DCategoria Cat = new DCategoria();
            Cat.IdCategoria = idcategoria;
            return Cat.eliminar(Cat);
        }
    }
}
