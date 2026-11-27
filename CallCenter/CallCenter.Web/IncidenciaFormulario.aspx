<%@ Page Title="Nueva incidencia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenciaFormulario.aspx.cs" Inherits="CallCenter.Web.IncidenciaFormulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="max-width: 1100px; margin: 0 auto;">
        <div class="mb-4">
            <h1 class="fw-bold mb-1">Nueva incidencia</h1>
            <p class="text-muted mb-0"> Registrá un nuevo reclamo o consulta del cliente. </p>
        </div>
        <asp:Panel ID="pnlAviso" runat="server" CssClass="alert alert-success alert-dismissible fade show shadow" Style="position: fixed; top: 85px; right: 20px; z-index: 1080; max-width: 430px; width: calc(100% - 40px);" Visible="false" role="alert">
            
            <asp:Label ID="lblAviso" runat="server" />
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Cerrar"> </button>
        </asp:Panel>
        
        <div class="card border-0 shadow-sm rounded-4">
            <div class="card-body p-4 p-md-5">
                <div class="row g-4">
        
        <div class="col-md-6 mb-3">
            <asp:Label ID="lblNumeroCliente" runat="server" Text="Número de cliente" AssociatedControlID="txtNumeroCliente" CssClass="form-label" />
            <asp:TextBox ID="txtNumeroCliente" runat="server" CssClass="form-control" TextMode="Number" />
            <asp:Button ID="btnBuscarCliente" runat="server" Text="Buscar cliente" CssClass="btn btn-primary mt-2" OnClick="btnBuscarCliente_Click" />
        </div>

         
<asp:Panel ID="pnlUsuarioDemo" runat="server"
    CssClass="col-md-6 mb-3"
    Visible="false">

    <asp:Label ID="lblUsuarioDemo" runat="server"
        Text="Usuario creador (solo demostración)"
        AssociatedControlID="ddlUsuarioDemo"
        CssClass="form-label" />

    <asp:DropDownList ID="ddlUsuarioDemo" runat="server"
        CssClass="form-select" />

</asp:Panel>

        <div class="col-12 col-md-6">
            <label class="form-label">Cliente</label>
            <div class="form-control bg-light" style="max-width: none; min-height: 38px;">
                <asp:Label ID="lblClienteEncontrado" runat="server" CssClass="d-block text-break"  Visible="false" />
            </div>
        </div>

        <div class="col-md-6 mb-3">
            <asp:Label ID="lblPrioridad" runat="server" Text="Prioridad" AssociatedControlID="ddlPrioridad" CssClass="form-label" />
            <asp:DropDownList ID="ddlPrioridad" runat="server" CssClass="form-select">
                <asp:ListItem Value="" Text="Pendiente: cargar prioridades" />
            </asp:DropDownList>
        </div>

        <div class="col-md-6 mb-3">
            <asp:Label ID="lblTipo" runat="server" Text="Tipo de incidencia"  AssociatedControlID="ddlTipo" CssClass="form-label" />
            <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-select">
                <asp:ListItem Value="" Text="Pendiente: cargar tipo de incidencia" />
            </asp:DropDownList>
        </div>

        <div class="col-md-12 mb-3">

            <asp:Label ID="Descripcion" runat="server"  Text="Descripción de la incidencia" AssociatedControlID="txtDescripcion" CssClass="form-label" />
            <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine"  Rows="6" CssClass="form-control"  Style="max-width: none; width: 100%; resize: vertical;"  placeholder="Ingresá una descripción detallada del reclamo o consulta..." />
        </div>
</div>
    <hr class="my-4" />
    <div class="d-flex justify-content-end gap-2 flex-wrap">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Enabled="true" />
        <a runat="server" href="~/Incidencias.aspx" class="btn btn-secondary">Cancelar</a>

    </div>

            </div>

        </div>

    </div>



</asp:Content> 
