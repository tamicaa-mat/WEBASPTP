using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpWeb.aspGrupo8A
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PromoNegocio negocio = new PromoNegocio();
                rptArticulos.DataSource = negocio.Listar();
                rptArticulos.DataBind();
            }
        }
        protected void verMas_OnClick(object sender, EventArgs e)
        {
            string btn = ((LinkButton)sender).CommandArgument;
            int idSeleccionado = int.Parse(btn);
            Session["Id"] = idSeleccionado;
            Response.Redirect("DetallesArticulo.aspx", false);

        }
    }
}