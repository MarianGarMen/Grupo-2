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
    /// Descripción breve de wsBoleta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsBoleta : System.Web.Services.WebService
    {
        [WebMethod(Description = "Listar boletas por cliente")]
        public DataSet ListarBoletaCliente(string CodCLiente)
        {
            Boleta boleta = new Boleta();
            boleta.CodCliente = CodCLiente;
            BoletaBL boletaBL = new BoletaBL();
            return boletaBL.ListarBoletaCliente(boleta);
        }

        [WebMethod(Description = "Listar boletas anuladas por cliente")]
        public DataSet ListarBoletaAnuladaCliente(string CodCLiente)
        {
            Boleta boleta = new Boleta();
            boleta.CodCliente = CodCLiente;
            BoletaBL boletaBL = new BoletaBL();
            return boletaBL.ListarBoletaClienteAnulada(boleta);
        }

        [WebMethod(Description = "Agregar una Boleta")]
        public string[] Agregar(string codCliente, string codVendedor)
        {
            Boleta boleta = new Boleta();
            boleta.CodCliente = codCliente;
            boleta.CodVendedor = codVendedor;
            BoletaBL boletaBL = new BoletaBL();

            string[] respuesta = new string[2];
            bool CodError = boletaBL.Agregar(boleta);

            if (CodError == true) respuesta[0] = "true";
            else respuesta[0] = "false";
            respuesta[1] = boletaBL.Mensaje;
            return respuesta;
        }

        [WebMethod(Description = "Consultar Ventas por Fecha")]
        public DataSet ConsultarVentaFecha(string usuario, string semana)
        {
            BoletaBL boletaBL = new BoletaBL();
            return boletaBL.ConsultarVentaFecha(usuario, semana);
        }
    }
}
