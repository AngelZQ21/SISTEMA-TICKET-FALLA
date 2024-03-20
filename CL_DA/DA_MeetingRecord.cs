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
    public class DA_MeetingRecord
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Meeting_Record> ListarReporteActaDeReunion(string StartDate, string EndDate, string IdsOperacion, int IdUser)
        {
            SqlConnection conexion = null;
            List<BE_Meeting_Record> listaResultado = new List<BE_Meeting_Record>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[4];

                    Parametro[0] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = StartDate;

                    Parametro[1] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = EndDate;

                    Parametro[2] = new SqlParameter("@IdsOperacion", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = IdsOperacion;
                    
                    Parametro[3] = new SqlParameter("@IdUser", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = IdUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_MEETING_RECORD_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Meeting_Record bE_Meeting_Record = new BE_Meeting_Record();
                            bE_Meeting_Record.bE_Operation = new BE_Operation();
                            bE_Meeting_Record.bE_Operation.IdOperation = DataUtil.ObjectToInt32(reader["IdOperation"]);
                            bE_Meeting_Record.bE_Operation.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Meeting_Record.bE_Employee = new BE_Employee();
                            bE_Meeting_Record.bE_Employee.IdEmployee = DataUtil.ObjectToInt32(reader["IdEmployee"]);
                            bE_Meeting_Record.bE_Employee.FullName = DataUtil.ObjectToString(reader["FullName"]);

                            bE_Meeting_Record.IdMeetingRecord = DataUtil.ObjectToInt32(reader["IdMeetingRecord"]);
                            bE_Meeting_Record.MeetingRecordNumber = DataUtil.ObjectToString(reader["MeetingRecordNumber"]);
                            bE_Meeting_Record.MeetingRecordDateString = DataUtil.ObjectToString(reader["MeetingRecordDateString"]);
                            bE_Meeting_Record.MeetingRecordHour = DataUtil.ObjectToString(reader["MeetingRecordHour"]);
                            bE_Meeting_Record.MeetingRecordStatus = DataUtil.ObjectToString(reader["MeetingRecordStatus"]);
                            bE_Meeting_Record.MeetingRecordStatusDescription = DataUtil.ObjectToString(reader["MeetingRecordStatusDescription"]);
                            bE_Meeting_Record.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Meeting_Record);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Meeting_Record bE_Meeting_Record = new BE_Meeting_Record();
                bE_Meeting_Record.ValorConsulta = "0";
                bE_Meeting_Record.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Meeting_Record);
            }
            return listaResultado;
        }
        
        public List<BE_Meeting_Record_Detail> ListarActaDeReunionDetalle(int IdMeetingRecord, int IdOperation)
        {
            SqlConnection conexion = null;
            List<BE_Meeting_Record_Detail> listaResultado = new List<BE_Meeting_Record_Detail>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@IdMeetingRecord", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdMeetingRecord;

                    Parametro[1] = new SqlParameter("@IdOperation", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = IdOperation;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_MEETING_RECORD_DETAIL_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Meeting_Record_Detail bE_Meeting_Record_Detail = new BE_Meeting_Record_Detail();
                            bE_Meeting_Record_Detail.bE_Employee = new BE_Employee();
                            bE_Meeting_Record_Detail.bE_PathFile = new BE_PathFile();
                            bE_Meeting_Record_Detail.bE_Meeting_Record = new BE_Meeting_Record();
                            bE_Meeting_Record_Detail.bE_Employee.IdEmployee= DataUtil.ObjectToInt32(reader["IdEmployee"]);
                            bE_Meeting_Record_Detail.bE_Employee.FullName= DataUtil.ObjectToString(reader["FullName"]);
                            bE_Meeting_Record_Detail.bE_PathFile.IdPathFile= DataUtil.ObjectToInt32(reader["IdPathFile"]);
                            bE_Meeting_Record_Detail.bE_PathFile.PathFile= DataUtil.ObjectToString(reader["PathFile"]);
                            bE_Meeting_Record_Detail.bE_PathFile.FileNameRegister= DataUtil.ObjectToString(reader["FileNameRegister"]);
                            bE_Meeting_Record_Detail.bE_Meeting_Record.IdMeetingRecord = DataUtil.ObjectToInt32(reader["IdMeetingRecord"]);
                            bE_Meeting_Record_Detail.bE_Meeting_Record.MeetingRecordNumber = DataUtil.ObjectToString(reader["MeetingRecordNumber"]);
                            bE_Meeting_Record_Detail.bE_Meeting_Record.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDateString"]);
                            bE_Meeting_Record_Detail.IdMeetingRecordDetail = DataUtil.ObjectToInt32(reader["IdMeetingRecordDetail"]);
                            bE_Meeting_Record_Detail.IdPointDiscussed= DataUtil.ObjectToInt32(reader["IdPointDiscussed"]);
                            bE_Meeting_Record_Detail.IdPointDiscussedDescription= DataUtil.ObjectToString(reader["IdPointDiscussedDescription"]);
                            bE_Meeting_Record_Detail.MeetingRecordDetailEvent= DataUtil.ObjectToString(reader["MeetingRecordDetailEvent"]);
                            bE_Meeting_Record_Detail.MeetingRecordDetailDateString= DataUtil.ObjectToString(reader["MeetingRecordDetailDateString"]);
                            bE_Meeting_Record_Detail.MeetingRecordDetailStatus= DataUtil.ObjectToString(reader["MeetingRecordDetailStatus"]);
                            bE_Meeting_Record_Detail.MeetingRecordDetailStatusDescription= DataUtil.ObjectToString(reader["MeetingRecordDetailStatusDescription"]);
                            bE_Meeting_Record_Detail.MeetingRecordDetailTopic= DataUtil.ObjectToString(reader["MeetingRecordDetailTopic"]);
                            bE_Meeting_Record_Detail.IdPrincipalEmployee = DataUtil.ObjectToInt32(reader["IdPrincipalEmployee"]);
                            bE_Meeting_Record_Detail.PrincipalFullName = DataUtil.ObjectToString(reader["PrincipalFullName"]);
                            bE_Meeting_Record_Detail.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Meeting_Record_Detail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Meeting_Record_Detail bE_Meeting_Record_Detail = new BE_Meeting_Record_Detail();
                bE_Meeting_Record_Detail.ValorConsulta = "0";
                bE_Meeting_Record_Detail.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Meeting_Record_Detail);
            }
            return listaResultado;
        }

        public string RegistrarActaDeReunion(BE_Meeting_Record bE_Meeting_Record)
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
                    Parametro[0].Value = bE_Meeting_Record.RegistrationUser;

                    Parametro[1] = new SqlParameter("@ListaPuntosATratarXML", SqlDbType.Xml);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Meeting_Record.ListaPuntosATratarXML;

                    Parametro[2] = new SqlParameter("@IdOperation", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Meeting_Record.bE_Operation.IdOperation;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_MEETING_RECORD_CREATE", Parametro))
                    {
                        while (reader.Read())
                        {
                            resultado = DataUtil.ObjectToString(reader["Resultado"]) + "|" + DataUtil.ObjectToString(reader["NroCierre"]);
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
        
        public string ActualizarActaDeReunion(BE_Meeting_Record bE_Meeting_Record)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];
                    Parametro[0] = new SqlParameter("@UpdateUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Meeting_Record.UpdateUser;

                    Parametro[1] = new SqlParameter("@IdMeetingRecord", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Meeting_Record.IdMeetingRecord;

                    Parametro[2] = new SqlParameter("@ListaPuntosATratarXML", SqlDbType.Xml);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Meeting_Record.ListaPuntosATratarXML;

                    Parametro[3] = new SqlParameter("@IdOperation", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Meeting_Record.bE_Operation.IdOperation;

                    Parametro[4] = new SqlParameter("@IdsMeetingRecordDetail", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_Meeting_Record.IdsMeetingRecordDetail;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_MEETING_RECORD_UPDATE", Parametro))
                    {
                        while (reader.Read())
                        {
                            resultado = DataUtil.ObjectToString(reader["Resultado"]) + "|" + DataUtil.ObjectToString(reader["NroCierre"]);
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
