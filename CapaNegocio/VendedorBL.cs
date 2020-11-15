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
    public class VendedorBL : Interface.IVendedor
    {
        private Datos datos = new DatosSQL();
        private string mensaje;
        public string Mensaje
        {
            get { return mensaje; }
        }
        private string nombreCompleto;
        public string NombreCompleto
        {
            get { return nombreCompleto; }
        }
        public bool Login(Vendedor vendedor)
        {
            DataRow fila = datos.TraerDataRow("spLoginVendedor", vendedor.CodVendedor, vendedor.Contrasena);
            mensaje = fila["Mensaje"].ToString();
            nombreCompleto = fila["NombreCompleto"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }
        public bool Actualizar(Vendedor vendedor)
        {
            DataRow fila = datos.TraerDataRow("spModificarVendedor", vendedor.CodVendedor, vendedor.Apellidos, vendedor.Nombres, vendedor.Usuario, vendedor.Contrasena);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public bool Agregar(Vendedor vendedor)
        {
            DataRow fila = datos.TraerDataRow("spAgregarVendedor", vendedor.Apellidos, vendedor.Nombres, vendedor.Usuario, vendedor.Contrasena);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public DataSet Buscar(string texto, string criterio)
        {
            return datos.TraerDataSet("spBuscarVendedor", texto, criterio);
        }

        public bool Eliminar(Vendedor vendedor)
        {
            DataRow fila = datos.TraerDataRow("spEliminarVendedor", vendedor.CodVendedor);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public DataSet Listar()
        {
            return datos.TraerDataSet("spListarVendedor");
        }
    }
}
