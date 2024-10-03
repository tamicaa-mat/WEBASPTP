using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id, descripcion from MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.idM = (int)datos.Lector["id"];
                    marca.NombreM = datos.Lector["descripcion"].ToString();

                    lista.Add(marca);
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

        // para agregar marcas nuevas
        public void agregar(Marca nuevaMarca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO MARCAS (descripcion) VALUES (@descripcion)");
                datos.SetearParametro("@descripcion", nuevaMarca.NombreM);
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
                datos.setearConsulta("DELETE FROM MARCAS WHERE id = @id");
                datos.SetearParametro("@id", id);
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
