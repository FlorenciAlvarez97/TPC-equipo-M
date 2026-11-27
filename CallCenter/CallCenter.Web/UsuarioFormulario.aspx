<%@ Page Title="Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioFormulario.aspx.cs" Inherits="CallCenter.Web.UsuarioFormulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mx-auto mt-5" style="max-width: 520px;">
        <h1 id="tituloPagina" runat="server" class="text-center fw-bold mb-4">Nuevo usuario</h1>
        
        <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
        <div class="card border-0 shadow-sm rounded-4">
            <div class="card-body p-4 p-md-5">
                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" CssClass="form-label" Text="Nombre" />
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength = "100" Style="max-width: none; width: 100%;"/>
                    <asp:RequiredFieldValidator  ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio" CssClass="text-danger" Display="Dynamic" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblNombreUsuario" runat="server" AssociatedControlID="txtNombreUsuario" CssClass="form-label" Text="Nombre de usuario" />
                    <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" MaxLength = "50"  Style="max-width: none; width: 100%;"/>
                    <asp:RequiredFieldValidator  ID="rfvNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="El usuario es obligatorio" CssClass="text-danger" Display="Dynamic" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblContrasena" runat="server" AssociatedControlID="txtContrasena" CssClass="form-label" Text="Contraseña" />
                    <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" Style="max-width: none; width: 100%;"/>
                    <asp:RequiredFieldValidator  ID="rfvContrasena" runat="server" ControlToValidate="txtContrasena" ErrorMessage="La contraseña es obligatoria" CssClass="text-danger" Display="Dynamic" />
                </div>
                
                <div class="mb-3">
                    <asp:Label ID="lblRol" runat="server" AssociatedControlID="ddlRol" CssClass="form-label" Text="Rol" />
                    <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select" Style="max-width: none; width: 100%;" AppendDataBoundItems="true" />
                        <asp:ListItem Text="Seleccioná un rol" Value="" Selected="True" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator  ID="rfvRol" runat="server" ControlToValidate="ddlRol" InitialValue =" " ErrorMessage="Selecciona un rol" CssClass="text-danger" Display="Dynamic" />
                </div>
                <div class="mb-3">
                    <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" Checked="true" />
                </div>
                
                <div class="d-flex justify-content-end gap-2 mt-4">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <a runat="server" href="~/Usuarios.aspx" class="btn btn-secondary">Cancelar</a>
                </div>
              </div>
            </div>
        </div>
</asp:Content> 