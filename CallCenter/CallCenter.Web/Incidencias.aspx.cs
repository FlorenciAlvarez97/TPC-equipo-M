
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
            if (!IsPostBack)
            {
                IncidenciaNegocio negocio = new IncidenciaNegocio();

                dgvIncidencias.DataSource = negocio.Listar();

                dgvIncidencias.DataBind();
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

            // Otros criterios de búsqueda
            else if (tipo != "todos" && tipo != "numero" && valor != "")
            {
                Func<Incidencia, string> obtenerDato = null;

                switch (tipo)
                {
                    case "cliente":
                        obtenerDato = i => i.cliente == null ? "" : i.cliente.Id + " " + i.cliente.Nombre + " " + i.cliente.Apellido;
                        break;

                    case "tipo":
                        obtenerDato = i => i.Tipo == null ? "" : i.Tipo.Nombre;
                        break;

                    case "prioridad":
                        obtenerDato = i =>i.prioridad == null ? "" : i.prioridad.Nombre;
                        break;

                    case "estado":
                        obtenerDato = i => i.Estado == null ? "" : i.Estado.Nombre;
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
