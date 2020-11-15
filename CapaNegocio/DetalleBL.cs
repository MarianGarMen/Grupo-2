using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
using CapaEntidad;

namespace CapaNegocio
{
    public class DetalleBL : Interface.IDetalle
    {
        private Datos datos = new DatosSQL();
        private string mensaje;
        public string Mensaje
        {
            get { return mensaje; }
        }

        public bool Agregar(Detalle detalle)
        {
            DataRow fila = datos.TraerDataRow("spAgregarDetalle", detalle.NroBoleta, detalle.CodProducto, detalle.Cantidad);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }
    }
}
