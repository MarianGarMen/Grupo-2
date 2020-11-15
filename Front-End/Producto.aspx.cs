using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;

namespace Front_End
{
    public partial class Producto : System.Web.UI.Page
    {
        private ServiceReferenceProducto.wsProductoSoapClient servicio = new ServiceReferenceProducto.wsProductoSoapClient();
        private void Listar()
        {
            gvProducto.DataSource = servicio.Listar();
            gvProducto.DataBind();
            alerta.Visible = false;
        }

        private void CargarCategorias() { 
            DataTable aux = servicio.ListarProdCat().Tables[0];
            ddlCategoriaAgregar.DataSource = aux;
            ddlCategoriaAgregar.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listar();
                CargarCategorias();
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(inpNombre.Text) && !String.IsNullOrEmpty(inpUnidadMedida.Text) && !String.IsNullOrEmpty(inpPrecio.Text) &&
                !String.IsNullOrEmpty(inpStock.Text) && !String.IsNullOrEmpty(ddlCategoriaAgregar.SelectedValue))
            {
                alerta.Visible = false;
                string nombre = inpNombre.Text.Trim();
                string unidadmedida = inpUnidadMedida.Text.Trim();
                float precio = float.Parse(inpPrecio.Text.Trim());
                int stock = int.Parse(inpStock.Text.Trim());
                string categoria = ddlCategoriaAgregar.SelectedValue;
                string codCategoria = categoria.Substring(0, 4);
                servicio.Agregar(nombre, unidadmedida, precio, stock, codCategoria);
                inpNombre.Text = "";
                inpUnidadMedida.Text = "";
                inpPrecio.Text = "";
                inpStock.Text = "";
                //.Items.FindByValue("SNVAL").Selected = true;
                ddlCategoriaAgregar.SelectedIndex = 0;
                Listar();
            }
            else
            {
                alerta.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
            }

        }

        protected void gvProducto_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvProducto.EditIndex = e.NewEditIndex;
            Listar();
        }

        protected void gvProducto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProducto.EditIndex = -1;
            Listar();
        }

        protected void gvProducto_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string CodProducto = (gvProducto.Rows[e.RowIndex].FindControl("txtCodProducto") as TextBox).Text.Trim();
            string Nombre = (gvProducto.Rows[e.RowIndex].FindControl("txtNombre") as TextBox).Text.Trim();
            string UnidadMedida = (gvProducto.Rows[e.RowIndex].FindControl("txtUnidadMedida") as TextBox).Text.Trim();
            float Precio = float.Parse((gvProducto.Rows[e.RowIndex].FindControl("txtPrecio") as TextBox).Text.Trim());
            int Stock = int.Parse((gvProducto.Rows[e.RowIndex].FindControl("txtStock") as TextBox).Text.Trim());
            //string Categoria = (gvProducto.Rows[e.RowIndex].FindControl("txtCategoria") as TextBox).Text.Trim();
            string Categoria = ((DropDownList)gvProducto.Rows[e.RowIndex].FindControl("ddlCategoria")).SelectedValue;
            //servicio.Modificar(CodVendedor, Apellidos, Nombres, Usuario);
            string codCategoria = Categoria.Substring(0, 4);
            servicio.Modificar(CodProducto, Nombre, UnidadMedida, Precio, Stock, codCategoria);
            gvProducto.EditIndex = -1;
            Listar();
        }

        protected void gvProducto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string CodProducto = (gvProducto.Rows[e.RowIndex].FindControl("lblCodProducto") as Label).Text.Trim();
            string Categoria = (gvProducto.Rows[e.RowIndex].FindControl("lblCategoria") as Label).Text.Trim();
            //servicio.Modificar(CodVendedor, Apellidos, Nombres, Usuario);
            string codCategoria = Categoria.Substring(0, 4);
            if (servicio.Eliminar(CodProducto, codCategoria))
            {
                gvProducto.EditIndex = -1;
                Listar();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Error');</script>");
            }
        }

        protected void gvProducto_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var t = e.Row.RowType;

            if (t == DataControlRowType.DataRow)
            {
                if (this.gvProducto.EditIndex >= 0 && e.Row.RowIndex == this.gvProducto.EditIndex)
                {
                    HiddenField hdnCategoria = (HiddenField)e.Row.FindControl("hdnCategoria");
                    DropDownList d = e.Row.FindControl("ddlCategoria") as DropDownList;
                    DataTable aux = servicio.ListarProdCat().Tables[0];
                    d.DataSource = aux;
                    d.DataBind();
                    d.Items.FindByValue(hdnCategoria.Value).Selected = true;
                }
            }
        }
    }
}