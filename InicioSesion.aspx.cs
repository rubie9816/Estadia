using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstadiaMWE
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Nombre_Empleado"] = null;
            Globales.usuario_actual = null;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            if (Conexion.validarUsuario(txtUsuario.Text, txtPassword.Text))
            {
                Globales.usuario_actual = Conexion.obtenerUsuario(txtUsuario.Text, txtPassword.Text);
                Session["Nombre_Empleado"] = Globales.usuario_actual.Nombre_Empleado;
                Response.Redirect("Menu.aspx");
            }
            else
            {
                txtUsuario.Text = "";
                txtPassword.Text = "";
                MsgBox("Informacion incorrecta", this.Page, this);
            }

        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}