using EstadiaMWE.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstadiaMWE
{
    public partial class AltaUnidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Nombre_Empleado"] == null)
            {
                Globales.usuario_actual = Conexion.obtenerUsuarioGuest();
            }

            lblusuario.Text = Globales.usuario_actual.Nombre_Empleado;
            if (!IsPostBack)
            {
                Globales.defectos_seleccionados.Clear();
                Globales.num_serie.Clear();
                LlenarDdlBD(ddlPartNumber, "CAT_NUMPARTE", "Num_Parte", "Id_NumParte");
                LlenarDdlBD(ddlArea, "CAT_AREA", "Area", "Id_Area");
                LlenarDdlBD(ddlDefecto, "CAT_DEFECTO", "FullDefecto", "Id_Defecto");
            }
        }

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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarInfoUnidad();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                //if (gvDefectos.Rows.Count > 0)
                //{
                //    estatus = Conexion.ConsultaEstatus("Analisis").Id_Status;
                //}

                Conexion.Alta_Unidad(new Modelos.Unidad
                {
                    FK_PartNumber = Convert.ToInt32(ddlPartNumber.SelectedValue),
                    Work_Order = txtNumOrden.Text,
                    FK_Area = Convert.ToInt32(ddlArea.SelectedValue),
                    Serial_Number = txtNumSerie.Text,
                    FK_Status = Conexion.ConsultaEstatus("RWK").Id_Status,
                }, "RWK") ;

                LimpiarInfoUnidad();

                MsgBox("Registro exitoso!", this.Page, this);
            }
            else
            {
                MsgBox("Informacion incompleta", this.Page, this);
            }
        }


        protected bool validarCampos()
        {
            if (txtNumOrden.Text != "" && gvNumSerie.Rows.Count > 0 && gvDefectos.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        protected void LimpiarInfoUnidad()
        {
            txtNumOrden.Text = "";
            txtNumSerie.Text = "";
            ddlPartNumber.SelectedIndex = 0;
            ddlDefecto.SelectedIndex = 0;
            ddlArea.SelectedIndex = 0;

            Globales.defectos_seleccionados.Clear();
            Globales.num_serie.Clear();
            LlenarGridDefectos(true);

        }


        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void btnAgregarNumSerie_Click(object sender, EventArgs e)
        {
            if (txtNumSerie.Text != "" && !Globales.num_serie.Exists(r => r == txtNumSerie.Text))
            {
                Globales.num_serie.Add(txtNumSerie.Text);
            }
            LlenarGridNumSerie(false);

        }

        protected void btnQTY_Click(object sender, EventArgs e)
        {
            if (txtQTY.Text != "" && txtserieinicial.Text != "")
            {
                int inicial = Convert.ToInt32(txtserieinicial.Text);

                for (int i = 0; i < Convert.ToInt32(txtQTY.Text); i++)
                {
                    Globales.num_serie.Add(inicial++.ToString());
                }
            }
            LlenarGridNumSerie(false);
        }

        protected void gvNumSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemToRemove = Globales.num_serie.Single(r => r == gvNumSerie.SelectedRow.Cells[1].Text);
            Globales.num_serie.Remove(itemToRemove);
            LlenarGridNumSerie(true);
        }

        protected void LlenarGridNumSerie(bool refresh)
        {
            if (Globales.num_serie.Count != 0 || refresh)
            {
                gvNumSerie.DataSource = Globales.num_serie;
                gvNumSerie.DataBind();
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
    }
}