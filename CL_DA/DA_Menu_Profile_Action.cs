using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using CL_BE;
using AccesoDatos;

namespace CL_DA
{
    public class DA_Menu_Profile_Action
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Menu_Profile_Action> ListarMenuPerfilAction(int idPerfil, string valorConsulta)
        {
            SqlConnection conexion = null;
            List<BE_Menu_Profile_Action> listaResultado = new List<BE_Menu_Profile_Action>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];
                    Parametro[0] = new SqlParameter("@IdProfile", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = idPerfil;

                    Parametro[1] = new SqlParameter("@QueryValue", SqlDbType.Char);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = valorConsulta;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_MENU_PROFILE_ACTION_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Menu_Profile_Action bE_Menu_Profile_Action = new BE_Menu_Profile_Action();
                            bE_Menu_Profile_Action.IdMenuProfileAction = DataUtil.ObjectToInt32(reader["IdMenuProfileAction"]);

                            BE_Menu be_Menu = new BE_Menu()
                            {
                                IdMenu = DataUtil.ObjectToInt32(reader["IdMenu"]),
                                VisualName = DataUtil.ObjectToString(reader["VisualName"]),
                                ActiveViews = DataUtil.ObjectToBool(reader["ActiveViews"])
                            };
                            BE_Action bE_Action = new BE_Action()
                            {
                                IdAction = DataUtil.ObjectToInt32(reader["IdAction"]),
                                ActionName = DataUtil.ObjectToString(reader["ActionName"])
                            };

                            bE_Menu_Profile_Action.Menu = be_Menu;
                            bE_Menu_Profile_Action.Action = bE_Action;
                            bE_Menu_Profile_Action.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
                            bE_Menu_Profile_Action.ValorConsulta = "1";
                            listaResultado.Add(bE_Menu_Profile_Action);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Menu_Profile_Action bE_Menu_Profile_Action = new BE_Menu_Profile_Action();
                bE_Menu_Profile_Action.ValorConsulta = "0";
                bE_Menu_Profile_Action.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Menu_Profile_Action);
            }

            return listaResultado;
        }

        public String actualizarEstadoMenuAccionPerfilP1(int idPerfil)
        {

            string resultado = "";
            SqlConnection conexion = null;
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@IdProfile", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = idPerfil;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_MENU_PROFILE_ACTION_UPDATE_STATE_P1", Parametro))
                    {

                        while (reader.Read())
                        {
                            resultado = DataUtil.ObjectToString(reader["Resultado"]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public String actualizarEstadoMenuAccionPerfilP2(String arrayIdMenu, int idPerfil)
        {
            string[] arraySeparador = new string[] { "," };
            string[] idMenuProfileAction = arrayIdMenu.Split(arraySeparador, StringSplitOptions.RemoveEmptyEntries);

            string resultado = "";
            int incrementador = 0;
            SqlConnection conexion = null;
            try
            {
                //1 recorre todos los Id's de Accion Perfil recibidos como parámetro y los setea  a activos 
                //en la tabla TB_MENU_PROFILE_ACTION según el id Perfil
                for (int i = 0; i < idMenuProfileAction.Length; i++)
                {

                    using (conexion = new SqlConnection(cadenaConexion))
                    {

                        SqlParameter[] Parametro = new SqlParameter[2];
                        Parametro[0] = new SqlParameter("@IdMenuProfileAction", SqlDbType.Int);
                        Parametro[0].Direction = ParameterDirection.Input;
                        Parametro[0].Value = idMenuProfileAction[i];

                        Parametro[1] = new SqlParameter("@IdProfile", SqlDbType.Int);
                        Parametro[1].Direction = ParameterDirection.Input;
                        Parametro[1].Value = idPerfil;

                        using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_MENU_PROFILE_ACTION_UPDATE_STATE_P2", Parametro))
                        {

                            while (reader.Read())
                            {
                                resultado = DataUtil.ObjectToString(reader["Resultado"]);
                                //2 Si actualiza el valor correctamente en cada recorrido, aumenta la variable incrementador en 1
                                if (resultado == "1")
                                {
                                    incrementador++;
                                }
                            }
                        }
                    }
                }
                //3 Compara el tamaño del array con la cantidad de actualizaciones, si es igual envía "1" que significa "éxito"
                if (idMenuProfileAction.Length == incrementador)
                {
                    resultado = "1";
                }
                else
                {
                    resultado = "0";
                }

            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }


    }
}
