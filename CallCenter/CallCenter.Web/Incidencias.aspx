<%@ Page Title="Incidencias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Incidencias.aspx.cs" Inherits="CallCenter.Web.Incidencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">

    <div>
        <h1 class="fw-bold mb-1">Incidencias</h1>
        <p class="text-muted mb-0">
            Consultá y gestioná los reclamos registrados.
        </p>
    </div>

    <div class="d-flex gap-2">
        <a runat="server" href="~/IncidenciaFormulario.aspx" class="btn btn-primary">
            Nueva incidencia
        </a>

        <a runat="server" href="~/Default.aspx" class="btn btn-secondary">
            Volver al inicio
        </a>
    </div>

</div>

<div class="card border-0 shadow-sm rounded-4 mb-4">
    <div class="card-body p-4">

        <h2 class="h5 fw-semibold mb-3">
            Buscar incidencias
        </h2>

        <div class="row g-3 align-items-end">

            <div class="col-12 col-lg-4">
                <asp:Label ID="lblTipoBusqueda" runat="server" Text="Buscar por" AssociatedControlID="ddlTipoBusqueda" CssClass="form-label" />

                <asp:DropDownList ID="ddlTipoBusqueda" runat="server" CssClass="form-select" Style="max-width: none;">

                    <asp:ListItem Text="Número de reclamo" Value="numero" />
                    <asp:ListItem Text="Cliente" Value="cliente" />
                    <asp:ListItem Text="Tipo de incidencia" Value="tipo" />
                    <asp:ListItem Text="Prioridad" Value="prioridad" />
                    <asp:ListItem Text="Estado" Value="estado" />
                    <asp:ListItem Text="Descripción" Value="descripcion" />
                    <asp:ListItem Text="Último seguimiento" Value="seguimiento" />
                    <asp:ListItem Text="Usuario creador" Value="creador" />
                    <asp:ListItem Text="Usuario asignado" Value="asignado" />
                    <asp:ListItem Text="Último usuario" Value="ultimoUsuario" />
                    <asp:ListItem Text="Fecha de alta" Value="fechaAlta" />
                    <asp:ListItem Text="Última modificación" Value="fechaModificacion" />

                </asp:DropDownList>
            </div>

            <div class="col-12 col-lg-6">
                <asp:Label ID="lblValorBuscar" runat="server" Text="Valor a buscar" AssociatedControlID="txtValorBuscar"  CssClass="form-label" />

                <asp:TextBox ID="txtValorBuscar" runat="server" CssClass="form-control" Style="max-width: none;" placeholder="Ingresá tu búsqueda" />
            </div>

            <div class="col-12 col-lg-2">
                <asp:Button ID="btnBuscarNumero"
                    runat="server"
                    Text="Buscar"
                    CssClass="btn btn-primary w-100"
                    Style="max-width: none;"
                    OnClick="btnBuscarNumero_Click"
                    CausesValidation="false" />
            </div>

        </div>

    </div>
</div>

    <asp:Label ID="lblErrorBusqueda" runat="server" CssClass="text-danger" Visible="false" />
    
    <div class="table-responsive bg-white border rounded-4 shadow-sm p-3">


    <asp:GridView ID="dgvIncidencias" runat="server" AutoGenerateColumns="false" Style="min-width: 1350px;"
        CssClass="table table-striped table-hover align-middle mb-0" DataKeyNames="Id"  GridLines="None" EmptyDataText="No hay incidencias registradas">

        <Columns>

            <asp:TemplateField HeaderText="Número"> 
                <ItemTemplate>  <asp:HyperLink ID="lnkDetalle" runat="server" Text='<%# Eval("Numero") %>' NavigateUrl='<%# "IncidenciaDetalle.aspx?id=" + Eval("Id") %>' CssClass="fw-bold" /> </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Cliente"> 
                <ItemTemplate> <%#: Eval("cliente.Id") %>  <%# Eval("cliente.Nombre") %> <%# Eval("cliente.Apellido") %></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tipo">
                <ItemTemplate> <%# Eval("Tipo.Nombre") %> </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Prioridad">
                <ItemTemplate> <%# Eval("prioridad.Nombre") %> </ItemTemplate>
            </asp:TemplateField>

               <asp:TemplateField HeaderText="Descripción">
                   <ItemTemplate> <div class="text-truncate" style="max-width: 240px;"> <%#: Eval("Descripcion") %> </div> </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Seguimientos">
                <ItemTemplate><div class="text-truncate" style="max-width: 240px;"> <%#: string.IsNullOrWhiteSpace(Eval("UltimoSeguimiento") as string) ? "Sin seguimientos" : (string)Eval("UltimoSeguimiento") %> </div></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate> <%# Eval("Estado.Nombre") %> </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="FechaAlta"  HeaderText="Fecha de alta" DataFormatString="{0:dd/MM/yyyy HH:mm}" HtmlEncode="false" />

            <asp:TemplateField HeaderText="Usuario creador">
                <ItemTemplate>  <%# Eval("UsuarioCreador") == null? "Pendiente" : Eval("UsuarioCreador.Nombre") %> </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Usuario asignado">
                <ItemTemplate> <%# Eval("UsuarioAsignado") == null  ? "Pendiente" : Eval("UsuarioAsignado.Nombre") %></ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="FechaUltimaModificacion"  HeaderText="Última modificación"  DataFormatString="{0:dd/MM/yyyy HH:mm}"  HtmlEncode="false" NullDisplayText="Sin modificaciones" />

            <asp:TemplateField HeaderText="Último usuario">
                <ItemTemplate>  <%# Eval("UsuarioUltimaModificacion") == null ? "-" : Eval("UsuarioUltimaModificacion.Nombre") %></ItemTemplate>
            </asp:TemplateField>

            
            
        

            
        </Columns>

    </asp:GridView>

</div>

</asp:Content>