using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Datos;
using Negocio;

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
            }
        }


    }
}