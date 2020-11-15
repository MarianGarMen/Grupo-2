<%@ Page Title="Cambiar Contraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarContrasena.aspx.cs" Inherits="Front_End.CambiarContrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="p-5">
                <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Cambio de Contraseña</h1>
                </div>
                <br />
                    <div class="form-group">
                        <asp:TextBox runat="server" type="password" class="form-control form-control-user"
                            ID="contrasena" placeholder="Contraseña Actual" required />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" type="password" class="form-control form-control-user"
                            ID="contrasenanueva" placeholder="Contraseña Nueva" required />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" type="password" class="form-control form-control-user"
                            ID="contrasenarepetir" placeholder="Repetir Contraseña Nueva" required />
                    </div>
                    <div class="alert alert-danger" role="alert" id="alerta" runat="server">
                        Rellene todos los campos
                    </div>
                    <div class="alert alert-danger" role="alert" id="alertapass" runat="server">
                        !Contraseña Incorrecta!
                    </div>
                    <div class="alert alert-danger" role="alert" id="alertapassdiferentes" runat="server">
                        !Las contraseñas no coinciden!
                    </div>
                    <div class="alert alert-success" role="alert" id="alertaCorrecto" runat="server">
                        Contraseña actualizada exitosamente
                    </div>
                    <br />
                    <asp:LinkButton NavigateUrl="Reportes.aspx" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Cambiar Contraseña" OnClick="Unnamed_Click" />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
