<%@ Page Title="Nueva incidencia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenciaFormulario.aspx.cs" Inherits="CallCenter.Web.IncidenciaFormulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Nueva incidencia</h1>

    <div class="row">

        <div class="col-md-6 mb-3">

            <asp:DropDownList ID="ddlCliente" runat="server"
                CssClass="form-select">
                <asp:ListItem Value="" Text="Pendiente: cargar clientes" />
            </asp:DropDownList>
        </div>


        <div class="col-md-6 mc-3">

            <asp:Label ID="lblTipo" runat="server"
                Text="Tipo de incidencia"
                AssociatedControlID="ddlTipo"
                CssClass="form.label" />

            <asp:DropDownList ID="ddlTipo" runat="server"
                CssClass="form-select">
                <asp:ListItem Value="" Text="Pendiente: cargar tipo de incidencia" />
            </asp:DropDownList>
        </div>

        <div class="col-md-6 mc-3">

            <asp:Label ID="lblPrioridad" runat="server"
                Text="Prioridad"
                AssociatedControlID="ddlPrioridad"
                CssClass="form.label" />

            <asp:DropDownList ID="ddlPrioridad" runat="server"
                CssClass="form-select">
                <asp:ListItem Value="" Text="Pendiente: cargar prioridades" />
            </asp:DropDownList>
        </div>

        <div class="col-md-12 mc-3">

            <asp:Label ID="Descripcion" runat="server"
                Text="Descripción de la incidencia"
                AssociatedControlID="txtDescripcion"
                CssClass="form.label" />

            <asp:TextBox ID="txtDescripcion" runat="server"
                TextMode="MultiLine"
                Rows="5"
                CssClass="form-control" />

        </div>
</div>
    <div class="mb-3">
        <a runat="server" href="~/IncidenciaFormulario.aspx" class="btn btn-primary"> Nueva Incidencia</a>
        <a runat="server" href="~/Default.aspx" class="btn btn-secondary"> Volver al inicio</a> 

    </div>


</asp:Content>
