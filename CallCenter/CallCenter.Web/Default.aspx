<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CallCenter.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
    <h1>Sistema Call Center</h1><p class="lead">Gestión de clientes e incidencias </p>

    <div class="row g-4 mb-4">
        <section class="col-md-4">
            <div class="card h-100">
                <div class="card-body d-flex flex-column p-4">
                    <h2 class="card-title">Clientes</h2> 
                    <p class="card-text"> Consultar los clientes y acceder a sus datos de contacto</p>
                    <a runat="server" href="~/Clientes.aspx" class="btn btn-primary mt-auto align-self-start"> Ir a clientes </a>
               </div>
           </div>
        </section>
   
        <section class="col-md-4">
            <div class="card h-100">
                <div class="card-body d-flex flex-column p-4">
                    <h2 class="card-title">Incidencias</h2> 
                    <p class="card-text"> Acceder a los reclamos y a las pantallas de atención</p>
                    <a runat="server" href="~/Incidencias.aspx" class="btn btn-primary mt-auto align-self-start"> Ir a incidencias </a>
                </div>
            </div>
        </section>

        <section class="col-md-4">
            <div class="card h-100">
                <div class="card-body d-flex flex-column p-4">
                    <h2 class="card-title">Prioridades</h2> 
                    <p class="card-text"> Sección donde mostraremos la lectura de prioridades desde la base de datos</p>
                    <a runat="server" href="~/Prioridades.aspx" class="btn btn-primary mt-auto align-self-start"> Ir a prioridades </a>
                </div>
            </div>
        </section>

        <section class="col-md-4">
            <div class="card h-100">
                <div class="card-body d-flex flex-column p-4">
                    <h2 class="card-title">Tipos de incidencia</h2> 
                    <p class="card-text"> Consultar y administrar los tipos de reclamos</p>
                    <a runat="server" href="~/TiposIncidencia.aspx" class="btn btn-primary mt-auto align-self-start"> Ir a tipos de incidencia </a>
                </div>
            </div>
        </section>

        <section class="col-md-4">
            <div class="card h-100">
                <div class="card-body d-flex flex-column p-4">
                    <h2 class="card-title">Usuarios</h2> 
                    <p class="card-text"> Consultar y administrar los usuarios del sistema</p>
                    <a runat="server" href="~/Usuarios.aspx" class="btn btn-primary mt-auto align-self-start"> Ir a usuarios </a>
                </div>
            </div>
       </section>
    </div>
</main>

</asp:Content>
