using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace CapaEntidad
{
    public class Categoria
    {
        [DataMember]
        public string CodCategoria
        { get; set; }
        [DataMember]
        public string Nombre
        { get; set; }
        [DataMember]
        public string CategoriaPadre
        { get; set; }
    }
}
