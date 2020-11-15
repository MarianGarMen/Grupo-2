using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace CapaEntidad
{
    public class Producto
    {
        [DataMember]
        public string CodProducto
        { get; set; }
        [DataMember]
        public string Nombre
        { get; set; }
        [DataMember]
        public string UnidadMedida
        { get; set; }
        [DataMember]
        public float Precio
        { get; set; }
        [DataMember]
        public int Stock
        { get; set; }
        [DataMember]
        public string CodCategoria
        { get; set; }
    }
}
