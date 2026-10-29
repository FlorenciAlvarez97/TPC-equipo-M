<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="CallCenter.Web.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Clientes</h1>
     <div class=" "mb-3> <a runat="server" href="~/ClienteFormulario.aspx" class="btn btn-primary">Nuevo cliente</a> </div>
    <p> </p>
    <a runat= "server" href ="~/Default.aspx" class= "btn btn-primary">
        volver al inicio
    </a>
</asp:Content>
