
<%@ Page Title="Prioridades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prioridades.aspx.cs" Inherits="CallCenter.Web.Prioridades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%-- ENCABEZADO --%>
    <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">

        <div>
            <h1 class="fw-bold mb-1">Prioridades</h1>
            <p class="text-muted mb-0">
                Consultá y administrá los niveles de prioridad.
            </p>
        </div>

        <div class="d-flex gap-2">
            <a runat="server" href="~/PrioridadFormulario.aspx" class="btn btn-primary">
                Nueva prioridad
            </a>

            <a runat="server" href="~/Default.aspx" class="btn btn-secondary">
                Volver al inicio
            </a>
        </div>
    </div>

    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />

    <div class="card border-0 shadow-sm rounded-4 mb-4">
        <div class="card-body p-4">

            <h2 class="h5 fw-semibold mb-3">
                Buscar prioridades
            </h2>

            <div class="row g-3 align-items-end">

                <div class="col-12 col-lg-6">
                    <asp:Label runat="server" AssociatedControlID="txtBuscarPrioridad" Text="Nombre o nivel" CssClass="form-label" />
                    <asp:TextBox ID="txtBuscarPrioridad" runat="server" CssClass="form-control" Style="max-width: none;" placeholder="Ingresá tu búsqueda" />
                </div>

                <div class="col-12 col-sm-6 col-lg-3">
                    <asp:Label runat="server" AssociatedControlID="ddlEstadoPrioridad" Text="Estado" CssClass="form-label" />
                    <asp:DropDownList ID="ddlEstadoPrioridad" runat="server" CssClass="form-select" Style="max-width: none;">

                        <asp:ListItem Text="Todos" Value="" />
                        <asp:ListItem Text="Activos" Value="1" />
                        <asp:ListItem Text="Inactivos" Value="0" />

                    </asp:DropDownList>
                </div>

                <div class="col-12 col-sm-6 col-lg-3">
                    <asp:Button ID="btnBuscarPrioridades"
                        runat="server"
                        Text="Buscar"
                        CssClass="btn btn-primary w-100"
                        Style="max-width: none;"
                        CausesValidation="false"
                        OnClick="btnBuscarPrioridades_Click" />
                </div>

            </div>
        </div>
    </div>

    <%-- TABLA --%>
    <div class="table-responsive bg-white border rounded-4 shadow-sm p-3">

        <asp:GridView ID="dgvPrioridades"
            runat="server"
            AutoGenerateColumns="false"
            DataKeyNames="Id"
            OnSelectedIndexChanged="dgvPrioridades_SelectedIndexChanged"
            OnRowCommand="dgvPrioridades_RowCommand"
            CssClass="table table-striped table-hover align-middle mb-0"
            GridLines="None"
            ShowHeaderWhenEmpty="true"
            EmptyDataText="No hay prioridades en la base de datos">

            <Columns>

                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Nivel" HeaderText="Nivel" />

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
                            CommandName='<%# (bool)Eval("Activo") ? "Desactivar" : "Reactivar" %>'
                            CommandArgument='<%# Eval("Id") %>'
                            CssClass="btn btn-outline-secondary btn-sm"
                            CausesValidation="false"
                            OnClientClick="return confirm('¿Estás seguro de cambiar el estado de esta prioridad?');" />

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </div>

</asp:Content>
