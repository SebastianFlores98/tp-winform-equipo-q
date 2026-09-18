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
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDatos datosArticulo = new ConexionDatos();

            try
            {
                datosArticulo.setearConsulta(
                    "SELECT " +
                        "ART.Id, " +
                        "ART.Codigo, " +
                        "ART.Nombre, " +
                        "ART.Descripcion, " +
                        "MAR.Descripcion AS DescripcionMarca, " +
                        "CAT.Descripcion AS DescripcionCategoria, " +
                        "ART.Precio, " + 
                        "IMG.ImagenUrl " +
                    "FROM ARTICULOS ART " +
                    "INNER JOIN MARCAS MAR ON MAR.Id = ART.IdMarca " +
                    "INNER JOIN CATEGORIAS CAT ON CAT.Id = ART.IdCategoria " +
                    "INNER JOIN IMAGENES IMG ON IMG.IdArticulo = ART.Id"
                );
                datosArticulo.ejecutarLectura();

                while (datosArticulo.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datosArticulo.Lector["Id"];
                    aux.CodigoArticulo = (string)datosArticulo.Lector["Codigo"];
                    aux.Nombre = (string)datosArticulo.Lector["Nombre"];
                    aux.Descripcion = (string)datosArticulo.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datosArticulo.Lector["DescripcionMarca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datosArticulo.Lector["DescripcionCategoria"];
                    aux.Precio = (decimal)datosArticulo.Lector["Precio"];
                    aux.UrlImagen = (string)datosArticulo.Lector["ImagenUrl"];

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

        public void Eliminar(int id)
        {
            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @id");
                datos.agregarParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Articulo arti)
        {
            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion)values('" + arti.CodigoArticulo + "', '" + arti.Nombre+ "', '"+ arti.Descripcion+"')"); 
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
  
    }
}
