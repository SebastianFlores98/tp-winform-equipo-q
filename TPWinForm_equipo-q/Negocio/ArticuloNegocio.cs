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
                        "MAR.Id AS IdMarca, " +
                        "MAR.Descripcion AS DescripcionMarca, " +
                        "CAT.Id AS IdCategoria, " +
                        "CAT.Descripcion AS DescripcionCategoria, " +
                        "ART.Precio, " +
                        "IMG.ImagenUrl " +
                    "FROM ARTICULOS ART " +
                    "INNER JOIN MARCAS MAR ON MAR.Id = ART.IdMarca " +
                    "LEFT JOIN CATEGORIAS CAT ON CAT.Id = ART.IdCategoria " +
                    "LEFT JOIN (" +
                        "SELECT IdArticulo, MIN(ImagenUrl) AS ImagenUrl " +
                        "FROM IMAGENES " +
                        "GROUP BY IdArticulo" +
                    ") IMG ON IMG.IdArticulo = ART.Id"
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
                    aux.Marca.Id = (int)datosArticulo.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datosArticulo.Lector["DescripcionMarca"];

                    // Contemplo NULL de categoria porque hay un artículo que posee un ID de categoria que no existe
                    aux.Categoria = new Categoria();
                    if (!(datosArticulo.Lector["IdCategoria"] is DBNull))
                    {
                        aux.Categoria.Id = (int)datosArticulo.Lector["IdCategoria"];
                        aux.Categoria.Descripcion = (string)datosArticulo.Lector["DescripcionCategoria"];
                    }
                    else
                    {
                        aux.Categoria.Id = 0; 
                        aux.Categoria.Descripcion = "Sin Categoría"; 
                    
                    }

                    aux.Precio = (decimal)datosArticulo.Lector["Precio"];

                    // Contemplo NULL de imágenes
                    if(!(datosArticulo.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.UrlImagen = (string)datosArticulo.Lector["ImagenUrl"];
                    }

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

        /*Agregar BD*/
        public void agregar(Articulo arti)
        {
            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, idMArca, idCategoria, Precio)values('" + arti.CodigoArticulo + "', '" + arti.Nombre + "', '" + arti.Descripcion + "', @idMarca, @idCategoria, " + arti.Precio + ")");
                                
                datos.agregarParametro("@idMarca", arti.Marca.Id);
                datos.agregarParametro("@idCategoria", arti.Categoria.Id);

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

        /*Modificar BD*/
        public void modificar(Articulo art)
        {
            ConexionDatos datosArticulo = new ConexionDatos();

            try
            {
                datosArticulo.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio WHERE Id = @id");

                datosArticulo.agregarParametro("@id", art.Id);
                datosArticulo.agregarParametro("@codigo", art.CodigoArticulo);
                datosArticulo.agregarParametro("@nombre", art.Nombre);
                datosArticulo.agregarParametro("@descripcion", art.Descripcion);
                datosArticulo.agregarParametro("@idMarca", art.Marca.Id);       
                datosArticulo.agregarParametro("@idCategoria", art.Categoria.Id); 
                datosArticulo.agregarParametro("@precio", art.Precio);
                //datosArticulo.agregarParametro("@img", art.UrlImagen);

                datosArticulo.ejecutarAccion();

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

        /*Eliminar BD*/
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
    }
}