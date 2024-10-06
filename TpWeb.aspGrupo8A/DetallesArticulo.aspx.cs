using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace TpWeb.aspGrupo8A
{
    public partial class DetallesArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idArticulo = 0;
                    if (Session["Id"] != null)
                    {
                        idArticulo = int.Parse(Session["Id"].ToString());
                    }
                    else
                    {
                        AccesoDatos datos = new AccesoDatos();
                        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                        Articulo articulo = articuloNegocio.PrimerArticulo();

                        if (articulo != null)
                            idArticulo = articulo.Id;
                        else
                        {
                            //lo mandara a una nueva pantalla de "Error no se encontro producto para mostrar" 
                        }
                    }
                    cargaImagenes(idArticulo);
                    cargaInformacionArticulo(idArticulo);
                    cargaOtrosArticulos(idArticulo);
            }
        }
        protected void cargaImagenes(int idArticulo)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            List<Imagen> imagenes = imagenNegocio.imagenesxArticulo(idArticulo);

            if(imagenes == null || imagenes.Count == 0)
            {
                Imagen imagenRota = new Imagen();
                imagenRota.Url = "https://media.istockphoto.com/id/1128826884/es/vector/ning%C3%BAn-s%C3%ADmbolo-de-vector-de-imagen-falta-icono-disponible-no-hay-galer%C3%ADa-para-este-momento.jpg?s=612x612&w=0&k=20&c=9vnjI4XI3XQC0VHfuDePO7vNJE7WDM8uzQmZJ1SnQgk=";
                imagenes.Add(imagenRota);
            }
            for(int x = 0; x < imagenes.Count; x++)
            {
                imagenes[x].Estado = (x == 0);
            }
            RepeaterImagenes.DataSource = imagenes;
            RepeaterImagenes.DataBind();
        }
        protected void cargaInformacionArticulo( int idArticulo)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo articulo = articuloNegocio.ObtenerArticuloId(idArticulo);

            try
            {
                if( articulo != null)
                {
                    nombreArticulo.InnerText = articulo.Nombre.ToString();
                    precioArticulo.InnerText = "$" + articulo.Precio.ToString();
                    descripcionArticulo.InnerText = articulo.Descripcion.ToString();
                    categoriaArticulo.InnerText = articulo.categoria.Nombre;
                    marcaArticulo.InnerText = articulo.marca.NombreM;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void cargaOtrosArticulos(int idArticuloSeleccionado)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            List<Articulo> listaArticulos = articuloNegocio.Listar(); // Usamos tu método "listar" para obtener todos los artículos

            // Filtrar el artículo seleccionado
            List<Articulo> otrosArticulos = listaArticulos.Where(a => a.Id != idArticuloSeleccionado).ToList();
            foreach(var articulo in otrosArticulos)
            {
                articulo.Imagenes = new ImagenNegocio().imagenesxArticulo(articulo.Id);
            }

            RepeaterLista.DataSource = otrosArticulos;
            RepeaterLista.DataBind();
        }
        protected void BtnVer_OnClick(object sender, EventArgs e)
        {
            string btn = ((Button)sender).CommandArgument;
            int idSeleccionado = int.Parse(btn);
            cargaInformacionArticulo(idSeleccionado);
            cargaOtrosArticulos(idSeleccionado);
            Session["Id"] = idSeleccionado;
            Response.Redirect("DetallesArticulo.aspx", false);
        }
    }
}