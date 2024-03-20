using AccesoDatos;
using CL_BE;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_DA
{
    public class DA_Indicator_Type
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;
        public List<BE_Indicator_Type> ListarTipoIndicador()
        {
            SqlConnection conexion = null;
            List<BE_Indicator_Type> listaResultado = new List<BE_Indicator_Type>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_INDICATOR_TYPE_LIST"))
                    {
                        while (reader.Read())
                        {
                            BE_Indicator_Type bE_Indicator_Type = new BE_Indicator_Type()
                            {
                                IdIndicatorType = DataUtil.ObjectToInt32(reader["IdIndicatorType"]),
                                IndicatorTypeCode = DataUtil.ObjectToString(reader["IndicatorTypeCode"]),
                                IndicatorTypeDescription = DataUtil.ObjectToString(reader["IndicatorTypeDescription"]),
                                RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]),
                                RegistrationDate = DataUtil.ObjectToDateTime(reader["RegistrationDate"]),
                                UpdateDate = DataUtil.ObjectToDateTime(reader["UpdateDate"]),
                                ValorConsulta = "1"
                            };
                            listaResultado.Add(bE_Indicator_Type);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator_Type bE_Indicator_Type = new BE_Indicator_Type();
                bE_Indicator_Type.ValorConsulta = "0";
                bE_Indicator_Type.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Indicator_Type);
            }

            return listaResultado;
        }
    }
}
