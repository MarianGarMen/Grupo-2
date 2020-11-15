using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;

namespace CapaNegocio.Interface
{
    interface IProducto
    {
        DataSet Listar();
        DataSet ListarProductoCategoria();
        bool Agregar(Producto producto);
        bool Eliminar(Producto producto);
        bool Actualizar(Producto producto);
        DataSet Buscar(string texto, string criterio);
    }
}
