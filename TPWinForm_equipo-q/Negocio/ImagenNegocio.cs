using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<string> ListarImagenes(int idArticulo)
        {
            List<string> lista = new List<string>();
            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.setearConsulta("SELECT ImagenUrl FROM IMAGENES WHERE IdArticulo = @idArticulo");
                datos.agregarParametro("@idArticulo", idArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        lista.Add((string)datos.Lector["ImagenUrl"]);
                    }
                }

                return lista;
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
