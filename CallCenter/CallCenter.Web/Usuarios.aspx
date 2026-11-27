
<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="CallCenter.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   
    <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">

        <div>
            <h1 class="fw-bold mb-1">Usuarios</h1>
            <p class="text-muted mb-0">
                Consultá y administrá los usuarios del sistema.
            </p>
        </div>

        <div class="d-flex gap-2">
            <a runat="server" href="~/UsuarioFormulario.aspx" class="btn btn-primary">
                Nuevo usuario
            </a>

            <a runat="server" href="~/Default.aspx" class="btn btn-secondary">
                Volver al inicio
            </a>
        </div>

    </div>

    <asp:Label ID="lblError" runat="server"
        CssClass="alert alert-danger d-block"
        Visible="false" />

    <div class="card border-0 shadow-sm rounded-4 mb-4">
        <div class="card-body p-4">

            <h2 class="h5 fw-semibold mb-3">
                Buscar usuarios
            </h2>

            <div class="row g-3 align-items-end">

                <div class="col-12 col-lg-4">
                    <asp:Label runat="server"  AssociatedControlID="txtBuscar"  Text="Nombre o usuario" CssClass="form-label" />
                    
                    <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" Style="max-width: none;" placeholder="Ingresá tu búsqueda" />

                </div>

                <div class="col-12 col-sm-6 col-lg-3">
                    <asp:Label runat="server" AssociatedControlID="ddlFiltroRol" Text="Rol"  CssClass="form-label" />

                    <asp:DropDownList ID="ddlFiltroRol" runat="server" CssClass="form-select"  Style="max-width: none;" AppendDataBoundItems="true">

                        <asp:ListItem Text="Todos los roles" Value="" />

                    </asp:DropDownList>
                </div>

                <div class="col-12 col-sm-6 col-lg-3">
                    <asp:Label runat="server" AssociatedControlID="ddlEstado" Text="Estado" CssClass="form-label" />

                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select" Style="max-width: none;">

                        <asp:ListItem Text="Todos" Value="" />
                        <asp:ListItem Text="Activos" Value="1" />
                        <asp:ListItem Text="Inactivos" Value="0" />

                    </asp:DropDownList>
                </div>

                <div class="col-12 col-lg-2">
                    <asp:Button ID="btnBuscar"
                        runat="server"
                        Text="Buscar"
                        CssClass="btn btn-primary w-100"
                        Style="max-width: none;"
                        OnClick="btnBuscar_Click"
                        CausesValidation="false" />
                </div>

            </div>
        </div>
    </div>


    <div class="table-responsive bg-white border rounded-4 shadow-sm p-3">

        <asp:GridView ID="dgvUsuarios"
            runat="server"
            AutoGenerateColumns="false"
            CssClass="table table-striped table-hover align-middle mb-0"
            GridLines="None"
            ShowHeaderWhenEmpty="true"
            EmptyDataText="No hay usuarios cargados"
            OnRowCommand="dgvUsuarios_RowCommand">

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

                        <a href='UsuarioFormulario.aspx?id=<%# Eval("Id") %>'
                           class="btn btn-sm btn-outline-primary">
                            Editar
                        </a>

                        <asp:Button ID="btnEstado"
                            runat="server"
                            CommandName="CambiarEstado"
                            CommandArgument='<%# Eval("Id") %>'
                            Text='<%# (bool)Eval("Activo") ? "Desactivar" : "Reactivar" %>'
                            CssClass="btn btn-sm btn-outline-danger"
                            CausesValidation="false"
                            OnClientClick="return confirm('¿Confirmás el cambio de estado de este usuario?');" />

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

    </div>

</asp:Content>
