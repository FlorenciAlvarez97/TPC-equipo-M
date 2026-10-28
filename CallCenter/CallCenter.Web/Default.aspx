<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CallCenter.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
    <h1>Sistema Call Center</h1><p class="lead">Gestión de clientes e incidencias </p>

    <div class="row">
        <section class="col-md-4"><h2>Clientes</h2> <p>Consultar los clientes y acceder a sus datos de contacto.</p>

               <a runat="server"
               href="~/Clientes.aspx"
               class="btn btn-primary">
                Ir a clientes
            </a>
        </section>

        <section class="col-md-4"><h2>Incidencias</h2> <p>Acceder a los reclamos y a las pantallas de atención </p>

            <a runat="server"
               href="~/Incidencias.aspx"
               class="btn btn-primary">
                Ir a incidencias
            </a>
        </section>

        <section class="col-md-4"><h2>Prioridades</h2><p> Sección donde mostraremos la lectura de prioridades desde la base de datos</p>

            <a runat="server"
               href="~/Prioridades.aspx"
               class="btn btn-primary">
                Ir a prioridades
            </a>
        </section>
    </div>
</main>

</asp:Content>
