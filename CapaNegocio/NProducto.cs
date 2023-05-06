using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
using System.Security.Permissions;

namespace CapaNegocio
{
    public class NProducto
    {
        //  Método que se encarga de llamar al método Mostra()
        public static DataTable Mostra()
        {
            return new DProducto().Mostrar();
        }

        public static string Insertar(
            string codigo, 
            string nombre, 
            string descripcion, 
            int idcategoria)
        {
            DProducto Cat = new DProducto();
            Cat.Codigo = codigo;
            Cat.Nombre = nombre;
            Cat.Descripcion = descripcion;
            Cat.IdCategoria = idcategoria;

            return Cat.Insertar(Cat);
        }

        //  Método para Buscar
        public static DataTable BuscarNombre(string TextBuscar)
        {
            DProducto Cat = new DProducto();
            Cat.TextoBuscar = TextBuscar;
            return Cat.BuscarNombre(Cat);
        }
    }
}
