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
    public class ProductoBL : Interface.IProducto
    {
        private Datos datos = new DatosSQL();
        private string mensaje;
        public string Mensaje
        {
            get { return mensaje; }
        }

        public bool Actualizar(Producto producto)
        {
            DataRow fila = datos.TraerDataRow("spModificarProducto", producto.CodProducto, producto.Nombre, producto.UnidadMedida, producto.Precio, producto.Stock, producto.CodCategoria);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public bool Agregar(Producto producto)
        {
            DataRow fila = datos.TraerDataRow("spAgregarProducto", producto.Nombre, producto.UnidadMedida, producto.Precio, producto.Stock, producto.CodCategoria);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public DataSet Buscar(string texto, string criterio)
        {
            return datos.TraerDataSet("spBuscarProducto", texto, criterio);
        }

        public bool Eliminar(Producto producto)
        {
            DataRow fila = datos.TraerDataRow("spEliminarProducto", producto.CodProducto, producto.CodCategoria);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public DataSet Listar()
        {
            return datos.TraerDataSet("spListarProductos");
        }

        public DataSet ListarProductoCategoria()
        {
            return datos.TraerDataSet("spListarProductosCategoria");
        }
    }
}
