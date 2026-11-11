<%@ Page Title="Tipos de incidencia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TiposIncidencia.aspx.cs" Inherits="CallCenter.Web.TiposIncidencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Tipos de incidencia</h1>
    
    <div class="mb-3">
        <a runat="server" href="~/TipoIncidenciaFormulario.aspx" class="btn btn-primary">Nuevo tipo</a>
    </div>

    <div class="mb-3">
        <a runat="server" href="~/Default.aspx" class="btn btn-secondary">Volver al inicio</a>
    </div>

     <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />

    
    <div class="table-responsive">
        <asp:GridView ID="dgvTiposIncidencia"
            runat="server"
            AutoGenerateColumns="false"
            DataKeyNames="Id"
            CssClass="table table-striped table-bordered"
            GridLines="None"
            ShowHeaderWhenEmpty="true"
            EmptyDataText="No hay tipos de incidenica en la base de datos">

            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />

                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <%#(bool)Eval("Activo") ? "Activo" : "Incativo" %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
     </div>

</asp:Content>