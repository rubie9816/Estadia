using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstadiaMWE
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombre_Empleado"] == null)
            {
                Response.Redirect("MenuPrincipal.aspx");
            }
            else
            {
                LlenarGridReportes(Conexion.consultaReporte());

                if (!IsPostBack)
                {
                    LlenarDdlBD(ddlStatus, "CAT_STATUS", "Nombre_status", "Id_Status");
                    LlenarDdlBD(ddlNumEmpleado, "USUARIO", "Num_Empleado", "Id_Usuario");
                    LlenarDdlBD(ddlPartNumber, "CAT_NUMPARTE", "Num_Parte", "Id_NumParte");
                    //serial
                    //wo
                }

            }
        }

        protected void LlenarGridReportes(DataSet ds)
        {
            gvReportes.DataSource = ds;

            try
            {
                gvReportes.DataBind();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void LlenarDdlBD(DropDownList ddl, string tabla, string nombre, string id)
        {

            ddl.DataSource = Conexion.ConsultaGeneral(tabla);
            ddl.DataTextField = nombre;
            ddl.DataValueField = id;
            ddl.DataBind();

            ListItem item = new ListItem { Text = "Select All", Value = "-1" };
            ddl.Items.Add(item);

            ddl.SelectedValue = (ddl.Items.FindByText("Select All")).Value;

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ddlNumEmpleado.SelectedValue == "-1" && ddlStatus.SelectedValue == "-1" && ddlTurno.SelectedValue == "-1"
                && ddlPartNumber.SelectedValue == "-1" && txtWo.Text == "" && txtSerialNum.Text == "")
            {
                //CALENDARIO
                LlenarGridReportes(Conexion.consultaReporte());
            }
            else
            {
                LlenarGridReportes(Conexion.consultaReporte(ddlNumEmpleado.SelectedItem.Text, ddlStatus.SelectedItem.Text, ddlTurno.SelectedItem.Text, txtWo.Text,
                   Convert.ToInt32(ddlPartNumber.SelectedItem.Value), txtSerialNum.Text));
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }

        protected void gvReportes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[0].Visible = false;
            }
        }
    }
}