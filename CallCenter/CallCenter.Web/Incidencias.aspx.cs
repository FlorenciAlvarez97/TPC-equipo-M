
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
    }
}
