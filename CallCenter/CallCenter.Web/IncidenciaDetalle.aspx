<%@ Page Title="Detalle de incidencia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenciaDetalle.aspx.cs" Inherits="CallCenter.Web.IncidenciaDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Detalle de incidencia</h1>
    <p></p>

    <div class="row g-4">
        <div class="col-md-8">

            <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
            
            <div class="card mb-4">
               <div class="card-header fw-bold"> Datos principales </div>
                
               <div class="card-body"> 
               <div class="row align-items-center mb-2"> <label class="col-sm-5 fw-bold">Número:</label>
               <div class="col-sm-7">
                   <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control-plaintext" Style="max-width: none;" ReadOnly="true" />
               </div> 
            </div>

            <div class="row align-items-center mb-2">
                <label class="col-sm-5 fw-bold">Cliente:</label>
                <div class="col-sm-7">
                    <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control-plaintext" Style="max-width: none;" ReadOnly="true" />
               </div>
            </div>
            
            <div class="row align-items-center mb-2">
                <label class="col-sm-5 fw-bold">Tipo de incidencia:</label>
                <div class="col-sm-7">
                    <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control-plaintext" Style="max-width: none;" ReadOnly="true" />
               </div>
            </div>

            <div class="row align-items-center mb-2">
                <label class="col-sm-5 fw-bold">Prioridad:</label>
                <div class="col-sm-7">
                    <asp:TextBox ID="txtPrioridad" runat="server" CssClass="form-control-plaintext"  Style="max-width: none;" ReadOnly="true" />
               </div>
            </div>
            
            <div class="row align-items-center mb-2"> 
                <label class="col-sm-5 fw-bold">Estado:</label>
                <div class="col-sm-7">
                    <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control-plaintext" Style="max-width: none;" ReadOnly="true" />
               </div>
            </div>

            <div class="row align-items-center">
                <label class="col-sm-5 fw-bold">Fecha de alta:</label>
                <div class="col-sm-7">
                    <asp:TextBox ID="txtFechaAlta" runat="server" CssClass="form-control-plaintext" Style="max-width: none;" ReadOnly="true" />
                </div>
           </div>
        </div>
     </div>

            
     <div class="card mb-4">

    <div class="card-header fw-bold"> Descripción </div>

    <div class="card-body">
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control-plaintext w-100" TextMode="MultiLine" Rows="5" ReadOnly="true" Style="max-width: none; resize: none;" />
    </div>
</div>


<div class="card mb-4">

    <div class="card-header fw-bold"> Nuevo seguimiento </div>

    <div class="card-body">
        <div class="mb-3">
            <asp:Label ID="lblTipoGestion" runat="server"  AssociatedControlID="ddlTipoGestion" CssClass="form-label" Text="Tipo de gestión" />
            <asp:DropDownList ID="ddlTipoGestion" runat="server" CssClass="form-select w-100" Style="max-width: none;"  AutoPostBack="true" OnSelectedIndexChanged="ddlTipoGestion_SelectedIndexChanged">
                <asp:ListItem Text="Registrar seguimiento" Value="seguimiento" />
                <asp:ListItem Text="Resolver incidencia" Value="resolver" />
                <asp:ListItem Text="Cerrar incidencia" Value="cerrar" />
                <asp:ListItem Text="Reabrir incidencia" Value="reabrir" />
            </asp:DropDownList>
        </div>

        <div class="mb-3">
            <asp:Label ID="lblComentarioSeguimiento" runat="server" AssociatedControlID="txtComentarioSeguimiento" CssClass="form-label" Text="Comentario de la gestión" />
            <asp:TextBox ID="txtComentarioSeguimiento" runat="server" CssClass="form-control w-100"  TextMode="MultiLine" Rows="5"  Style="max-width: none;" placeholder="Describí qué gestión realizaste..." />
        </div>

        <div class="text-end">
            <asp:Button ID="btnGuardarGestion" runat="server" Text="Guardar gestión" CssClass="btn btn-primary" OnClick="btnGuardarGestion_Click" Enabled="false" />
        </div>

    </div>

</div>

<div style="display: none;">

<h3 class="h5">Resolver incidencia</h3>
            
            <div class="mb-3">
                <asp:Label ID="lblResolucion" runat="server" AssociatedControlID="txtResolucion" CssClass="form-label" Text="Resolución (obligatoria)" />
                <asp:TextBox ID="txtResolucion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                <p class="form-text">Describí cómo se resolvió la incidencia</p>
            </div>

            <div class="mb-4">
                <asp:Button ID="btnResolver" runat="server" Text="Resolver" CssClass="btn btn-success" OnClick="btnResolver_Click" />
            </div>

            <h3 class="h5">Cerrar incidencia</h3>

            <div class="mb-3">
                <asp:Label ID="lblComentarioCierre" runat="server" AssociatedControlID="txtComentarioCierre" CssClass="form-label" Text="Comentario final de cierre (obligatorio)" />
                <asp:TextBox ID="txtComentarioCierre" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                <p class="form-text">Indicá el motivo del cierre </p>
            </div>

            <div class="mb-4">
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar incidencia" CssClass="btn btn-danger" OnClick="btnCerrar_Click" />
            </div>

            <h3 class="h5">Reabrir incidencia</h3>
            <div class="mb-4">
                <asp:Button ID="btnReabrir" runat="server" Text="Reabrir incidencia" CssClass="btn btn-warning" OnClick="btnReabrir_Click" />
            </div>
         </div>

            <div class="mb-3">
                <a runat="server" href="~/Incidencias.aspx" class="btn btn-secondary">Volver a incidencias</a>
            </div>
        </div>
        <div class="col-md-4">
             <div class="card mb-4">
                  <div class="card-header fw-bold">
                      <h3 class="h5">Reasignar incidencia</h3>
                  </div>

                  <div class="card-body">
                      <div class="mb-3">
                          <asp:Label ID="lblUsuarioAsignado" runat="server" AssociatedControlID="txtUsuarioAsignado" CssClass="form-label" Text="Usuario asignado actualmente" />
                          <asp:TextBox ID="txtUsuarioAsignado" runat="server" CssClass="form-control" Text="-" ReadOnly="true" />
                      </div>
                      <div class="mb-3">
                          <asp:Label ID="lblNuevoResponsable" runat="server" AssociatedControlID="ddlNuevoResponsable" CssClass="form-label" Text="Nuevo usuario responsable" />
                          <asp:DropDownList ID="ddlNuevoResponsable" runat="server" CssClass="form-select"></asp:DropDownList>
                      </div>
                      
                      <div class="mb-4">
                          <asp:Button ID="btnReasignar" runat="server" Text="Reasignar" CssClass="btn btn-primary" OnClick="btnReasignar_Click" />
                     </div>
                 </div>
             </div>
             <div class="card mb-4">
                 <div class="card-header fw-bold"> Historial de seguimientos</div>
                 <div class="card-body">
                     <asp:GridView ID="dgvHistorial" runat="server" AutoGenerateColumns="false" CssClass="table table-borderless" GridLines="None" ShowHeader="false" EmptyDataText="Todavía no hay seguimientos registrados.">
                         <Columns>
                             <asp:TemplateField>
                                 <ItemTemplate>
                                     <div class="border-bottom pb-3 mb-3">
                                         <div class="fw-bold">
                                             <%#: Eval("Fecha", "{0:dd/MM/yyyy HH:mm}") %>
                                         </div>
                                         <div class="text-muted small"> 
                                             <%#: Eval("Usuario.Nombre") %> <%#: Eval("EstadoResultante.Nombre") %>
                                         </div>
                                         <div class="mt-2 text-break">
                                             <%#: Eval("Comentario") %>
                                         </div>
                                     </div>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                     </asp:GridView>
                 </div>
             </div>
         </div>
     </div>
</asp:Content>
