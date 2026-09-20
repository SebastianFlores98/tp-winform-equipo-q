using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
        public class MarcaNegocio
        {
            public List<Marca> Listar()
            {
                List<Marca> lista = new List<Marca>();
                ConexionDatos datos = new ConexionDatos();

                try
                {
                    datos.setearConsulta("SELECT Id, Descripcion FROM MARCAS");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Marca aux = new Marca();
                        aux.Id = (int)datos.Lector["Id"];
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                        lista.Add(aux);
                    }
                    return lista;
                }
                catch (Exception) { throw; }
                finally { datos.cerrarConexion(); }
            }

  

        /*Eliminar BD*/
        public void Eliminar(int id)
        {
            if (Validaciones.MarcaEnUso(id))
            {
                throw new Exception("No se puede eliminar porque el ID está en uso en la tabla ARTÍCULOS.");
            }

            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.setearConsulta("DELETE FROM MARCAS WHERE Id = @id");
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


        /*Agregar BD*/
        public void agregar(Marca Marca)
        {
            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.setearConsulta("insert into MARCAS (Descripcion)values(@descripcion)");
                datos.agregarParametro("@descripcion", Marca.Descripcion);
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

        public void modificar(Marca Marca)
        {
            ConexionDatos datosMarca = new ConexionDatos();

            try
            {
                datosMarca.setearConsulta("UPDATE MARCAS SET Descripcion = @descripcion WHERE Id = @id");


                datosMarca.agregarParametro("@descripcion", Marca.Descripcion);
                datosMarca.agregarParametro("@id", Marca.Id);

               

                datosMarca.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosMarca.cerrarConexion();
            }
        }

    }
}

