using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Datos;
using Negocio;
using static System.Net.Mime.MediaTypeNames;

namespace TpWeb.aspGrupo8A
{
    public partial class SeleccionarPremio : System.Web.UI.Page
    {
        //public void Page_Load(object sender, EventArgs e)
        //{
        //    PromoNegocio negocio = new PromoNegocio();
        //    dgvArticulos.DataSource = negocio.Listar();
        //    dgvArticulos.DataBind();
        //}


        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PromoNegocio negocio = new PromoNegocio();
                rptArticulos.DataSource = negocio.Listar();
                rptArticulos.DataBind();

                try
                {
                    if (Session["idVoucher"] != null)
                    {
                        string IDVoucher = (Session["idVoucher"].ToString());
                    }
                }
                catch (Exception ex) 
                { 
                    Response.Redirect("Default.aspx");
                }
            }
        }
        protected string TextDescripcion(string descripcion)
        {
            int maxCaracter = 90;

            if (descripcion.Length > maxCaracter)
                return descripcion.Substring(0, maxCaracter) + "...";
            else
                return descripcion;
        }
        protected void verMas_OnClick(object sender, EventArgs e)
        {
            string btn = ((LinkButton)sender).CommandArgument;
            int idSeleccionado  = int.Parse(btn);
            Session["Id"] = idSeleccionado;
            Response.Redirect("DetallesArticulo.aspx", false);
        }
        protected void ButtonSeleccionar_OnClick(object sender, EventArgs e)
        {
            string idArticuloSeleccionado = ((Button)sender).CommandArgument;
            int idArticulo = int.Parse(idArticuloSeleccionado);
            Session["idArticulo"] = idArticulo;
            Response.Redirect("RegistroCliente.aspx");
        }
    }
}