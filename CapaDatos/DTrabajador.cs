using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTrabajador
    {
        private int _idTrabajador;
        private string _Apellidos;
        private string _Nombres;
        private string _Acceso;
        private string _Usuario;
        private string _Clave;
        private string _TextBuscar;

        
        public int IdTrabajador
        {
            get { return _idTrabajador; }
            set { _idTrabajador = value; }
        }

        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }

        public string Nombres
        {
            get { return _Nombres; }
            set { _Nombres = value; }
        }

        public string Acceso
        {
            get { return _Acceso; }
            set { _Acceso = value; }
        }
        public string usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }

        }
        public string clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }
        public string TextoBuscar
        {
            get { return _TextBuscar; }
            set { _TextBuscar = value; }
        }

        public DTrabajador(){
        }

        public DTrabajador(
            int idTrabajador, 
            string apellidos,
            string nombres,
            string acceso,
            string usuario,
            string clave,
            string textbuscar) 
        {
            this.IdTrabajador = idTrabajador;
            this.Apellidos = apellidos;
            this.Nombres = nombres;
            this.Acceso = acceso;
            this.usuario = usuario;
            this.clave = clave;
            this.TextoBuscar = textbuscar;
        }

        public DataTable Login(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parametro Usuario
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 30;
                ParUsuario.Value = Trabajador.usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                // Parametro Clave
                SqlParameter ParClave = new SqlParameter();
                ParClave.ParameterName = "@clave";
                ParClave.SqlDbType = SqlDbType.VarChar;
                ParClave.Size = 30;
                ParClave.Value = Trabajador.clave;
                SqlCmd.Parameters.Add(ParClave);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

    }
}
