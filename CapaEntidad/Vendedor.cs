using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace CapaEntidad
{
    public class Vendedor
    {
        [DataMember]
        public string CodVendedor
        { get; set; }
        [DataMember]
        public string Apellidos
        { get; set; }
        [DataMember]
        public string Nombres
        { get; set; }
        [DataMember]
        public string Usuario
        { get; set; }
        [DataMember]
        public string Contrasena
        { get; set; }
    }
}
