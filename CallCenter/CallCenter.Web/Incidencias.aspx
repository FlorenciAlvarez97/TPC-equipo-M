<%@ Page Title="Incidencias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Incidencias.aspx.cs" Inherits="CallCenter.Web.Incidencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Incidencias</h1>
    <p> </p>

    <div class="mb-3">
        <a runat="server" href="~/IncidenciaFormulario.aspx" class="btn btn-primary">Nueva incidencia</a>
        <a runat="server" href="~/IncidenciaDetalle.aspx" class="btn btn-outline-primary">Ver detalle</a>
        <a runat="server" href="~/Default.aspx" class="btn btn-secondary">Volver al inicio</a>
    </div>

    
<div class="table-responsive">

    <asp:GridView ID="dgvIncidencias" runat="server"
        AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered"
        DataKeyNames="Id"
        GridLines="None"
        EmptyDataText="No hay incidencias registradas.">

        <Columns>

            <asp:BoundField DataField="Numero" HeaderText="Número" />
            <asp:BoundField DataField="FechaAlta"  HeaderText="Fecha de alta" DataFormatString="{0:dd/MM/yyyy HH:mm}" HtmlEncode="false" />
            <asp:TemplateField HeaderText="Cliente"> 
                <ItemTemplate>  <%# Eval("cliente.Nombre") %> <%# Eval("cliente.Apellido") %></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tipo">
                <ItemTemplate> <%# Eval("Tipo.Nombre") %> </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Prioridad">
                <ItemTemplate> <%# Eval("prioridad.Nombre") %> </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate> <%# Eval("Estado.Nombre") %> </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</div>

</asp:Content>