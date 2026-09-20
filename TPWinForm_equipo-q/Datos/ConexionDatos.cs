using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ConexionDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public ConexionDatos()
        {
            // Conexión a base
            /* 
             * NOTA: Para desarrollo local usamos SQL Server en Docker (puerto 1433).
             * Si se ejecuta con SQL Server Express local, cambiar a: "server=.\SQLEXPRESS; ..."
            */
            conexion = new SqlConnection("Server=localhost,1433;Database=CATALOGO_P3_DB;User Id=sa;Password=PASSWORD;TrustServerCertificate=True;");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregarParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }

        public int ejecutarAccionScalar()
        {
            try
            {
                comando.Connection = conexion;
                conexion.Open();

                // Capturamos el ID Nuevo
                object resultado = comando.ExecuteScalar();

                if (resultado != null)
                {
                    return Convert.ToInt32(resultado);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
