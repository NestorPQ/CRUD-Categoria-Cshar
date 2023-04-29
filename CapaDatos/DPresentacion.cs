using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DPresentacion
    {
        private int _idPresentacion;
        private string _nombre;
        private string _descripcion;

        private string _TextoBuscar;

        //Métodos setter and getter
        public int IdPresentacion
        {
            get { return _idPresentacion; }
            set { _idPresentacion = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructor vacío

        public DPresentacion() { }
        //Constructor con parámetros
        public DPresentacion(int idpresentacion, string nombre, string descripcion)
        {
            this.IdPresentacion = idpresentacion;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        //Método para mostrar las categorías
        public DataTable MostrarP()
        {
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                // 1. Establecer la cadena de conexion
                SqlCon.ConnectionString = Conexion.Cn;
                // 2. Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                // 3. La conexion que va a usar el comando
                SqlCmd.Connection = SqlCon;
                // 4. El comando a ejecutar
                SqlCmd.CommandText = "spu_mostrar_presentacion";
                // 5. Decirle al comando que va a ejecutar una sentencia SQL
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // 6. No hay parámetros

                // 7: Ejecutar el comando y llenar en el DataTable
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Método para insertar una categoria
        public string InsertarP(DPresentacion Presentacion)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                // 1. Establecer la cadena de conexion
                SqlCon.ConnectionString = Conexion.Cn;
                // 2. Abrir la Conexion
                SqlCon.Open();
                // 3. Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                // 4. La conexion que va a usar el comando
                SqlCmd.Connection = SqlCon;
                // 5. El comando a ejecutar
                SqlCmd.CommandText = "spu_insertar_presentacion";
                // 6. Decirle al comando que va a ejecutar una sentencia SQL
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // 7. Parámetros
                // Parametro IdCategoria
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                // Declaramos el parametro de salida
                ParIdPresentacion.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                //Parámetro Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parámetro Nombre
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                // 8. Ejecutar el comando
                Rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso de manera correcta";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }



        // Metodo para modificar
        public string EditarP(DPresentacion Presentacion)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                // 1. Establecer la cadena de conexion
                SqlCon.ConnectionString = Conexion.Cn;
                // 2. Abrir la Conexion
                SqlCon.Open();
                // 3. Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                // 4. La conexion que va a usar el comando
                SqlCmd.Connection = SqlCon;
                // 5. El comando a ejecutar
                SqlCmd.CommandText = "spu_modificar_presentacion";
                // 6. Decirle al comando que va a ejecutar una sentencia SQL
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // 7. Parámetros
                // Parametro IdCategoria
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Presentacion.IdPresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);
                // Declaramos el parametro de salida


                //Parámetro Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parámetro Nombre
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                // 8. Ejecutar el comando
                Rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso de manera correcta";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }
    }
}
