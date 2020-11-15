<%@ Page Title="Administrar Categorías" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="Front_End.Categoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">Mantenimiento Categoría</h6>
        </div>
        <div class="card-header py-3">
            <asp:LinkButton NavigateUrl="#" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Agregar Categoría" data-toggle="modal" data-target="#registerModal"/>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="gvCategoria" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" 
                    CssClass="table table-bordered" width="100%" cellspacing="0" DataKeyNames="CodCategoria"
                    OnRowEditing="gvCategoria_RowEditing" OnRowCancelingEdit="gvCategoria_RowCancelingEdit" 
                    OnRowUpdating="gvCategoria_RowUpdating" OnRowDeleting="gvCategoria_RowDeleting"
                    OnRowDataBound="gvCategoria_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Código Categoría">
                            <ItemTemplate>
                                <asp:Label id="lblCodCategoria" Text='<%# Eval("CodCategoria") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCodCategoria" CssClass="form-control form-control-user " runat="server" Text='<%# Eval("CodCategoria") %>' ReadOnly></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Nombre") %>' id="lblNombreCat" runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNombre" CssClass="form-control form-control-user" runat="server" Text='<%# Eval("Nombre") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Categoría Padre">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("CategoriaPadre") %>' runat="server" id="lblCategoria"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField ID="hdnCategoria" runat="server" Value='<%#Eval("CategoriaPadre") %>' />
                                <asp:DropDownList runat="server" ID="ddlCategoria" DataTextField="Categoria" DataValueField="Categoria"
                                    AppendDataBoundItems=true class="form-control">
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Acciones" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton NavigateUrl="#" ID="btnEdit" runat="server" CssClass="btn btn-warning btn-circle" CommandName="Edit" ToolTip="Edit">
                                    <i class="fas fa-pen"></i>
                                </asp:LinkButton>
                                
                                <asp:LinkButton NavigateUrl="#" ID="btnDelete" runat="server" CssClass="btn btn-danger btn-circle" CommandName="Delete" ToolTip="Delete"  >
                                    <i class="fas fa-trash"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton NavigateUrl="#" ID="btnUpdate" runat="server" CssClass="btn btn-success btn-circle" CommandName="Update" ToolTip="Update">
                                    <i class="far fa-save"></i>
                                </asp:LinkButton>
                                <asp:LinkButton NavigateUrl="#" ID="btnCancel" runat="server" CssClass="btn btn-warning btn-circle" CommandName="Cancel" ToolTip="Cancel">
                                    <i class="fas fa-window-close"></i>
                                </asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>    
                </asp:GridView>
            </div>
        </div>
    </div>
    <!--Modal para agregar-->
    <div class="modal fade" id="registerModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Agregar Categoría</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:TextBox runat="server" type="text" CssClass="form-control form-control-user" id="inpNombre" placeholder="Nombre"/>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlCategoriaAgregar" runat="server" AutoPostBack="false" name="Categoría" class="form-control" AppendDataBoundItems="true" 
                            DataTextField="Categoria" DataValueField="Categoria">
                            <asp:ListItem Text="<Seleccione la Categoría Padre>" Value="SNVAL" />
                            <asp:ListItem Text="Ninguna" Value="NULL" />
                        </asp:DropDownList>
                    </div>
                    <div class="alert alert-danger" role="alert" id="alerta" runat="server">
                        Rellene todos los campos
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancelar</button>
                    <asp:Button Text="Agregar" id="btnAgregarModal" runat="server" CssClass="btn btn-primary" OnClick="Unnamed_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
