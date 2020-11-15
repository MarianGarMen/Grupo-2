using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;

namespace CapaNegocio.Interface
{
    interface IVendedor
    {
        bool Login(Vendedor vendedor);
        DataSet Listar();
        bool Agregar(Vendedor vendedor);
        bool Eliminar(Vendedor CodVendedor);
        bool Actualizar(Vendedor vendedor);
        DataSet Buscar(string texto, string criterio);
    }
}
