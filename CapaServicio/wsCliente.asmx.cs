using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data;
using CapaNegocio;
using CapaEntidad;
using System.Security.Cryptography;
using System.Text;

namespace CapaServicio
{
    /// <summary>
    /// Descripción breve de wsCliente
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsCliente : System.Web.Services.WebService
    {
        [WebMethod(Description = "Login de Cliente")]
        public string[] Login(string CodCliente, string Contrasena)
        {
            Cliente cliente= new Cliente();
            cliente.CodCliente = CodCliente;
            cliente.Contrasena = Contrasena;
            ClienteBL clienteBL= new ClienteBL();
            string[] respuesta = new string[3];
            bool CodError = clienteBL.Login(cliente);
            if (clienteBL.Login(cliente)) respuesta[0] = "true";
            else respuesta[0] = "false";
            respuesta[1] = clienteBL.Mensaje;
            respuesta[2] = clienteBL.NombreCompleto;
            return respuesta;
        }

        [WebMethod(Description = "Cambiar Contraseña")]
        public string[] CambiarContrasena(string Usuario, string NuevaContrasena)
        {
            Cliente cliente = new Cliente();
            cliente.Usuario = Usuario;
            ClienteBL clienteBL = new ClienteBL();
            string[] respuesta = new string[2];
            bool CodError = clienteBL.CambiarContrasena(cliente, NuevaContrasena);
            if (clienteBL.CambiarContrasena(cliente,NuevaContrasena)) respuesta[0] = "true";
            else respuesta[0] = "false";
            respuesta[1] = clienteBL.Mensaje;
            return respuesta;
        }
        [WebMethod(Description = "Listar datos de la tabla Cliente")]
        public DataSet Listar()
        {
            ClienteBL clienteBL = new ClienteBL();
            return clienteBL.Listar();
        }

        [WebMethod(Description = "Listar datos de la tabla Cliente 2")]
        public DataSet ListarClientes()
        {
            ClienteBL clienteBL = new ClienteBL();
            return clienteBL.ListarClientes();
        }

        [WebMethod(Description = "Agregar un Cliente ")]
        public bool Agregar(string Apellidos, string Nombres, string Direccion, string Usuario, string Contrasena)
        {
            Cliente cliente = new Cliente();
            cliente.Apellidos = Apellidos;
            cliente.Nombres = Nombres;
            cliente.Usuario = Usuario;
            cliente.Direccion = Direccion;
            cliente.Contrasena = Contrasena;
            ClienteBL clienteBL = new ClienteBL();
            if (clienteBL.Agregar(cliente)) return true;
            else return false;
        }

        [WebMethod(Description = "Modificar un Cliente")]
        public bool Modificar(string CodCliente, string Apellidos, string Nombres, string direccion, string Usuario)
        {
            Cliente cliente = new Cliente();
            cliente.CodCliente = CodCliente;
            cliente.Apellidos = Apellidos;
            cliente.Nombres = Nombres;
            cliente.Usuario = Usuario;
            cliente.Direccion = direccion;
            ClienteBL clienteBL = new ClienteBL();
            if (clienteBL.Actualizar(cliente)) return true;
            else return false;
        }

        [WebMethod(Description = "Eliminar un Cliente")]
        public bool Eliminar(string CodCliente)
        {
            Cliente cliente = new Cliente();
            cliente.CodCliente = CodCliente;
            ClienteBL clienteBL = new ClienteBL();
            if (clienteBL.Eliminar(cliente)) return true;
            else return false;
        }

        [WebMethod(Description = "Buscar un Cliente")]
        public DataSet Buscar(string texto, string criterio)
        {
            string _texto = texto;
            string _criterio = criterio;
            ClienteBL clienteBL = new ClienteBL();
            return clienteBL.Buscar(_texto, _criterio);
        }
    }
}
