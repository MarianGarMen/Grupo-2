<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Front_End.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="alert alert-warning" role="alert" id="alertaNoRegistro" runat="server">
        No hay boletas registradas en la semana elegida
    </div>
    <div class="alert alert-danger" role="alert" id="alertaNoSemana" runat="server">
      Debe elegir una semana
    </div>
    <div class="alert alert-danger" role="alert" id="alertaNoDatos" runat="server">
      No hay datos que exportar
    </div>
    <div class="alert alert-success" role="alert" id="alertaExito" runat="server">
      Datos exportados exitosamente
    </div>

    <asp:TextBox ID="txtSemana" runat="server" type="week" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Button ID="btnReporte" runat="server" Text="Consultar" OnClick="btnReporte_Click" CssClass="btn btn-primary btn-user btn-block"/>
    <asp:Button ID="btnExcel" runat="server" Text="Exportar a Excel" OnClick="btnExcel_Click" CssClass="btn btn-primary btn-user btn-block"/>
    <asp:Button ID="btnPdf" runat="server" Text="Exportar a PDF" OnClick="btnPdf_Click" CssClass="btn btn-primary btn-user btn-block"/>
    <br />
    <asp:GridView ID="GridConsulta" runat="server" CssClass="table table-bordered"></asp:GridView>
</asp:Content>
