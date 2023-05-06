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
    public class DProducto
    {
        private int _idProducto;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;

        private int _idCategoria;
        private string _TextoBuscar;


        private int IdProducto;

        public int   IdProctoducto
        {
            get { return    _idProducto; }
            set { _idProducto = value; }
        }

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public int IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public DProducto()
        { }

        public DProducto(
                int idProducto, 
                string codigo, 
                string nombre,
                string descripcion, 
                int idCategoria, 
                string textoBuscar)
        {
            _idProducto = idProducto;
            _Codigo = codigo;
            _Nombre = nombre;
            _Descripcion = descripcion;
            _idCategoria = idCategoria;
            _TextoBuscar = textoBuscar;
        }
        

public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("producto");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_producto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

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
        public string Insertar(DProducto Producto)
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
                SqlCmd.CommandText = "spinsertar_producto";
                // 6. Decirle al comando que va a ejecutar una sentencia SQL
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // 7. Parámetros

                // Parametro IdProducto
                SqlParameter ParIdProduto = new SqlParameter();
                ParIdProduto.ParameterName = "@idproducto";
                ParIdProduto.SqlDbType = SqlDbType.Int;
                // Declaramos el parametro de salida
                ParIdProduto.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdProduto);

                //Parámetro Codigo
                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 20;
                ParCodigo.Value = Producto.Codigo;
                SqlCmd.Parameters.Add(Codigo);

                //Parámetro Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Producto.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Parámetro Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Producto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                // Parametro idCategoria
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                // Declaramos el parametro de salida
                ParIdCategoria.Value = Producto.IdCategoria;
                SqlCmd.Parameters.Add(ParIdProduto);

                // 8. Ejecutar el comando
                Rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso de manera correcta";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public DataTable BuscarNombre(DProducto Producto)
        {
            string Rpta = "";
            DataTable DtResultado = new DataTable("producto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_producto_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parametro Nombre
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 30;
                ParTextoBuscar.Value = Producto.TextoBuscar;
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


    }

}
