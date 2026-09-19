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

        // Consulto en la base si existe el IdMarca en la tabla ARTÍCULOS
        public bool ExisteEnArticulos(int id)
        {
            ConexionDatos datos = new ConexionDatos();
            try
            {
                datos.setearConsulta("SELECT IdMarca FROM ARTICULOS WHERE IdMarca = @id");
                datos.agregarParametro("@id", id);
                datos.ejecutarLectura(); 

                return datos.Lector.Read();
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

        /*Eliminar BD*/
        public void Eliminar(int id)
        {
            if (ExisteEnArticulos(id))
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
    }
}

