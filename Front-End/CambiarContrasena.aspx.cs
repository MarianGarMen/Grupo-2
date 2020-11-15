using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_End
{
    public partial class CambiarContrasena : System.Web.UI.Page
    {
        private ServiceReferenceCliente.wsClienteSoapClient servicio = new ServiceReferenceCliente.wsClienteSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            alerta.Visible = false;
            alertapass.Visible = false;
            alertapassdiferentes.Visible = false;
            alertaCorrecto.Visible = false;
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(contrasena.Text) && !String.IsNullOrEmpty(contrasenanueva.Text) && !String.IsNullOrEmpty(contrasenarepetir.Text))
            {
                if (contrasenanueva.Text != contrasenarepetir.Text)
                {
                    alertapassdiferentes.Visible = true;
                }
                else
                {
                    string Usuario = Session["username"].ToString();
                    string Password = contrasena.Text.Trim();
                    string NewPassword = contrasenanueva.Text.Trim();
                    string NewPassword2 = contrasenarepetir.Text.Trim();
                    string CodError = servicio.Login(Usuario, Password)[0];
                    string Mensaje = servicio.Login(Usuario, Password)[1];
                    if (CodError == "true")
                    {
                        alertaCorrecto.Visible = true;
                        contrasena.Text = "";
                        contrasenanueva.Text = "";
                        contrasenarepetir.Text = "";
                        servicio.CambiarContrasena(Usuario, NewPassword);
                    }
                    else
                    {
                        alertapass.Visible = true;
                    }
                }
            }
            else
            {
                alerta.Visible = true;
            }
        }
    }
}