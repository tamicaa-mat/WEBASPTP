using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpWeb.aspGrupo8A
{
    public partial class PromoVoucher : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCanjear_Click(object sender, EventArgs e)
        {
          
            string codigoVoucher = txtCodigoVoucher.Text;

            AccesoDatos accesoDatos = new AccesoDatos();

            // Verificar si el código de voucher existe
            bool existeVoucher = accesoDatos.ExisteCodigoVoucher(codigoVoucher);

            if (existeVoucher)
            {
                // Si el voucher existe, redirigir a la página de selección de premio
                Response.Redirect("SeleccionarPremio.aspx");
            }
            else
            {
                // Si el voucher no existe, mostrar un mensaje de error
                lblError.Text = "El código del voucher no es válido o ya ha sido utilizado.";
                lblError.Visible = true;
            }

        }




















    }






}