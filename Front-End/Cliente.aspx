<%@ Page Title="Administrar Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Front_End._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">Mantenimiento Cliente</h6>
        </div>
        <div class="card-header py-3">
            <asp:LinkButton NavigateUrl="#" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Agregar Cliente" data-toggle="modal" data-target="#registerModal"/>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="gvCliente" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" 
                    CssClass="table table-bordered" width="100%" cellspacing="0" DataKeyNames="CodCliente" OnRowEditing="gvCliente_RowEditing"
                    OnRowCancelingEdit="gvCliente_RowCancelingEdit" OnRowUpdating="gvCliente_RowUpdating" OnRowDeleting="gvCliente_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Código Cliente">
                            <ItemTemplate>
                                <asp:Label  Text='<%# Eval("CodCliente") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCodCliente" CssClass="form-control form-control-user " runat="server" Text='<%# Eval("CodCliente") %>' ReadOnly></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Apellidos">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Apellidos") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtApellidos" CssClass="form-control form-control-user" runat="server" Text='<%# Eval("Apellidos") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombres">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Nombres") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNombres" CssClass="form-control form-control-user" runat="server" Text='<%# Eval("Nombres") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Dirección">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Direccion") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDireccion" CssClass="form-control form-control-user" runat="server" Text='<%# Eval("Direccion") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Usuario">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Usuario") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtUsuario" CssClass="form-control form-control-user" runat="server" Text='<%# Eval("Usuario") %>'></asp:TextBox>
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
                    <h5 class="modal-title" id="exampleModalLabel">Agregar Cliente</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:TextBox runat="server" type="text" CssClass="form-control form-control-user" id="inpApellidos" placeholder="Apellidos"/>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" type="text" CssClass="form-control form-control-user" id="inpNombres" placeholder="Nombres"/>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" type="text" CssClass="form-control form-control-user" id="inpDireccion" placeholder="Direccion"/>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" type="email" CssClass="form-control form-control-user" id="inpUsuario" placeholder="Usuario"/>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" type="password" CssClass="form-control form-control-user" id="inpContrasena" placeholder="Contraseña"/>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" type="password" CssClass="form-control form-control-user" id="inpContrasena2" placeholder="Repita su Contraseña"/>
                    </div>
                    <div class="alert alert-danger" role="alert" id="alerta" runat="server">
                        Rellene todos los campos
                    </div>
                    <div class="alert alert-danger" role="alert" id="alertapass" runat="server">
                        Las contraseñas no coinciden
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancelar</button>
                     <asp:LinkButton NavigateUrl="#" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="Unnamed_Click1"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
