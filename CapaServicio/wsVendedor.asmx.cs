using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data;
using CapaNegocio;
using CapaEntidad;

namespace CapaServicio
{
    /// <summary>
    /// Descripción breve de wsVendedor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsVendedor : System.Web.Services.WebService
    {
        [WebMethod(Description = "Login de Vendedor ")]
        public string[] Login(string CodVendedor, string Contrasena)
        {
            Vendedor vendedor = new Vendedor();
            vendedor.CodVendedor = CodVendedor;
            vendedor.Contrasena = Contrasena;
            VendedorBL vendedorBL = new VendedorBL();
            string[] respuesta = new string[3];
            bool CodError = vendedorBL.Login(vendedor);
            if (vendedorBL.Login(vendedor)) respuesta[0] = "true";
            else respuesta[0] = "false";
            respuesta[1] = vendedorBL.Mensaje;
            respuesta[2] = vendedorBL.NombreCompleto;
            return respuesta;
        }

        [WebMethod(Description = "Listar datos de la tabla vendedor")]
        public DataSet Listar()
        {
            VendedorBL vendedor = new VendedorBL();
            return vendedor.Listar();
        }

        [WebMethod(Description = "Agregar un Vendedor a la tabla vendedor")]
        public bool Agregar(string Apellidos, string Nombres, string Usuario, string Contrasena)
        {
            Vendedor vendedor = new Vendedor();
            vendedor.Apellidos = Apellidos;
            vendedor.Nombres = Nombres;
            vendedor.Usuario = Usuario;
            vendedor.Contrasena = Contrasena;
            VendedorBL vendedorBL = new VendedorBL();
            if (vendedorBL.Agregar(vendedor)) return true;
            else return false;
        }

        [WebMethod(Description = "Modificar un Vendedor a la tabla vendedor")]
        public bool Modificar(string CodVendedor, string Apellidos, string Nombres, string Usuario)
        {
            Vendedor vendedor = new Vendedor();
            vendedor.CodVendedor = CodVendedor;
            vendedor.Apellidos = Apellidos;
            vendedor.Nombres = Nombres;
            vendedor.Usuario = Usuario;
            VendedorBL vendedorBL = new VendedorBL();
            if (vendedorBL.Actualizar(vendedor)) return true;
            else return false;
        }

        [WebMethod(Description = "Eliminar un Vendedor a la tabla vendedor")]
        public bool Eliminar(string CodVendedor)
        {
            Vendedor vendedor = new Vendedor();
            vendedor.CodVendedor = CodVendedor;
            VendedorBL vendedorBL = new VendedorBL();
            if (vendedorBL.Eliminar(vendedor)) return true;
            else return false;
        }

        [WebMethod(Description = "Buscar un Vendedor a la tabla vendedor")]
        public DataSet Buscar(string texto, string criterio)
        {
            string _texto = texto;
            string _criterio = criterio;
            VendedorBL vendedor = new VendedorBL();
            return vendedor.Buscar(_texto, _criterio);
        }
    }
}
