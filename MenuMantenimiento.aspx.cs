using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstadiaMWE
{
    public partial class MenuMantenimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombre_Empleado"] == null)
            {
                Response.Redirect("MenuPrincipal.aspx");
            }
        }

 
        protected void btnDefecto_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mantenimiento/Man_Defecto.aspx");

        }

        protected void btnUsuario_Click(object sender, EventArgs e)
        {

        }

        protected void btnArea_Click(object sender, EventArgs e)
        {

        }

        protected void btnStatus_Click(object sender, EventArgs e)
        {

        }

        protected void btnTurno_Click(object sender, EventArgs e)
        {

        }

        protected void btnNumParte_Click(object sender, EventArgs e)
        {

        }

        protected void btnCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnTipoUsuario_Click(object sender, EventArgs e)
        {

        }

        protected void btnAreaInt_Click(object sender, EventArgs e)
        {

        }
    }
}