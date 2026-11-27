
<%@ Page Title="Nuevo Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteFormulario.aspx.cs" Inherits="CallCenter.Web.ClienteFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="max-width: 1050px; margin: 0 auto;">

        <div class="mb-4">
            <h1 id="tituloPagina" runat="server" class="fw-bold mb-1"> Nuevo cliente </h1>

            <p class="text-muted mb-0"> Completá los datos del cliente. </p>
        </div>

        <asp:Label ID="lblError"  runat="server" CssClass="alert alert-danger d-block" Visible="false" />
 
        <div class="card border-0 shadow-sm rounded-4">
            <div class="card-body p-4 p-md-5">
                <div class="row g-4">

                    <div class="col-12 col-md-6">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre" AssociatedControlID="txtNombre" CssClass="form-label" />
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50" Style="max-width: none;" />
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio" CssClass="text-danger" Display="Dynamic" />
                    </div>

                    <div class="col-12 col-md-6">
                        <asp:Label ID="lblApellido" runat="server" Text="Apellido" AssociatedControlID="txtApellido" CssClass="form-label" />
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" MaxLength="30" Style="max-width: none;" />
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="El apellido es obligatorio" CssClass="text-danger" Display="Dynamic" />

                    </div>

                    <div class="col-12 col-md-6">
                        <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="txtEmail" CssClass="form-label" />
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="50" Style="max-width: none;" />
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="El email es obligatorio"  CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"  ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Ingresá un email válido" CssClass="text-danger" Display="Dynamic" />
                    </div>

                    <div class="col-12 col-md-6">
                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono" AssociatedControlID="txtTelefono" CssClass="form-label" />
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="10" Style="max-width: none;" />
                    </div>

                    <div class="col-12">
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección" AssociatedControlID="txtDireccion" CssClass="form-label" />
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="100" Style="max-width: none;" />
                    </div>

                    <div class="col-12">
                        <asp:CheckBox ID="chkActivo" runat="server" Text="Cliente activo" Checked="true" />
                    </div>

                </div>

                <hr class="my-4" />
                <div class="d-flex justify-content-end gap-2">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary px-4"  OnClick="btnGuardar_Click" />
                    <a runat="server" href="~/Clientes.aspx" class="btn btn-secondary px-4"> Cancelar  </a>

                </div>

            </div>
        </div>

    </div>

</asp:Content>
