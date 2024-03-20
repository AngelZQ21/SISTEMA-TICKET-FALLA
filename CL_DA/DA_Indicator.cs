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
    public class DA_Indicator
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;
        public List<BE_Indicator> ListarIndicador()
        {
            SqlConnection conexion = null;
            List<BE_Indicator> listaResultado = new List<BE_Indicator>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_INDICATOR_LIST"))
                    {
                        while (reader.Read())
                        {
                            BE_Indicator bE_Indicator = new BE_Indicator()
                            {
                                IdIndicator = DataUtil.ObjectToInt32(reader["IdIndicator"]),
                                IndicatorType = DataUtil.ObjectToString(reader["IndicatorType"]),
                                IndicatorCode = DataUtil.ObjectToString(reader["IndicatorCode"]),
                                IndicatorDescription = DataUtil.ObjectToString(reader["IndicatorDescription"]),
                                RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]),
                                UpdateDate = DataUtil.ObjectToDateTime(reader["UpdateDate"]),
                                ValorConsulta = "1"
                            };
                            listaResultado.Add(bE_Indicator);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator bE_Indicator = new BE_Indicator();
                bE_Indicator.ValorConsulta = "0";
                bE_Indicator.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Indicator);
            }

            return listaResultado;
        }

        //Lista de indicadores utilizada para llenar la barra superior de notificaciones y alertas
        public List<BE_Indicator> ListarIndicadorParaNavigation()
        {
            SqlConnection conexion = null;
            List<BE_Indicator> listaResultado = new List<BE_Indicator>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_INDICATOR_LEVEL1_LIST"))
                    {
                        while (reader.Read())
                        {
                            BE_Indicator bE_Indicator = new BE_Indicator();
                            BE_Indicator_Type bE_Indicator_Type = new BE_Indicator_Type();
                            BE_Indicator_Navigation bE_Indicator_Navigation = new BE_Indicator_Navigation();

                            bE_Indicator_Type.IdIndicatorType = DataUtil.ObjectToInt32(reader["IdIndicatorType"]);
                            bE_Indicator_Type.IndicatorTypeDescription = DataUtil.ObjectToString(reader["IndicatorTypeDescription"]);
                            bE_Indicator.IndicatorsQuantity = DataUtil.ObjectToInt32(reader["IndicatorsQuantity"]);
                            bE_Indicator_Navigation.totalIndicatorQuantity = DataUtil.ObjectToInt32(reader["totalIndicatorQuantity"]);
                            bE_Indicator.bE_Indicator_Navigation = bE_Indicator_Navigation;
                            bE_Indicator.bE_Indicator_Type = bE_Indicator_Type;
                            bE_Indicator.ValorConsulta = "1";

                            listaResultado.Add(bE_Indicator);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator bE_Indicator = new BE_Indicator();
                bE_Indicator.ValorConsulta = "0";
                bE_Indicator.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Indicator);
            }

            return listaResultado;
        }

        //Lista de indicadores a detalle utilizada para llenar la barra superior de notificaciones y alertas
        public List<BE_Indicator> ListarIndicadorDetalleParaNavigation(int IdIndicatorType)
        {
            SqlConnection conexion = null;
            List<BE_Indicator> listaResultado = new List<BE_Indicator>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@IdIndicatorType", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdIndicatorType;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_INDICATOR_LEVEL2_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Indicator bE_Indicator = new BE_Indicator();
                            bE_Indicator.IdIndicator = DataUtil.ObjectToInt32(reader["IdIndicator"]);
                            bE_Indicator.IndicatorCode = DataUtil.ObjectToString(reader["IndicatorCode"]);
                            bE_Indicator.IndicatorDescription = DataUtil.ObjectToString(reader["IndicatorDescription"]);
                            bE_Indicator.IndicatorsCodeQuantity = DataUtil.ObjectToInt32(reader["IndicatorsCodeQuantity"]);
                            bE_Indicator.BackDay = DataUtil.ObjectToString(reader["BackDay"]);
                            bE_Indicator.CurrentDay = DataUtil.ObjectToString(reader["CurrentDay"]);

                            bE_Indicator.ValorConsulta = "1";

                            listaResultado.Add(bE_Indicator);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator bE_Indicator = new BE_Indicator();
                bE_Indicator.ValorConsulta = "0";
                bE_Indicator.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Indicator);
            }

            return listaResultado;
        }

        public List<BE_Indicator> listarIndicadorModalBarraSuperior(int IdIndicator, int IdIndicatorType, string startDate, string endDate, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Indicator> listaResultado = new List<BE_Indicator>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];
                    Parametro[0] = new SqlParameter("@IdIndicator", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdIndicator;

                    Parametro[1] = new SqlParameter("@IdTypeIndicator", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = IdIndicatorType;

                    Parametro[2] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = startDate;

                    Parametro[3] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = endDate;

                    Parametro[4] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_INDICATOR_LEVEL3_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Indicator bE_Indicator = new BE_Indicator();
                            BE_Indicator_Type bE_Indicator_Type = new BE_Indicator_Type();
                            BE_Indicator_User bE_Indicator_User = new BE_Indicator_User();

                            bE_Indicator.IdIndicator = DataUtil.ObjectToInt32(reader["IdIndicator"]);
                            bE_Indicator.IndicatorCode = DataUtil.ObjectToString(reader["IndicatorCode"]);
                            bE_Indicator.IndicatorDescription = DataUtil.ObjectToString(reader["IndicatorDescription"]);

                            bE_Indicator_Type.IndicatorTypeDescription = DataUtil.ObjectToString(reader["IndicatorTypeDescription"]);

                            bE_Indicator_User.RegisterDetail = DataUtil.ObjectToString(reader["RegisterDetail"]);
                            bE_Indicator_User.IdIndicatorUser = DataUtil.ObjectToInt32(reader["IdIndicatorUser"]);
                            bE_Indicator_User.RegistrationDate = DataUtil.ObjectToDateTime(reader["RegistrationDate"]);
                            bE_Indicator_User.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDateString"]);
                            bE_Indicator_User.UpdateDate = DataUtil.ObjectToDateTime(reader["UpdateDate"]);
                            bE_Indicator_User.UpdateDateString = DataUtil.ObjectToString(reader["UpdateDateString"]);
                            bE_Indicator_User.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
                            bE_Indicator_User.RegistrationUserName = DataUtil.ObjectToString(reader["RegistrationUserName"]);
                            bE_Indicator_User.UpdateUserName = DataUtil.ObjectToString(reader["UpdateUserName"]);

                            bE_Indicator.bE_Indicator_Type = bE_Indicator_Type;
                            bE_Indicator.bE_Indicator_User = bE_Indicator_User;
                            bE_Indicator.ValorConsulta = "1";

                            listaResultado.Add(bE_Indicator);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator bE_Indicator = new BE_Indicator();
                bE_Indicator.ValorConsulta = "0";
                bE_Indicator.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Indicator);
            }

            return listaResultado;
        }

        public List<BE_Indicator> listarIndicadorPorTipo(int IdIndicatorType)
        {
            SqlConnection conexion = null;
            List<BE_Indicator> listaResultado = new List<BE_Indicator>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@IdIndicatorType", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdIndicatorType;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_INDICATOR_BY_ID_INDICATOR_TYPE_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Indicator bE_Indicator = new BE_Indicator();
                            BE_Indicator_Type bE_Indicator_Type = new BE_Indicator_Type();

                            bE_Indicator.IdIndicator = DataUtil.ObjectToInt32(reader["IdIndicator"]);
                            bE_Indicator_Type.IdIndicatorType = DataUtil.ObjectToInt32(reader["IdIndicatorType"]);
                            bE_Indicator.IndicatorCode = DataUtil.ObjectToString(reader["IndicatorCode"]);
                            bE_Indicator.IndicatorDescription = DataUtil.ObjectToString(reader["IndicatorDescription"]);

                            bE_Indicator.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
                            bE_Indicator.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
                            bE_Indicator.RegistrationUser = DataUtil.ObjectToInt32(reader["RegistrationUser"]);
                            bE_Indicator.RegistrationDate = DataUtil.ObjectToDateTime(reader["RegistrationDate"]);
                            bE_Indicator.UpdateUser = DataUtil.ObjectToInt32(reader["UpdateUser"]);
                            bE_Indicator.UpdateDate = DataUtil.ObjectToDateTime(reader["UpdateDate"]);

                            bE_Indicator.IndicatorCodeDescription = DataUtil.ObjectToString(reader["IndicatorCodeDescription"]);

                            bE_Indicator.bE_Indicator_Type = bE_Indicator_Type;
                            bE_Indicator.ValorConsulta = "1";

                            listaResultado.Add(bE_Indicator);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator bE_Indicator = new BE_Indicator();
                bE_Indicator.ValorConsulta = "0";
                bE_Indicator.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Indicator);
            }

            return listaResultado;
        }

        public String actualizarEstadoIndicadorP1()
        {

            string resultado = "";
            SqlConnection conexion = null;
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_INDICATOR_UPDATE_STATE_P1"))
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

        public String actualizarEstadoIndicadorP2(String arrayIdIndicator)
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

                        SqlParameter[] Parametro = new SqlParameter[1];
                        Parametro[0] = new SqlParameter("@IdIndicator", SqlDbType.Int);
                        Parametro[0].Direction = ParameterDirection.Input;
                        Parametro[0].Value = idsProfileIndicator[i];

                        using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_INDICATOR_UPDATE_STATE_P2", Parametro))
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
