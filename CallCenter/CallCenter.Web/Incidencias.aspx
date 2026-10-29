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
        <table class="table table-striped table-bordered">
            <thead>
                <tr>
                    <th scope="col">Número</th>
                    <th scope="col">Fecha de alta</th>
                    <th scope="col">Cliente</th>
                    <th scope="col">Tipo</th>
                    <th scope="col">Prioridad</th>
                    <th scope="col">Estado</th>
                    <th scope="col">Acciones</th>
                </tr>
            </thead>
        </table>
    </div>
</asp:Content>