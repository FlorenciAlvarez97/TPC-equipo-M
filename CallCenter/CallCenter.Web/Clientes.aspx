<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="CallCenter.Web.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Clientes</h1>
    <p> </p>
    <div class="mb-3">
        <a runat="server" href="~/ClienteFormulario.aspx" class="btn btn-primary">Nuevo cliente</a>
        <a runat="server" href="~/Default.aspx" class="btn btn-secondary">Volver al inicio</a>
    </div>
    <div class="row mb-3">
        <div class="col-md-8">
            <asp:Label ID="lblBuscar" runat="server" Text="Buscar por nombre, apellido o email" AssociatedControlID="txtBuscar" CssClass="form-label" />
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-4 d-flex align-items-end">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-outline-primary" Enabled="false" CausesValidation="false" />
        </div>
    </div>
    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
    <div class="table-responsive">
        <asp:GridView ID="dgvClientes" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" GridLines="None" ShowHeaderWhenEmpty="true" EmptyDataText="No hay clientes cargados">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content> 