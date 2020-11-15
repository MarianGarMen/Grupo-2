using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Front_End
{
    public partial class Categoria : System.Web.UI.Page
    {
        private ServiceReferenceCategoria.wsCategoriaSoapClient servicio = new ServiceReferenceCategoria.wsCategoriaSoapClient();
        private ServiceReferenceProducto.wsProductoSoapClient servicioProd = new ServiceReferenceProducto.wsProductoSoapClient();
        private void Listar()
        {
            gvCategoria.DataSource = servicio.Listar();
            gvCategoria.DataBind();
            alerta.Visible = false;
        }
        private void CargarCategorias()
        {
            DataTable aux = servicioProd.ListarProdCat().Tables[0];
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
            if (!String.IsNullOrEmpty(inpNombre.Text) && !String.IsNullOrEmpty(ddlCategoriaAgregar.SelectedValue))
            {
                alerta.Visible = false;
                string nombre = inpNombre.Text.Trim();
                string categoria = ddlCategoriaAgregar.SelectedValue;
                string codCategoria = categoria.Substring(0, 4);
                servicio.Agregar(nombre, codCategoria);
                inpNombre.Text = "";
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

        protected void gvCategoria_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvCategoria.EditIndex = e.NewEditIndex;
            Listar();
        }

        protected void gvCategoria_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCategoria.EditIndex = -1;
            Listar();
        }

        protected void gvCategoria_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Nombre = (gvCategoria.Rows[e.RowIndex].FindControl("txtNombre") as TextBox).Text.Trim();
            //string Categoria = (gvProducto.Rows[e.RowIndex].FindControl("txtCategoria") as TextBox).Text.Trim();
            string codCategoria = (gvCategoria.Rows[e.RowIndex].FindControl("txtCodCategoria") as TextBox).Text.Trim();
            string Categoria = ((DropDownList)gvCategoria.Rows[e.RowIndex].FindControl("ddlCategoria")).SelectedValue;
            //servicio.Modificar(CodVendedor, Apellidos, Nombres, Usuario);
            string codCategoriaPadre = Categoria.Substring(0, 4);
            servicio.Modificar(codCategoria,Nombre,codCategoriaPadre);
            gvCategoria.EditIndex = -1;
            Listar();
        }

        protected void gvCategoria_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string CodProducto = (gvCategoria.Rows[e.RowIndex].FindControl("lblCodCategoria") as Label).Text.Trim();
            //servicio.Modificar(CodVendedor, Apellidos, Nombres, Usuario);
            if (servicio.Eliminar(CodProducto))
            {
                gvCategoria.EditIndex = -1;
                Listar();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Error');</script>");
            }
        }

        protected void gvCategoria_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var t = e.Row.RowType;

            if (t == DataControlRowType.DataRow)
            {
                if (this.gvCategoria.EditIndex >= 0 && e.Row.RowIndex == this.gvCategoria.EditIndex)
                {
                    HiddenField hdnCategoria = (HiddenField)e.Row.FindControl("hdnCategoria");
                    DropDownList d = e.Row.FindControl("ddlCategoria") as DropDownList;
                    DataTable aux = servicioProd.ListarProdCat().Tables[0];
                    d.Items.Insert(0, new ListItem("Ninguna", "NULL"));
                    d.DataSource = aux;
                    d.DataBind();
                    //Response.Write("<script language=javascript>alert('"+ hdnCategoria.Value + "-"+ (e.Row.FindControl("txtNombre") as TextBox).Text.Trim() + "');</script>");
                    if (hdnCategoria.Value != "") {
                        d.Items.FindByValue(hdnCategoria.Value).Selected = true;
                    }
                    
                }
            }
        }
    }
}