<%@ Page Title="Detalle de incidencia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenciaDetalle.aspx.cs" Inherits="CallCenter.Web.IncidenciaDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Detalle de incidencia</h1>
    <p> </p>

    <div class="row">
        <div class="col-md-6">

            <div class="mb-3">
                <label class="form-label">Número</label>
                <input type="text" class="form-control" value="-" disabled />
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de alta</label>
                <input type="text" class="form-control" value="-" disabled />
            </div>
            <div class="mb-3">
                <label class="form-label">Cliente</label>
                <input type="text" class="form-control" value="-" disabled />
            </div>
            <div class="mb-3">
                <label class="form-label">Tipo</label>
                <input type="text" class="form-control" value="-" disabled />
            </div>
            <div class="mb-3">
                <label class="form-label">Prioridad</label>
                <input type="text" class="form-control" value="-" disabled />
            </div>
            <div class="mb-3">
                <label class="form-label">Estado</label>
                <input type="text" class="form-control" value="-" disabled />
            </div>
            <div class="mb-3">
                <label class="form-label">Descripción</label>
                <textarea class="form-control" rows="5" disabled></textarea>
            </div>

            <h2 class="h4">Gestión de la incidencia</h2>

            <div class="mb-3">
                <asp:Label ID="lblUsuarioAsignado" runat="server" AssociatedControlID="txtUsuarioAsignado" CssClass="form-label" Text="Usuario asignado actualmente" />
                <asp:TextBox ID="txtUsuarioAsignado" runat="server" CssClass="form-control" Text="-" ReadOnly="true" />
            </div>

            <h3 class="h5">Reasignar incidencia</h3>

            <div class="mb-3"> 
                <asp:Label ID="lblNuevoResponsable" runat="server" AssociatedControlID="ddlNuevoResponsable" CssClass="form-label" Text="Nuevo usuario responsable" />
                <asp:DropDownList ID="ddlNuevoResponsable" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Seleccioná un usuario" Value="" Selected="True" />
                    <asp:ListItem Text="Telefonista A" Value="demo-a" />
                    <asp:ListItem Text="Telefonista B" Value="demo-b" />
                </asp:DropDownList>
            </div>

            <div class="mb-4">
                <asp:Button ID="btnReasignar" runat="server" Text="Reasignar" CssClass="btn btn-primary" Enabled="false" />
            </div>

            <h3 class="h5">Resolver incidencia</h3>

            <div class="mb-3">
                <asp:Label ID="lblResolucion" runat="server" AssociatedControlID="txtResolucion" CssClass="form-label" Text="Información final de resolución" />
                <asp:TextBox ID="txtResolucion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                
                <p class="form-text"> Describí la respuesta o solución brindada al cliente</p>
            </div>
            
            <div class="mb-4">
                <asp:Button ID="btnResolver" runat="server" Text="Resolver" CssClass="btn btn-success" Enabled="false" />
            </div>
            
            <h3 class="h5">Cerrar incidencia</h3>

            <div class="mb-3">
                <asp:Label ID="lblComentarioCierre" runat="server" AssociatedControlID="txtComentarioCierre" CssClass="form-label" Text="Comentario final de cierre (obligatorio)" />
                <asp:TextBox ID="txtComentarioCierre" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                
                <p class="form-text"> Indicá el motivo del cierre </p>
            </div>
            
            <div class="mb-4">
                <asp:Button ID="btnCerrarIncidencia" runat="server" Text="Cerrar incidencia" CssClass="btn btn-danger" Enabled="false" /> 
            </div>

            <div class="mb-3">
                <a runat="server" href="~/Incidencias.aspx" class="btn btn-secondary">Volver a incidencias</a>
            </div>
        </div>
    </div>
</asp:Content> 