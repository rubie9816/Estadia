using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstadiaMWE
{
    public partial class Bitacora : System.Web.UI.Page
    {
        //string fecha = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Nombre_Empleado"] == null)
            {
                Response.Redirect("MenuPrincipal.aspx");
            }
            else
            {

                LlenarGridReportes(Conexion.consultaBitacora());
                if (!IsPostBack)
                {

                    LlenarDdlBD(ddlStatus, "CAT_STATUS", "Nombre_status", "Id_Status");
                    LlenarDdlBD(ddlNumEmpleado, "USUARIO", "Num_Empleado", "Id_Usuario");
                    LlenarDdlBD(ddlPartNumber, "CAT_NUMPARTE", "Num_Parte", "Id_NumParte");
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
                && ddlPartNumber.SelectedValue == "-1" && txtWo.Text == "" && txtSerialNum.Text == "" && txtFecha.Text == "")
            {

                //CALENDARIO
                LlenarGridReportes(Conexion.consultaBitacora());
            }
            else
            {
                LlenarGridReportes(Conexion.consultaBitacora(ddlNumEmpleado.SelectedItem.Text, ddlStatus.SelectedItem.Text, ddlTurno.SelectedItem.Text, txtWo.Text,
                    Convert.ToInt32(ddlPartNumber.SelectedItem.Value), txtSerialNum.Text, Globales.fecha_seleccionada));
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
           // Globales.fecha_seleccionada = DateTime.Now.ToString("yyyy-MM-dd");
            Globales.fecha_seleccionada = DateTime.Now.ToString();
            Response.Redirect(Request.Url.ToString());
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }

        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            Globales.fecha_seleccionada = txtFecha.Text;

            // DateTime date = DateTime.ParseExact(Globales.fecha_seleccionada, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            //LlenarGridReportes(Conexion.consultaBitacora(ddlNumEmpleado.SelectedItem.Text, ddlStatus.SelectedItem.Text, ddlTurno.SelectedItem.Text, txtWo.Text,
            //        Convert.ToInt32(ddlPartNumber.SelectedItem.Value), txtSerialNum.Text, Globales.fecha_seleccionada));
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