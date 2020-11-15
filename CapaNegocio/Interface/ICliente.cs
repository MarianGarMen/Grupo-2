using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;

namespace CapaNegocio.Interface
{
    interface ICliente
    {
        bool Login(Cliente cliente);
        bool CambiarContrasena(Cliente cliente, string nuevaContrasena);
        DataSet Listar();
        DataSet ListarClientes();
        bool Agregar(Cliente cliente);
        bool Eliminar(Cliente cliente);
        bool Actualizar(Cliente cliente);
        DataSet Buscar(string texto, string criterio);
    }
}
