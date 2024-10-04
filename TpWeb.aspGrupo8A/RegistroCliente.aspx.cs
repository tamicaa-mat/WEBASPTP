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

        protected void btnParticipar_OnClick(object sender, EventArgs e)
        {
            try
            { 

                Cliente cliente = new Cliente();
                cliente.DNI = textDni.Text.ToString();
                cliente.Nombre = textNombre.Text.ToString();
                cliente.Apellido = textApellido.Text.ToString();
                cliente.Email = textEmail.Text.ToString();
                cliente.Direccion = textDireccion.Text.ToString();
                cliente.Ciudad = textCiudad.Text.ToString();
                cliente.CodigoPostal = int.Parse(textCP.Text);
                

                ClienteNegocio clienteNegocio = new ClienteNegocio();

                if (validarCajasTexto())
                {
                    return;
                }

                else
                {
                    clienteNegocio.AltaCliente(cliente);
                    Response.Redirect("RegistroExitoso.aspx?nombre=" + Server.UrlEncode(cliente.Nombre), false);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        ///validaciones de cajas de texto 
        bool esNumero(string texto)
        {
            long numero;
            return long.TryParse(texto, out numero);
        }
        public bool validarCajasTexto()
        {
            string mensajeError = "";

        
            if (string.IsNullOrEmpty(textDni.Text))
            {
                mensajeError = "El campo DNI no puede estar vacío.\n";
            }
            else if (!esNumero(textDni.Text))  
            {
                mensajeError = "DNI debe contener solo números.\n";
            }

          
            if (!string.IsNullOrEmpty(mensajeError))
            {
                textDni.Text = "";  
                textDni.Attributes["placeholder"] = mensajeError;  
                //textDni.ForeColor = System.Drawing.Color.Red; 
            }

           
            textDni.ForeColor = System.Drawing.Color.Black;
            return true;  
        }








    }

}





