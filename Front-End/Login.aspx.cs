using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_End
{
    public partial class Login : System.Web.UI.Page
    {
        private ServiceReferenceVendedor.wsVendedorSoapClient servicio = new ServiceReferenceVendedor.wsVendedorSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            alerta.Visible = false;
            alertapass.Visible = false;
            if (Session["username"] != null)
            {
                Response.Redirect("Reportes.aspx");
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(exampleInputEmail.Text)&& !String.IsNullOrEmpty(exampleInputPassword.Text))
            {
                string Usuario = exampleInputEmail.Text.Trim();
                string Password = exampleInputPassword.Text.Trim();
                string CodError = servicio.Login(Usuario, Password)[0];
                string Mensaje = servicio.Login(Usuario, Password)[1];
                string NombreCompleto = servicio.Login(Usuario, Password)[2];
                if (CodError == "true")
                {
                    Session["username"] = Usuario;
                    Session["nombreCompleto"] = NombreCompleto;
                    Response.Redirect("Reportes.aspx");
                }
                else
                {
                    alertapass.Visible = true ;
                }
            }
            else
            {
                alerta.Visible = true;
            }
        }
    }
}