<%@ Page Title="Incidencias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Incidencias.aspx.cs" Inherits="CallCenter.Web.Incidencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Incidencias</h1>
    <p> </p>

    <div class="mb-3">
        <a runat="server" href="~/IncidenciaFormulario.aspx" class="btn btn-primary">Nueva incidencia</a>
      <%--  <a runat="server" href="~/IncidenciaDetalle.aspx" class="btn btn-outline-primary">Ver detalle</a> --%>
        <a runat="server" href="~/Default.aspx" class="btn btn-secondary">Volver al inicio</a>
    </div>

    
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

            <asp:TemplateField HeaderText="Actividad">
                <ItemTemplate>  <%# Eval("FechaUltimaModificacion") == null  ? "Solo alta" : "Con modificaciones" %> </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Seguimientos">
                <ItemTemplate> <span class="text-muted"> Por implementar</span> </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

</div>

</asp:Content>