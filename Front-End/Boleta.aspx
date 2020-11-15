<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Boleta.aspx.cs" Inherits="Front_End.Boleta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="alert alert-danger" role="alert" id="alertaNoCliente" runat="server">
            No ha seleccionado un cliente!
        </div>
        <div class="alert alert-danger" role="alert" id="alertaNoVendedor" runat="server">
            No ha seleccionado un vendedor!
        </div>
        <div class="alert alert-danger" role="alert" id="alertaError" runat="server">
            Se produjo un error al registrar la boleta!
        </div>
        <div class="alert alert-danger" role="alert" id="alertaMenor0" runat="server">
            La cantidad no puede ser menor a 0
        </div>
        <div class="alert alert-danger" role="alert" id="alertaNoStock" runat="server">
            Lo sentimos, no tenemos suficiente stock
        </div>
        <div class="alert alert-danger" role="alert" id="alertaSelecProd" runat="server">
            No ha seleccionado productos
        </div>
        <div class="alert alert-success" role="alert" id="alertaBoletaCreada" runat="server">
            Boleta creada exitosamente
        </div>
        <label for="Cliente">Cliente: </label>
        <asp:DropDownList runat="server" ID="IDCliente" DataTextField="NombresCliente" DataValueField="CodCliente"
            AppendDataBoundItems=true class="form-control">
            <asp:ListItem Text="<Seleccione Cliente>" Value="SNVAL" />
        </asp:DropDownList>
        <br />
    </div>
    <asp:GridView ID="gvProducto" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center"
        CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="CodProducto" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="UnidadMedida" HeaderText="Unidad Medida" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:BoundField DataField="Stock" HeaderText="Stock" />
            <asp:TemplateField HeaderText="Comprar" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:TextBox ID="IDcantidad" name="IDcantidad" runat="server" Text="0" type="number" min="0" step="1"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnBoleta" runat="server" Text="Generar Boleta" OnClick="btnBoleta_Click" CssClass="btn btn-primary btn-user btn-block"/>
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-primary btn-user btn-block"/>
    <br />
    
</asp:Content>
