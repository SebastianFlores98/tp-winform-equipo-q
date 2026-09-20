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
                datos.setearConsulta(
                    "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, idMarca, idCategoria, Precio) " +
                    "OUTPUT INSERTED.Id " + 
                    "VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio)"
                 );

                datos.agregarParametro("@codigo", arti.CodigoArticulo);
                datos.agregarParametro("@nombre", arti.Nombre);
                datos.agregarParametro("@descripcion", arti.Descripcion);
                datos.agregarParametro("@idMarca", arti.Marca.Id);
                datos.agregarParametro("@idCategoria", arti.Categoria.Id);
                datos.agregarParametro("@precio", arti.Precio);

                int idArticuloNuevo = datos.ejecutarAccionScalar();

                datos.cerrarConexion(); 

                // Recorremos la lista de imagenes para insertarlas a la tabla (IMAGENES)
                if (arti.Imagenes != null && arti.Imagenes.Count > 0 && idArticuloNuevo > 0)
                {
                    foreach (string url in arti.Imagenes)
                    {
                        if (!string.IsNullOrEmpty(url))
                        {
                            datos = new ConexionDatos(); 

                            datos.setearConsulta(
                                "INSERT INTO IMAGENES (IdArticulo, ImagenUrl) " +
                                "VALUES (@idArticulo, @imagenUrl)"
                            );
                            datos.agregarParametro("@idArticulo", idArticuloNuevo);
                            datos.agregarParametro("@imagenUrl", url);

                            datos.ejecutarAccion(); 
                            datos.cerrarConexion(); 
                        }
                    }
                }
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
                datosArticulo.setearConsulta(
                    "UPDATE ARTICULOS " +
                    "SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio " +
                    "WHERE Id = @id");

                datosArticulo.agregarParametro("@id", art.Id);
                datosArticulo.agregarParametro("@codigo", art.CodigoArticulo);
                datosArticulo.agregarParametro("@nombre", art.Nombre);
                datosArticulo.agregarParametro("@descripcion", art.Descripcion);
                datosArticulo.agregarParametro("@idMarca", art.Marca.Id);
                datosArticulo.agregarParametro("@idCategoria", art.Categoria.Id);
                datosArticulo.agregarParametro("@precio", art.Precio);

                datosArticulo.ejecutarAccion();
                datosArticulo.cerrarConexion();

                // Eliminamos todas las imagenes y volvemos a cargar 
                ConexionDatos datosImagenesBorrar = new ConexionDatos();
                datosImagenesBorrar.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @idArticulo");
                datosImagenesBorrar.agregarParametro("@idArticulo", art.Id);

                datosImagenesBorrar.ejecutarAccion();
                datosImagenesBorrar.cerrarConexion();

                if (art.Imagenes != null && art.Imagenes.Count > 0)
                {
                    foreach (string url in art.Imagenes)
                    {
                        if (!string.IsNullOrEmpty(url))
                        {
                            ConexionDatos datosImagenesInsertar = new ConexionDatos();

                            datosImagenesInsertar.setearConsulta(
                                "INSERT INTO IMAGENES (IdArticulo, ImagenUrl) " +
                                "VALUES (@idArticulo, @imagenUrl)"
                            );
                            datosImagenesInsertar.agregarParametro("@idArticulo", art.Id);
                            datosImagenesInsertar.agregarParametro("@imagenUrl", url);

                            datosImagenesInsertar.ejecutarAccion();
                            datosImagenesInsertar.cerrarConexion();
                        }
                    }
                }
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