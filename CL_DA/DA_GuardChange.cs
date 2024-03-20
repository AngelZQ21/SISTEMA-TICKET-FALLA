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
    public class DA_GuardChange
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_GuardChange> ListarReporteCambioDeGuardia(string StartDate, string EndDate, string IdsOperacion)
        {
            SqlConnection conexion = null;
            List<BE_GuardChange> listaResultado = new List<BE_GuardChange>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = StartDate;

                    Parametro[1] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = EndDate;

                    Parametro[2] = new SqlParameter("@IdsOperacion", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = IdsOperacion;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_GUARD_CHANGE_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_GuardChange bE_GuardChange = new BE_GuardChange();
                            bE_GuardChange.bE_Operation = new BE_Operation();
                            bE_GuardChange.bE_Meeting_Record = new BE_Meeting_Record();
                            bE_GuardChange.bE_Meeting_Record.bE_Employee = new BE_Employee();
                            bE_GuardChange.bE_Meeting_Record.bE_Employee.IdEmployee = DataUtil.ObjectToInt32(reader["MeetingRecordIdEmployee"]);
                            bE_GuardChange.bE_Meeting_Record.IdMeetingRecord = DataUtil.ObjectToInt32(reader["IdMeetingRecord"]);
                            bE_GuardChange.bE_Meeting_Record.MeetingRecordNumber = DataUtil.ObjectToString(reader["MeetingRecordNumber"]);
                            bE_GuardChange.bE_Meeting_Record.RegistrationDateString = DataUtil.ObjectToString(reader["MeetingRecordRegistrationDateString"]);
                            bE_GuardChange.bE_Meeting_Record.FullName = DataUtil.ObjectToString(reader["MeetingRecordFullName"]);

                            bE_GuardChange.bE_Operation.IdOperation = DataUtil.ObjectToInt32(reader["IdOperation"]);
                            bE_GuardChange.bE_Operation.OperationName = DataUtil.ObjectToString(reader["OperationName"]);

                            bE_GuardChange.FullName = DataUtil.ObjectToString(reader["GuardChangeFullName"]);
                            bE_GuardChange.IdGuardChange = DataUtil.ObjectToInt32(reader["IdGuardChange"]);
                            bE_GuardChange.IdsPrincipals = DataUtil.ObjectToString(reader["IdsPrincipals"]);
                            bE_GuardChange.IdsGuests = DataUtil.ObjectToString(reader["IdsGuests"]);
                            bE_GuardChange.GuardChangeDateString = DataUtil.ObjectToString(reader["GuardChangeDateString"]);
                            bE_GuardChange.GuardChangeHour = DataUtil.ObjectToString(reader["GuardChangeHour"]);
                            bE_GuardChange.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_GuardChange);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_GuardChange bE_GuardChange = new BE_GuardChange();
                bE_GuardChange.ValorConsulta = "0";
                bE_GuardChange.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_GuardChange);
            }
            return listaResultado;
        }
        public List<BE_Employee> RegistrarCambioDeGuardia(BE_GuardChange bE_GuardChange)
        {
            SqlConnection conexion = null;
            List<BE_Employee> listaResultado = new List<BE_Employee>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_GuardChange.RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdOperation", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_GuardChange.bE_Operation.IdOperation;

                    Parametro[2] = new SqlParameter("@IdMeetingRecord", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_GuardChange.bE_Meeting_Record.IdMeetingRecord;

                    Parametro[3] = new SqlParameter("@ListaTrabajadoresXML", SqlDbType.Xml);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_GuardChange.ListaTrabajadoresXML;
                    
                    Parametro[4] = new SqlParameter("@ListaActividadesXML", SqlDbType.Xml);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_GuardChange.ListaActividadesXML;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_GUARD_CHANGE_CREATE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Employee bE_Employee = new BE_Employee();
                            bE_Employee.EmployeeMails = DataUtil.ObjectToString(reader["EmployeeMails"]);
                            bE_Employee.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Employee);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Employee bE_Employee = new BE_Employee();
                bE_Employee.ValorConsulta = "0";
                bE_Employee.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Employee);
            }

            return listaResultado;
        }




    }
}
