using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_End
{
    public partial class Contact : Page
    {
        private ServiceReferenceVendedor.wsVendedorSoapClient servicio = new ServiceReferenceVendedor.wsVendedorSoapClient();
        private void Listar()
        {
            gvVendedor.DataSource = servicio.Listar();
            gvVendedor.DataBind();
            alerta.Visible = false;
            alertapass.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listar();
            }
        }

        protected void gvVendedor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvVendedor.EditIndex = e.NewEditIndex;
            Listar();
        }

        protected void gvVendedor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvVendedor.EditIndex = -1;
            Listar();
        }

        protected void gvVendedor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string CodVendedor = (gvVendedor.Rows[e.RowIndex].FindControl("txtCodVendedor") as TextBox).Text.Trim();
            string Apellidos = (gvVendedor.Rows[e.RowIndex].FindControl("txtApellidos") as TextBox).Text.Trim();
            string Nombres = (gvVendedor.Rows[e.RowIndex].FindControl("txtNombres") as TextBox).Text.Trim();
            string Usuario = (gvVendedor.Rows[e.RowIndex].FindControl("txtUsuario") as TextBox).Text.Trim();
            servicio.Modificar(CodVendedor, Apellidos, Nombres, Usuario);
            gvVendedor.EditIndex = -1;
            Listar();
        }


        protected void gvVendedor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //string CodVendedor = (gvVendedor.Rows[e.RowIndex].FindControl("lblCodVendedor") as TextBox).Text.Trim();
            string CodVendedor = gvVendedor.DataKeys[e.RowIndex].Value.ToString();
            if (servicio.Eliminar(CodVendedor))
            {
                gvVendedor.EditIndex = -1;
                Listar();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Error');</script>");
            }
            
        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            
            if(!String.IsNullOrEmpty(inpApellidos.Text) && !String.IsNullOrEmpty(inpNombres.Text) && !String.IsNullOrEmpty(inpUsuario.Text) &&
                !String.IsNullOrEmpty(inpContrasena.Text) && !String.IsNullOrEmpty(inpContrasena2.Text))
            {
                alerta.Visible = false;
                string apellidos = inpApellidos.Text.Trim();
                string nombres = inpNombres.Text.Trim();
                string usuario = inpUsuario.Text.Trim();
                string contrasena1 = inpContrasena.Text.Trim();
                string contrasena2 = inpContrasena2.Text.Trim();
                if (inpContrasena.Text != inpContrasena2.Text)
                {
                    alertapass.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                }
                else
                {
                    alertapass.Visible = false;
                    servicio.Agregar(apellidos, nombres, usuario, contrasena1);
                    inpApellidos.Text = "";
                    inpNombres.Text = "";
                    inpUsuario.Text = "";
                    inpContrasena.Text = "";
                    inpContrasena2.Text = "";
                    Listar();
                }
            }
            else
            {
                alerta.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
            }
        }
    }
}