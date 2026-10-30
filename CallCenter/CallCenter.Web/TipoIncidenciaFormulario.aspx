<%@ Page Title="Tipo de incidencia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipoIncidenciaFormulario.aspx.cs" Inherits="CallCenter.Web.TipoIncidenciaFormulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Tipo de incidencia</h1>

    <div class="row">
        <div class="col-md-6">
            <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" CssClass="form-label" Text="Nombre" />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <asp:Label ID="lblDescripcion" runat="server" AssociatedControlID="txtDescripcion" CssClass="form-label" Text="Descripción" />
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" Checked="true" />
        </div>

         <div class="mb-3">
             <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" Enabled="false" />
             <a runat="server" href="~/TiposIncidencia.aspx" class="btn btn-secondary"> Cancelar </a>
         </div>
    </div>
</asp:Content>
