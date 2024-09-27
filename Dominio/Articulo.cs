using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Dominio 
{
    public partial class Articulo
    {
        public int Id { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string Imagen { get; set; }  
        public float Precio { get; set; }
        [DisplayName("Categoría")]
        public Categoria categoria { get; set; }
        [DisplayName("Marca")]
        public Marca marca { get; set; }
        public List<string> ImagenesXArticulo()
        {
            List<string> imagenes = new List<string>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                datos.SetearParametro("@IdArticulo", this.Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        imagenes.Add(datos.Lector["ImagenUrl"].ToString());
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
            return imagenes;
        }
    }
}