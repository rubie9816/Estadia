using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstadiaMWE
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombre_Empleado"] == null)
            {
                Response.Redirect("MenuPrincipal.aspx");
            }
            else
            {
                lblUsuario.Text = Globales.usuario_actual.Nombre_Empleado;
            }
        }

        protected void btnMantenimiento_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuMantenimiento.aspx");
        }

        protected void btnRetrabajo_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuRetrabajo.aspx");
        }

        protected void btnReportes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }



        protected void btnAnalisis_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAnalisis.aspx");
        }

        protected void btnBitacora_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bitacora.aspx");
        }

        protected void btnModificaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Modificaciones.aspx");
        }
    }
}