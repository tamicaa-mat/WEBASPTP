using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Microsoft.Ajax.Utilities;
using Negocio;

namespace TpWeb.aspGrupo8A
{
    public partial class RegistroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void textDni_TextChanged(object sender, EventArgs e)
        {
            string dni = textDni.Text;
            Cliente cliente = new Cliente();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            cliente = clienteNegocio.ObtenerDniCliente(dni);

            if (cliente != null)
            {
                textDni.Text = cliente.DNI.ToString();
                textNombre.Text = cliente.Nombre.ToString();
                textApellido.Text = cliente.Apellido.ToString();
                textEmail.Text = cliente.Email.ToString();
                textDireccion.Text = cliente.Direccion.ToString();
                textCiudad.Text = cliente.Ciudad.ToString();
                textCP.Text = cliente.CodigoPostal.ToString();
            }
        }
    }
}