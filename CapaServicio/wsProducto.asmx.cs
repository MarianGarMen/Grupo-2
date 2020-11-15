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
    /// Descripción breve de wsProducto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsProducto : System.Web.Services.WebService
    {

        [WebMethod(Description = "Listar datos de la tabla Producto")]
        public DataSet Listar()
        {
            ProductoBL productoBL = new ProductoBL();
            return productoBL.Listar();
        }

        [WebMethod(Description = "Listar Categoria-Productp de la tabla Producto")]
        public DataSet ListarProdCat()
        {
            ProductoBL productoBL = new ProductoBL();
            return productoBL.ListarProductoCategoria();
        }

        [WebMethod(Description = "Agregar un Producto")]
        public bool Agregar(string nombre, string unidad_de_medida, float precio, int stock, string CodCatetegoria)
        {
            Producto producto = new Producto();
            producto.Nombre = nombre;
            producto.UnidadMedida = unidad_de_medida;
            producto.Precio = precio;
            producto.Stock = stock;
            producto.CodCategoria = CodCatetegoria;
            ProductoBL productoBL = new ProductoBL();
            if (productoBL.Agregar(producto)) return true;
            else return false;
        }

        [WebMethod(Description = "Eliminar un Producto")]
        public bool Eliminar(string CodProducto, string Codcategoria)
        {
            Producto producto = new Producto();
            producto.CodProducto = CodProducto;
            producto.CodCategoria = Codcategoria;
            ProductoBL productoBL = new ProductoBL();
            if (productoBL.Eliminar(producto)) return true;
            else return false;
        }

        [WebMethod(Description = "Modificar una producto")]
        public bool Modificar(string codProducto, string nombre, string unidad_de_medida, float precio, int stock, string CodCatetegoria)
        {
            Producto producto = new Producto();
            producto.CodProducto = codProducto;
            producto.Nombre = nombre;
            producto.UnidadMedida = unidad_de_medida;
            producto.Precio = precio;
            producto.Stock = stock;
            producto.CodCategoria = CodCatetegoria;
            ProductoBL productoBL = new ProductoBL();
            if (productoBL.Actualizar(producto)) return true;
            else return false;
        }

        [WebMethod(Description = "Buscar una producto")]
        public DataSet Buscar(string texto, string criterio)
        {
            string _texto = texto;
            string _criterio = criterio;
            ProductoBL productoBL = new ProductoBL();
            return productoBL.Buscar(_texto, _criterio);
        }
    }
}
