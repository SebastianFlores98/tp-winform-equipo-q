using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDatos datosArticulo = new ConexionDatos();

            try
            {
                datosArticulo.setearConsulta(" SELECT Codigo, Nombre, Descripcion, Precio FROM ARTICULOS ");
                datosArticulo.ejecutarLectura();

                while (datosArticulo.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.CodigoArticulo = (string)datosArticulo.Lector["Codigo"];
                    aux.Nombre = (string)datosArticulo.Lector["Nombre"];
                    aux.Descripcion = (string)datosArticulo.Lector["Descripcion"];
                    aux.Precio = (decimal)datosArticulo.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosArticulo.cerrarConexion();
            }
        }
    }
}
