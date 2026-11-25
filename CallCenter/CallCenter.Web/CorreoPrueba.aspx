
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorreoPrueba.aspx.cs" Inherits="CallCenter.Web.CorreoPrueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>Prueba de correo - Call Center</title>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <h2>Prueba de correo - Call Center</h2>

            <asp:Button ID="btnProbarCorreo"  runat="server" Text="Enviar correo de prueba"  OnClick="btnProbarCorreo_Click" />
            <br />
            <br />

            <asp:Label ID="lblResultado" runat="server" />
        </div>
    </form>
</body>

</html>
