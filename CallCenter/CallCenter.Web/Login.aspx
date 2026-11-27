<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CallCenter.Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center w-100" style="min-height: 80vh;">

        <div class="w-100" style="max-width: 520px; margin: 0 auto; padding: 20px;">
             <h1 class="text-center mb-4" style="font-size: 2.2rem;">Iniciar sesión</h1>
            <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
            
            <div class="mb-3">
                 <asp:Label ID="lblUsuario" runat="server" AssociatedControlID="txtUsuario" CssClass="form-label-5" Text="Nombre de usuario" />
                 <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control form-control-lg w-100" Style="max-width: none; width: 100%;"/>
             </div>

              <div class="mb-3">
                  <asp:Label ID="lblContrasena" runat="server" AssociatedControlID="txtContrasena" CssClass="form-label fs-5" Text="Contraseña" />
                  <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control form-control-lg w-100" TextMode="Password" Style="max-width: none; width: 100%;"/>
              </div>

             <div class="d-grid mt-4">
                 <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary btn-lg w-100"  Style="max-width: none;" OnClick="btnIngresar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
