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
    public class DA_Meeting_Record_Activity
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Meeting_Record_Activity> ListarActividadesPendientes(int IdGuardChange)
        {
            SqlConnection conexion = null;
            List<BE_Meeting_Record_Activity> listaResultado = new List<BE_Meeting_Record_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@IdGuardChange", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdGuardChange;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_MEETING_RECORD_ACTIVITY_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Meeting_Record_Activity bE_Meeting_Record_Activity = new BE_Meeting_Record_Activity();
                            bE_Meeting_Record_Activity.bE_Meeting_Record_Detail = new BE_Meeting_Record_Detail();
                            bE_Meeting_Record_Activity.bE_Employee = new BE_Employee();
                            bE_Meeting_Record_Activity.bE_GuardChange = new BE_GuardChange();

                            bE_Meeting_Record_Activity.IdMeetingRecordActivity = DataUtil.ObjectToInt32(reader["IdMeetingRecordActivity"]);
                            bE_Meeting_Record_Activity.bE_GuardChange.IdGuardChange = DataUtil.ObjectToInt32(reader["IdGuardChange"]);
                            bE_Meeting_Record_Activity.bE_Meeting_Record_Detail.IdMeetingRecordDetail = DataUtil.ObjectToInt32(reader["IdMeetingRecordDetail"]);
                            bE_Meeting_Record_Activity.bE_Employee.IdEmployee = DataUtil.ObjectToInt32(reader["IdEmployee"]);
                            bE_Meeting_Record_Activity.bE_Employee.FullName = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Meeting_Record_Activity.MeetingRecordActivityActivity = DataUtil.ObjectToString(reader["MeetingRecordActivityActivity"]);
                            bE_Meeting_Record_Activity.MeetingRecordActivityCommentary = DataUtil.ObjectToString(reader["MeetingRecordActivityCommentary"]);
                            bE_Meeting_Record_Activity.MeetingRecordActivityEndDateString = DataUtil.ObjectToString(reader["MeetingRecordActivityEndDateString"]);
                            bE_Meeting_Record_Activity.MeetingRecordActivityStatus = DataUtil.ObjectToString(reader["MeetingRecordActivityStatus"]);
                            bE_Meeting_Record_Activity.MeetingRecordActivityStatusDescription = DataUtil.ObjectToString(reader["MeetingRecordActivityStatusDescription"]);
                            
                            bE_Meeting_Record_Activity.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Meeting_Record_Activity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Meeting_Record_Activity bE_Meeting_Record_Activity = new BE_Meeting_Record_Activity();
                bE_Meeting_Record_Activity.ValorConsulta = "0";
                bE_Meeting_Record_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Meeting_Record_Activity);
            }
            return listaResultado;
        }


    }
}
