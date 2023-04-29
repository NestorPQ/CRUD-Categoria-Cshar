using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Importaciones necesarias
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCategoria
    {
        private int _idCategoria;
        private string _nombre;
        private string _descripcion;

        private string _TextoBuscar;

        //Métodos setter and getter
        public int IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
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

        public DCategoria() { }
        //Constructor con parámetros
        public DCategoria(int idcategoria, string nombre, string descripcion)
        {
            this.IdCategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        //Método para mostrar las categorías
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria");
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
                SqlCmd.CommandText = "sp_mostrar_categoria";
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
        public string Insertar(DCategoria Categoria)
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
                SqlCmd.CommandText = "sp_insertar_categoria";
                // 6. Decirle al comando que va a ejecutar una sentencia SQL
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // 7. Parámetros
                // Parametro IdCategoria
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                // Declaramos el parametro de salida
                ParIdCategoria.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdCategoria);

                //Parámetro Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parámetro Nombre
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Categoria.Descripcion;
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
        public string Editar(DCategoria Categoria)
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
                SqlCmd.CommandText = "sp_modificar_categoria";
                // 6. Decirle al comando que va a ejecutar una sentencia SQL
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // 7. Parámetros
                // Parametro IdCategoria
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Categoria.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);
                // Declaramos el parametro de salida


                //Parámetro Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parámetro Nombre
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Categoria.Descripcion;
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

        public DataTable BuscarNombre(DCategoria Categoria)
        {
            string Rpta = "";
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_categoria_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parametro Nombre
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 30;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public string eliminar(DCategoria Categoria)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
              
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_eliminar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // 7. Parámetros
                // Parametro IdCategoria
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Categoria.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                Rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;

        }


    }
}