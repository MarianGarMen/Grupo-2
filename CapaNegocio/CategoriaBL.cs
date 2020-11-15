using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
using CapaEntidad;
using CapaNegocio.Interface;

namespace CapaNegocio
{
    public class CategoriaBL : Interface.ICategoria
    {
        private Datos datos = new DatosSQL();
        private string mensaje;
        public string Mensaje
        {
            get { return mensaje; }
        }

        public bool Actualizar(Categoria categoria)
        {
            DataRow fila = datos.TraerDataRow("spModificarCategoria", categoria.CodCategoria, categoria.Nombre, categoria.CategoriaPadre);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public bool Agregar(Categoria categoria)
        {
            DataRow fila = datos.TraerDataRow("spAgregarCategoria", categoria.Nombre, categoria.CategoriaPadre);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public DataSet Buscar(string texto, string criterio)
        {
            return datos.TraerDataSet("spBuscarCategoria", texto, criterio);
        }

        public bool Eliminar(Categoria categoria)
        {
            DataRow fila = datos.TraerDataRow("spEliminarCategoria", categoria.CodCategoria);
            mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public DataSet Listar()
        {
            return datos.TraerDataSet("spListarCategoria");
        }

    }
}
