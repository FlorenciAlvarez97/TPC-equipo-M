<%@ Page Title="Prioridades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prioridades.aspx.cs" Inherits="CallCenter.Web.Prioridades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Prioridades</h1>
    <div class="mb-3"> <a runat="server" href="~/PrioridadFormulario.aspx" class="btn btn-primary"> Nueva prioridad </a> </div>
    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
    
    <div class="mb-4">
        <div class="d-flex gap-3 align-items-end flex-wrap">
            <div>
                <asp:Label runat="server" AssociatedControlID="txtBuscarPrioridad"  Text="Nivel"  CssClass="form-label" />
                <asp:TextBox ID="txtBuscarPrioridad" runat="server"  CssClass="form-control" placeholder="Ingresá tu búsqueda" />
            </div>
            
            <div>
                <asp:Label runat="server" AssociatedControlID="ddlEstadoPrioridad"  Text="Estado" CssClass="form-label" />
                
                <asp:DropDownList ID="ddlEstadoPrioridad" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Todos" Value="" />
                    <asp:ListItem Text="Activos" Value="1" />
                    <asp:ListItem Text="Inactivos" Value="0" />
                </asp:DropDownList>
            </div>
            
            <asp:Button ID="btnBuscarPrioridades"
                runat="server"
                Text="Buscar"
                CssClass="btn btn-primary"
                CausesValidation="false"
                OnClick="btnBuscarPrioridades_Click" />
        </div>
    </div>
    
    <div class="table-responsive">
        <asp:GridView ID="dgvPrioridades"
            runat="server"
            AutoGenerateColumns="false"
            DataKeyNames="Id"
            OnSelectedIndexChanged="dgvPrioridades_SelectedIndexChanged"
            OnRowCommand="dgvPrioridades_RowCommand"
            CssClass="table table-striped table-bordered"
            GridLines="None"
            ShowHeaderWhenEmpty="true"
            EmptyDataText="No hay prioridades en la base de datos">

            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Nivel" HeaderText="Nivel" />

                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <%#(bool)Eval("Activo") ? "Activo" : "Incativo" %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField
                    HeaderText="Acciones"
                    ShowSelectButton="true"
                    SelectText="Editar"
                    ButtonType="Link"
                    CausesValidation="false" >
                    <ControlStyle CssClass="=btn btn-outline-primary btn-sm"/>  
                </asp:CommandField>

                <asp:TemplateField HeaderText= "Cambiar estado">
                    <ItemTemplate>
                        <asp:Button ID="btnCambiarEstado" runat="server" 
                            Text='<%#(bool)Eval("Activo") ? "Desactivar" : "Reactivar" %>'
                            CommandName='<%#(bool)Eval("Activo") ? "Desactivar" : "Reactivar" %>'
                            CommandArgument='<%#Eval ("Id") %>'
                            CssClass="btn btn-outline-secondary btn-sm"
                            CausesValidation="false"
                            OnCLientClick="return confirm('¿Esta seguro de guardar el cambio?');" />
                    </ItemTemplate>
                </asp:TemplateField>
           </Columns>
       </asp:GridView>
    </div>

    <a runat= "server" href ="~/Default.aspx" class= "btn btn-primary"> volver al inicio</a>
</asp:Content>
