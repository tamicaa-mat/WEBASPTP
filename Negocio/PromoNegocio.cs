using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Dominio;


namespace Negocio
{
    public class PromoNegocio
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

        public void guardarVoucher(string codigoVoucher, int idCliente, DateTime fechaCanje, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                    datos.setearConsulta("UPDATE Vouchers SET IdCliente = @IdCliente, FechaCanje = @FechaCanje, IdArticulo = @IdArticulo " +
                                         "WHERE CodigoVoucher = @CodigoVoucher;");
                    datos.SetearParametro("@IdCliente", idCliente);
                    datos.SetearParametro("@FechaCanje", fechaCanje);
                    datos.SetearParametro("@IdArticulo", idArticulo);
                    datos.SetearParametro("@CodigoVoucher", codigoVoucher);

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
