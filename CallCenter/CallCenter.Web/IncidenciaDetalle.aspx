<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Detalle de incidencia</h1>
    <p> </p>

    <div class="row">
        <div class="col-md-6">

            <div class="mb-3">
                <label class="form-label">Número</label>
                <input type="text" class="form-control" value="-" disabled />
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de alta</label>
                <input type="text" class="form-control" value="-" disabled />
            </div>
            <div class="mb-3">
                <label class="form-label">Cliente</label>
                <input type="text" class="form-control" value="-" disabled />
            </div>
            <div class="mb-3">
                <label class="form-label">Tipo</label>
                <input type="text" class="form-control" value="-" disabled />
            </div>
            <div class="mb-3">
                <label class="form-label">Prioridad</label>
                <input type="text" class="form-control" value="-" disabled />
            </div>
            <div class="mb-3">
                <label class="form-label">Estado</label>
                <input type="text" class="form-control" value="-" disabled />
            </div>
            <div class="mb-3">
                <label class="form-label">Descripción</label>
                <textarea class="form-control" rows="5" disabled></textarea>
            </div>

            <div class="mb-3">
                <a runat="server" href="~/Incidencias.aspx" class="btn btn-secondary">Volver a incidencias</a>
            </div>

        </div>
    </div>
</asp:Content> 