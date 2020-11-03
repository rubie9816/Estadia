using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstadiaMWE
{
    public partial class Modificaciones : System.Web.UI.Page

    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Nombre_Empleado"] == null)
            {
                Response.Redirect("MenuPrincipal.aspx");
            }
            else
            {

                if (txtBuscarWO.Text != "" || txtBuscarSN.Text != "")
                {
                    LlenarGridAnalisis(Conexion.ConsultaUnidadFiltro(new Modelos.Status { Nombre_Status = "All" }, txtBuscarWO.Text, txtBuscarSN.Text));
                }
                else
                {
                    LlenarGridAnalisis(Conexion.ConsultaUnidadEstatus(new Modelos.Status { Nombre_Status = "All" }));
                }
                btnModificar.Enabled = false;

                if (!IsPostBack)
                {
                    ModificarInfoUnidad(false);
                    //LlenarDdlBD(ddlTurno, "CAT_TURNO", "Turno", "Id_Turno");
                    LlenarDdlBD(ddlArea, "CAT_AREA", "Area", "Id_Area");
                    LlenarDdlBD(ddlPartNumber, "CAT_NUMPARTE", "Num_Parte", "Id_NumParte");
                    LlenarDdlBD(ddlDefecto, "CAT_DEFECTO", "FullDefecto", "Id_Defecto");
                    LlenarDdlBD(ddlStatus, "CAT_STATUS", "Nombre_status", "Id_Status");

                    //Agregar el Guest al dropDownList
                    //ListItem item = new ListItem { Text = "Guest", Value = "-1" };
                    //ddlEmpleado.Items.Add(item);
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
            //int id = Convert.ToInt32(ddlDefecto.SelectedValue);

            //if (!Globales.defectos_seleccionados.Exists(r => r.Id_Defecto == id))
            //{
            //    Globales.defectos_seleccionados.Add(new Modelos.Defecto { Id_Defecto = Convert.ToInt32(ddlDefecto.SelectedValue), defecto = ddlDefecto.SelectedItem.Text });
            //    LlenarGridDefectos(false);
            //}
        }



        //GRIDVIEW ANALISIS
        protected void LlenarGridAnalisis(DataSet ds)
        {
            gvUnidades.DataSource = ds;

            try
            {
                gvUnidades.DataBind();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void gvAnalisis_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpiar el gvDefectos para la nueva seleccion
            Globales.defectos_seleccionados.Clear();
            if (txtBuscarWO.Text != "" || txtBuscarSN.Text != "")
            {
                LlenarGridAnalisis(Conexion.ConsultaUnidadFiltro(new Modelos.Status { Nombre_Status = "All" }, txtBuscarWO.Text, txtBuscarSN.Text));
            }
            else
            {
                LlenarGridAnalisis(Conexion.ConsultaUnidadEstatus(new Modelos.Status { Nombre_Status = "All" }));
            }
            Globales.defectos_seleccionados = Conexion.ConsultaDefectosLista(Convert.ToInt32(gvUnidades.SelectedRow.Cells[1].Text));
            LlenarGridDefectos(true);

            ModificarInfoUnidad(false);
            btnModificar.Enabled = true;
            MostrarInfoUnidad();

            //Globales.unidad_seleccionada = new Modelos.Unidad
            //{
            //    Id_Unidad = Convert.ToInt32(gvUnidades.SelectedRow.Cells[1].Text),
            //    FK_PartNumber = Convert.ToInt32(ddlPartNumber.SelectedValue),
            //    Work_Order = txtWorkOrder.Text,
            //    FK_Area = Convert.ToInt32(ddlArea.SelectedValue),
            //    Serial_Number = txtSerialNumber.Text,
            //    FK_Status = Convert.ToInt32(ddlStatus.SelectedValue),
            //    Falla = txtFalla.Text
            //};
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
        protected void gvDefectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvDefectos.SelectedRow.Cells[1].Text);

            var itemToRemove = Globales.defectos_seleccionados.Single(r => r.Id_Defecto == id);
            Globales.defectos_seleccionados.Remove(itemToRemove);

            LlenarGridDefectos(true);
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
                Globales.unidad_seleccionada.Id_Unidad = Convert.ToInt32(gvUnidades.SelectedRow.Cells[1].Text);
                Globales.unidad_seleccionada.FK_PartNumber = Convert.ToInt32(ddlPartNumber.SelectedValue);
                Globales.unidad_seleccionada.Work_Order = txtWorkOrder.Text;
                Globales.unidad_seleccionada.FK_Area = Convert.ToInt32(ddlArea.SelectedValue);
                Globales.unidad_seleccionada.Serial_Number = txtSerialNumber.Text;
                Globales.unidad_seleccionada.FK_Status = Convert.ToInt32(ddlStatus.SelectedValue);
                Globales.unidad_seleccionada.Falla = txtFalla.Text;

                Conexion.Modificar_Unidad( Conexion.ConsultaEstatus("Analisis"));

                LimpiarInfoUnidad();
                if (txtBuscarWO.Text != "" || txtBuscarSN.Text != "")
                {
                    LlenarGridAnalisis(Conexion.ConsultaUnidadFiltro(new Modelos.Status { Nombre_Status = "All" }, txtBuscarWO.Text, txtBuscarSN.Text));
                }
                else
                {
                    LlenarGridAnalisis(Conexion.ConsultaUnidadEstatus(new Modelos.Status { Nombre_Status = "All" }));
                }
            }
            else
            {
                MsgBox("Informacion incompleta", this.Page, this);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }

        //...
        protected void MostrarInfoUnidad()
        {
            LimpiarInfoUnidad();

            txtFechaEntrada.Text = Conexion.consultaFechaAlta(gvUnidades.SelectedRow.Cells[1].Text);
            txtWorkOrder.Text = gvUnidades.SelectedRow.Cells[2].Text;
            ddlPartNumber.SelectedValue = (ddlPartNumber.Items.FindByText(gvUnidades.SelectedRow.Cells[4].Text)).Value;
            txtSerialNumber.Text = gvUnidades.SelectedRow.Cells[5].Text;
            ddlStatus.SelectedValue = (ddlStatus.Items.FindByText(gvUnidades.SelectedRow.Cells[6].Text)).Value;
            if (gvUnidades.SelectedRow.Cells[7].Text != "N/A")
            {
                txtFalla.Text = gvUnidades.SelectedRow.Cells[7].Text;
            }
            if (gvUnidades.SelectedRow.Cells[3].Text != "N/A")
            {
                ddlArea.SelectedValue = (ddlArea.Items.FindByText(gvUnidades.SelectedRow.Cells[3].Text)).Value;
            }
        }

        protected void LimpiarInfoUnidad()
        {
            txtWorkOrder.Text = "";
            txtSerialNumber.Text = "";
            txtFechaEntrada.Text = "";
            txtReferencia.Text = "";
            txtFalla.Text = "";
            ddlPartNumber.SelectedIndex = 0;
            ddlDefecto.SelectedIndex = 0;
            ddlArea.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;

        }

        protected void ModificarInfoUnidad(bool modificable)
        {
            txtWorkOrder.Enabled = modificable;
            txtSerialNumber.Enabled = modificable;
            gvDefectos.Enabled = modificable;
            ddlPartNumber.Enabled = modificable;
            ddlDefecto.Enabled = modificable;
            ddlArea.Enabled = modificable;
            ddlStatus.Enabled = false;
            txtReferencia.Enabled = modificable;
            txtFalla.Enabled = modificable;
            txtFechaEntrada.Enabled = false;

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarInfoUnidad(true);
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
            if (txtSerialNumber.Text != "" && txtWorkOrder.Text != "")
            {
                return true;
            }

            return false;
        }

        protected void gvAnalisis_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
                //    e.Row.Cells[7].Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGridAnalisis(Conexion.ConsultaUnidadFiltro(new Modelos.Status { Nombre_Status = "All" }, txtBuscarWO.Text, txtBuscarSN.Text));

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarInfoUnidad();
            txtBuscarSN.Text = "";
            txtBuscarWO.Text = "";
            LlenarGridAnalisis(Conexion.ConsultaUnidadEstatus(new Modelos.Status { Nombre_Status = "All" }));

        }

        protected void btnAgregarDefecto_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlDefecto.SelectedValue);

            if (!Globales.defectos_seleccionados.Exists(r => r.Id_Defecto == id) && txtReferencia.Text != "")
            {
                Globales.defectos_seleccionados.Add(new Modelos.Defecto { Id_Defecto = Convert.ToInt32(ddlDefecto.SelectedValue), defecto = ddlDefecto.SelectedItem.Text, Referencia = txtReferencia.Text });
                LlenarGridDefectos(false);
            }
        }
    }
}