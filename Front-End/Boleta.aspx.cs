using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_End
{
    public partial class Boleta : System.Web.UI.Page
    {
        private ServiceReferenceProducto.wsProductoSoapClient servicio = new ServiceReferenceProducto.wsProductoSoapClient();
        private ServiceReferenceBoleta.wsBoletaSoapClient servicioboleta = new ServiceReferenceBoleta.wsBoletaSoapClient();
        private ServiceReferenceDetalle.wsDetalleSoapClient serviciodetalle = new ServiceReferenceDetalle.wsDetalleSoapClient();
        private ServiceReferenceCliente.wsClienteSoapClient serviciocliente = new ServiceReferenceCliente.wsClienteSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    CargarCliente();
                    Listar();
                    alertaBoletaCreada.Visible = false;
                    alertaError.Visible = false;
                    alertaMenor0.Visible = false;
                    alertaNoCliente.Visible = false;
                    alertaNoStock.Visible = false;
                    alertaNoVendedor.Visible = false;
                    alertaSelecProd.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void Listar()
        {
            gvProducto.DataSource = servicio.Listar();
            gvProducto.DataBind();
        }

        private void CargarCliente()
        {
            DataTable aux = serviciocliente.ListarClientes().Tables[0];
            IDCliente.DataSource = aux;
            IDCliente.DataBind();
        }


        protected void btnBoleta_Click(object sender, EventArgs e)
        {
            if (!validarGridView()) return;

            string cliente_st = IDCliente.SelectedValue.Trim();
            string vendedor_st = Session["username"].ToString();

            string[] rsta = servicioboleta.Agregar(cliente_st, vendedor_st).ToArray();
            string codError = rsta[0];
            //Obtener IdBoleta
            string idBoleta = rsta[1];

            foreach (GridViewRow gr in gvProducto.Rows)
            {
                TextBox txtCantidad = (TextBox)gr.FindControl("IDcantidad");
                string stringcantidad = txtCantidad.Text.ToString();
                int cantidad = int.Parse(stringcantidad);
                if (cantidad > 0)
                {
                    //Agregamos detalles
                    string idproducto = gr.Cells[0].Text;
                    string[] respuesta = serviciodetalle.Agregar(idBoleta, idproducto, stringcantidad).ToArray();
                    if (respuesta[0] == "false")
                    {
                        //Response.Write("<script language=javascript>alert('" + respuesta[1] + "');</script>");
                        alertaError.Visible = true;
                    }
                }
            }
            alertaBoletaCreada.Visible = true;
            //Response.Write("<script language=javascript>alert('Boleta creada');</script>");
            CargarCliente();
            Listar();
        }

        public bool validarGridView()
        {
            int indiceCliente = IDCliente.SelectedIndex;
            if (indiceCliente == 0)
            {
                //Response.Write("<script language=javascript>alert('No ha elegido un cliente');</script>");
                alertaError.Visible = true;
                return false;
            }
            else
            {
                alertaError.Visible = false;
            }
            bool hayProductos = false;
            foreach (GridViewRow gr in gvProducto.Rows)
            {
                TextBox txtCantidad = (TextBox)gr.FindControl("IDcantidad");
                string stringcantidad = txtCantidad.Text.ToString();
                int cantidad = int.Parse(stringcantidad);
                int stock = int.Parse(gr.Cells[4].Text);
                if (cantidad < 0)
                {
                    //Response.Write("<script language=javascript>alert('La cantidad no puede ser negativa');</script>");
                    alertaMenor0.Visible = true;
                    return false;
                }
                else if (cantidad > stock)
                {
                    alertaMenor0.Visible = false;
                    //Response.Write("<script language=javascript>alert('No se puede superar el stoock de un producto');</script>");
                    alertaNoStock.Visible = true;
                    return false;
                }
                else if (cantidad > 0)
                {
                    alertaMenor0.Visible = false;
                    alertaNoStock.Visible = false;
                    hayProductos = true;
                }
            }
            if (!hayProductos)
            {
                //Response.Write("<script language=javascript>alert('No hay productos que agregar');</script>");
                alertaSelecProd.Visible = true;
            }
            else
            {
                alertaSelecProd.Visible = false;
            }
            return hayProductos;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Regresar al formulario principal
        }
    }
}