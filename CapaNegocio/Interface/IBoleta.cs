using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;

namespace CapaNegocio.Interface
{
    interface IBoleta
    {
        DataSet ListarBoletaCliente(Boleta boleta);
        DataSet ListarBoletaClienteAnulada(Boleta boleta);
        bool Agregar(Boleta boleta);
        DataSet ConsultarVentaFecha(string codVendedor, string semana);
    }
}