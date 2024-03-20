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
    public class DA_ListGeneralActivity
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Activity> ListarGeneralActivity()
        {
            SqlConnection conexion = null;

            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    //SqlParameter[] Parametro = new SqlParameter[2];

                    //Parametro[0] = new SqlParameter("@NroTicket", SqlDbType.VarChar);
                    //Parametro[0].Direction = ParameterDirection.Input;
                    //Parametro[0].Value = NroTicket;

                    //Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_GENERAL_ACTIVITY"))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Activity.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Activity.UsuarioNameTicket = DataUtil.ObjectToString(reader["UsuarioName"]);
                            bE_Activity.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Activity.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Activity.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Activity.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Activity.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Activity.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Activity.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
                            bE_Activity.StatusTicket = DataUtil.ObjectToString(reader["StatusTicket"]);

                            /*------------ ACTIVITY ------------*/

                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            //bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]); 
                            //bE_Activity.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            //bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            bE_Activity.ValidationButton = DataUtil.ObjectToString(reader["ValidationButton"]);
                            //bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsible"]);
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

        public List<BE_Activity> ListarTicketYResponsableGraphic(string StatusTicket0, string ResponsibleId0, string EventFilterTicket)
        {
            SqlConnection conexion = null;

            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@StatusTicket", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = StatusTicket0;

                    Parametro[1] = new SqlParameter("@ResponsibleId", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = ResponsibleId0;

                    Parametro[2] = new SqlParameter("@EventFilterTicket", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = EventFilterTicket;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_GRAPHIC_TICKET_RESPONSIBLE_PRUEBA", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Activity.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);

                            bE_Activity.IdPerson = DataUtil.ObjectToString(reader["IdPerson"]);
                            bE_Activity.PersonAlias = DataUtil.ObjectToString(reader["PersonAlias"]);

                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.OperationAlias = DataUtil.ObjectToString(reader["OperationAlias"]);
                            bE_Activity.CodeColorOperation = DataUtil.ObjectToString(reader["CodeColor"]);
                            /*------------ ACTIVITY ------------*/

                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
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

        public List<BE_Activity> ListarUserActivitiesGraphic(int RegistrationUserX)
        {
            SqlConnection conexion = null;

            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUserX;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_GRAPHIC_MY_TICKETS" , Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Activity.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);

                            bE_Activity.IdPerson = DataUtil.ObjectToString(reader["IdPerson"]);
                            bE_Activity.PersonAlias = DataUtil.ObjectToString(reader["PersonAlias"]);

                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.OperationAlias = DataUtil.ObjectToString(reader["OperationAlias"]);
                            bE_Activity.CodeColorOperation = DataUtil.ObjectToString(reader["CodeColor"]);
                            /*------------ ACTIVITY ------------*/

                            //bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
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

        public List<BE_Ticket> ListDetalleTicketResponsible(string TicketNumber)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@NroTicket", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = TicketNumber;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_DETAIL_TICKET_RESPONSIBLE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.StartHour = DataUtil.ObjectToString(reader["StartHour"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.UsuarioNameTicket = DataUtil.ObjectToString(reader["UsuarioName"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Ticket.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
                            bE_Ticket.StatusTicket = DataUtil.ObjectToString(reader["StatusTicket"]);
                            bE_Ticket.CategoryTicketStatus = DataUtil.ObjectToString(reader["CategoryTicketName"]);
                            bE_Ticket.ProblemTicket = DataUtil.ObjectToString(reader["ProblemTicket"]);
                            bE_Ticket.SolutionTicket = DataUtil.ObjectToString(reader["SolutionTicket"]);
                            bE_Ticket.TicketTypeStatus = DataUtil.ObjectToString(reader["TicketTypeStatus"]);
                            bE_Ticket.ValidationUserOpId = DataUtil.ObjectToString(reader["ValidationUserOpId"]);
                            bE_Ticket.DateValidationUserOp = DataUtil.ObjectToString(reader["DateValidationUserOp"]);
                            bE_Ticket.ComponentIds = DataUtil.ObjectToString(reader["ComponentIds"]);
                            bE_Ticket.WhoCallId = DataUtil.ObjectToInt32(reader["WhoCallId"]);
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

        public List<BE_Activity> ListarArchivosDeActividades(int IdTicket)
        {
            SqlConnection conexion = null;

            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdTicket;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_FILES_TICKET_ACIVITY", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            bE_Activity.NumberTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);

                            bE_Activity.IdActivityDetail = DataUtil.ObjectToInt(reader["IdActivityDetail"]);
                            bE_Activity.DescriptionBoard = DataUtil.ObjectToString(reader["DescriptionBoard"]);
                            bE_Activity.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDate"]);
                            bE_Activity.ResponsibleActivity = DataUtil.ObjectToString(reader["ResponsibleActivity"]);

                            bE_Activity.IdActivityFiles = DataUtil.ObjectToInt(reader["IdActivityFiles"]);
                            bE_Activity.TituloInforme = DataUtil.ObjectToString(reader["TitleName"]);
                            bE_Activity.PathFile = DataUtil.ObjectToString(reader["PathFile"]);
                            bE_Activity.NameParaQuienInforme = DataUtil.ObjectToString(reader["ForWhoReport"]);
                            bE_Activity.AsuntoInforme = DataUtil.ObjectToString(reader["ReportMatter"]);
                            bE_Activity.OperacionNombre = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.FechaRegistroInforme = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Activity.AntecedentesInforme = DataUtil.ObjectToString(reader["ReportBackground"]);
                            bE_Activity.ConclusionesInforme = DataUtil.ObjectToString(reader["ReportConclusions"]);
                            bE_Activity.ActivityDevelopInforme = DataUtil.ObjectToString(reader["ActivityDevelopment"]);
                            bE_Activity.ReportRecommendations = DataUtil.ObjectToString(reader["ReportRecommendations"]);
                            bE_Activity.TipoArchivo = DataUtil.ObjectToString(reader["FileTableAbbreviation"]);
                            bE_Activity.StartDate = DataUtil.ObjectToString(reader["StartDate"]);

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

        public List<BE_Activity> ListarTodosArchivosDeActividades(int IdTicket, string RadioFile)
        {
            SqlConnection conexion = null;

            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdTicket;

                    Parametro[1] = new SqlParameter("@RadioFile", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RadioFile;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ALL_FILES_TICKET_ACIVITY", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            bE_Activity.NumberTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);

                            //bE_Activity.IdActivityDetail = DataUtil.ObjectToInt(reader["IdActivityDetail"]);
                            //bE_Activity.DescriptionBoard = DataUtil.ObjectToString(reader["DescriptionBoard"]);
                            bE_Activity.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDate"]);
                            //bE_Activity.ResponsibleActivity = DataUtil.ObjectToString(reader["ResponsibleActivity"]);

                            //bE_Activity.IdActivityFiles = DataUtil.ObjectToInt(reader["IdActivityFiles"]);
                            bE_Activity.TituloInforme = DataUtil.ObjectToString(reader["TitleName"]);
                            bE_Activity.PathFile = DataUtil.ObjectToString(reader["PathFile"]);
                            bE_Activity.NameParaQuienInforme = DataUtil.ObjectToString(reader["ForWhoReport"]);
                            bE_Activity.AsuntoInforme = DataUtil.ObjectToString(reader["ReportMatter"]);
                            bE_Activity.OperacionNombre = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.FechaRegistroInforme = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Activity.AntecedentesInforme = DataUtil.ObjectToString(reader["ReportBackground"]);
                            bE_Activity.ConclusionesInforme = DataUtil.ObjectToString(reader["ReportConclusions"]);
                            bE_Activity.ActivityDevelopInforme = DataUtil.ObjectToString(reader["ActivityDevelopment"]);
                            bE_Activity.ReportRecommendations = DataUtil.ObjectToString(reader["ReportRecommendations"]);
                            bE_Activity.TipoArchivo = DataUtil.ObjectToString(reader["FileTableAbbreviation"]);

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
