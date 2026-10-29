<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="CallCenter.Web.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Clientes</h1>
     <p> </p>
     <div class= "mb-3">
         <a runat="server" href="~/ClienteFormulario.aspx" class="btn btn-primary">
             Nuevo cliente</a> 
         <a runat= "server" href ="~/Default.aspx" class= "btn btn-secondary">
             volver al inicio</a>
    </div>

    <div class="col-md-8">

        <asp:Label ID="lblBuscar" runat="server"
            Text="Buscar por nombre, apellido o email"
            AssociatedControlId="txtBuscar"
            CssClass="form-label" />

        <asp:TextBox Id="txtBuscar" runat="server"
            CssClass="form-control" />

    </div>

    <div class="col-md-4 mt-2">

        <asp:Button ID="btnBuscar" runat="server"
            Text="Buscar"
            CssClass="btn btn-outline-primary"
            Enabled="false"
            CausesValidation="false" />
    </div>

    <div class="table-responsive">

        <table class="table table-striped table-bordered">

            <thead>
                <tr>
                    <th scope="col">Nombre</th>
                    <th scope="col">Apellido</th>
                    <th scope="col">Email</th>
                    <th scope="col">Telefóno</th>
                    <th scope="col">Activo</th>
                    <th scope="col">Acciones</th>
                </tr>
            </thead>
        </table>
    </div>

</asp:Content>
