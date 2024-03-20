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
    public class DA_Menu
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Menu> ValidarMenuPerfilActual(int idPerfil,string Controlador, string Vista)
        {
            SqlConnection conexion = null;
            List<BE_Menu> listaResultado = new List<BE_Menu>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];
                    Parametro[0] = new SqlParameter("@IdProfile", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = idPerfil;

                    Parametro[1] = new SqlParameter("@Controller", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = Controlador;

                    Parametro[2] = new SqlParameter("@ViewController", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = Vista;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_MENU_VALIDATE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Menu bE_Menu = new BE_Menu();
                            bE_Menu.IdMenu = DataUtil.ObjectToInt32(reader["IdMenu"]);
                            bE_Menu.Controller = DataUtil.ObjectToString(reader["Controller"]);
                            bE_Menu.ViewController = DataUtil.ObjectToString(reader["ViewController"]);
                            bE_Menu.ValorConsulta = "1";
                            listaResultado.Add(bE_Menu);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BE_Menu bE_Menu = new BE_Menu();
                bE_Menu.ValorConsulta = "0";
                bE_Menu.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Menu);
            }

            return listaResultado;
        }


        public List<BE_Menu_Profile> ListarMenu(int idPerfil, string valorConsulta )
        {
            SqlConnection conexion = null;
            List<BE_Menu_Profile> listaResultado = new List<BE_Menu_Profile>();
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

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_MENU_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Menu_Profile bE_Menu_Profile = new BE_Menu_Profile();
                            
                            BE_Menu be_Menu = new BE_Menu() {
                                IdMenu = DataUtil.ObjectToInt32(reader["IdMenu"]),
                                MenuGroup = DataUtil.ObjectToInt32(reader["MenuGroup"]),
                                Scale = DataUtil.ObjectToInt32(reader["Scale"]),
                                ScaleId = DataUtil.ObjectToInt32(reader["ScaleId"]),
                                DependencyScale = DataUtil.ObjectToInt32(reader["DependencyScale"]),
                                MainId = DataUtil.ObjectToInt32(reader["MainId"]),
                                DependencyMainId = DataUtil.ObjectToInt32(reader["DependencyMainId"]),
                                HasDependency = DataUtil.ObjectToString(reader["HasDependency"]),
                                IconShowed = DataUtil.ObjectToString(reader["IconShowed"]),
                                Controller = DataUtil.ObjectToString(reader["Controller"]),
                                ViewController = DataUtil.ObjectToString(reader["ViewController"]),
                                VisualName = DataUtil.ObjectToString(reader["VisualName"]),
                                DependencySequence = DataUtil.ObjectToString(reader["DependencySequence"]),
                                DependencySequenceName = DataUtil.ObjectToString(reader["DependencySequenceName"]),
                                ActiveViews = DataUtil.ObjectToBool(reader["ActiveViews"])
                            };
                            bE_Menu_Profile.Menu = be_Menu;
                            bE_Menu_Profile.MainView = DataUtil.ObjectToString(reader["MainView"]);
                            bE_Menu_Profile.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
                            bE_Menu_Profile.ValorConsulta = "1";
                            listaResultado.Add(bE_Menu_Profile);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Menu_Profile bE_Menu_Profile = new BE_Menu_Profile();
                bE_Menu_Profile.ValorConsulta = "0";
                bE_Menu_Profile.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Menu_Profile);
            }

            return listaResultado;
        }
    }
}
