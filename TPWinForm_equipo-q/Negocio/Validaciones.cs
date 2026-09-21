using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Validaciones
    {

        // valido descrip nulls o espacio vacio
        public static bool ValidarDescripcion(string descripcion)
        {
            return string.IsNullOrWhiteSpace(descripcion);
        }

        // valida si la marca se usa en algun articulo
        public static bool MarcaEnUso(int idMarca)
        {
            ConexionDatos datos = new ConexionDatos();
            try
            {
                datos.setearConsulta("SELECT IdMarca FROM ARTICULOS WHERE IdMarca = @id");
                datos.agregarParametro("@id", idMarca);
                datos.ejecutarLectura();
                return datos.Lector.Read();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }

        // valida si la marca se usa en algun articulo
        public static bool CategoriaEnUso(int idCategoria)
        {
            ConexionDatos datos = new ConexionDatos();
            try
            {
                datos.setearConsulta("SELECT IdCategoria FROM ARTICULOS WHERE IdCategoria = @id");
                datos.agregarParametro("@id", idCategoria);
                datos.ejecutarLectura();
                return datos.Lector.Read();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }

        public static bool SoloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter))) { return false; }
            }
            return true;
        }
    }
}

