<%@ Page Title="Prioridades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prioridades.aspx.cs" Inherits="CallCenter.Web.Prioridades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Prioridades</h1>
    <div class="mb-3"> <a runat="server" href="~/PrioridadFormulario.aspx" class="btn btn-primary"> Nueva prioridad </a> </div>
    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />

    <div class="table-responsive">
        <asp:GridView ID="dgvPrioridades"
            runat="server"
            AutoGenerateColumns="false"
            CssClass="table table-striped table-bordered"
            GridLines="None"
            ShowHeaderWhenEmpty="true"
            EmptyDataText="No hay prioridades en la base de datos">

            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Nivel" HeaderText="Nivel" />
            </Columns>
         </asp:GridView>
    </div>

    <a runat= "server" href ="~/Default.aspx" class= "btn btn-primary"> volver al inicio</a>
</asp:Content>
