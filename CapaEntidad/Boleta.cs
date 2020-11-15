using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace CapaEntidad
{
    public class Boleta
    {
        [DataMember]
        public string NroBoleta
        { get; set; }
        [DataMember]
        public DateTime Fecha
        { get; set; }
        [DataMember]
        public string CodCliente
        { get; set; }
        [DataMember]
        public string CodVendedor
        { get; set; }
        [DataMember]
        public byte Anulado
        { get; set; }
    }
}