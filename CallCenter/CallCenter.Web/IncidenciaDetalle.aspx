<%@ Page Title="Detalle de incidencia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenciaDetalle.aspx.cs" Inherits="CallCenter.Web.IncidenciaDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Detalle de incidencia</h1>
    <p></p>

    <div class="row">
        <div class="col-md-6">

            <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
            <div class="mb-3">
                <label class="form-label">Número</label>
                <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de alta</label>
                <asp:TextBox ID="txtFechaAlta" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="mb-3">
                <label class="form-label">Cliente</label>
                <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="mb-3">
                <label class="form-label">Tipo</label>
                <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="mb-3">
                <label class="form-label">Prioridad</label>
                <asp:TextBox ID="txtPrioridad" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="mb-3">
                <label class="form-label">Estado</label>
                <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="mb-3">
                <label class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" ReadOnly="true" />
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
                   
                </asp:DropDownList>
            </div>

            <div class="mb-4">
               <asp:Button ID="btnReasignar" runat="server" Text="Reasignar" CssClass="btn btn-primary" OnClick="btnReasignar_Click" />
            </div>

            <h3 class="h5">Resolver incidencia</h3>
            <div class="mb-3">
                <asp:Label ID="lblResolucion" runat="server" AssociatedControlID="txtResolucion" CssClass="form-label" Text="Resolución (obligatoria)" />
                <asp:TextBox ID="txtResolucion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                <p class="form-text">Describí cómo se resolvió la incidencia</p>
            </div>
            <div class="mb-4">
                <asp:Button ID="btnResolver" runat="server" Text="Resolver" CssClass="btn btn-success" Enabled="false" />
            </div>

            <h3 class="h5">Cerrar incidencia</h3>

            <div class="mb-3">
                <asp:Label ID="lblComentarioCierre" runat="server" AssociatedControlID="txtComentarioCierre" CssClass="form-label" Text="Comentario final de cierre (obligatorio)" />
                <asp:TextBox ID="txtComentarioCierre" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                <p class="form-text">Indicá el motivo del cierre </p>
            </div>

            <div class="mb-4">
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar incidencia" CssClass="btn btn-danger" Enabled="false" />
            </div>
            <div class="mb-3">
                <a runat="server" href="~/Incidencias.aspx" class="btn btn-secondary">Volver a incidencias</a>
            </div>
        </div>
    </div>
</asp:Content>
