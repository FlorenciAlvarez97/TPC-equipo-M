<%@ Page Title="Nueva incidencia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenciaFormulario.aspx.cs" Inherits="CallCenter.Web.IncidenciaFormulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Nueva incidencia</h1>

    <div class="row">

        <div class="col-md-6 mb-3">
            <asp:Label ID="lblCliente" runat="server"
                Text="Cliente"
                AssociatedControlID="ddlCliente"
                CssClass="form-label" />
            <asp:DropDownList ID="ddlCliente" runat="server"
                CssClass="form-select">
                <asp:ListItem Value="" Text="Pendiente: cargar clientes" />
            </asp:DropDownList>
        </div>


        <div class="col-md-6 mb-3">

            <asp:Label ID="lblTipo" runat="server"
                Text="Tipo de incidencia"
                AssociatedControlID="ddlTipo"
                CssClass="form-label" />

            <asp:DropDownList ID="ddlTipo" runat="server"
                CssClass="form-select">
                <asp:ListItem Value="" Text="Pendiente: cargar tipo de incidencia" />
            </asp:DropDownList>
        </div>

        <div class="col-md-6 mb-3">

            <asp:Label ID="lblPrioridad" runat="server"
                Text="Prioridad"
                AssociatedControlID="ddlPrioridad"
                CssClass="form-label" />

            <asp:DropDownList ID="ddlPrioridad" runat="server"
                CssClass="form-select">
                <asp:ListItem Value="" Text="Pendiente: cargar prioridades" />
            </asp:DropDownList>
        </div>

        <div class="col-md-12 mb-3">

            <asp:Label ID="Descripcion" runat="server"
                Text="Descripción de la incidencia"
                AssociatedControlID="txtDescripcion"
                CssClass="form-label" />

            <asp:TextBox ID="txtDescripcion" runat="server"
                TextMode="MultiLine"
                Rows="5"
                CssClass="form-control" />

        </div>
</div>
    <div class="mb-3">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" Enabled="false" />
        <a runat="server" href="~/Incidencias.aspx" class="btn btn-secondary">Cancelar</a>

    </div>


</asp:Content> 
