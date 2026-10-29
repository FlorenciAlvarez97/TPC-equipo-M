<%@ Page Title="Nuevo Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientesFormulario.aspx.cs" Inherits="CallCenter.Web.ClienteFormulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Nuevo cliente</h1>
    <p class="text-muted"></p>
    <div class="row">
        <div class= "col-md-6 mb-3">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre" AssociatedControlID="txtNombre" CssClass="col-form-label" />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        </div>

        <div class= "col-md-6 mb-3">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido" AssociatedControlID="txtApellido" CssClass="col-form-label" />
                <asp:TextBox ID="txtAlpellido" runat="server" CssClass="form-control" />
        </div>

        <div class= "col-md-6 mb-3">
            <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="txtEmail" CssClass="col-form-label" />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>

        <div class= "col-md-6 mb-3">
            <asp:Label ID="lblTelefono" runat="server" Text="Telefono" AssociatedControlID="txtTelefono" CssClass="col-form-label" />
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
        </div>

        <div class= "col-md-12 mb-3">
            <asp:Label ID="lblDireccion" runat="server" Text="Direccion" AssociatedControlID="txtDireccion" CssClass="col-form-label" />
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
        </div>

        <div class= "col-md-12 mb-3">
             <asp:CheckBox ID="chkActivo" runat="server" Text="Cliente Activo" Checked="true" />

        </div>
    </div
    <div class="mt-3">

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" Enabled="false" CausesValidation="false" />
        <a runat="server" href="~/Clientes.aspx" class="btn btn-secondary" Cancelar/Volver al listado <a />
    </div>


</asp:Content>
