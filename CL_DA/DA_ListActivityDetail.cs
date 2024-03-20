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
    public class DA_ListActivityDetail
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public string RegistrarActivityDetail(BE_ActivityDetail bE_ActivityDetail)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_ActivityDetail.RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdActivity", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_ActivityDetail.IdActivity;

                    //Parametro[2] = new SqlParameter("@Commentary", SqlDbType.VarChar);
                    //Parametro[2].Direction = ParameterDirection.Input;
                    //Parametro[2].Value = bE_ActivityDetail.Commentary;

                    Parametro[2] = new SqlParameter("@IdsPathFileUpdate", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_ActivityDetail.idsPathFileUpdate;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_ACTIVITY_DETAIL_CREATE", Parametro))
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

            return resultado.ToString();
        }

        public string UpdateStateActivityDetail(BE_ActivityDetail bE_ActivityDetail)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_ActivityDetail.RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdActivity", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_ActivityDetail.IdActivity;

                    Parametro[2] = new SqlParameter("@NroTicket", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_ActivityDetail.NumberTicket;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "STR_UPDATE_STATE_ACTIVITY_DETAIL", Parametro))
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

            return resultado.ToString();
        }

    }
}
