using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NTrabajador
    {
        public static DataTable Login(string usuario, string clave)
        {
            DTrabajador obj = new DTrabajador();
            obj.usuario = usuario;
            obj.clave = clave;

            return obj.Login(obj);
        }
    }
}
