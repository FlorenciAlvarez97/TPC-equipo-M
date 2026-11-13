<%@ Page Title="Nuevo Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteFormulario.aspx.cs" Inherits="CallCenter.Web.ClienteFormulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="tituloPagina" runat="server">Nuevo cliente</h1>
    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
    <p class="text-muted"></p>
    <div class="row">
        <div class= "col-md-6 mb-3">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre" AssociatedControlID="txtNombre" CssClass="col-form-label" />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength = "50"  />
            <asp:RequiredFieldValidator  ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio" CssClass="text-danger" Display="Dynamic" />
        </div>


        <div class= "col-md-6 mb-3">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido" AssociatedControlID="txtApellido" CssClass="col-form-label" />
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" MaxLength = "30" />
                <asp:RequiredFieldValidator  ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="El apellido es obligatorio" CssClass="text-danger" Display="Dynamic" />
        </div>

        <div class= "col-md-6 mb-3">
            <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="txtEmail" CssClass="col-form-label" />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength ="50" />
            <asp:RequiredFieldValidator  ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="El email es obligatorio" CssClass="text-danger" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate ="txtEmail"
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Ingresa un email válido" CssClass="text-danger" Display="Dynamic" />
        </div>

        <div class= "col-md-6 mb-3">
            <asp:Label ID="lblTelefono" runat="server" Text="Telefono" AssociatedControlID="txtTelefono" CssClass="col-form-label" />
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength = "10" />
        </div>

        <div class= "col-md-12 mb-3">
            <asp:Label ID="lblDireccion" runat="server" Text="Direccion" AssociatedControlID="txtDireccion" CssClass="col-form-label" />
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength = "150" />
        </div>

        <div class= "col-md-12 mb-3">
             <asp:CheckBox ID="chkActivo" runat="server" Text="Cliente Activo" Checked="true" />

        </div>
    </div>
    <div class="mt-3">

       <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        <a runat="server" href="~/Clientes.aspx" class="btn btn-secondary"> Cancelar </a>

    </div>


</asp:Content>
