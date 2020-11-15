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
    /// Descripción breve de wsDetalle
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsDetalle : System.Web.Services.WebService
    {
        [WebMethod(Description = "Agregar una Detalle")]
        public string[] Agregar(string NroBoleta, string CodProducto, string cantidad)
        {
            Detalle detalle = new Detalle();
            detalle.NroBoleta = NroBoleta;
            detalle.CodProducto = CodProducto;
            detalle.Cantidad = int.Parse(cantidad);
            DetalleBL detalleBL = new DetalleBL();

            string[] respuesta = new string[2];
            bool CodError = detalleBL.Agregar(detalle);

            if (CodError == true) respuesta[0] = "true";
            else respuesta[0] = "false";
            respuesta[1] = detalleBL.Mensaje;
            return respuesta;
        }
    }
}
