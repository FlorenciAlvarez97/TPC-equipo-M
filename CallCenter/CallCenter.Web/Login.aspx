<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CallCenter.Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Iniciar sesión</h1>

     <div class="row">
         <div class="col-md-6">

             <div class="mb-3">
                 <asp:Label ID="lblUsuario" runat="server" AssociatedControlID="txtUsuario" CssClass="form-label" Text="Nombre de usuario" />
                 <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"/>
             </div>

              <div class="mb-3">
                  <asp:Label ID="lblContrasena" runat="server" AssociatedControlID="txtContrasena" CssClass="form-label" Text="Contraseña" />
                  <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password"/>
              </div>

             <div class="mb-3">
                 <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary" Enabled="false" />
                 <a runat="server" href="~/Default.aspx" class="btn btn-outline-primary"> Ver demostración </a>
            </div>
        </div>
    </div>
</asp:Content>
