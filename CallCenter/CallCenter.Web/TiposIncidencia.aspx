
<%@ Page Title="Tipos de incidencia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TiposIncidencia.aspx.cs" Inherits="CallCenter.Web.TiposIncidencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%-- ENCABEZADO --%>
    <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">

        <div>
            <h1 class="fw-bold mb-1">Tipos de incidencia</h1>
            <p class="text-muted mb-0">
                Consultá y administrá los tipos de incidencia.
            </p>
        </div>

        <div class="d-flex gap-2">
            <a runat="server" href="~/TipoIncidenciaFormulario.aspx" class="btn btn-primary">
                Nuevo tipo
            </a>

            <a runat="server" href="~/Default.aspx" class="btn btn-secondary">
                Volver al inicio
            </a>
        </div>

    </div>

    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block"  Visible="false" />

    <%-- BUSCADOR --%>
    <div class="card border-0 shadow-sm rounded-4 mb-4">
        <div class="card-body p-4">

            <h2 class="h5 fw-semibold mb-3">
                Buscar tipos de incidencia
            </h2>

            <div class="row g-3 align-items-end">

                <div class="col-12 col-lg-6">
                    <asp:Label runat="server" AssociatedControlID="txtBuscarTipo" Text="Nombre o descripción" CssClass="form-label" />
                    <asp:TextBox ID="txtBuscarTipo" runat="server" CssClass="form-control" Style="max-width: none;" placeholder="Ingresá tu búsqueda" />
                </div>

                <div class="col-12 col-sm-6 col-lg-3">
                    <asp:Label runat="server" AssociatedControlID="ddlEstadoTipo" Text="Estado" CssClass="form-label" />
                    <asp:DropDownList ID="ddlEstadoTipo"  runat="server"  CssClass="form-select" Style="max-width: none;">

                        <asp:ListItem Text="Todos" Value="" />
                        <asp:ListItem Text="Activos" Value="1" />
                        <asp:ListItem Text="Inactivos" Value="0" />

                    </asp:DropDownList>
                </div>

                <div class="col-12 col-sm-6 col-lg-3">
                    <asp:Button ID="btnBuscarTipos"
                        runat="server"
                        Text="Buscar"
                        CssClass="btn btn-primary w-100"
                        Style="max-width: none;"
                        CausesValidation="false"
                        OnClick="btnBuscarTipos_Click" />
                </div>

            </div>
        </div>
    </div>

    <%-- TABLA --%>
    <div class="table-responsive bg-white border rounded-4 shadow-sm p-3">

        <asp:GridView ID="dgvTiposIncidencia"
            runat="server"
            AutoGenerateColumns="false"
            DataKeyNames="Id"
            OnSelectedIndexChanged="dgvTiposIncidencia_SelectedIndexChanged"
            OnRowCommand="dgvTiposIncidencia_RowCommand"
            CssClass="table table-striped table-hover align-middle mb-0"
            GridLines="None"
            ShowHeaderWhenEmpty="true"
            EmptyDataText="No hay tipos de incidencia en la base de datos">

            <Columns>

                <asp:BoundField DataField="Id" HeaderText="ID" />

                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />

                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <%# (bool)Eval("Activo") ? "Activo" : "Inactivo" %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField
                    HeaderText="Acciones"
                    ShowSelectButton="true"
                    SelectText="Editar"
                    ButtonType="Link"
                    CausesValidation="false">

                    <ControlStyle CssClass="btn btn-outline-primary btn-sm" />

                </asp:CommandField>

                <asp:TemplateField HeaderText="Cambiar estado">
                    <ItemTemplate>

                        <asp:Button ID="btnCambiarEstado"
                            runat="server"
                            Text='<%# (bool)Eval("Activo") ? "Desactivar" : "Reactivar" %>'
                            CommandName="CambiarEstado"
                            CommandArgument='<%# Eval("Id") %>'
                            CssClass="btn btn-outline-secondary btn-sm"
                            CausesValidation="false"
                            OnClientClick="return confirm('¿Seguro que querés cambiar el estado de este tipo de incidencia?');" />

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

    </div>

</asp:Content>
