<%@ Page Title="Prioridad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrioridadFormulario.aspx.cs" Inherits="CallCenter.Web.PrioridadFormulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <h1>Prioridad</h1>
    <div class="row">
        <div class="col-md-6">

             <div class="mb-3">
                 <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" CssClass="form-label" Text="Nombre" />
                 <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50"/>
             </div>

            <div class="mb-3">
                <asp:Label ID="lblNivel" runat="server" AssociatedControlID="txtNivel" CssClass="form-label" Text="Nivel" />
                <asp:TextBox ID="txtNivel" runat="server" CssClass="form-control" TextMode="Number"/>
            </div>

            <div class="mb-3">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" Enabled="false" />
                <a runat="server" href="~/Prioridades.aspx" class="btn btn-secondary"> Cancelar </a>
            </div>
        </div>
    </div>
</asp:Content>
