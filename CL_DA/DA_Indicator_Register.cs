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
    public class DA_Indicator_Register
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;
        public List<BE_Indicator_Register> ListarRegistroIndicador(string starDate, string endDate)
        {
            SqlConnection conexion = null;
            List<BE_Indicator_Register> listaResultado = new List<BE_Indicator_Register>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];
                    Parametro[0] = new SqlParameter("@StartDate", SqlDbType.VarChar,50);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = starDate;

                    Parametro[1] = new SqlParameter("@EndDate", SqlDbType.VarChar,50);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = endDate;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_INDICATOR_REGISTER_LIST",Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Indicator_Register bE_Indicator_Register = new BE_Indicator_Register();

                                bE_Indicator_Register.IdIndicatorRegister = DataUtil.ObjectToInt32(reader["IdIndicatorRegister"]);
                                BE_Indicator Be_Indicator = new BE_Indicator()
                                {
                                    IdIndicator = DataUtil.ObjectToInt32(reader["IdIndicator"]),
                                    IndicatorCode = DataUtil.ObjectToString(reader["IndicatorCode"]),
                                    IndicatorDescription = DataUtil.ObjectToString(reader["IndicatorDescription"])
                                };
                                bE_Indicator_Register.bE_Indicator = Be_Indicator;
                                bE_Indicator_Register.IndicatorTypeDescription = DataUtil.ObjectToString(reader["IndicatorTypeDescription"]);
                                bE_Indicator_Register.RegisterDetail = DataUtil.ObjectToString(reader["RegisterDetail"]);
                                bE_Indicator_Register.RegistrationDate = DataUtil.ObjectToDateTime(reader["RegistrationDate"]);
                                bE_Indicator_Register.ValorConsulta = "1";
                                listaResultado.Add(bE_Indicator_Register);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator_Register bE_Indicator_Register = new BE_Indicator_Register();
                bE_Indicator_Register.ValorConsulta = "0";
                bE_Indicator_Register.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Indicator_Register);
            }

            return listaResultado;
        }
    }
}
