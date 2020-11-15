using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
namespace Front_End
{
    public partial class About : Page
    {
        ServiceReferenceBoleta.wsBoletaSoapClient servicio = new ServiceReferenceBoleta.wsBoletaSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                alertaExito.Visible = false;
                alertaNoDatos.Visible = false;
                alertaNoRegistro.Visible = false;
                alertaNoSemana.Visible = false;
                btnExcel.Visible = false;
                btnPdf.Visible = false;
            };
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            string semana = txtSemana.Text;
            string codVendedor = Session["username"].ToString(); //IDVENDEDOR
            if (semana.Equals(""))
            {
                alertaNoSemana.Visible = true;
                //Response.Write("<script language=javascript>alert('Debe elegir una semana');</script>");
            }
            else
            {
                alertaNoSemana.Visible = false;
                DataSet data = servicio.ConsultarVentaFecha(codVendedor, semana);
                if (data.Tables[0].Rows.Count == 0)
                {
                    alertaNoRegistro.Visible = true;
                    //Response.Write("<script language=javascript>alert('No hay boletas en la semana elegida');</script>");
                }
                else
                {
                    alertaNoRegistro.Visible = false;
                    GridConsulta.DataSource = data;
                    GridConsulta.DataBind();
                    btnExcel.Visible = true;
                    btnPdf.Visible = true;
                }
            }

        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            if (GridConsulta.Rows.Count == 0)
            {
                alertaNoDatos.Visible = true;
                //Response.Write("<script language=javascript>alert('No hay datos que exportar');</script>");
            }
            else
            {
                alertaNoDatos.Visible = false;
                ExportToExcel(GridConsulta);
                alertaExito.Visible = true;
            }
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            if (GridConsulta.Rows.Count == 0)
            {
                alertaNoDatos.Visible = true;
                //Response.Write("<script language=javascript>alert('No hay datos que exportar');</script>");
            }
            else
            {
                alertaNoDatos.Visible = false;
                ExportGridToPDF();
                alertaExito.Visible = true;
            }
        }

        private void ExportToExcel(GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            form.Controls.Add(wControl);
            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=Reporte.xls");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }
        private void ExportGridToPDF()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Reporte.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridConsulta.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            #pragma warning disable CS0612 // Type or member is obsolete  
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            #pragma warning restore CS0612 // Type or member is obsolete  
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            GridConsulta.AllowPaging = true;
            GridConsulta.DataBind();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}