<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Usuarios</h1>
    <p> </p>

    <div class="mb-3">
        <a runat="server" href="~/Default.aspx" class="btn btn-secondary">Volver al inicio</a>
    </div>

    <div class="table-responsive">
        <table class="table table-striped table-bordered">
            <thead>
                <tr>
                    <th scope="col">Nombre</th>
                    <th scope="col">Usuario</th>
                    <th scope="col">Rol</th>
                    <th scope="col">Activo</th>
                </tr>
            </thead>
        </table>
    </div>
</asp:Content>