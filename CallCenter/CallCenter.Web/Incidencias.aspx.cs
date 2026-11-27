
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Negocio;
using CallCenter.Dominio;

namespace CallCenter.Web
{
    public partial class Incidencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Sesion.ExigirLogin();
            if (!IsPostBack)
            {
                IncidenciaNegocio negocio = new IncidenciaNegocio();

                List<Incidencia> lista = negocio.Listar();
               
                dgvIncidencias.DataSource = lista;

                dgvIncidencias.DataBind();
            }
        }

        protected void ddlTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = ddlTipoBusqueda.SelectedValue;

            txtValorBuscar.Text = "";
            ddlValorBuscar.Items.Clear();
            lblErrorBusqueda.Visible = false;

            bool usarDesplegable = tipo == "tipo" ||tipo == "prioridad" || tipo == "estado";

            txtValorBuscar.Visible = !usarDesplegable;
            ddlValorBuscar.Visible = usarDesplegable;

            lblValorBuscar.AssociatedControlID = usarDesplegable ? "ddlValorBuscar": "txtValorBuscar";

            if (usarDesplegable)
            {
                switch (tipo)
                {
                    case "tipo":
                        TipoIncidenciaNegocio negocioTipos = new TipoIncidenciaNegocio();
                        ddlValorBuscar.DataSource = negocioTipos.Listar();
                        break;

                    case "prioridad":
                        PrioridadNegocio negocioPrioridades = new PrioridadNegocio();
                        ddlValorBuscar.DataSource = negocioPrioridades.Listar();
                        break;

                    case "estado":
                        IncidenciaNegocio negocio = new IncidenciaNegocio();
                        ddlValorBuscar.DataSource = negocio.ListarEstados();
                        break;
                }

                ddlValorBuscar.DataTextField = "Nombre";
                ddlValorBuscar.DataValueField = "Id";
                ddlValorBuscar.DataBind();

                ddlValorBuscar.Items.Insert(0,new ListItem("Todas las opciones", ""));
            }
        }

        protected void btnBuscarNumero_Click(object sender, EventArgs e)
        {
            lblErrorBusqueda.Visible = false;

            string tipo = ddlTipoBusqueda.SelectedValue;
            string valor = txtValorBuscar.Text.Trim();

            // Recuperar las incidencias
            IncidenciaNegocio negocio = new IncidenciaNegocio();

            List<Incidencia> lista = negocio.Listar();
            
            dgvIncidencias.DataSource = lista;

            // Buscar por número exacto
            if (tipo == "numero" && valor != "")
            {
                int numero;

                if (!int.TryParse(valor, out numero) || numero <= 0)
                {
                    lblErrorBusqueda.Text = "Ingresá un número de reclamo válido.";
                    lblErrorBusqueda.Visible = true;

                    return;
                }

                lista = lista.Where(i => i.Numero == numero).ToList();
            }

            else if (tipo == "tipo" || tipo == "prioridad" || tipo == "estado")
            {
                int id;

                if (int.TryParse(ddlValorBuscar.SelectedValue, out id))
                {
                    switch (tipo)
                    {
                        case "tipo":
                            lista = lista.Where(i => i.Tipo != null &&  i.Tipo.Id == id).ToList();
                            break;

                        case "prioridad":
                            lista = lista.Where(i => i.prioridad != null && i.prioridad.Id == id).ToList();
                            break;

                        case "estado":
                            lista = lista.Where(i => i.Estado != null && i.Estado.Id == id).ToList();
                            break;
                    }
                }
            }

            // Otros criterios de búsqueda
            else if (tipo != "todos" && tipo != "numero" && valor != "")
            {
                Func<Incidencia, string> obtenerDato = null;

                switch (tipo)
                {
                    case "cliente":
                        obtenerDato = i => i.cliente == null ? "" : i.cliente.Id + " " + i.cliente.Nombre + " " + i.cliente.Apellido;
                        break;

                    case "descripcion":
                        obtenerDato = i => i.Descripcion;
                        break;

                    case "seguimiento":
                        obtenerDato = i => i.UltimoSeguimiento;
                        break;

                    case "creador":
                        obtenerDato = i =>
                            i.UsuarioCreador == null ? "" :
                            i.UsuarioCreador.Nombre;
                        break;

                    case "asignado":
                        obtenerDato = i => i.UsuarioAsignado == null ? "" : i.UsuarioAsignado.Nombre;
                        break;

                    case "ultimoUsuario":
                        obtenerDato = i => i.UsuarioUltimaModificacion == null ? "" : i.UsuarioUltimaModificacion.Nombre;
                        break;

                    case "fechaAlta":
                        obtenerDato = i =>  i.FechaAlta.ToString("dd/MM/yyyy HH:mm");
                        break;

                    case "fechaModificacion":
                        obtenerDato = i => i.FechaUltimaModificacion.HasValue ? i.FechaUltimaModificacion.Value.ToString("dd/MM/yyyy HH:mm"): "Sin modificaciones";
                        break;
                }

                if (obtenerDato != null)
                {
                    lista = lista.Where(i => (obtenerDato(i) ?? "").IndexOf(valor,StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
            }

            dgvIncidencias.DataSource = lista;
            dgvIncidencias.DataBind();
        }

    }
}
