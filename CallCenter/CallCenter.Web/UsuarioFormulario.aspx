<%@ Page Title="Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioFormulario.aspx.cs" Inherits="CallCenter.Web.UsuarioFormulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="tituloPagina" runat="server">Nuevo usuario</h1>
    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
    <div class="row">
        <div class="col-md-6">
            <div class="mb-3">
                <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" CssClass="form-label" Text="Nombre" />
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblNombreUsuario" runat="server" AssociatedControlID="txtNombreUsuario" CssClass="form-label" Text="Nombre de usuario" />
                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblContrasena" runat="server" AssociatedControlID="txtContrasena" CssClass="form-label" Text="Contraseña" />
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password"/>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblRol" runat="server" AssociatedControlID="ddlRol" CssClass="form-label" Text="Rol" />
                <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                    <asp:ListItem Text="Seleccioná un rol" Value="" Selected="True" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" Checked="true" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                <a runat="server" href="~/Usuarios.aspx" class="btn btn-secondary">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content> 