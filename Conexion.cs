using EstadiaMWE.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace EstadiaMWE
{
    public static class Conexion
    {


        private static SqlConnection miconexion = new SqlConnection(@"Data Source=DESKTOP-5N6URFE\SQLEXPRESS;Initial Catalog=ayrDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");

        //private static void Abrir()
        //{
        //    miconexion.Open();
        //}

        //private static void Cerrar()
        //{
        //    miconexion.Close();
        //}

        #region Altas

        //public static void Alta_Unidad(Modelos.Unidad nuevaUnidad)
        //{
        //    foreach (var numero_serie in Globales.num_serie)
        //    {
        //        miconexion.Open();
        //        SqlCommand cmd = miconexion.CreateCommand();

        //        cmd.CommandText = " INSERT INTO UNIDAD(Work_Order, FK_PartNumber, Serial_Number, FK_Status, Falla) values('" + nuevaUnidad.Work_Order + "',"
        //            + nuevaUnidad.FK_PartNumber + ",'"
        //            + numero_serie + "',"
        //            + nuevaUnidad.FK_Status + ",'"
        //            + nuevaUnidad.Falla + "')";

        //        cmd.ExecuteNonQuery();

        //        miconexion.Close();

        //        Alta_Bitacora(new Modelos.Bitacora
        //        {
        //            FK_Unidad = obtenerUltimoID("UNIDAD"),
        //            _Status = "Analisis",
        //            _Turno = int.Parse(DateTime.Now.TimeOfDay.ToString("hh")) >= 5 && int.Parse(DateTime.Now.TimeOfDay.ToString("hh")) <= 16 ? "Primero" : "Segundo",
        //            _NumEmpleado = Globales.usuario_actual.Num_Empleado,
        //            // _NumEmpleado = Globales.usuario_actual.Num_Empleado != "0" ? Globales.usuario_actual.Num_Empleado.ToString() : "Guest",
        //            Fecha = DateTime.Now,
        //        }); ;
        //    }
        //}

        public static void Alta_Unidad(Modelos.Unidad nuevaUnidad, string estatus)
        {
            foreach (var numero_serie in Globales.num_serie)
            {
                miconexion.Open();
                SqlCommand cmd = miconexion.CreateCommand();
                cmd.CommandText = " INSERT INTO UNIDAD(Work_Order,";

                if (estatus != "Analisis")
                {
                    cmd.CommandText += "FK_Area,";
                }

                cmd.CommandText += "FK_PartNumber, Serial_Number, FK_Status";

                if (nuevaUnidad.Falla != null)
                {
                    cmd.CommandText += ", Falla";
                }

                cmd.CommandText += ") values('" + nuevaUnidad.Work_Order + "',";


                if (estatus != "Analisis")
                {
                    cmd.CommandText += nuevaUnidad.FK_Area + ",";
                }

                cmd.CommandText += nuevaUnidad.FK_PartNumber + ",'" + numero_serie + "'," + nuevaUnidad.FK_Status;

                if (nuevaUnidad.Falla != null)
                {
                    cmd.CommandText += ",'" + nuevaUnidad.Falla + "'";
                }

                cmd.CommandText += ")";

                cmd.ExecuteNonQuery();

                miconexion.Close();

                Alta_Bitacora(new Modelos.Bitacora
                {
                    FK_Unidad = obtenerUltimoID("UNIDAD"),
                    _Status = estatus,
                    _Turno = int.Parse(DateTime.Now.TimeOfDay.ToString("hh")) >= 5 && int.Parse(DateTime.Now.TimeOfDay.ToString("hh")) <= 16 ? "Primero" : "Segundo",
                    _NumEmpleado = Globales.usuario_actual.Num_Empleado,
                    Fecha = DateTime.Now,
                }); ;

                if (nuevaUnidad.FK_Status == ConsultaEstatus("RWK").Id_Status)
                {
                    //AGREGAR DEFECTOS DE LA UNIDAD SI EXISTEN
                    int i = 0;
                    foreach (var defecto in Globales.defectos_seleccionados)
                    {
                        Alta_Unidad_Defecto(defecto, true);
                        i++;
                    }

                }
            }

        }

        internal static DataSet ConsultaUnidadFiltro(Status status)
        {
            throw new NotImplementedException();
        }

        private static void Alta_Bitacora(Modelos.Bitacora bitacora)
        {
            miconexion.Open();
            SqlCommand cmd = miconexion.CreateCommand();

            cmd.CommandText = "INSERT INTO BITACORA values(" + bitacora.FK_Unidad +
                ",'" + bitacora._Status +
                "','" + bitacora._Turno +
                "','" + bitacora._NumEmpleado +
                "','" + bitacora.Fecha + "')";

            cmd.ExecuteNonQuery();
            miconexion.Close();
        }

        public static void Alta_Unidad_Defecto(Modelos.Defecto defecto, bool nuevo)
        {
            int id_unidad = Globales.unidad_seleccionada.Id_Unidad;

            if (nuevo)
            {
                id_unidad = obtenerUltimoID("UNIDAD");
            }

            SqlCommand cmd = miconexion.CreateCommand();
            cmd.CommandText = " INSERT INTO UNIDAD_DEFECTO values(" + id_unidad + "," + defecto.Id_Defecto + ",'" + defecto.Referencia + "')";
            miconexion.Open();
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

            }

            miconexion.Close();

        }

        #endregion

        #region Modificaciones
        public static void Modificar_Unidad(Modelos.Status estatus)
        {
            miconexion.Open();
            SqlCommand cmd = miconexion.CreateCommand();


            cmd.CommandText = " UPDATE UNIDAD SET " +
                "Work_Order = '" + Globales.unidad_seleccionada.Work_Order + "'," +
                "FK_Area = " + Globales.unidad_seleccionada.FK_Area + "," +
                "FK_PartNumber = " + Globales.unidad_seleccionada.FK_PartNumber + "," +
                "Serial_Number = '" + Globales.unidad_seleccionada.Serial_Number + "'," +
                "FK_Status = " + estatus.Id_Status;

            if (Globales.unidad_seleccionada.Falla != "")
            {
                cmd.CommandText += ",Falla = '" + Globales.unidad_seleccionada.Falla + "'";
            }

            cmd.CommandText += " WHERE Id_Unidad = " + Globales.unidad_seleccionada.Id_Unidad;

            cmd.ExecuteNonQuery();

            miconexion.Close();

            if (Globales.unidad_seleccionada.FK_Status != estatus.Id_Status)
            {
                Alta_Bitacora(new Modelos.Bitacora
                {
                    FK_Unidad = Globales.unidad_seleccionada.Id_Unidad,
                    _Status = estatus.Nombre_Status,
                    _Turno = int.Parse(DateTime.Now.TimeOfDay.ToString("hh")) >= 5 && int.Parse(DateTime.Now.TimeOfDay.ToString("hh")) <= 16 ? "Primero" : "Segundo",
                    _NumEmpleado = Globales.usuario_actual.Num_Empleado.ToString(),
                    Fecha = DateTime.Now
                });

            }
            filtrarDefectos();

        }
        #endregion

        #region Validaciones
        public static bool validarUsuario(string usuario, string password)
        {
            miconexion.Open();
            SqlCommand cmd = new SqlCommand("select * from USUARIO where username = '" + usuario + "' and password = '" + password + "'", miconexion);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                miconexion.Close();
                return true;
            }
            else
            {
                miconexion.Close();
                return false;
            }
        }
        #endregion

        #region Consultas
        public static DataSet ConsultaGeneral(string tabla)
        {
            string query = "";
            switch (tabla)
            {
                case "CAT_DEFECTO":
                    query = "SELECT Id_Defecto, Codigo, Descripcion, Codigo + ' ' + Descripcion AS FullDefecto FROM CAT_DEFECTO";
                    break;
                default:
                    query = "SELECT * FROM " + tabla;
                    break;
            }
            miconexion.Open();
            SqlCommand cmd = new SqlCommand(query, miconexion);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            miconexion.Close();
            return ds;
        }

        public static DataSet consultaReporte()
        {
            string query = "SELECT UNIDAD.Id_Unidad, UNIDAD.Serial_Number, UNIDAD.Work_Order,CAT_AREA.Area as Area,CAT_NUMPARTE.Num_Parte as Part_Number, CAT_STATUS.Nombre_status as Estatus, BITACORA._NumEmpleado as Empleado, BITACORA._Turno as Turno from UNIDAD INNER JOIN BITACORA ON UNIDAD.Id_Unidad = BITACORA.FK_Unidad INNER JOIN CAT_STATUS ON UNIDAD.FK_Status = CAT_STATUS.Id_Status AND CAT_STATUS.Nombre_status = BITACORA._Status  INNER JOIN CAT_AREA ON UNIDAD.FK_Area = CAT_AREA.Id_Area INNER JOIN CAT_NUMPARTE ON UNIDAD.FK_PartNumber = CAT_NUMPARTE.Id_NumParte ";


            miconexion.Open();
            SqlCommand cmd = new SqlCommand(query, miconexion);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            miconexion.Close();
            return ds;
        }

        public static DataSet consultaReporte(string empleado, string estatus, string turno, string wo, int partnumber, string serialnumber)
        {
            int i = 0;

            string query = "SELECT UNIDAD.Id_Unidad, UNIDAD.Serial_Number, UNIDAD.Work_Order,CAT_AREA.Area as Area,CAT_NUMPARTE.Num_Parte as Part_Number, CAT_STATUS.Nombre_status as Estatus, BITACORA._NumEmpleado as Empleado, BITACORA._Turno as Turno from UNIDAD INNER JOIN BITACORA ON UNIDAD.Id_Unidad = BITACORA.FK_Unidad INNER JOIN CAT_STATUS ON UNIDAD.FK_Status = CAT_STATUS.Id_Status AND CAT_STATUS.Nombre_status = BITACORA._Status  INNER JOIN CAT_AREA ON UNIDAD.FK_Area = CAT_AREA.Id_Area INNER JOIN CAT_NUMPARTE ON UNIDAD.FK_PartNumber = CAT_NUMPARTE.Id_NumParte " +
                "WHERE ";

            if (empleado != "Select All")
            {
                query += "BITACORA._NumEmpleado = '" + empleado + "'";
                i++;
            }
            if (estatus != "Select All")
            {
                if (i > 0)
                {
                    query += " and ";
                }

                query += "BITACORA._Status = '" + estatus + "'";
                i++;
            }
            if (turno != "Select All")
            {
                if (i > 0)
                {
                    query += " and ";
                }

                query += "BITACORA._Turno = '" + turno + "'";
            }
            if (wo != "")
            {
                if (i > 0)
                {
                    query += " and ";
                }

                query += "UNIDAD.Work_Order = '" + wo + "'";
            }
            if (partnumber != -1)
            {
                if (i > 0)
                {
                    query += " and ";
                }

                query += "UNIDAD.FK_PartNumber = " + partnumber + "";
            }
            if (serialnumber != "")
            {
                if (i > 0)
                {
                    query += " and ";
                }

                query += "UNIDAD.Serial_Number = '" + serialnumber + "'";
            }

            miconexion.Open();
            SqlCommand cmd = new SqlCommand(query, miconexion);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            miconexion.Close();
            return ds;
        }

        public static DataSet consultaBitacora()
        {
            string query = "SELECT UNIDAD.Id_Unidad, UNIDAD.Serial_Number, UNIDAD.Work_Order,CAT_AREA.Area as Area,CAT_NUMPARTE.Num_Parte as Part_Number, BITACORA._Status as Estatus, BITACORA._NumEmpleado as Empleado, BITACORA._Fecha as Fecha, BITACORA._Turno as Turno from UNIDAD INNER JOIN BITACORA ON UNIDAD.Id_Unidad = BITACORA.FK_Unidad  INNER JOIN CAT_AREA ON UNIDAD.FK_Area = CAT_AREA.Id_Area INNER JOIN CAT_NUMPARTE ON UNIDAD.FK_PartNumber = CAT_NUMPARTE.Id_NumParte order by BITACORA._Fecha asc ";


            miconexion.Open();
            SqlCommand cmd = new SqlCommand(query, miconexion);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            miconexion.Close();
            return ds;
        }

        public static DataSet consultaBitacora(string empleado, string estatus, string turno, string wo, int partnumber, string serialnumber, string fecha)
        {
            int i = 0;

            string query = "SELECT UNIDAD.Id_Unidad, UNIDAD.Serial_Number, UNIDAD.Work_Order,CAT_AREA.Area as Area,CAT_NUMPARTE.Num_Parte as Part_Number, BITACORA._Status as Estatus, BITACORA._NumEmpleado as Empleado, BITACORA._Fecha as Fecha, BITACORA._Turno as Turno from UNIDAD INNER JOIN BITACORA ON UNIDAD.Id_Unidad = BITACORA.FK_Unidad INNER JOIN CAT_AREA ON UNIDAD.FK_Area = CAT_AREA.Id_Area INNER JOIN CAT_NUMPARTE ON UNIDAD.FK_PartNumber = CAT_NUMPARTE.Id_NumParte " +
                "WHERE ";

            if (empleado != "Select All")
            {
                query += "BITACORA._NumEmpleado = '" + empleado + "'";
                i++;
            }
            if (estatus != "Select All")
            {
                if (i > 0)
                {
                    query += " and ";
                }

                query += "BITACORA._Status = '" + estatus + "'";
                i++;
            }
            if (turno != "Select All")
            {
                if (i > 0)
                {
                    query += " and ";
                }
                i++;
                query += "BITACORA._Turno = '" + turno + "'";
            }
            if (wo != "")
            {
                if (i > 0)
                {
                    query += " and ";
                }
                i++;
                query += "UNIDAD.Work_Order = '" + wo + "'";
            }
            if (partnumber != -1)
            {
                if (i > 0)
                {
                    query += " and ";
                }
                i++;
                query += "UNIDAD.FK_PartNumber = " + partnumber + "";
            }
            if (serialnumber != "")
            {
                if (i > 0)
                {
                    query += " and ";
                }
                i++;
                query += "UNIDAD.Serial_Number = '" + serialnumber + "'";
            }
            if (fecha != "")
            {
                if (i > 0)
                {
                    query += " and ";
                }
                i++;
                query += " cast (BITACORA._Fecha as date) = '" + fecha + "'";
            }

            query += " order by BITACORA._Fecha asc ";

            miconexion.Open();
            SqlCommand cmd = new SqlCommand(query, miconexion);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            miconexion.Close();
            return ds;
        }

        public static string consultaFechaAlta(string id_unidad)
        {
            string query = "SELECT MIN(_Fecha) FROM BITACORA where FK_Unidad = " + id_unidad;
            SqlCommand command = new SqlCommand(query, miconexion);
            miconexion.Open();
            var fecha_alta = command.ExecuteScalar();
            miconexion.Close();
            return fecha_alta.ToString();
        }

        public static DataSet ConsultaUnidadEstatus(Modelos.Status estatus)
        {
            string query = "SELECT UNIDAD.Id_Unidad,UNIDAD.Work_Order,IsNull(CAT_AREA.Area, 'N/A') as Area, CAT_NUMPARTE.Num_Parte as Part_Number,UNIDAD.Serial_Number, CAT_STATUS.Nombre_status as Estatus,  IsNull(UNIDAD.Falla, 'N/A') as Falla from UNIDAD LEFT OUTER JOIN  CAT_AREA ON UNIDAD.FK_Area = CAT_AREA.Id_Area INNER JOIN CAT_STATUS ON UNIDAD.FK_Status = CAT_STATUS.Id_Status INNER JOIN CAT_NUMPARTE ON UNIDAD.FK_PartNumber = CAT_NUMPARTE.Id_NumParte ";

            if (estatus.Nombre_Status != "All")
            {
                query += " where UNIDAD.FK_Status = '" + estatus.Id_Status + "'";
            }
            miconexion.Open();
            SqlCommand cmd = new SqlCommand(query, miconexion);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            miconexion.Close();
            return ds;
        }

        public static DataSet ConsultaUnidadFiltro(Modelos.Status estatus, string wo, string partnumber)
        {
            int i = 0;
            string query = "SELECT UNIDAD.Id_Unidad,UNIDAD.Work_Order,IsNull(CAT_AREA.Area, 'N/A') as Area, CAT_NUMPARTE.Num_Parte as Part_Number,UNIDAD.Serial_Number, CAT_STATUS.Nombre_status as Estatus,  IsNull(UNIDAD.Falla, 'N/A') as Falla from UNIDAD LEFT OUTER JOIN  CAT_AREA ON UNIDAD.FK_Area = CAT_AREA.Id_Area INNER JOIN CAT_STATUS ON UNIDAD.FK_Status = CAT_STATUS.Id_Status INNER JOIN CAT_NUMPARTE ON UNIDAD.FK_PartNumber = CAT_NUMPARTE.Id_NumParte ";

            if (estatus.Nombre_Status != "All")
            {
                query += " where UNIDAD.FK_Status = '" + estatus.Id_Status + "'";
                i++;
            }

            if (wo != "")
            {
                if (i > 0)
                {
                    query += " and  Work_order = '" + wo + "'";
                }
                else
                {
                    query += "where Work_order = '" + wo + "'";
                }
                i++;
            }

            if (partnumber != "")
            {
                if (i > 0)
                {
                    query += " and Serial_Number = '" + partnumber + "'";
                }
                else
                {
                    query += "where Serial_Number = '" + partnumber + "'";
                }
            }
            miconexion.Open();
            SqlCommand cmd = new SqlCommand(query, miconexion);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            miconexion.Close();
            return ds;
        }
        #endregion

        #region ConsultasEspecificas
        static int obtenerUltimoID(string tabla)
        {
            string query = "SELECT IDENT_CURRENT('" + tabla + "')";
            SqlCommand command = new SqlCommand(query, miconexion);
            miconexion.Open();
            var _id = command.ExecuteScalar();
            miconexion.Close();
            return Convert.ToInt32(_id);
        }

        public static Modelos.Usuario obtenerUsuarioGuest()
        {
            miconexion.Open();
            SqlCommand cmd = new SqlCommand("select * from USUARIO where Nombre_Empleado = 'Guest'", miconexion);
            SqlDataReader reader = cmd.ExecuteReader();

            Modelos.Usuario nuevo_usuario = new Modelos.Usuario();
            while (reader.Read())
            {
                nuevo_usuario.Id_Usuario = (int)reader["Id_Usuario"];
                nuevo_usuario.Nombre_Empleado = (string)reader["Nombre_Empleado"];
                nuevo_usuario.FK_TipoUsuario = (int)reader["FK_TipoUsuario"];
                nuevo_usuario.Num_Empleado = (string)reader["Num_Empleado"];
            }
            miconexion.Close();
            return nuevo_usuario;
        }
        public static Modelos.Usuario obtenerUsuario(string usuario, string password)
        {
            miconexion.Open();
            SqlCommand cmd = new SqlCommand("select * from USUARIO where username = '" + usuario + "' and password = '" + password + "'", miconexion);
            SqlDataReader reader = cmd.ExecuteReader();

            Modelos.Usuario nuevo_usuario = new Modelos.Usuario();
            while (reader.Read())
            {
                nuevo_usuario.Id_Usuario = (int)reader["Id_Usuario"];
                nuevo_usuario.Nombre_Empleado = (string)reader["Nombre_Empleado"];
                nuevo_usuario.Username = (string)reader["username"];
                nuevo_usuario.Password = (string)reader["password"];
                nuevo_usuario.FK_AreaInt = (int)reader["FK_AreaInt"];
                nuevo_usuario.FK_TipoUsuario = (int)reader["FK_TipoUsuario"];
                nuevo_usuario.Num_Empleado = (string)reader["Num_Empleado"];
            }
            miconexion.Close();
            return nuevo_usuario;
        }
        public static List<Modelos.Defecto> ConsultaDefectosLista(int id_unidad)
        {
            List<Modelos.Defecto> list_bd = new List<Defecto>();
            miconexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT CAT_DEFECTO.Id_Defecto, CAT_DEFECTO.Codigo, CAT_DEFECTO.Descripcion, CAT_DEFECTO.Codigo + ' ' + CAT_DEFECTO.Descripcion AS Defecto FROM UNIDAD_DEFECTO INNER JOIN CAT_DEFECTO ON UNIDAD_DEFECTO.FK_Defecto = CAT_DEFECTO.Id_Defecto where FK_Unidad = " + id_unidad, miconexion);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Modelos.Defecto defecto = new Modelos.Defecto();
                defecto.Id_Defecto = (int)reader["Id_Defecto"];
                defecto.Codigo = (string)reader["Codigo"];
                defecto.Descripcion = (string)reader["Descripcion"];
                defecto.defecto = (string)reader["Defecto"];
                defecto.Referencia = ConsultaReferencias(id_unidad, defecto.Id_Defecto);
                list_bd.Add(defecto);
                // Globales.defectos_seleccionados.Add(defecto);
            }
            //Globales.defectos_INICIAL = Globales.defectos_seleccionados;
            miconexion.Close();

            return list_bd;
        }

        public static string ConsultaReferencias(int id_unidad, int id_defecto)
        {
            string query = "SELECT Referencia from UNIDAD_DEFECTO where FK_Unidad = " + id_unidad + " and FK_Defecto = " + id_defecto;
            SqlCommand command = new SqlCommand(query, miconexion);
            var referencia = command.ExecuteScalar();
            return referencia.ToString();
        }

        public static Modelos.Status ConsultaEstatus(string estatus)
        {
            miconexion.Open();
            //if (estatus == "CALIDAD")
            //{
            //    estatus = "CALIDAD or Nombre_Status = SCRAP";
            //}
            SqlCommand cmd = new SqlCommand("SELECT * from CAT_STATUS where Nombre_Status = '" + estatus + "'", miconexion);
            SqlDataReader reader = cmd.ExecuteReader();

            Modelos.Status status = new Modelos.Status();
            while (reader.Read())
            {
                status.Id_Status = (int)reader["Id_Status"];
                status.Nombre_Status = (string)reader["Nombre_Status"];

            }
            miconexion.Close();
            return status;
        }

        #endregion

        #region Bajas
        public static void eliminarUnidad_Defecto(Modelos.Unidad unidad, Modelos.Defecto defecto)
        {
            miconexion.Open();
            SqlCommand cmd = miconexion.CreateCommand();

            cmd.CommandText = "DELETE FROM UNIDAD_DEFECTO WHERE FK_Defecto = " + defecto.Id_Defecto + " AND FK_UNIDAD = " + unidad.Id_Unidad;

            cmd.ExecuteNonQuery();

            miconexion.Close();
        }
        #endregion

        //PENDIENTE
        public static void filtrarDefectos()
        {
            List<Modelos.Defecto> list_bd = ConsultaDefectosLista(Globales.unidad_seleccionada.Id_Unidad);

            foreach (var item in list_bd)
            {
                if (!Globales.defectos_seleccionados.Exists(r => r.Id_Defecto == item.Id_Defecto))
                {
                    eliminarUnidad_Defecto(Globales.unidad_seleccionada, item);
                }
            }

            foreach (var item in Globales.defectos_seleccionados)
            {
                if (!list_bd.Exists(r => r.Id_Defecto == item.Id_Defecto))
                {
                    Alta_Unidad_Defecto(item, false);
                }
            }
        }

    }
}