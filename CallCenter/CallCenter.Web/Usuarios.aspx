<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="CallCenter.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Usuarios</h1>
    <p></p>
    <div class="mb-3">
        <a runat="server" href="~/UsuarioFormulario.aspx" class="btn btn-primary">Nuevo usuario</a>
        <a runat="server" href="~/Default.aspx" class="btn btn-secondary">Volver al inicio</a>
    </div>
    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
    <div class="table-responsive">
        <asp:GridView ID="dgvUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" GridLines="None" ShowHeaderWhenEmpty="true" EmptyDataText="No hay usuarios cargados">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                <asp:TemplateField HeaderText="Rol">
                    <ItemTemplate>
                        <%# Eval("Rol.Nombre") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <a href='UsuarioFormulario.aspx?id=<%# Eval("Id") %>' class="btn btn-sm btn-outline-primary">Editar</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
