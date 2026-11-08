<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="CallCenter.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Usuarios</h1>
    <p></p>
    <div class="mb-3">
        <a runat="server" href="~/UsuarioFormulario.aspx" class="btn btn-primary">Nuevo usuario</a>
        <a runat="server" href="~/Default.aspx" class="btn btn-secondary">Volver al inicio</a>
    </div>
    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
    <div class="row g-2 mb-3">
        <div class="col-md-4">
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Buscar por nombre o usuario" />
        </div>
        <div class="col-md-3">
            <asp:DropDownList ID="ddlFiltroRol" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                <asp:ListItem Text="Todos los roles" Value="" />
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
                <asp:ListItem Text="Todos" Value="" />
                <asp:ListItem Text="Activos" Value="1" />
                <asp:ListItem Text="Inactivos" Value="0" />
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary w-100" OnClick="btnBuscar_Click" />
        </div>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="dgvUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" GridLines="None" ShowHeaderWhenEmpty="true" EmptyDataText="No hay usuarios cargados" OnRowCommand="dgvUsuarios_RowCommand">
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
                        <asp:Button ID="btnEstado" runat="server" CommandName="CambiarEstado" CommandArgument='<%# Eval("Id") %>' Text='<%# (bool)Eval("Activo") ? "Desactivar" : "Reactivar" %>' CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('¿Confirmás el cambio de estado de este usuario?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>