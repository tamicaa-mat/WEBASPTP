using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS Marca, 
                                     A.IdCategoria, C.Descripcion AS Categoria, A.Precio, 
                                     MIN(I.ImagenUrl) AS ImagenesUrl
                                     FROM ARTICULOS A
                                     JOIN MARCAS M ON A.IdMarca = M.Id
                                     LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id
                                     LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo
                                     GROUP BY A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion, A.IdCategoria, C.Descripcion, A.Precio");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = datos.Lector["Codigo"].ToString();
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Descripcion = datos.Lector["Descripcion"].ToString();
                    aux.marca = new Marca((int)datos.Lector["IdMarca"], datos.Lector["marca"].ToString());
                    aux.categoria = new Categoria((int)datos.Lector["idCategoria"], datos.Lector["categoria"].ToString());

                    if (aux.Imagenes == null)
                        aux.Imagenes = new List<Imagen>();

                    if (!(datos.Lector["ImagenesUrl"] is DBNull))
                    {
                        aux.Imagenes.Add(new Imagen(datos.Lector["ImagenesUrl"].ToString()));
                    }
                    else
                    {
                        aux.Imagenes.Add(new Imagen("https://media.istockphoto.com/id/1128826884/es/vector/ning%C3%BAn-s%C3%ADmbolo-de-vector-de-imagen-falta-icono-disponible-no-hay-galer%C3%ADa-para-este-momento.jpg?s=612x612&w=0&k=20&c=9vnjI4XI3XQC0VHfuDePO7vNJE7WDM8uzQmZJ1SnQgk="));
                    }
                    aux.Precio = (float)(decimal)datos.Lector["Precio"];
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
                datos.cerrarConexion();
            }
        }
        public void agregar(Articulo articuloNuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            agregarArticulo(articuloNuevo);
            int idArticulo = datos.ObtenerIdArticulo(articuloNuevo.Codigo);
            agregarImagenUrl(idArticulo, articuloNuevo.Imagenes);
        }
        public void agregarArticulo(Articulo nuevoArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdCategoria, IdMarca, Precio) " +
                                     "VALUES (@Codigo, @Nombre, @Descripcion, @IdCategoria, @IdMarca, @Precio);");
                datos.SetearParametro("@Codigo", nuevoArticulo.Codigo);
                datos.SetearParametro("@Nombre", nuevoArticulo.Nombre);
                datos.SetearParametro("@Descripcion", nuevoArticulo.Descripcion);
                datos.SetearParametro("@IdCategoria", nuevoArticulo.categoria.Id);
                datos.SetearParametro("@IdMarca", nuevoArticulo.marca.idM);
                datos.SetearParametro("@Precio", nuevoArticulo.Precio);
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
        public void agregarImagenUrl(int idArticulo, List<Imagen> Imagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) " +
                                     "VALUES (@IdArticulo, @ImagenUrl)");
                datos.SetearParametro("@IdArticulo", idArticulo);
                datos.SetearParametro("@ImagenUrl", Imagen);
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
        public void Modificar(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            modificarArticulo(modificar);
            int idArticulo = datos.ObtenerIdArticulo(modificar.Codigo);
            modificarImagenUrl(idArticulo, modificar.Imagenes);
        }
        public void modificarArticulo(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca," +
                                     "IdCategoria = @IdCategoria, Precio = @Precio where Id = @Id");
                datos.SetearParametro("@Codigo", modificar.Codigo);
                datos.SetearParametro("@Nombre", modificar.Nombre);
                datos.SetearParametro("@Descripcion", modificar.Descripcion);
                datos.SetearParametro("@IdCategoria", modificar.categoria.Id);
                datos.SetearParametro("@IdMarca", modificar.marca.idM);
                datos.SetearParametro("@Precio", modificar.Precio);
                datos.SetearParametro("@Id", modificar.Id);
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
        public void modificarImagenUrl(int idArticulo, List<Imagen> Imagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl where idArticulo = @IdArticulo");
                datos.SetearParametro("@IdArticulo", idArticulo);
                datos.SetearParametro("@ImagenUrl", Imagen);
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
        public void Eliminar(Articulo Eliminar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "DELETE FROM ARTICULOS where Codigo = '" + Eliminar.Codigo + "'";
                datos.setearConsulta(consulta);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public Articulo BuscarMenorPrecio()
        {
            AccesoDatos datos = new AccesoDatos();
            Articulo articuloMenorPrecio = null;

            try
            {
                string consulta = "SELECT TOP 1 Codigo, Nombre, Descripcion, IdCategoria, IdMarca, Precio " +
                                  "FROM ARTICULOS ORDER BY Precio ASC";
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    articuloMenorPrecio = new Articulo
                    {
                        Codigo = datos.Lector["Codigo"].ToString(),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        Precio = (float)(decimal)datos.Lector["Precio"]
                    };
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

            return articuloMenorPrecio;
        }

        public List<Articulo> ListarxMarca(Articulo Marca)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> ListarxMarca = new List<Articulo>();

            try
            {
                string Consulta = "SELECT A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion as Marca " +
                                  "FROM ARTICULOS A " +
                                  "INNER JOIN MARCAS M ON A.IdMarca = M.Id " +
                                  "WHERE M.Descripcion = '" + Marca.marca.NombreM + "'";
                datos.setearConsulta(Consulta);
                //datos.SetearParametro("@Marca", Marca);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Codigo = datos.Lector["Codigo"].ToString();
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Descripcion = datos.Lector["Descripcion"].ToString();
                    aux.marca = new Marca(datos.Lector["Marca"].ToString());
                    aux.Precio = (float)(decimal)datos.Lector["Precio"];
                    ListarxMarca.Add(aux);
                }
                return ListarxMarca;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }

        public void EliminarImagenUrl(int idArticulo, string imagenUrl)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @idArticulo AND ImagenUrl = @imagenUrl");
                datos.SetearParametro("@idArticulo", idArticulo);
                datos.SetearParametro("@imagenUrl", imagenUrl);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
