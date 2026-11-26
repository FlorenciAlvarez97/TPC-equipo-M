<%@ Page Title="Incidencias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Incidencias.aspx.cs" Inherits="CallCenter.Web.Incidencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Incidencias</h1>
    <p> </p>

    <div class="mb-3">
        <a runat="server" href="~/IncidenciaFormulario.aspx" class="btn btn-primary">Nueva incidencia</a>
      <%--  <a runat="server" href="~/IncidenciaDetalle.aspx" class="btn btn-outline-primary">Ver detalle</a> --%>
        <a runat="server" href="~/Default.aspx" class="btn btn-secondary">Volver al inicio</a>
    </div>



<div class="mb-4">

    <div class="d-flex gap-3 align-items-end flex-wrap">
        <div>
            <asp:Label ID="lblTipoBusqueda" runat="server" AssociatedControlID="ddlTipoBusqueda"  CssClass="form-label" Text="Buscar por" />
            <asp:DropDownList ID="ddlTipoBusqueda" runat="server" CssClass="form-select">
                <asp:ListItem Text="Número de reclamo" Value="numero" />
                <asp:ListItem Text="Cliente" Value="cliente" />
                <asp:ListItem Text="Tipo de incidencia" Value="tipo" />
                <asp:ListItem Text="Prioridad" Value="prioridad" />
                <asp:ListItem Text="Estado" Value="estado" />
                <asp:ListItem Text="Usuario creador" Value="creador" />
                <asp:ListItem Text="Usuario asignado" Value="asignado" />
                <asp:ListItem Text="Último usuario" Value="ultimoUsuario" />
                <asp:ListItem Text="Fecha de alta" Value="fechaAlta" />
                <asp:ListItem Text="Última modificación" Value="fechaModificacion" />


            </asp:DropDownList>
        </div>

        <div>
            <asp:Label ID="lblValorBuscar" runat="server" AssociatedControlID="txtValorBuscar" CssClass="form-label" Text="Valor a buscar" />
            <asp:TextBox ID="txtValorBuscar" runat="server" CssClass="form-control" placeholder="Ingresá tu búsqueda" />
        </div>

        <asp:Button ID="btnBuscarNumero" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscarNumero_Click" />
    </div>

    <asp:Label ID="Label1" runat="server" CssClass="text-danger" Visible="false" />
</div>

    <asp:Label ID="lblErrorBusqueda" runat="server" CssClass="text-danger" Visible="false" />

<div class="table-responsive">

    <asp:GridView ID="dgvIncidencias" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered table-hover" DataKeyNames="Id"  GridLines="None" EmptyDataText="No hay incidencias registradas">

        <Columns>

            <asp:TemplateField HeaderText="Número"> 
                <ItemTemplate>  <asp:HyperLink ID="lnkDetalle" runat="server" Text='<%# Eval("Numero") %>' NavigateUrl='<%# "IncidenciaDetalle.aspx?id=" + Eval("Id") %>' CssClass="fw-bold" /> </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="FechaAlta"  HeaderText="Fecha de alta" DataFormatString="{0:dd/MM/yyyy HH:mm}" HtmlEncode="false" />
            
            <asp:BoundField DataField="FechaUltimaModificacion"  HeaderText="Última modificación"  DataFormatString="{0:dd/MM/yyyy HH:mm}"  HtmlEncode="false" NullDisplayText="Sin modificaciones" />
            
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

            <asp:TemplateField HeaderText="Usuario creador">
                <ItemTemplate>  <%# Eval("UsuarioCreador") == null? "Pendiente" : Eval("UsuarioCreador.Nombre") %> </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Usuario asignado">
                <ItemTemplate> <%# Eval("UsuarioAsignado") == null  ? "Pendiente" : Eval("UsuarioAsignado.Nombre") %></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Último usuario">
                <ItemTemplate>  <%# Eval("UsuarioUltimaModificacion") == null ? "-" : Eval("UsuarioUltimaModificacion.Nombre") %></ItemTemplate>
            </asp:TemplateField>

        

            
        </Columns>

    </asp:GridView>

</div>

</asp:Content>