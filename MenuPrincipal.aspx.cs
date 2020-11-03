using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstadiaMWE
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Nombre_Empleado"] = null;
            Globales.usuario_actual = null;
        }


        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaUnidad.aspx");
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioSesion.aspx");
        }

        protected void btnAnalisis_Click(object sender, EventArgs e)
        {
            Response.Redirect("Alta_Analisis.aspx");
        }
    }
}