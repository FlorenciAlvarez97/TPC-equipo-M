<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CallCenter.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   

<main class="py-4">

    <div class="text-center mb-5">
        <h1 class="display-5 fw-bold text-dark">
            Sistema Call Center
        </h1>
        <p class="lead text-secondary">
            Gestión de clientes e incidencias
        </p>
    </div>

    <div class="dashboard-grid">

        <%-- CLIENTES --%>
        <section runat="server" id="secClientes">
            <a runat="server" href="~/Clientes.aspx"
               class="card dashboard-card h-100 text-decoration-none text-dark" style="min-height: 155px;" > 
                <div class="card-body p-4 text-center d-flex flex-column align-items-center justify-content-center">
                    <div class="dashboard-icon">👥</div>
                    <h2 class="h3 fw-bold mt-3">Clientes</h2>
                    <p class="fs-5 text-secondary">
                        Consultar y gestionar clientes.
                    </p>
                </div>
            </a>
        </section>

        <%-- INCIDENCIAS --%>
        <section runat="server" id="secIncidencias">
            <a runat="server" href="~/Incidencias.aspx"
               class="card dashboard-card h-100 text-decoration-none text-dark" style="min-height: 155px;">
                <div class="card-body p-4 text-center d-flex flex-column align-items-center justify-content-center">
                    <div class="dashboard-icon">🎧</div>
                    <h2 class="h3 fw-bold mt-3">Incidencias</h2>
                    <p class="fs-5 text-secondary">
                        Consultar y gestionar reclamos.
                    </p>
                </div>
            </a>
        </section>

        <%-- PRIORIDADES --%>
        <section runat="server" id="secPrioridades">
            <a runat="server" href="~/Prioridades.aspx"
               class="card dashboard-card h-100 text-decoration-none text-dark" style="min-height: 155px;">
                <div class="card-body p-4 text-center d-flex flex-column align-items-center justify-content-center">
                    <div class="dashboard-icon">🚩</div>
                    <h2 class="h3 fw-bold mt-3">Prioridades</h2>
                    <p class="fs-5 text-secondary">
                        Administrar niveles de prioridad.
                    </p>
                </div>
            </a>
        </section>

        <%-- TIPOS DE INCIDENCIA --%>
        <section runat="server" id="secTipos">
            <a runat="server" href="~/TiposIncidencia.aspx"
               class="card dashboard-card h-100 text-decoration-none text-dark" style="min-height: 155px;">
                <div class="card-body p-4 text-center d-flex flex-column align-items-center justify-content-center">
                    <div class="dashboard-icon">📋</div>
                    <h2 class="h3 fw-bold mt-3">Tipos de incidencia</h2>
                    <p class="fs-5 text-secondary">
                        Administrar tipos de reclamos.
                    </p>
                </div>
            </a>
        </section>

        <%-- USUARIOS --%>
        <section runat="server" id="secUsuarios">
            <a runat="server" href="~/Usuarios.aspx"
               class="card dashboard-card h-100 text-decoration-none text-dark" style="min-height: 155px;">
                <div class="card-body p-4 text-center d-flex flex-column align-items-center justify-content-center">
                    <div class="dashboard-icon">👤</div>
                    <h2 class="h3 fw-bold mt-3">Usuarios</h2>
                    <p class="fs-5 text-secondary">
                        Administrar usuarios del sistema.
                    </p>
                </div>
            </a>
        </section>
    </div>
</main>


</asp:Content> 
