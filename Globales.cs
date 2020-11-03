using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EstadiaMWE
{
    public class Globales
    {
        public static bool multiseleccion;

       // public static bool busqueda;
        
        public static List<Modelos.Defecto> defectos_seleccionados = new List<Modelos.Defecto>();

        //public static List<string> referencias = new List<string>();

        public static List<string> num_serie = new List<string>();

        // public static List<Modelos.Defecto> defectos_INICIAL = new List<Modelos.Defecto>();

        public static Modelos.Usuario usuario_actual = new Modelos.Usuario();

        public static Modelos.Unidad unidad_seleccionada = new Modelos.Unidad();

        public static List<Modelos.Unidad> unidades_seleccionadas = new List<Modelos.Unidad>();


        public static string fecha_seleccionada = "";
        // public static List<Modelos.Status> lista_estatus = new List<Modelos.Status>();


        public static string txtBuscarWO;

        public static string txtBuscarSN;

        public static DataSet ds;

        public static Object cambiarTexto()
        {

            if (txtBuscarWO != "")
            {
                ds = (Conexion.ConsultaUnidadFiltro(Conexion.ConsultaEstatus("Analisis"), txtBuscarWO, txtBuscarSN));
            }
            else
            {
                if (txtBuscarSN == "")
                {
                    ds = (Conexion.ConsultaUnidadEstatus(Conexion.ConsultaEstatus("Analisis")));
                }
            }

            return null;
        }
    }
}