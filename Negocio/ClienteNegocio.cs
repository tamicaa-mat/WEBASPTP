using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP" +
                                     " FROM Clientes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente Cliente = new Cliente();
                    Cliente.Id = (int)datos.Lector["Id"];
                    Cliente.DNI = datos.Lector["Documento"].ToString();
                    Cliente.Nombre = datos.Lector["Nombre"].ToString();
                    Cliente.Apellido = datos.Lector["Apellido"].ToString();
                    Cliente.Email = datos.Lector["Email"].ToString();
                    Cliente.Direccion = datos.Lector["Direccion"].ToString();
                    Cliente.Ciudad = datos.Lector["Ciudad"].ToString();
                    Cliente.CodigoPostal = (int)datos.Lector["CP"];
       
                    lista.Add(Cliente);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los clientes", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Cliente ObtenerDniCliente(string dni)
        {
            Cliente cliente = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @dni");
                datos.SetearParametro("@dni", dni);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    Cliente clienteExistente = new Cliente();
                    clienteExistente.Id = (int)datos.Lector["Id"];
                    clienteExistente.DNI = datos.Lector["Documento"].ToString();
                    clienteExistente.Nombre = datos.Lector["Nombre"].ToString();
                    clienteExistente.Apellido = datos.Lector["Apellido"].ToString();
                    clienteExistente.Email = datos.Lector["Email"].ToString();
                    clienteExistente.Direccion = datos.Lector["Direccion"].ToString();
                    clienteExistente.Ciudad = datos.Lector["Ciudad"].ToString();
                    clienteExistente.CodigoPostal = (int)datos.Lector["CP"];

                    cliente = clienteExistente;
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
            return cliente;
        }
        public void AltaCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Clientes(Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) " +
                                     "VALUES(@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)");

                datos.SetearParametro("@Documento", cliente.DNI);
                datos.SetearParametro("@Nombre",cliente.Nombre);
                datos.SetearParametro("@Apellido",cliente.Apellido);
                datos.SetearParametro("@Email",cliente.Email);
                datos.SetearParametro("@Direccion",cliente.Direccion);
                datos.SetearParametro("@Ciudad",cliente.Ciudad);
                datos.SetearParametro("@CP",cliente.CodigoPostal);
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
