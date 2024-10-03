using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    class ImagenNegocio
    {
        public class NegocioImagen
        {
            public List<Imagen> listar(int idArticulo)
            {
                List<Imagen> lista = new List<Imagen>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                    datos.SetearParametro("@IdArticulo", idArticulo);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Imagen imagen = new Imagen();
                        imagen.Id = (int)datos.Lector["Id"];
                        imagen.IdArticulo = (int)datos.Lector["IdArticulo"];
                        imagen.Url = datos.Lector["ImagenUrl"].ToString();

                        lista.Add(imagen);
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

            public void agregar(Imagen nuevaImagen)
            {
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                    datos.SetearParametro("@IdArticulo", nuevaImagen.IdArticulo);
                    datos.SetearParametro("@ImagenUrl", nuevaImagen.Url);
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

            public void eliminar(int id)
            {
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("DELETE FROM IMAGENES WHERE Id = @Id");
                    datos.SetearParametro("@Id", id);
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
}
