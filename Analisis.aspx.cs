using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstadiaMWE
{
    public partial class Analisis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombre_Empleado"] == null)
            {
                Response.Redirect("MenuPrincipal.aspx");
            }
            else
            {
                LlenarGridAnalisis(Conexion.ConsultaUnidadEstatus(Conexion.ConsultaEstatus("Analisis")));

                if (!IsPostBack)
                {
                    ModificarInfoUnidad(false);
                    LlenarDdlBD(ddlArea, "CAT_AREA", "Area", "Id_Area");
                    LlenarDdlBD(ddlPartNumber, "CAT_NUMPARTE", "Num_Parte", "Id_NumParte");
                    LlenarDdlBD(ddlDefecto, "CAT_DEFECTO", "FullDefecto", "Id_Defecto");
                    LlenarDdlBD(ddlStatus, "CAT_STATUS", "Nombre_status", "Id_Status");
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
            //gvAnalisis.DataSource = null;
            //gvAnalisis.DataBind();
            Globales.txtBuscarWO = txtBuscarWO.Text;
            Globales.txtBuscarSN = txtBuscarSN.Text;

            Globales.cambiarTexto();
            gvAnalisis.DataSource = Globales.ds;

            try
            {
                gvAnalisis.DataBind();
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
                LlenarGridAnalisis(Conexion.ConsultaUnidadFiltro(Conexion.ConsultaEstatus("Analisis"), txtBuscarWO.Text, txtBuscarSN.Text));
            }
            else
            {
                LlenarGridAnalisis(Conexion.ConsultaUnidadEstatus(Conexion.ConsultaEstatus("Analisis")));
            }

            Globales.defectos_seleccionados = Conexion.ConsultaDefectosLista(Convert.ToInt32(gvAnalisis.SelectedRow.Cells[2].Text));
            //Globales.unidad_seleccionada.Id_Unidad = Convert.ToInt32(gvAnalisis.SelectedRow.Cells[1].Text);
            LlenarGridDefectos(true);

            ModificarInfoUnidad(true);
            // btnModificar.Enabled = true;
            MostrarInfoUnidad();

            if (Globales.multiseleccion)
            {
                //int id = ;

                if (!Globales.unidades_seleccionadas.Exists(r => r.Id_Unidad == Convert.ToInt32(gvAnalisis.SelectedRow.Cells[2].Text)))
                {
                    Globales.unidades_seleccionadas.Add(new Modelos.Unidad
                    {
                        Id_Unidad = Convert.ToInt32(gvAnalisis.SelectedRow.Cells[2].Text)
                    });
                }

                foreach (GridViewRow row in gvAnalisis.Rows)
                {
                    if (Globales.unidades_seleccionadas.Exists(r => r.Id_Unidad == Convert.ToInt32(row.Cells[2].Text)))
                    {
                        colorsito(row);
                    }
                }
            }

            //Globales.unidad_seleccionada = new Modelos.Unidad
            //{
            //    Id_Unidad = Convert.ToInt32(gvAnalisis.SelectedRow.Cells[1].Text),
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
            int id = Convert.ToInt32(gvDefectos.SelectedRow.Cells[2].Text);

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
        protected void btnRWK_Click(object sender, EventArgs e)
        {
            if (gvDefectos.Rows.Count != 0 && validarCampos())
            {
                Conexion.Modificar_Unidad(Conexion.ConsultaEstatus("RWK"));

                Response.Redirect(Request.Url.ToString());
                MsgBox("Unidad enviada.", this.Page, this);
            }
            else
            {
                MsgBox("Informacion incompleta", this.Page, this);
            }

        }

        protected void btnCalidad_Click(object sender, EventArgs e)
        {
            if (gvDefectos.Rows.Count != 0 && validarCampos())
            {
                Globales.unidad_seleccionada.Id_Unidad = Convert.ToInt32(gvAnalisis.SelectedRow.Cells[2].Text);
                Globales.unidad_seleccionada.FK_PartNumber = Convert.ToInt32(ddlPartNumber.SelectedValue);
                Globales.unidad_seleccionada.Work_Order = txtWorkOrder.Text;
                Globales.unidad_seleccionada.FK_Area = Convert.ToInt32(ddlArea.SelectedValue);
                Globales.unidad_seleccionada.Serial_Number = txtSerialNumber.Text;
                Globales.unidad_seleccionada.FK_Status = Convert.ToInt32(ddlStatus.SelectedValue);
                Globales.unidad_seleccionada.Falla = txtFalla.Text;

                Conexion.Modificar_Unidad(Conexion.ConsultaEstatus("Calidad"));

                Response.Redirect(Request.Url.ToString());
                MsgBox("Unidad enviada.", this.Page, this);
            }
            else
            {
                MsgBox("Informacion incompleta", this.Page, this);
            }
        }


        protected void btnScrap_Click(object sender, EventArgs e)
        {
            if (gvDefectos.Rows.Count != 0 && validarCampos())
            {

                Globales.unidad_seleccionada.Id_Unidad = Convert.ToInt32(gvAnalisis.SelectedRow.Cells[2].Text);
                Globales.unidad_seleccionada.FK_PartNumber = Convert.ToInt32(ddlPartNumber.SelectedValue);
                Globales.unidad_seleccionada.Work_Order = txtWorkOrder.Text;
                Globales.unidad_seleccionada.FK_Area = Convert.ToInt32(ddlArea.SelectedValue);
                Globales.unidad_seleccionada.Serial_Number = txtSerialNumber.Text;
                Globales.unidad_seleccionada.FK_Status = Convert.ToInt32(ddlStatus.SelectedValue);
                Globales.unidad_seleccionada.Falla = txtFalla.Text;

                Conexion.Modificar_Unidad(Conexion.ConsultaEstatus("Scrap"));
                // Conexion.Modificar_Unidad(Globales.unidad_seleccionada, Conexion.ConsultaEstatus("Scrap"));

                Response.Redirect(Request.Url.ToString());
                MsgBox("Unidad enviada.", this.Page, this);
            }
            else
            {
                MsgBox("Informacion incompleta", this.Page, this);
            }


            //Conexion.Modificar_Unidad(new Modelos.Unidad
            //{
            //    Id_Unidad = Convert.ToInt32(gvAnalisis.SelectedRow.Cells[1].Text),
            //    FK_PartNumber = Convert.ToInt32(ddlPartNumber.SelectedValue),
            //    Work_Order = txtWorkOrder.Text,
            //    FK_Area = Convert.ToInt32(ddlArea.SelectedValue),
            //    Serial_Number = txtSerialNumber.Text,
            //    FK_Status = Convert.ToInt32(ddlStatus.SelectedValue)
            //},
            //Conexion.ConsultaEstatus("SCRAP"));

            //MsgBox("Unidad modificada. Paso a estatus de SCRAP", this.Page, this);
            //Response.Redirect(Request.Url.ToString());

            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seguro?????')", true);
        }

        //...

        protected void MostrarInfoUnidad()
        {
            LimpiarInfoUnidad();

            txtFechaEntrada.Text = Conexion.consultaFechaAlta(gvAnalisis.SelectedRow.Cells[2].Text);
            txtWorkOrder.Text = gvAnalisis.SelectedRow.Cells[3].Text;
            ddlPartNumber.SelectedValue = (ddlPartNumber.Items.FindByText(gvAnalisis.SelectedRow.Cells[5].Text)).Value;
            txtSerialNumber.Text = gvAnalisis.SelectedRow.Cells[6].Text;
            ddlStatus.SelectedValue = (ddlStatus.Items.FindByText(gvAnalisis.SelectedRow.Cells[7].Text)).Value;

            txtFalla.Text = gvAnalisis.SelectedRow.Cells[8].Text;

        }

        protected void colorsito(GridViewRow row)
        {
            row.BackColor = Color.Pink;
        }

        protected void LimpiarInfoUnidad()
        {
            txtWorkOrder.Text = "";
            txtSerialNumber.Text = "";
            txtFechaEntrada.Text = "";
            txtReferencia.Text = "";

            ddlPartNumber.SelectedIndex = 0;
            ddlDefecto.SelectedIndex = 0;
            ddlArea.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            // ddlEmpleado.SelectedIndex = 0;

        }

        protected void ModificarInfoUnidad(bool modificable)
        {
            txtWorkOrder.Enabled = false;
            txtSerialNumber.Enabled = false;
            txtFechaEntrada.Enabled = false;
            txtReferencia.Enabled = modificable;
            ddlPartNumber.Enabled = false;
            ddlDefecto.Enabled = modificable;
            ddlArea.Enabled = modificable;
            ddlStatus.Enabled = false;
            txtFalla.Enabled = false;
            // ddlEmpleado.Enabled = false;

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
                //e.Row.Cells[1].Visible = false;
                //e.Row.Cells[3].Visible = false;
            }
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //Globales.busqueda = true;
            //if (txtBuscarWO.Text != "" || txtBuscarSN.Text != "")
            //{
            //    LlenarGridAnalisis(Conexion.ConsultaUnidadFiltro(Conexion.ConsultaEstatus("Analisis"), txtBuscarWO.Text, txtBuscarSN.Text));
            //    txtBuscarWO.Enabled = false;
            //}
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            
            LimpiarInfoUnidad();
            txtBuscarSN.Text = "";
            txtBuscarWO.Text = "";
            LlenarGridAnalisis(Conexion.ConsultaUnidadEstatus(Conexion.ConsultaEstatus("Analisis")));
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (Globales.multiseleccion)
            {
                Globales.multiseleccion = false;
            }
            else
            {
                Globales.multiseleccion = true;
            }
        }


        public void cambiarTexto()
        {
            if (txtBuscarWO.Text != "")
            {
                LlenarGridAnalisis(Conexion.ConsultaUnidadFiltro(Conexion.ConsultaEstatus("Analisis"), txtBuscarWO.Text, txtBuscarSN.Text));
            }
            else
            {
                if (txtBuscarSN.Text == "")
                {
                    LlenarGridAnalisis(Conexion.ConsultaUnidadEstatus(Conexion.ConsultaEstatus("Analisis")));
                }
            }
        }

        protected void txtBuscarWO_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarWO.Text != "")
            {
                LlenarGridAnalisis(Conexion.ConsultaUnidadFiltro(Conexion.ConsultaEstatus("Analisis"), txtBuscarWO.Text, txtBuscarSN.Text));
            }
            else
            {
                if (txtBuscarSN.Text == "")
                {
                    LlenarGridAnalisis(Conexion.ConsultaUnidadEstatus(Conexion.ConsultaEstatus("Analisis")));
                }
            }
        }

        protected void txtBuscarSN_TextChanged(object sender, EventArgs e)
        {
           

            if (txtBuscarSN.Text != "")
            {
                LlenarGridAnalisis(Conexion.ConsultaUnidadFiltro(Conexion.ConsultaEstatus("Analisis"), txtBuscarWO.Text, txtBuscarSN.Text));
            }
            else
            {
                if (txtBuscarWO.Text == "")
                {
                    LlenarGridAnalisis(Conexion.ConsultaUnidadEstatus(Conexion.ConsultaEstatus("Analisis")));
                }
            }
        }

    }

}