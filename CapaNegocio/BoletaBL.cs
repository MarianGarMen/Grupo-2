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
    public class BoletaBL : Interface.IBoleta
    {
        private Datos datos = new DatosSQL();
        private string mensaje;
        public string Mensaje
        {
            get { return mensaje; }
        }

        public bool Agregar(Boleta boleta)
        {
            DataRow fila = datos.TraerDataRow("spAgregarBoleta", boleta.CodCliente, boleta.CodVendedor);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public DataSet ListarBoletaCliente(Boleta boleta)
        {
            return datos.TraerDataSet("spListarBoletaReciente", boleta.CodCliente);
        }

        public DataSet ListarBoletaClienteAnulada(Boleta boleta)
        {
            return datos.TraerDataSet("spListarBoletasAnuladas", boleta.CodCliente);
        }

        public DataSet ConsultarVentaFecha(string usuario, string semana)
        {
            return datos.TraerDataSet("spConsultarVentaxFecha", usuario, semana);
        }
    }
}
