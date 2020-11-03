using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.DynamicData;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EstadiaMWE
{
    public partial class Retrabajo : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombre_Empleado"] == null)
            {
                Response.Redirect("MenuPrincipal.aspx");
            }
            else
            {
                LlenarGridRetrabajo(Conexion.ConsultaUnidadEstatus(Conexion.ConsultaEstatus("RWK")));

                if (!IsPostBack)
                {
                    btnRetrabajar.Enabled = false;
                    ModificarInfoUnidad(false);
                    LlenarDdlBD(ddlArea, "CAT_AREA", "Area", "Id_Area");
                    LlenarDdlBD(ddlPartNumber, "CAT_NUMPARTE", "Num_Parte", "Id_NumParte");
                    LlenarDdlBD(ddlStatus, "CAT_STATUS", "Nombre_status", "Id_Status");
                    LlenarDdlBD(ddlDefecto, "CAT_DEFECTO", "FullDefecto", "Id_Defecto");

                }

            }

        }

        //DROPDOWNLIST
        protected void LlenarDdlBD(DropDownList ddl, string tabla, string nombre, string id)
        {

            ddl.DataSource = Conexion.ConsultaGeneral(tabla);
            ddl.DataTextField = nombre;
            ddl.DataValueField = id;
            ddl.DataBind();

        }
        protected void ddlDefecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlDefecto.SelectedValue);

            if (!Globales.defectos_seleccionados.Exists(r => r.Id_Defecto == id))
            {
                Globales.defectos_seleccionados.Add(new Modelos.Defecto { Id_Defecto = Convert.ToInt32(ddlDefecto.SelectedValue), defecto = ddlDefecto.SelectedItem.Text });
                //Conexion.Alta_Unidad_Defecto(new Modelos.Defecto { Id_Defecto = Convert.ToInt32(ddlDefecto.SelectedValue), defecto = ddlDefecto.SelectedItem.Text }, Globales.unidad_seleccionada.Id_Unidad);
                LlenarGridDefectos(false);
            }
        }


        //GRIDVIEW RETRABAJO
        protected void LlenarGridRetrabajo(DataSet ds)
        {

            gvRetrabajo.DataSource = ds;

            try
            {
                gvRetrabajo.DataBind();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void gvRetrabajo_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Limpiar el gvDefectos para la nueva seleccion
            btnRetrabajar.Enabled = true;
            Globales.defectos_seleccionados.Clear();
            Globales.defectos_seleccionados = Conexion.ConsultaDefectosLista(Convert.ToInt32(gvRetrabajo.SelectedRow.Cells[1].Text));

            LlenarGridDefectos(true); //Limpiar el gvDefectos para la nueva seleccion

            //ModificarInfoUnidad(true);
            MostrarInfoUnidad();

            Globales.unidad_seleccionada = new Modelos.Unidad
            {
                Id_Unidad = Convert.ToInt32(gvRetrabajo.SelectedRow.Cells[1].Text),
                FK_PartNumber = Convert.ToInt32(ddlPartNumber.SelectedValue),
                Work_Order = txtWorkOrder.Text,
                FK_Area = Convert.ToInt32(ddlArea.SelectedValue),
                Serial_Number = txtSerialNumber.Text,
                FK_Status = Convert.ToInt32(ddlStatus.SelectedValue)
            };

        }


        //GRIDVIEW DEFECTOS

        protected void LlenarGridDefectos(bool refresh)
        {
            if (Globales.defectos_seleccionados.Count != 0 || refresh)
            {
                gvDefectos.DataSource = Globales.defectos_seleccionados;
                gvDefectos.DataBind();
            }

        }

        protected void LlenarGridDefectosSeleccionados(bool refresh)
        {
            if (Globales.defectos_seleccionados.Count != 0 || refresh)
            {
                gvDefectosSelec.DataSource = Globales.defectos_seleccionados;
                gvDefectosSelec.DataBind();
            }

        }

        protected void gvDefectos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 3)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
            }
        }

        //BOTONES
        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                // Conexion.Modificar_Unidad(Globales.unidad_seleccionada, Conexion.ConsultaEstatus("CALIDAD"));

                MsgBox("Unidad modificada. Paso a estatus Calidad", this.Page, this);
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                MsgBox("Informacion incompleta", this.Page, this);
            }

        }

        protected void btnRetrabajar_Click(object sender, EventArgs e)
        {

            // MsgBox("Unidad modificada. Paso a estatus RWK", this.Page, this);
            btnRetrabajar.Text = "Retrabajando...";
            btnRetrabajar.Enabled = false;
            ddlStatus.SelectedValue = (ddlStatus.Items.FindByText("RWK").Value);

            //   Conexion.Modificar_Unidad(Globales.unidad_seleccionada, Conexion.ConsultaEstatus("RWK"));
            gvRetrabajo.Enabled = false;


            LlenarGridRetrabajo(Conexion.ConsultaUnidadEstatus(Conexion.ConsultaEstatus("RWK")));


            ModificarInfoUnidad(true);
        }

        //...
        protected void MostrarInfoUnidad()
        {
            LimpiarInfoUnidad();

            txtFechaEntrada.Text = Conexion.consultaFechaAlta(gvRetrabajo.SelectedRow.Cells[1].Text);
            txtWorkOrder.Text = gvRetrabajo.SelectedRow.Cells[2].Text;
            ddlPartNumber.SelectedValue = (ddlPartNumber.Items.FindByText(gvRetrabajo.SelectedRow.Cells[4].Text)).Value;
            txtSerialNumber.Text = gvRetrabajo.SelectedRow.Cells[5].Text;
            ddlStatus.SelectedValue = (ddlStatus.Items.FindByText(gvRetrabajo.SelectedRow.Cells[6].Text)).Value;
            if (gvRetrabajo.SelectedRow.Cells[7].Text != "&nbsp;")
            {
                txtFalla.Text = gvRetrabajo.SelectedRow.Cells[7].Text;
            }
            if (gvRetrabajo.SelectedRow.Cells[3].Text != "N/A")
            {
                ddlArea.SelectedValue = (ddlArea.Items.FindByText(gvRetrabajo.SelectedRow.Cells[3].Text)).Value;
            }
            //txtFechaSalida.Text = DateTime.Now.ToString();
        }

        protected void LimpiarInfoUnidad()
        {
            txtWorkOrder.Text = "";
            txtReferencia.Text = "";
            txtSerialNumber.Text = "";
            //tFechaSalida.Text = "";

            ddlPartNumber.SelectedIndex = 0;
            ddlDefecto.SelectedIndex = 0;
            ddlArea.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            // ddlEmpleado.SelectedIndex = 0;
            //ddlTurno.SelectedIndex = 0;

        }

        protected void ModificarInfoUnidad(bool modificable)
        {
            txtWorkOrder.Enabled = false;
            txtReferencia.Enabled = modificable;
            txtSerialNumber.Enabled = modificable;

            //txtFechaEntrada.Enabled = false;
            //txtFechaSalida.Enabled = false;
            btnScrap.Enabled = modificable;
            btnAlta.Enabled = modificable;
            ddlPartNumber.Enabled = modificable;
            ddlDefecto.Enabled = modificable;
            ddlArea.Enabled = false;
            ddlStatus.Enabled = false;
            gvDefectos.Enabled = false;
            gvDefectosSelec.Enabled = modificable;
            //  ddlEmpleado.Enabled = false;
            //ddlTurno.Enabled = false;

        }

        protected void btnScrap_Click(object sender, EventArgs e)
        {
            // Conexion.Modificar_Unidad(Globales.unidad_seleccionada, Conexion.ConsultaEstatus("SCRAP"));

            MsgBox("Unidad modificada. Paso a estatus de SCRAP", this.Page, this);
            Response.Redirect(Request.Url.ToString());
        }



        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected bool validarCampos()
        {
            if (txtSerialNumber.Text != "" && txtWorkOrder.Text != "" && txtReferencia.Text != "")
            {
                return true;
            }

            return false;
        }

        protected void gvRetrabajo_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 3)
            {
                //e.Row.Cells[1].Visible = false;
                //e.Row.Cells[7].Visible = false;
            }
        }

        protected void btnAgregarDefecto_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlDefecto.SelectedValue);

            if (!Globales.defectos_seleccionados.Exists(r => r.Id_Defecto == id) && txtReferencia.Text != "")
            {
                Globales.defectos_seleccionados.Add(new Modelos.Defecto { Id_Defecto = Convert.ToInt32(ddlDefecto.SelectedValue), defecto = ddlDefecto.SelectedItem.Text, Referencia = txtReferencia.Text });
                LlenarGridDefectosSeleccionados(false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGridRetrabajo(Conexion.ConsultaUnidadFiltro(Conexion.ConsultaEstatus("RWK"), txtBuscarWO.Text, txtBuscarSN.Text));

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarInfoUnidad();
            txtBuscarSN.Text = "";
            txtBuscarWO.Text = "";
            LlenarGridRetrabajo(Conexion.ConsultaUnidadEstatus(Conexion.ConsultaEstatus("RWK")));
        }

        protected void gvDefectosSelec_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvDefectos.SelectedRow.Cells[1].Text);
            // string codigo = gvDefectos.SelectedRow.Cells[2].Text;

            var itemToRemove = Globales.defectos_seleccionados.Single(r => r.Id_Defecto == id);
            Globales.defectos_seleccionados.Remove(itemToRemove);
            // Conexion.eliminarUnidad_Defecto(Globales.unidad_seleccionada, itemToRemove);

            LlenarGridDefectosSeleccionados(true);
        }

        protected void gvDefectosSelec_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 3)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
            }
        }
    }
}