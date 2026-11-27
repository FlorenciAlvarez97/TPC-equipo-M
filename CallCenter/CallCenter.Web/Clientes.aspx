<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="CallCenter.Web.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">

    <div>
        <h1 class="fw-bold mb-1">Clientes</h1>
        <p class="text-muted mb-0">
            Consultá y gestioná la información de tus clientes.
        </p>
    </div>
    <div class="d-flex gap-2">
        <a runat="server" href="~/ClienteFormulario.aspx" class="btn btn-primary">
            Nuevo cliente
        </a>

        <a runat="server" href="~/Default.aspx" class="btn btn-secondary">
            Volver al inicio
        </a>
    </div>
</div>

<div class="card border-0 shadow-sm rounded-4 mb-4">
    <div class="card-body p-4">
        <h2 class="h5 fw-semibold mb-3">Buscar clientes</h2>
        <div class="row g-3 align-items-end">

            <div class="col-12 col-lg-6">
                <asp:Label 	ID="lblBuscar" runat="server" Text="Nombre, apellido o email" AssociatedControlID="txtBuscar" CssClass="form-label" />
                <asp:TextBox ID="txtBuscar" runat="server"  CssClass="form-control" Style="max-width: none;" placeholder="Ingresá tu búsqueda" />
            </div>

            <div class="col-12 col-sm-6 col-lg-3">
                <asp:Label 	ID="lblEstado" runat="server" Text="Estado" AssociatedControlID="ddlEstado" CssClass="form-label" />
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select" Style="max-width: none;">

                    <asp:ListItem Text="Todos" Value="" Selected="True" />
                    <asp:ListItem Text="Activos" Value="1" />
                    <asp:ListItem Text="Inactivos" Value="0" />

                </asp:DropDownList>
            </div>

            <div class="col-12 col-sm-6 col-lg-3">
                <asp:Button ID="btnBuscar" runat="server"
                    Text="Buscar"
                    CssClass="btn btn-primary w-100"
                    Style="max-width: none;"
                    OnClick="btnBuscar_Click"
                    CausesValidation="false" />
            </div>
        </div>
    </div>
</div>

    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
    <div class="table-responsive bg-white border rounded-4 shadow-sm p-3">
        <asp:GridView ID="dgvClientes" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover align-middle mb-0" GridLines="None" ShowHeaderWhenEmpty="true" EmptyDataText="No hay clientes cargados" OnRowCommand="dgvClientes_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <a href='<%# ResolveUrl("~/ClienteFormulario.aspx?id=" + Eval("Id")) %>' class="btn btn-sm btn-outline-primary">Editar</a>
                        <asp:Button ID="btnEstado" runat="server" CssClass="btn btn-sm btn-outline-secondary" CommandName="CambiarEstado" CommandArgument='<%# Eval("Id") %>' Text='<%# (bool)Eval("Activo") ? "Desactivar" : "Reactivar" %>' OnClientClick="return confirm('¿Seguro que querés cambiar el estado de este cliente?');" CausesValidation="false" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
