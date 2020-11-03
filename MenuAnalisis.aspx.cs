using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstadiaMWE
{
    public partial class MenuAnalisis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombre_Empleado"] == null)
            {
                Response.Redirect("MenuPrincipal.aspx");
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("Alta_Analisis.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnAnalisis_Click(object sender, EventArgs e)
        {
            Response.Redirect("Analisis.aspx");
        }
    }
}