using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data;
using CapaNegocio;
using CapaEntidad;

namespace CapaServicio
{
    /// <summary>
    /// Descripción breve de wsCategoria
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsCategoria : System.Web.Services.WebService
    {

        [WebMethod(Description = "Listar datos de la tabla Categoria")]
        public DataSet Listar()
        {
            CategoriaBL categoriaBL = new CategoriaBL();
            return categoriaBL.Listar();
        }

        [WebMethod(Description = "Agregar una Categoria")]
        public bool Agregar(string nombre, string categoriaPadre)
        {
            Categoria categoria = new Categoria();
            categoria.Nombre = nombre;
            categoria.CategoriaPadre = categoriaPadre;
            CategoriaBL categoriaBL = new CategoriaBL();
            if (categoriaBL.Agregar(categoria)) return true;
            else return false;
        }

        [WebMethod(Description = "Eliminar una Categoria")]
        public bool Eliminar(string Codcategoria)
        {
            Categoria categoria = new Categoria();
            categoria.CodCategoria = Codcategoria;
            CategoriaBL categoriaBL = new CategoriaBL();
            if (categoriaBL.Eliminar(categoria)) return true;
            else return false;
        }

        [WebMethod(Description = "Modificar una Categoria")]
        public bool Modificar(string codcategoria, string nombre, string categoriaPadre)
        {
            Categoria categoria = new Categoria();
            categoria.CodCategoria = codcategoria;
            categoria.Nombre = nombre;
            categoria.CategoriaPadre = categoriaPadre;
            CategoriaBL categoriaBL = new CategoriaBL();
            if (categoriaBL.Actualizar(categoria)) return true;
            else return false;
        }

        [WebMethod(Description = "Buscar una Categoria")]
        public DataSet Buscar(string texto, string criterio)
        {
            string _texto = texto;
            string _criterio = criterio;
            CategoriaBL categoriaBL = new CategoriaBL();
            return categoriaBL.Buscar(_texto, _criterio);
        }


    }
}
