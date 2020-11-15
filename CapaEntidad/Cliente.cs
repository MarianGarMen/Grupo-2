using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace CapaEntidad
{
    public class Cliente
    {
        [DataMember]
        public string CodCliente
        { get; set; }
        [DataMember]
        public string Apellidos
        { get; set; }
        [DataMember]
        public string Nombres
        { get; set; }
        [DataMember]
        public string Direccion
        { get; set; }
        [DataMember]
        public string Usuario
        { get; set; }
        [DataMember]
        public string Contrasena
        { get; set; }
    }
}
