using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
using CapaEntidad;

using System.Diagnostics;

namespace CapaNegocio
{
    public class ClienteBL : Interface.ICliente
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

        public bool Login(Cliente cliente)
        {
            DataRow fila = datos.TraerDataRow("spLoginCliente", cliente.CodCliente, cliente.Contrasena);
            mensaje = fila["Mensaje"].ToString();
            nombreCompleto = fila["NombreCompleto"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public bool CambiarContrasena(Cliente cliente, string nuevaContrasena)
        {
            DataRow fila = datos.TraerDataRow("spCambiarContrasena", cliente.Usuario, nuevaContrasena);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
            
        }
        public bool Actualizar(Cliente cliente)
        {
            DataRow fila = datos.TraerDataRow("spModificarCliente", cliente.CodCliente, cliente.Apellidos, cliente.Nombres, cliente.Direccion, cliente.Usuario);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public bool Agregar(Cliente cliente)
        {
            DataRow fila = datos.TraerDataRow("spAgregarCliente", cliente.Apellidos, cliente.Nombres, cliente.Direccion, cliente.Usuario, cliente.Contrasena);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public DataSet Buscar(string texto, string criterio)
        {
            return datos.TraerDataSet("spBuscarCliente", texto, criterio);
        }

        public bool Eliminar(Cliente cliente)
        {
            DataRow fila = datos.TraerDataRow("spEliminarCliente", cliente.CodCliente);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public DataSet Listar()
        {
            return datos.TraerDataSet("spListarCliente");
        }

        public DataSet ListarClientes()
        {
            return datos.TraerDataSet("spListarClienteDDL");
        }

        
    }
}
