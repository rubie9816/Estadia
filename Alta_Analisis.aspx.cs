using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstadiaMWE
{
    public partial class Alta_Analisis : System.Web.UI.Page
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
                Globales.num_serie.Clear();
                LlenarDdlBD(ddlPartNumber, "CAT_NUMPARTE", "Num_Parte", "Id_NumParte");
            }
        }
        protected void LlenarDdlBD(DropDownList ddl, string tabla, string nombre, string id)
        {
            ddl.DataSource = Conexion.ConsultaGeneral(tabla);
            ddl.DataTextField = nombre;
            ddl.DataValueField = id;
            ddl.DataBind();
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
                    FK_Status = Conexion.ConsultaEstatus("Analisis").Id_Status,
                    Falla = txtFalla.Text
                }, "Analisis");

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
            if (txtNumOrden.Text != "" && txtFalla.Text != "" && gvNumSerie.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

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
            LlenarGrid(false);
        }

        protected void LlenarGrid(bool refresh)
        {
            if (Globales.num_serie.Count != 0 || refresh)
            {
                gvNumSerie.DataSource = Globales.num_serie;
                gvNumSerie.DataBind();
            }

        }

        protected void gvNumSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemToRemove = Globales.num_serie.Single(r => r == gvNumSerie.SelectedRow.Cells[1].Text);
            Globales.num_serie.Remove(itemToRemove);
            LlenarGrid(true);
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
            LlenarGrid(false);
        }

        protected void LimpiarInfoUnidad()
        {
            txtNumOrden.Text = "";
            txtNumSerie.Text = "";
            txtFalla.Text = "";
            txtQTY.Text = "";
            txtserieinicial.Text = "";
            ddlPartNumber.SelectedIndex = 0;
            Globales.num_serie.Clear();
            LlenarGrid(true);
        }

    }
}