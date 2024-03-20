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
    public class DA_Configuration
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Configuration> ListarConfiguracion(string valorBusqueda, string valorConsulta)
        {

            SqlConnection conexion = null;
            List<BE_Configuration> listaResultado = new List<BE_Configuration>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[2];
                    Parametro[0] = new SqlParameter("@Search", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = valorBusqueda;

                    Parametro[1] = new SqlParameter("@QueryValue", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = valorConsulta;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_SYSTEM_CONFIGURATION_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Configuration bE_Configuration = new BE_Configuration();
                            bE_Configuration.IdConfiguration = DataUtil.ObjectToInt32(reader["IdConfiguration"]);
                            bE_Configuration.ZCSyncTime = DataUtil.ObjectToInt32(reader["ZCSyncTime"]);
                            bE_Configuration.EmbeddedQuantityDays = DataUtil.ObjectToInt32(reader["EmbeddedQuantityDays"]);
                            bE_Configuration.MinDate = DataUtil.ObjectToInt32(reader["MinDate"]);
                            bE_Configuration.StockRestriction = DataUtil.ObjectToString(reader["StockRestriction"]);
                            bE_Configuration.PrefixSetting = DataUtil.ObjectToString(reader["PrefixSetting"]);
                            bE_Configuration.DecimalQuantity = DataUtil.ObjectToInt32(reader["DecimalQuantity"]);
                            bE_Configuration.DecimalQuantity2 = DataUtil.ObjectToInt32(reader["DecimalQuantity2"]);
                            bE_Configuration.MaxRowsReport = DataUtil.ObjectToInt32(reader["MaxRowsReport"]);
                            bE_Configuration.MaxRowsSummary = DataUtil.ObjectToInt32(reader["MaxRowsSummary"]);
                            bE_Configuration.MaxRowsGraphic = DataUtil.ObjectToInt32(reader["MaxRowsGraphic"]);
                            bE_Configuration.MaxDataGraphic = DataUtil.ObjectToInt32(reader["MaxDataGraphic"]);
                            bE_Configuration.PathFile = DataUtil.ObjectToString(reader["PathFile"]);
                            bE_Configuration.PathFileInput = DataUtil.ObjectToString(reader["PathFileInput"]);
                            bE_Configuration.PathFileOut = DataUtil.ObjectToString(reader["PathFileOut"]);
                            bE_Configuration.PathFileDencrypt = DataUtil.ObjectToString(reader["PathFileDencrypt"]);
                            bE_Configuration.PathFileTemp = DataUtil.ObjectToString(reader["PathFileTemp"]);
                            bE_Configuration.PathSystem = DataUtil.ObjectToString(reader["PathSystem"]);
                            bE_Configuration.PathFileDispatchOk = DataUtil.ObjectToString(reader["PathFileDispatchOk"]);
                            bE_Configuration.PathFileDispatchError = DataUtil.ObjectToString(reader["PathFileDispatchError"]);
                            bE_Configuration.TypeLoginZeus = DataUtil.ObjectToInt32(reader["TypeLoginZeus"]);
                            bE_Configuration.LogBus = DataUtil.ObjectToInt32(reader["LogBus"]);
                            bE_Configuration.LogDispatch = DataUtil.ObjectToInt32(reader["LogDispatch"]);
                            bE_Configuration.LogProtocol = DataUtil.ObjectToInt32(reader["LogProtocol"]);
                            bE_Configuration.logError = DataUtil.ObjectToInt32(reader["logError"]);
                            bE_Configuration.Migration_BlackList_Driver = DataUtil.ObjectToInt32(reader["Migration_BlackList_Driver"]);
                            bE_Configuration.Migration_BlackList_Vehicle = DataUtil.ObjectToInt32(reader["Migration_BlackList_Vehicle"]);
                            bE_Configuration.Migration_Driver = DataUtil.ObjectToInt32(reader["Migration_Driver"]);
                            bE_Configuration.Migration_Operator = DataUtil.ObjectToInt32(reader["Migration_Operator"]);
                            bE_Configuration.Migration_Vehicle = DataUtil.ObjectToInt32(reader["Migration_Vehicle"]);
                            bE_Configuration.DefaultStation = DataUtil.ObjectToInt32(reader["DefaultStation"]);
                            bE_Configuration.PercentVIMS = DataUtil.ObjectToInt32(reader["PercentVIMS"]);
                            bE_Configuration.ValidateVehicle = DataUtil.ObjectToBool(reader["ValidateVehicle"]);
                            bE_Configuration.ValidateOperator = DataUtil.ObjectToBool(reader["ValidateOperator"]);
                            bE_Configuration.ValidateDriver = DataUtil.ObjectToBool(reader["ValidateDriver"]);
                            bE_Configuration.Sound = DataUtil.ObjectToBool(reader["Sound"]);
                            bE_Configuration.MaxColumnRestriction = DataUtil.ObjectToInt32(reader["MaxColumnRestriction"]);
                            bE_Configuration.NumberLockType = DataUtil.ObjectToInt32(reader["NumberLockType"]);
                            bE_Configuration.MaxTimeBombas = DataUtil.ObjectToInt32(reader["MaxTimeBombas"]);
                            bE_Configuration.MaxTimeNoFujo = DataUtil.ObjectToInt32(reader["MaxTimeNoFujo"]);
                            bE_Configuration.ValorConsulta = "1";
                            listaResultado.Add(bE_Configuration);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Configuration bE_Configuration = new BE_Configuration();
                bE_Configuration.ValorConsulta = "0";
                bE_Configuration.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Configuration);
            }

            return listaResultado;
        }

        public string EditarConfiguracion(BE_Configuration bE_Configuration)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[41];

                    Parametro[0] = new SqlParameter("@IdConfiguration", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Configuration.IdConfiguration;

                    Parametro[1] = new SqlParameter("@ZCSyncTime", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Configuration.ZCSyncTime;

                    Parametro[2] = new SqlParameter("@EmbeddedQuantityDays", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Configuration.EmbeddedQuantityDays;

                    Parametro[3] = new SqlParameter("@MinDate", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Configuration.MinDate;

                    Parametro[4] = new SqlParameter("@StockRestriction", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_Configuration.StockRestriction;

                    Parametro[5] = new SqlParameter("@PrefixSetting", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_Configuration.PrefixSetting;

                    Parametro[6] = new SqlParameter("@DecimalQuantity", SqlDbType.Int);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_Configuration.DecimalQuantity;

                    Parametro[7] = new SqlParameter("@DecimalQuantity2", SqlDbType.Int);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = bE_Configuration.DecimalQuantity2;

                    Parametro[8] = new SqlParameter("@MaxRowsReport", SqlDbType.Int);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = bE_Configuration.MaxRowsReport;

                    Parametro[9] = new SqlParameter("@MaxRowsSummary", SqlDbType.Int);
                    Parametro[9].Direction = ParameterDirection.Input;
                    Parametro[9].Value = bE_Configuration.MaxRowsSummary;

                    Parametro[10] = new SqlParameter("@MaxRowsGraphic", SqlDbType.Int);
                    Parametro[10].Direction = ParameterDirection.Input;
                    Parametro[10].Value = bE_Configuration.MaxRowsGraphic;

                    Parametro[11] = new SqlParameter("@MaxDataGraphic", SqlDbType.Int);
                    Parametro[11].Direction = ParameterDirection.Input;
                    Parametro[11].Value = bE_Configuration.MaxDataGraphic;

                    Parametro[12] = new SqlParameter("@PathFile", SqlDbType.VarChar);
                    Parametro[12].Direction = ParameterDirection.Input;
                    Parametro[12].Value = bE_Configuration.PathFile;

                    Parametro[13] = new SqlParameter("@PathFileInput", SqlDbType.VarChar);
                    Parametro[13].Direction = ParameterDirection.Input;
                    Parametro[13].Value = bE_Configuration.PathFileInput;

                    Parametro[14] = new SqlParameter("@PathFileOut", SqlDbType.VarChar);
                    Parametro[14].Direction = ParameterDirection.Input;
                    Parametro[14].Value = bE_Configuration.PathFileOut;

                    Parametro[15] = new SqlParameter("@PathFileDencrypt", SqlDbType.VarChar);
                    Parametro[15].Direction = ParameterDirection.Input;
                    Parametro[15].Value = bE_Configuration.PathFileDencrypt;

                    Parametro[16] = new SqlParameter("@PathFileTemp", SqlDbType.VarChar);
                    Parametro[16].Direction = ParameterDirection.Input;
                    Parametro[16].Value = bE_Configuration.PathFileTemp;

                    Parametro[17] = new SqlParameter("@PathSystem", SqlDbType.VarChar);
                    Parametro[17].Direction = ParameterDirection.Input;
                    Parametro[17].Value = bE_Configuration.PathSystem;

                    Parametro[18] = new SqlParameter("@PathFileDispatchOk", SqlDbType.VarChar);
                    Parametro[18].Direction = ParameterDirection.Input;
                    Parametro[18].Value = bE_Configuration.PathFileDispatchOk;

                    Parametro[19] = new SqlParameter("@PathFileDispatchError", SqlDbType.VarChar);
                    Parametro[19].Direction = ParameterDirection.Input;
                    Parametro[19].Value = bE_Configuration.PathFileDispatchError;

                    Parametro[20] = new SqlParameter("@TypeLoginZeus", SqlDbType.Int);
                    Parametro[20].Direction = ParameterDirection.Input;
                    Parametro[20].Value = bE_Configuration.TypeLoginZeus;

                    Parametro[21] = new SqlParameter("@LogBus", SqlDbType.Int);
                    Parametro[21].Direction = ParameterDirection.Input;
                    Parametro[21].Value = bE_Configuration.LogBus;

                    Parametro[22] = new SqlParameter("@LogDispatch", SqlDbType.Int);
                    Parametro[22].Direction = ParameterDirection.Input;
                    Parametro[22].Value = bE_Configuration.LogDispatch;

                    Parametro[23] = new SqlParameter("@LogProtocol", SqlDbType.Int);
                    Parametro[23].Direction = ParameterDirection.Input;
                    Parametro[23].Value = bE_Configuration.LogProtocol;

                    Parametro[24] = new SqlParameter("@logError", SqlDbType.Int);
                    Parametro[24].Direction = ParameterDirection.Input;
                    Parametro[24].Value = bE_Configuration.logError;

                    Parametro[25] = new SqlParameter("@Migration_BlackList_Driver", SqlDbType.Int);
                    Parametro[25].Direction = ParameterDirection.Input;
                    Parametro[25].Value = bE_Configuration.Migration_BlackList_Driver;

                    Parametro[26] = new SqlParameter("@Migration_BlackList_Vehicle", SqlDbType.Int);
                    Parametro[26].Direction = ParameterDirection.Input;
                    Parametro[26].Value = bE_Configuration.Migration_BlackList_Vehicle;

                    Parametro[27] = new SqlParameter("@Migration_Driver", SqlDbType.Int);
                    Parametro[27].Direction = ParameterDirection.Input;
                    Parametro[27].Value = bE_Configuration.Migration_Driver;

                    Parametro[28] = new SqlParameter("@Migration_Operator", SqlDbType.Int);
                    Parametro[28].Direction = ParameterDirection.Input;
                    Parametro[28].Value = bE_Configuration.Migration_Operator;

                    Parametro[29] = new SqlParameter("@Migration_Vehicle", SqlDbType.Int);
                    Parametro[29].Direction = ParameterDirection.Input;
                    Parametro[29].Value = bE_Configuration.Migration_Vehicle;

                    Parametro[30] = new SqlParameter("@DefaultStation", SqlDbType.Int);
                    Parametro[30].Direction = ParameterDirection.Input;
                    Parametro[30].Value = bE_Configuration.DefaultStation;

                    Parametro[31] = new SqlParameter("@PercentVIMS", SqlDbType.Decimal);
                    Parametro[31].Direction = ParameterDirection.Input;
                    Parametro[31].Value = bE_Configuration.PercentVIMS;

                    Parametro[32] = new SqlParameter("@ValidateVehicle", SqlDbType.Bit);
                    Parametro[32].Direction = ParameterDirection.Input;
                    Parametro[32].Value = bE_Configuration.ValidateVehicle;

                    Parametro[33] = new SqlParameter("@ValidateOperator", SqlDbType.Bit);
                    Parametro[33].Direction = ParameterDirection.Input;
                    Parametro[33].Value = bE_Configuration.ValidateOperator;

                    Parametro[34] = new SqlParameter("@ValidateDriver", SqlDbType.Bit);
                    Parametro[34].Direction = ParameterDirection.Input;
                    Parametro[34].Value = bE_Configuration.ValidateDriver;

                    Parametro[35] = new SqlParameter("@Sound", SqlDbType.Bit);
                    Parametro[35].Direction = ParameterDirection.Input;
                    Parametro[35].Value = bE_Configuration.Sound;

                    Parametro[36] = new SqlParameter("@MaxColumnRestriction", SqlDbType.Int);
                    Parametro[36].Direction = ParameterDirection.Input;
                    Parametro[36].Value = bE_Configuration.MaxColumnRestriction;

                    Parametro[37] = new SqlParameter("@NumberLockType", SqlDbType.Int);
                    Parametro[37].Direction = ParameterDirection.Input;
                    Parametro[37].Value = bE_Configuration.NumberLockType;

                    Parametro[38] = new SqlParameter("@MaxTimeBombas", SqlDbType.Int);
                    Parametro[38].Direction = ParameterDirection.Input;
                    Parametro[38].Value = bE_Configuration.MaxTimeBombas;

                    Parametro[39] = new SqlParameter("@MaxTimeNoFujo", SqlDbType.Int);
                    Parametro[39].Direction = ParameterDirection.Input;
                    Parametro[39].Value = bE_Configuration.MaxTimeNoFujo;

                    Parametro[40] = new SqlParameter("@UpdateUser", SqlDbType.Int);
                    Parametro[40].Direction = ParameterDirection.Input;
                    Parametro[40].Value = bE_Configuration.UpdateUser;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_SYSTEM_CONFIGURATION_UPDATE", Parametro))
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

        public List<BE_Configuration> ListarConfigurationAlert(int IdUser)
        {

            SqlConnection conexion = null;
            List<BE_Configuration> listaResultado = new List<BE_Configuration>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdUser;

                    //Parametro[1] = new SqlParameter("@QueryValue", SqlDbType.VarChar);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = valorConsulta;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ALERT_STATUS_CONFIGURATION", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Configuration bE_Configuration = new BE_Configuration();
                            bE_Configuration.AlertStatus = DataUtil.ObjectToString(reader["AlertStatus"]);
                            bE_Configuration.ValorConsulta = "1";
                            listaResultado.Add(bE_Configuration);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Configuration bE_Configuration = new BE_Configuration();
                bE_Configuration.ValorConsulta = "0";
                bE_Configuration.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Configuration);
            }

            return listaResultado;
        }

        public string EditAlertStatus(string AlertStatusValue, int IdUser)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@ValueAlertStatus", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = AlertStatusValue;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = IdUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_UPDATE_STATUS_ALERT_CONFIGURATION", Parametro))
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
    }
}
