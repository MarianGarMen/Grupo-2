using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_End
{
    public partial class _Default : Page
    {
        private ServiceReferenceCliente.wsClienteSoapClient servicio = new ServiceReferenceCliente.wsClienteSoapClient();
        private void Listar()
        {
            gvCliente.DataSource = servicio.Listar();
            gvCliente.DataBind();
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

        protected void gvCliente_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCliente.EditIndex = e.NewEditIndex;
            Listar();
        }

        protected void gvCliente_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCliente.EditIndex = -1;
            Listar();
        }

        protected void gvCliente_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string CodCliente = (gvCliente.Rows[e.RowIndex].FindControl("txtCodCliente") as TextBox).Text.Trim();
            string Apellidos = (gvCliente.Rows[e.RowIndex].FindControl("txtApellidos") as TextBox).Text.Trim();
            string Nombres = (gvCliente.Rows[e.RowIndex].FindControl("txtNombres") as TextBox).Text.Trim();
            string Direccion = (gvCliente.Rows[e.RowIndex].FindControl("txtDireccion") as TextBox).Text.Trim();
            string Usuario = (gvCliente.Rows[e.RowIndex].FindControl("txtUsuario") as TextBox).Text.Trim();
            servicio.Modificar(CodCliente,Apellidos,Nombres,Direccion,Usuario);
            gvCliente.EditIndex = -1;
            Listar();
        }

        protected void gvCliente_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //string CodVendedor = (gvVendedor.Rows[e.RowIndex].FindControl("lblCodVendedor") as TextBox).Text.Trim();
            string CodCliente = gvCliente.DataKeys[e.RowIndex].Value.ToString();
            if (servicio.Eliminar(CodCliente))
            {
                gvCliente.EditIndex = -1;
                Listar();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Error');</script>");
            }

        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(inpApellidos.Text) && !String.IsNullOrEmpty(inpNombres.Text) && !String.IsNullOrEmpty(inpUsuario.Text) &&
                !String.IsNullOrEmpty(inpContrasena.Text) && !String.IsNullOrEmpty(inpContrasena2.Text) && !String.IsNullOrEmpty(inpDireccion.Text))
            {
                alerta.Visible = false;
                string apellidos = inpApellidos.Text.Trim();
                string nombres = inpNombres.Text.Trim();
                string usuario = inpUsuario.Text.Trim();
                string direccion = inpDireccion.Text.Trim();
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
                    servicio.Agregar(apellidos,nombres,direccion,usuario,contrasena1);
                    inpApellidos.Text = "";
                    inpNombres.Text = "";
                    inpUsuario.Text = "";
                    inpDireccion.Text = "";
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