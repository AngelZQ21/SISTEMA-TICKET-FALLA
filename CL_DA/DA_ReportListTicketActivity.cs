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
    public class DA_ReportListTicketActivity
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Grafic_Value> ListTicketXActivityDate(string fechaInicio, string fechaFin)
        {
            SqlConnection conexion = null;
            List<BE_Grafic_Value> listaResultado = new List<BE_Grafic_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = fechaInicio;

                    Parametro[1] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = fechaFin;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_TICKET_DATES_GRAPHIS_BAR", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                            bE_Grafic_Value.CantidadTicketPendiente = DataUtil.ObjectToInt(reader["CantidadPendientes"]);
                            bE_Grafic_Value.CantidadTicketCompletado = DataUtil.ObjectToInt(reader["CantidadCompletados"]);
                            bE_Grafic_Value.FechaCreacion = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Grafic_Value.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Grafic_Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Grafic_Value>();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }

        public List<BE_Grafic_Value> ListTicketXActivityDate2(string fechaInicio, string fechaFin)
        {
            SqlConnection conexion = null;
            List<BE_Grafic_Value> listaResultado = new List<BE_Grafic_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = fechaInicio;

                    Parametro[1] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = fechaFin;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_ACTIVITY_DATES_GRAPHIS_BAR", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                            bE_Grafic_Value.CantidadActivityPendiente = DataUtil.ObjectToInt(reader["CantidadPendientes"]);
                            bE_Grafic_Value.CantidadActivityCompletado= DataUtil.ObjectToInt(reader["CantidadCompletados"]);
                            bE_Grafic_Value.FechaCreacion = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Grafic_Value.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Grafic_Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Grafic_Value>();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicket(string StatusBar, string FilterDate)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@StatusBar", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = StatusBar;

                    Parametro[1] = new SqlParameter("@FilterDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = FilterDate;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_BAR", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.UsuarioNameTicket = DataUtil.ObjectToString(reader["UsuarioName"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            //bE_Ticket.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            //bE_Ticket.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Activity> ListarActivity(string StatusBar, string FilterDate)
        {
            SqlConnection conexion = null;
            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@StatusBar", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = StatusBar;

                    Parametro[1] = new SqlParameter("@FilterDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = FilterDate;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITY_BAR", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            //bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            //bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            //bE_Activity.ValidationButton = DataUtil.ObjectToString(reader["ValidationButton"]);
                            //bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            //bE_Activity.IdResponsible = DataUtil.ObjectToInt(reader["IdResponsible"]);
                            bE_Activity.PercentageNumber = DataUtil.ObjectToString(reader["NumberPercentage"]);
                            bE_Activity.ValorConsulta = "1";
                            listaResultado.Add(bE_Activity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Activity bE_Activity = new BE_Activity();
                bE_Activity.ValorConsulta = "0";
                bE_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Activity);
            }
            return listaResultado;
        }
    }
}
