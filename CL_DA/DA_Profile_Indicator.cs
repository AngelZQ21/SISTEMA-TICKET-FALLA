using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using AccesoDatos;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
namespace CL_DA
{
    public class DA_Profile_Indicator
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Profile_Indicator> ListarIndicadorPerfil(string valorBusqueda, string valorConsulta, int idPerfil)
        {
            SqlConnection conexion = null;
            List<BE_Profile_Indicator> listaResultado = new List<BE_Profile_Indicator>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];
                    Parametro[0] = new SqlParameter("@Search", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = valorBusqueda;

                    Parametro[1] = new SqlParameter("@QueryValue", SqlDbType.Char);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = valorConsulta;

                    Parametro[2] = new SqlParameter("@IdPerfil", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = idPerfil;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_PROFILE_INDICATOR_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Profile_Indicator bE_Profile_Indicator = new BE_Profile_Indicator();
                            bE_Profile_Indicator.IdProfileIndicator = DataUtil.ObjectToInt32(reader["IdProfileIndicator"]);
                            BE_Profile bE_Profile = new BE_Profile()
                            {
                                IdProfile = DataUtil.ObjectToInt32(reader["IdProfile"]),
                                ProfileName = DataUtil.ObjectToString(reader["ProfileName"])
                            };
                            bE_Profile_Indicator.Profile = bE_Profile;
                            BE_Indicator bE_Indicator = new BE_Indicator()
                            {
                                IdIndicator = DataUtil.ObjectToInt32(reader["IdIndicator"]),
                                IndicatorType = DataUtil.ObjectToString(reader["IndicatorType"]),
                                IndicatorCode = DataUtil.ObjectToString(reader["IndicatorCode"]),
                                IndicatorDescription = DataUtil.ObjectToString(reader["IndicatorDescription"])
                            };
                            bE_Profile_Indicator.Indicator = bE_Indicator;
                            bE_Profile_Indicator.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
                            bE_Profile_Indicator.UpdateDate = DataUtil.ObjectToDateTime(reader["UpdateDate"]);
                            bE_Profile_Indicator.ValorConsulta = "1";
                            listaResultado.Add(bE_Profile_Indicator);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Profile_Indicator bE_Profile_Indicator = new BE_Profile_Indicator();
                bE_Profile_Indicator.ValorConsulta = "0";
                bE_Profile_Indicator.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Profile_Indicator);
            }

            return listaResultado;
        }

        public String actualizarEstadoIndicadorPerfilP1(int idPerfil)
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

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_PROFILE_INDICATOR_UPDATE_STATE_P1", Parametro))
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

        public String actualizarEstadoIndicadorPerfilP2(String arrayIdIndicator, int idPerfil)
        {
            string[] arraySeparador = new string[] { "," };
            string[] idsProfileIndicator = arrayIdIndicator.Split(arraySeparador, StringSplitOptions.RemoveEmptyEntries);

            string resultado = "";
            int incrementador = 0;
            SqlConnection conexion = null;
            try
            {
                //1 recorre todos los Id's de indicador perfil recibidos como parámetro y los setea  a activos 
                //en la tabla TB_PROFILE_INDICATOR según el id Perfil
                for (int i = 0; i < idsProfileIndicator.Length; i++)
                {

                    using (conexion = new SqlConnection(cadenaConexion))
                    {

                        SqlParameter[] Parametro = new SqlParameter[2];
                        Parametro[0] = new SqlParameter("@IdProfileIndicator", SqlDbType.Int);
                        Parametro[0].Direction = ParameterDirection.Input;
                        Parametro[0].Value = idsProfileIndicator[i];

                        Parametro[1] = new SqlParameter("@IdProfile", SqlDbType.Int);
                        Parametro[1].Direction = ParameterDirection.Input;
                        Parametro[1].Value = idPerfil;

                        using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_PROFILE_INDICATOR_UPDATE_STATE_P2", Parametro))
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
                if (idsProfileIndicator.Length == incrementador)
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
