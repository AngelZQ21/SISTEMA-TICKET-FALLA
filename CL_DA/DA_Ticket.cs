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
    public class DA_Ticket
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Ticket> CrearTicket(BE_Ticket bE_Ticket)
        {
            //BE_Ticket bE_Ticket = new BE_Ticket();
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    
                    SqlParameter[] Parametro = new SqlParameter[12];

                    Parametro[0] = new SqlParameter("@IdOperation", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Ticket.IdOperation;

                    Parametro[1] = new SqlParameter("@IdEncargado", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Ticket.IdEncargado;

                    Parametro[2] = new SqlParameter("@FechaInicio", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Ticket.FechaInicio;

                    Parametro[3] = new SqlParameter("@IdRazon", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Ticket.IdRazon;

                    Parametro[4] = new SqlParameter("@IdCriticidad", SqlDbType.Int);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_Ticket.IdCriticidad;

                    Parametro[5] = new SqlParameter("@DetalleText", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_Ticket.DetalleText;

                    Parametro[6] = new SqlParameter("@RegisterUser", SqlDbType.Int);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_Ticket.RegistrationUser;

                    Parametro[7] = new SqlParameter("@ResponsibleId", SqlDbType.Int);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = bE_Ticket.ResponsibleId;

                    Parametro[8] = new SqlParameter("@LocationId", SqlDbType.Int);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = bE_Ticket.IdLocation;

                    Parametro[9] = new SqlParameter("@TitleDetalle", SqlDbType.VarChar);
                    Parametro[9].Direction = ParameterDirection.Input;
                    Parametro[9].Value = bE_Ticket.TitleDetalle;

                    Parametro[10] = new SqlParameter("@StatusFile", SqlDbType.VarChar);
                    Parametro[10].Direction = ParameterDirection.Input;
                    Parametro[10].Value = bE_Ticket.StatusFile;

                    Parametro[11] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[11].Direction = ParameterDirection.Input;
                    Parametro[11].Value = bE_Ticket.StatusCategory;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_CREATE_TICKET", Parametro))
                    {
                        while (reader.Read())
                        {
                            //BE_Ticket bE_Ticket = new BE_Ticket();
                            //bE_Ticket.IdTicket = DataUtil.ObjectToInt(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]); 
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ReponsibleName"]);
                            bE_Ticket.PersonMail = DataUtil.ObjectToString(reader["PersonMail"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.EmailWhoCall = DataUtil.ObjectToString(reader["EmailWhoCall"]);
                            bE_Ticket.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
                            //bE_Ticket.StatusCategory = DataUtil.ObjectToString(reader["CategoryTicketStatus"]);
                            //bE_Ticket.EmailUserLogin = DataUtil.ObjectToString(reader["EmailUserLogin"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                //BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }

            return listaResultado;
        }
        
        public List<BE_Ticket> ListarTicketCreado(string StartDate, string EndDate, string IdTicket, int ValueFilter)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
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

                    Parametro[2] = new SqlParameter("@IdTicket", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = IdTicket;

                    Parametro[3] = new SqlParameter("@ValueFilter", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = ValueFilter;

                    //Parametro[4] = new SqlParameter("@IdTicket", SqlDbType.VarChar);
                    //Parametro[4].Direction = ParameterDirection.Input;
                    //Parametro[4].Value = IdTicket;

                    //Parametro[5] = new SqlParameter("@IdCriticidad", SqlDbType.Int);
                    //Parametro[5].Direction = ParameterDirection.Input;
                    //Parametro[5].Value = IdCriticalidad;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_GENERATE_2", Parametro))
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
                            bE_Ticket.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Ticket.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
                            bE_Ticket.StatusTicket = DataUtil.ObjectToString(reader["StatusTicket"]);
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

        public List<BE_Ticket> ListarVigenciaFechas(string StartDate, string EndDate, string IdTicket, string IdResponsable, string TypeValue)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];

                    Parametro[0] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = StartDate;

                    Parametro[1] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = EndDate;

                    Parametro[2] = new SqlParameter("@IdTicket", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = IdTicket;

                    Parametro[3] = new SqlParameter("@IdResponsible", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = IdResponsable;

                    Parametro[4] = new SqlParameter("@TypeValue", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = TypeValue;

                    //Parametro[5] = new SqlParameter("@IdCriticidad", SqlDbType.Int);
                    //Parametro[5].Direction = ParameterDirection.Input;
                    //Parametro[5].Value = IdCriticalidad;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_VADILITY_TICKET", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["FechaRegistroTicket"]);
                            bE_Ticket.EndDate = DataUtil.ObjectToString(reader["FechaFinTicket"]);
                            bE_Ticket.DifferenceDate = DataUtil.ObjectToString(reader["DiferenciaEnDias"]);                               
                            bE_Ticket.StatusTicket = DataUtil.ObjectToString(reader["EstadoTicket"]);
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

        public List<BE_Ticket> ListarDetalleTicketGraphic(string NumberTicket)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@NumberTicket", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = NumberTicket;

                    //Parametro[1] = new SqlParameter("@StatusValue", SqlDbType.VarChar);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = Estado;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_GRAPHIC", Parametro))
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

        public List<BE_Ticket> ListNumberTicket(BE_Ticket bE_Ticket)
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
                    Parametro[0].Value = bE_Ticket.NroTicket;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_RESEND_EMAIL", Parametro))
                    {
                        while (reader.Read())
                        {
                            //BE_Ticket bE_Ticket = new BE_Ticket();

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
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.CategoryTicketStatus = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                //BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketBusqueda(string StartDate, string EndDate, int RegistrationUser, string StatusCategory, string NumberTicketSearch, string FilterType)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[6];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    //Parametro[1] = new SqlParameter("@FilterValue", SqlDbType.VarChar);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = FilterValue;

                    //Parametro[1] = new SqlParameter("@IdTicket", SqlDbType.VarChar);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = IdTicket;

                    Parametro[1] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = StartDate;

                    Parametro[2] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = EndDate;

                    //Parametro[5] = new SqlParameter("@FilterValuePenCom", SqlDbType.VarChar);
                    //Parametro[5].Direction = ParameterDirection.Input;
                    //Parametro[5].Value = FilterValuePenCom;

                    Parametro[3] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = StatusCategory;
                    
                    Parametro[4] = new SqlParameter("@NumberTicketSearch", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = NumberTicketSearch;

                    //Parametro[5] = new SqlParameter("@FilterPlatMov", SqlDbType.VarChar);
                    //Parametro[5].Direction = ParameterDirection.Input;
                    //Parametro[5].Value = PlatMovlStatus;

                    Parametro[5] = new SqlParameter("@FilterType", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = FilterType;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET__BUSQUEDA", Parametro))
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
                            bE_Ticket.WhoCallId = DataUtil.ObjectToInt(reader["WhoCallId"]);
                            bE_Ticket.StartDateTime = DataUtil.ObjectToString(reader["StartDateTime"]);
                            bE_Ticket.OperandDateTime = DataUtil.ObjectToString(reader["OperandDateTime"]);
                            bE_Ticket.EndDateTime = DataUtil.ObjectToString(reader["EndDateTime"]);
                            bE_Ticket.ComponentIds = DataUtil.ObjectToString(reader["ComponentIds"]);
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

        public List<BE_Ticket> ListarTicketPendientes(BE_Ticket bE_Ticket)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    //Parametro[0] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    //Parametro[0].Direction = ParameterDirection.Input;
                    //Parametro[0].Value = StartDate;

                    //Parametro[1] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = EndDate;

                    //Parametro[2] = new SqlParameter("@IdOperation", SqlDbType.VarChar);
                    //Parametro[2].Direction = ParameterDirection.Input;
                    //Parametro[2].Value = IdsOperacion;

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Ticket.RegistrationUser;

                    Parametro[1] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Ticket.StatusCategory;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LST_COMBO_TICKET" , Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_TicketT = new BE_Ticket();

                            bE_TicketT.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_TicketT.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_TicketT.ValorConsulta = "1";
                            listaResultado.Add(bE_TicketT);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                //BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketCompletados(BE_Ticket bE_Ticket)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    //Parametro[0] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    //Parametro[0].Direction = ParameterDirection.Input;
                    //Parametro[0].Value = StartDate;

                    //Parametro[1] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = EndDate;

                    //Parametro[2] = new SqlParameter("@IdOperation", SqlDbType.VarChar);
                    //Parametro[2].Direction = ParameterDirection.Input;
                    //Parametro[2].Value = IdsOperacion;

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Ticket.RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LST_COMBO_TICKET_COMPLETE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_TicketT = new BE_Ticket();

                            bE_TicketT.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_TicketT.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_TicketT.ValorConsulta = "1";
                            listaResultado.Add(bE_TicketT);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                //BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public String AnularTicket(int IdTicket, int RegistrationUser)
        {
            SqlConnection conexion = null;
            var listaResultado = "";
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdTicket;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_INACTIVITY_TICKET", Parametro))
                    {
                        while (reader.Read())
                        {
                            listaResultado = DataUtil.ObjectToString(reader["Resultado"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }
            return listaResultado;
        }

        public String ActualizarSolutionTicketMovil(int TicketIdMovil, string ValueLstComponent, string TicketProblem, string TicketSolution, int RegistrationUser)
        {
            SqlConnection conexion = null;
            var listaResultado = "";
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];

                    Parametro[0] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = TicketIdMovil;

                    //Parametro[1] = new SqlParameter("@TitleDetailMovil", SqlDbType.VarChar);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = TitleDetailMovil;

                    Parametro[1] = new SqlParameter("@TicketProblem", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = TicketProblem;

                    Parametro[2] = new SqlParameter("@TicketSolution", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = TicketSolution;

                    Parametro[3] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = RegistrationUser;

                    Parametro[4] = new SqlParameter("@IdLstComponent", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = ValueLstComponent;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_PROBLEM_SOLUTION_TICKET_MOVIL", Parametro))
                    {
                        while (reader.Read())
                        {
                            listaResultado = DataUtil.ObjectToString(reader["Resultado"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }
            return listaResultado;
        }

        public List<BE_Ticket> ActualizarDetalleTicketMovil(int TicketIdMovil, string TitleDetailMovil, int IdLocationDetail, string DetailTicket, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];

                    Parametro[0] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = TicketIdMovil;

                    Parametro[1] = new SqlParameter("@TitleDetailMovil", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = TitleDetailMovil;

                    Parametro[2] = new SqlParameter("@IdLocationDetail", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = IdLocationDetail;

                    Parametro[3] = new SqlParameter("@DetailTicket", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = DetailTicket;

                    Parametro[4] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = RegistrationUser;

                    //Parametro[5] = new SqlParameter("@TicketProblem", SqlDbType.VarChar);
                    //Parametro[5].Direction = ParameterDirection.Input;
                    //Parametro[5].Value = TicketProblem;

                    //Parametro[6] = new SqlParameter("@TicketSolution", SqlDbType.VarChar);
                    //Parametro[6].Direction = ParameterDirection.Input;
                    //Parametro[6].Value = TicketSolution;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_UPDATE_TICKET_MOVIL_DETAIL", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.TitleValue = DataUtil.ObjectToString(reader["TitleValue"]);
                            bE_Ticket.LocationValue = DataUtil.ObjectToString(reader["LocationValue"]);
                            bE_Ticket.DetailValue = DataUtil.ObjectToString(reader["DetailValue"]);
                            //bE_Ticket.ProblemValue = DataUtil.ObjectToString(reader["ProblemValue"]);
                            //bE_Ticket.SolutionValue = DataUtil.ObjectToString(reader["SolutionValue"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Grafic_Value> ListarTicketsXOperacion(int RegistrationUser, string fechaInicio, string fechaFin, string Estado, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Grafic_Value> listaResultado = new List<BE_Grafic_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = fechaInicio;

                    Parametro[2] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = fechaFin;

                    Parametro[3] = new SqlParameter("@StatusValue", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = Estado;

                    Parametro[4] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = StatusCategory;

                    //Parametro[4] = new SqlParameter("@CompartmentName", SqlDbType.VarChar);
                    //Parametro[4].Direction = ParameterDirection.Input;
                    //Parametro[4].Value = CompartmentName;

                    //Parametro[5] = new SqlParameter("@ProductName", SqlDbType.VarChar);
                    //Parametro[5].Direction = ParameterDirection.Input;
                    //Parametro[5].Value = ProductName;

                    //Parametro[6] = new SqlParameter("@ReasonName", SqlDbType.VarChar);
                    //Parametro[6].Direction = ParameterDirection.Input;
                    //Parametro[6].Value = ReasonName;

                    //Parametro[7] = new SqlParameter("@PNPName", SqlDbType.VarChar);
                    //Parametro[7].Direction = ParameterDirection.Input;
                    //Parametro[7].Value = PNPName;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_GRAPHIST_TICKET_TO_OPERATION", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();

                            bE_Grafic_Value.TicketQuantity = DataUtil.ObjectToInt(reader["CantidadTicket"]);
                            bE_Grafic_Value.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Grafic_Value.ValorConsulta = "1";
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

        public List<BE_Grafic_Value> ListCycleTicketVehicle(string ValueYear, string ValueMonth)
        {
            SqlConnection conexion = null;
            List<BE_Grafic_Value> listaResultado = new List<BE_Grafic_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@ValueYear", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = ValueYear;

                    Parametro[1] = new SqlParameter("@ValueMonth", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = ValueMonth;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LST_CYCLE_STATUS_TICKET", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();

                            bE_Grafic_Value.NumberTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Grafic_Value.DifferenceFirst = DataUtil.ObjectToInt(reader["DifferenceFirst"]);
                            bE_Grafic_Value.DifferenceSecond = DataUtil.ObjectToInt(reader["DifferenceSecond"]);
                            bE_Grafic_Value.Pendiente = DataUtil.ObjectToString(reader["Pendiente"]);
                            bE_Grafic_Value.Operando = DataUtil.ObjectToString(reader["Operando"]);
                            bE_Grafic_Value.Completado = DataUtil.ObjectToString(reader["Completado"]);
                            //bE_Grafic_Value.NumberTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            //bE_Grafic_Value.QuantityValue = DataUtil.ObjectToInt(reader["QuantityTicket"]);
                            //bE_Grafic_Value.FechaValue = DataUtil.ObjectToString(reader["FechaValue"]);
                            //bE_Grafic_Value.StatusTicket = DataUtil.ObjectToString(reader["StatusTicket"]);
                            //bE_Grafic_Value.DataType = DataUtil.ObjectToString(reader["DataType"]);
                            bE_Grafic_Value.ValorConsulta = "1";
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

        public List<BE_Grafic_Value> ListarTicketsXMeses(int RegistrationUser, string fechaInicio, string fechaFin, string Estado, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Grafic_Value> listaResultado = new List<BE_Grafic_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = fechaInicio;

                    Parametro[2] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = fechaFin;

                    Parametro[3] = new SqlParameter("@StatusValue", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = Estado;

                    Parametro[4] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = StatusCategory;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_GRAPHIST_TICKET_TO_MONTH", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();

                            bE_Grafic_Value.TicketQuantity = DataUtil.ObjectToInt(reader["CantidadTicket"]);
                            bE_Grafic_Value.CalendarMonthName = DataUtil.ObjectToString(reader["CalendarMonthName"]);
                            bE_Grafic_Value.ValorConsulta = "1";
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

        public List<BE_Grafic_Value> ListarActividadesXOperacion(int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Grafic_Value> listaResultado = new List<BE_Grafic_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    //Parametro[1] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = fechaFin;

                    //Parametro[2] = new SqlParameter("@IdFleet", SqlDbType.VarChar);
                    //Parametro[2].Direction = ParameterDirection.Input;
                    //Parametro[2].Value = idFleet;

                    //Parametro[3] = new SqlParameter("@IdVehicle", SqlDbType.VarChar);
                    //Parametro[3].Direction = ParameterDirection.Input;
                    //Parametro[3].Value = idVehicle;

                    //Parametro[4] = new SqlParameter("@CompartmentName", SqlDbType.VarChar);
                    //Parametro[4].Direction = ParameterDirection.Input;
                    //Parametro[4].Value = CompartmentName;

                    //Parametro[5] = new SqlParameter("@ProductName", SqlDbType.VarChar);
                    //Parametro[5].Direction = ParameterDirection.Input;
                    //Parametro[5].Value = ProductName;

                    //Parametro[6] = new SqlParameter("@ReasonName", SqlDbType.VarChar);
                    //Parametro[6].Direction = ParameterDirection.Input;
                    //Parametro[6].Value = ReasonName;

                    //Parametro[7] = new SqlParameter("@PNPName", SqlDbType.VarChar);
                    //Parametro[7].Direction = ParameterDirection.Input;
                    //Parametro[7].Value = PNPName;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_GRAPHIST_ACTIVITY_TO_OPERATION" , Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();

                            bE_Grafic_Value.ActivityQuantity = DataUtil.ObjectToInt(reader["CantidadActividad"]);
                            bE_Grafic_Value.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Grafic_Value.ValorConsulta = "1";
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

        public List<BE_Grafic_Value> ListarActividadesXUsuario(int RegistrationUser, string fechaInicio, string fechaFin, string Estado, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Grafic_Value> listaResultado = new List<BE_Grafic_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = fechaInicio;

                    Parametro[2] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = fechaFin;

                    Parametro[3] = new SqlParameter("@StatusValue", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = Estado;

                    Parametro[4] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = StatusCategory;

                    //Parametro[4] = new SqlParameter("@CompartmentName", SqlDbType.VarChar);
                    //Parametro[4].Direction = ParameterDirection.Input;
                    //Parametro[4].Value = CompartmentName;

                    //Parametro[5] = new SqlParameter("@ProductName", SqlDbType.VarChar);
                    //Parametro[5].Direction = ParameterDirection.Input;
                    //Parametro[5].Value = ProductName;

                    //Parametro[6] = new SqlParameter("@ReasonName", SqlDbType.VarChar);
                    //Parametro[6].Direction = ParameterDirection.Input;
                    //Parametro[6].Value = ReasonName;

                    //Parametro[7] = new SqlParameter("@PNPName", SqlDbType.VarChar);
                    //Parametro[7].Direction = ParameterDirection.Input;
                    //Parametro[7].Value = PNPName;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_GRAPHIST_ACTIVITY_TO_USER", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();

                            bE_Grafic_Value.ActivityQuantity = DataUtil.ObjectToInt(reader["CantidadTicket"]);
                            bE_Grafic_Value.ResponsibleName = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Grafic_Value.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Grafic_Value.ValorConsulta = "1";
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

        public List<BE_Grafic_Value> ListarTicketXActividad(int IdTicket, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Grafic_Value> listaResultado = new List<BE_Grafic_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdTicket;

                    Parametro[1] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = StatusCategory;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_GRAPHIC_TICKET_X_ACTIVITY_7", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();

                            bE_Grafic_Value.ResponsibleName = DataUtil.ObjectToString(reader["PersonName"]);
                            bE_Grafic_Value.NumberPercentage = DataUtil.ObjectToInt(reader["NumberPercentage"]);
                            bE_Grafic_Value.ValorConsulta = "1";
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

        public List<BE_Grafic_Value> ListarActividadesXUsuarioASSAC()
        {
            SqlConnection conexion = null;
            List<BE_Grafic_Value> listaResultado = new List<BE_Grafic_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    //SqlParameter[] Parametro = new SqlParameter[1];

                    //Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    //Parametro[0].Direction = ParameterDirection.Input;
                    //Parametro[0].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_GRAPHIST_ACTIVITY_TO_USER_ASSAC"))
                    {
                        while (reader.Read())
                        {
                            BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();

                            bE_Grafic_Value.ActivityQuantity = DataUtil.ObjectToInt(reader["CantidadActividad"]);
                            bE_Grafic_Value.ResponsibleName = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Grafic_Value.ValorConsulta = "1";
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

        public List<BE_PathFile> ListarArchivoTicket(int IdTicket)
        {
            SqlConnection conexion = null;
            List<BE_PathFile> listaResultado = new List<BE_PathFile>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdTicket;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_PATH_FILE_TICKET", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_PathFile bE_Path = new BE_PathFile();
                            bE_Path.IdPathFile = DataUtil.ObjectToInt32(reader["IdTicketFile"]);
                            //bE_Path.FileTableAbbreviation = DataUtil.ObjectToString(reader["FileTableAbbreviation"]);
                            bE_Path.IdRegister = DataUtil.ObjectToInt32(reader["IdRegister"]);
                            bE_Path.PathFile = DataUtil.ObjectToString(reader["PathFile"]);
                            bE_Path.FileNameRegister = DataUtil.ObjectToString(reader["FileNameRegister"]);
                            bE_Path.FileSize = DataUtil.ObjectToString(reader["FileSize"]);
                            //bE_Path.FileType = DataUtil.ObjectToString(reader["FileType"]);
                            //bE_Path.FullName = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Path.RegistrationDate = DataUtil.ObjectToDateTime(reader["RegistrationDate"]);
                            bE_Path.TituloInforme = DataUtil.ObjectToString(reader["TitleName"]);
                            bE_Path.IdParaQuienInforme = DataUtil.ObjectToInt(reader["IdParaInforme"]);
                            bE_Path.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDateString"]);
                            bE_Path.NameParaQuienInforme = DataUtil.ObjectToString(reader["ForWhoReport"]);
                            bE_Path.AsuntoInforme = DataUtil.ObjectToString(reader["ReportMatter"]);
                            bE_Path.OperacionNombre = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Path.FechaRegistroInforme = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Path.AntecedentesInforme = DataUtil.ObjectToString(reader["ReportBackground"]);
                            bE_Path.ConclusionesInforme = DataUtil.ObjectToString(reader["ReportConclusions"]);
                            bE_Path.ActivityDevelopInforme = DataUtil.ObjectToString(reader["ActivityDevelopment"]);
                            bE_Path.RecomendacionesInforme = DataUtil.ObjectToString(reader["ReportRecommendations"]);
                            bE_Path.TipoArchivo = DataUtil.ObjectToString(reader["TipoArchivo"]);
                            bE_Path.ValorConsulta = "1";
                            listaResultado.Add(bE_Path);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_PathFile>();
                BE_PathFile bE_PathFile = new BE_PathFile();
                bE_PathFile.ValorConsulta = "0";
                bE_PathFile.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_PathFile);
            }
            return listaResultado;
        }

        public List<BE_Grafic_Value> ListActivityXTicket(string fechaInicio, string fechaFin, string Estado, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Grafic_Value> listaResultado = new List<BE_Grafic_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[4];

                    Parametro[0] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = fechaInicio;

                    Parametro[1] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = fechaFin;

                    Parametro[2] = new SqlParameter("@StatusValue", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = Estado;

                    Parametro[3] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = StatusCategory;

                    //Parametro[3] = new SqlParameter("@IdVehicle", SqlDbType.VarChar);
                    //Parametro[3].Direction = ParameterDirection.Input;
                    //Parametro[3].Value = idVehicle;

                    //Parametro[4] = new SqlParameter("@CompartmentName", SqlDbType.VarChar);
                    //Parametro[4].Direction = ParameterDirection.Input;
                    //Parametro[4].Value = CompartmentName;

                    //Parametro[5] = new SqlParameter("@ProductName", SqlDbType.VarChar);
                    //Parametro[5].Direction = ParameterDirection.Input;
                    //Parametro[5].Value = ProductName;

                    //Parametro[6] = new SqlParameter("@ReasonName", SqlDbType.VarChar);
                    //Parametro[6].Direction = ParameterDirection.Input;
                    //Parametro[6].Value = ReasonName;

                    //Parametro[7] = new SqlParameter("@PNPName", SqlDbType.VarChar);
                    //Parametro[7].Direction = ParameterDirection.Input;
                    //Parametro[7].Value = PNPName;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_GRAPHIST_ACTIVITY_TICKET" , Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();

                            bE_Grafic_Value.NumberTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Grafic_Value.ActivityQuantity = DataUtil.ObjectToInt(reader["CantidadActividad"]);
                            bE_Grafic_Value.ValorConsulta = "1";
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

        public List<BE_Ticket> ListarTicketBuscarUsuario(int RegistrationUser, int IdPerson, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@PersonId", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = IdPerson;

                    Parametro[2] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = StatusCategory;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_SEARCH_USERS", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.OldDifferenceDate = DataUtil.ObjectToString(reader["OldDifferenceDate"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Ticket.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketCriticidad(int RegistrationUser, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = StatusCategory;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_CRITIZIDE_PAST_DATE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.CantidadActividades = DataUtil.ObjectToString(reader["CantidadActividades"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]); 
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketCriticidadMediaCA(int RegistrationUser, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = StatusCategory;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_CRITIZIDE_PAST_DATE_MEDIA", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.CantidadActividades = DataUtil.ObjectToString(reader["CantidadActividades"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketCriticidadBajaCA(int RegistrationUser, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = StatusCategory;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_CRITIZIDE_PAST_DATE_BAJA", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.CantidadActividades = DataUtil.ObjectToString(reader["CantidadActividades"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketMedia(int RegistrationUser, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = StatusCategory;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_CRITIZIDE_MEDIA", Parametro))
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
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketGraphic(string OperationName)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@OperationName", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = OperationName;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_OPERATION_GRAPHIC", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketResponsibleGraphic(int IdResponsible)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@IdResponsible", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdResponsible;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_RESPONSIBLE_GRAPHIC", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_PathFile> ListarFileTicketGraphic(int IdTicket)
        {
            SqlConnection conexion = null;
            List<BE_PathFile> listaResultado = new List<BE_PathFile>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdTicket;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_PATH_FILE_TICKET_GRAPHIC", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_PathFile bE_PathFile = new BE_PathFile();

                            bE_PathFile.IdPathFile = DataUtil.ObjectToInt32(reader["IdTicketFile"]);
                            bE_PathFile.FileTableAbbreviation = DataUtil.ObjectToString(reader["FileTableAbbreviation"]);
                            bE_PathFile.IdRegister = DataUtil.ObjectToInt32(reader["IdRegister"]);
                            bE_PathFile.PathFile = DataUtil.ObjectToString(reader["PathFile"]);
                            bE_PathFile.FileNameRegister = DataUtil.ObjectToString(reader["FileNameRegister"]);
                            bE_PathFile.FileSize = DataUtil.ObjectToString(reader["FileSize"]);
                            bE_PathFile.FileType = DataUtil.ObjectToString(reader["FileType"]);
                            bE_PathFile.FullName = DataUtil.ObjectToString(reader["FullName"]);
                            bE_PathFile.RegistrationDate = DataUtil.ObjectToDateTime(reader["RegistrationDate"]);
                            bE_PathFile.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDateString"]);
                            bE_PathFile.ValorConsulta = "1";
                            listaResultado.Add(bE_PathFile);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_PathFile>();
                BE_PathFile bE_PathFile = new BE_PathFile();
                bE_PathFile.ValorConsulta = "0";
                bE_PathFile.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_PathFile);
            }

            return listaResultado;
        }

        public List<BE_Activity> ListarTicketPorActividad(int IdTicket, string Estado)
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

                    Parametro[1] = new SqlParameter("@StatusValue", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = Estado;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITY_GRAPHIC", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();


                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
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
                listaResultado = new List<BE_Activity>();
                BE_Activity bE_Activity = new BE_Activity();
                bE_Activity.ValorConsulta = "0";
                bE_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Activity);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketBaja(int RegistrationUser, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = StatusCategory;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_CRITIZIDE_BAJA", Parametro))
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
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketAlta(int RegistrationUser, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;
               
                    Parametro[1] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = StatusCategory;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_CRITIZIDE_ALTA", Parametro))
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
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarActRefereceTicket(string NroTicket)
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
                    Parametro[0].Value = NroTicket;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_REFERENCE_TICKET", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarActRefereceTicketPendiente(string NroTicket)
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
                    Parametro[0].Value = NroTicket;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_REFERENCE_TICKET_PENDIENTE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarActRefereceTicketCompletado(string NroTicket)
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
                    Parametro[0].Value = NroTicket;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_REFERENCE_TICKET_COMPLETADO", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketCombo(int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_COMBO", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketxResponsable(string StartDate, string EndDate, string IdsResponsible, string IdsTicket, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];

                    Parametro[0] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = StartDate;

                    Parametro[1] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = EndDate;

                    Parametro[2] = new SqlParameter("@IdResponsible", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = IdsResponsible;

                    Parametro[3] = new SqlParameter("@IdTicket", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = IdsTicket;
                    //Parametro[3] = new SqlParameter("@NumberTicket", SqlDbType.VarChar);
                    //Parametro[3].Direction = ParameterDirection.Input;
                    //Parametro[3].Value = NumberTicket;

                    Parametro[4] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_X_RESPONSIBLE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.UsuarioNameTicket = DataUtil.ObjectToString(reader["UsuarioName"]);
                            bE_Ticket.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
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

        public List<BE_Ticket> ListarTicketxResponsable2(string StartDate, string EndDate, string IdsTicket, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
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

                    //Parametro[2] = new SqlParameter("@IdResponsible", SqlDbType.VarChar);
                    //Parametro[2].Direction = ParameterDirection.Input;
                    //Parametro[2].Value = IdsResponsible;

                    Parametro[2] = new SqlParameter("@IdTicket", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = IdsTicket;

                    Parametro[3] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_X_RESPONSIBLE2", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.UsuarioNameTicket = DataUtil.ObjectToString(reader["UsuarioName"]);
                            bE_Ticket.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
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

        public String EditarResponsible(int ResponsibleId, int TicketId, int RegistrationUser)
        {
            SqlConnection conexion = null;
            var listaResultado = "";
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdResponsible", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = ResponsibleId;

                    Parametro[2] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = TicketId;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_EDIT_RESPONSIBLE", Parametro))
                    {
                        while (reader.Read())
                        {
                            listaResultado = DataUtil.ObjectToString(reader["Resultado"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }
            return listaResultado;
        }

        public String EditarTicketResponsible(int ResponsibleId, string TicketId)
        {
            SqlConnection conexion = null;
            var listaResultado = "";
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    //Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    //Parametro[0].Direction = ParameterDirection.Input;
                    //Parametro[0].Value = RegistrationUser;

                    Parametro[0] = new SqlParameter("@IdResponsible", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = ResponsibleId;

                    Parametro[1] = new SqlParameter("@IdTicket", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = TicketId;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_EDIT_TICKET_TO_RESPONSIBLE", Parametro))
                    {
                        while (reader.Read())
                        {
                            listaResultado = DataUtil.ObjectToString(reader["Resultado"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }
            return listaResultado;
        }

        public String AnularArchivoTicket(int IdTicketFile, int RegistrationUser)
        {
            SqlConnection conexion = null;
            var listaResultado = "";
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdTicketFile", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = IdTicketFile;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_DELETE_FILE_TICKET", Parametro))
                    {
                        while (reader.Read())
                        {
                            listaResultado = DataUtil.ObjectToString(reader["Resultado"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }
            return listaResultado;
        }

        public String TicketClose(int IdTicket, int RegistrationUser)
        {
            SqlConnection conexion = null;
            var listaResultado = "";
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = IdTicket;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_CLOSE_TICKET", Parametro))
                    {
                        while (reader.Read())
                        {
                            listaResultado = DataUtil.ObjectToString(reader["Resultado"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }
            return listaResultado;
        }

        public String TicketOperando(int IdTicket, int RegistrationUser)
        {
            SqlConnection conexion = null;
            var listaResultado = "";
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = IdTicket;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_OPERADO_TICKET", Parametro))
                    {
                        while (reader.Read())
                        {
                            listaResultado = DataUtil.ObjectToString(reader["Resultado"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarResponsableReport(string StartDate, string EndDate, string IdsResponsible, string NumberTicket, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];

                    Parametro[0] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = StartDate;

                    Parametro[1] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = EndDate;

                    Parametro[2] = new SqlParameter("@IdResponsible", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = IdsResponsible;

                    Parametro[3] = new SqlParameter("@NumberTicket", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = NumberTicket;

                    Parametro[4] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_RESPOSIBLE_QUANTITY", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.ResponsibleId = DataUtil.ObjectToInt32(reader["IdPerson"]);
                            bE_Ticket.FullName = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Ticket.CantidadTicket = DataUtil.ObjectToString(reader["CantidadTicket"]);
                            bE_Ticket.Cargo = DataUtil.ObjectToString(reader["PositionName"]);
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
        
        public List<BE_Ticket> ListarTicketsCompletados(string StartDate, string EndDate, string IdTickets, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[4];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = StartDate;

                    Parametro[2] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = EndDate;

                    Parametro[3] = new SqlParameter("@IdTickets", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = IdTickets;

                    //Parametro[4] = new SqlParameter("@CompartmentName", SqlDbType.VarChar);
                    //Parametro[4].Direction = ParameterDirection.Input;
                    //Parametro[4].Value = CompartmentName;

                    //Parametro[5] = new SqlParameter("@ProductName", SqlDbType.VarChar);
                    //Parametro[5].Direction = ParameterDirection.Input;
                    //Parametro[5].Value = ProductName;

                    //Parametro[6] = new SqlParameter("@ReasonName", SqlDbType.VarChar);
                    //Parametro[6].Direction = ParameterDirection.Input;
                    //Parametro[6].Value = ReasonName;

                    //Parametro[7] = new SqlParameter("@PNPName", SqlDbType.VarChar);
                    //Parametro[7].Direction = ParameterDirection.Input;
                    //Parametro[7].Value = PNPName;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_COMPLETE", Parametro))
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
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Ticket.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public String ChangeStatus(int IdTicket, string Comentario, int RegistrationUser)
        {
            SqlConnection conexion = null;
            var listaResultado = "";
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdTicket;

                    Parametro[1] = new SqlParameter("@Commentary", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = Comentario;

                    Parametro[2] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_CHANGE_STATUS_TICKET", Parametro))
                    {
                        while (reader.Read())
                        {
                            listaResultado = DataUtil.ObjectToString(reader["Resultado"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarDiagramaTicketActividades()
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    //SqlParameter[] Parametro = new SqlParameter[1];

                    //Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    //Parametro[0].Direction = ParameterDirection.Input;
                    //Parametro[0].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_DIAGRAM_TICKET_ACTIVITY"))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ReponsibleNameTicket"]);
                            bE_Ticket.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Ticket.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Ticket.ReponsibleNameActivity = DataUtil.ObjectToString(reader["ReponsibleNameActivity"]);
                            bE_Ticket.ValorConsulta = "1";

                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTreeViewTicketActivity(string idTickets, string FechaInicio, string FechaFin, string ValueRadio)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[4];

                    Parametro[0] = new SqlParameter("@idTickets", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = idTickets;

                    Parametro[1] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = FechaInicio;

                    Parametro[2] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = FechaFin;

                    Parametro[3] = new SqlParameter("@ValueRadio", SqlDbType.VarChar);/**/
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = ValueRadio;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_TO_ACTIVITY_TREE_VIEW" , Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.ActiveViews = DataUtil.ObjectToBool(reader["ActiveViews"]);
                            bE_Ticket.DependencySequence = DataUtil.ObjectToString(reader["Dependency"]);
                            bE_Ticket.DependencyMainId = DataUtil.ObjectToInt(reader["DependencyMainId"]);
                            bE_Ticket.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Ticket.IdActivityTicket = DataUtil.ObjectToInt(reader["IdActivityTicket"]);
                            bE_Ticket.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            //bE_Ticket.AliasTicket = DataUtil.ObjectToString(reader["AliasTicket"]);
                            //bE_Ticket.IdActivty = DataUtil.ObjectToInt(reader["IdActivity"]);
                            //bE_Ticket.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            //bE_Ticket.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
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

        public List<BE_Ticket> ListarTicketsMenu(string ValueTicketMenu)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@ValueTicketMenu", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = ValueTicketMenu;

                    //Parametro[1] = new SqlParameter("@QueryValue", SqlDbType.Char);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = valorConsulta;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LST_TICKETS_MENU", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.IdTicket = DataUtil.ObjectToInt(reader["IdTicket"]);
                            bE_Ticket.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Ticket.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Ticket.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Ticket.EmailWhoCall = DataUtil.ObjectToString(reader["WhoCallName"]);
                            bE_Ticket.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Ticket.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Ticket.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.StatusTicket = DataUtil.ObjectToString(reader["StatusTicket"]);
                            bE_Ticket.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsaibleName"]);
                            bE_Ticket.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Ticket.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);

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

        public List<BE_Activity> ListarActivityMenu(string ValueActivityMenu)
        {
            SqlConnection conexion = null;
            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@ValueActivityMenu", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = ValueActivityMenu;

                    //Parametro[1] = new SqlParameter("@QueryValue", SqlDbType.Char);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = valorConsulta;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LST_ACTIVITY_MENU", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.ResponsibleActivity = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.PercentageNumber = DataUtil.ObjectToString(reader["NumberPercentage"]);
                            bE_Activity.StatusActivity = DataUtil.ObjectToString(reader["StatusActivity"]);

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

        public List<BE_Ticket> ListarTicketToday(int RegistrationUser, string StatusCategory, int OperationId)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = StatusCategory;

                    Parametro[2] = new SqlParameter("@OperationId", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = OperationId;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_TODAY", Parametro))
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
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Ticket.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
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

        public List<BE_Ticket> CantidadTicketByEvent()
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_QUANTITY_EVENT"))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();

                            bE_Ticket.CategoryTicketStatus = DataUtil.ObjectToString(reader["CategoryTicketStatus"]);
                            bE_Ticket.QuantityTicketEvent = DataUtil.ObjectToString(reader["CantidadTicket"]);
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

        public List<BE_Ticket> ListarTicketsHistoricos(string StatusCategory, string StartDate, string EndDate)
        {
            SqlConnection conexion = null;
            List<BE_Ticket> listaResultado = new List<BE_Ticket>();
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

                    Parametro[2] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = StatusCategory;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_HISTORIC_TICKET", Parametro))
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
                            bE_Ticket.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Ticket.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Ticket.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Ticket.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
                            bE_Ticket.StatusTicket = DataUtil.ObjectToString(reader["StatusTicket"]);
                            bE_Ticket.CategoryTicketStatus = DataUtil.ObjectToString(reader["CategoryTicketStatus"]);
                            bE_Ticket.ValorConsulta = "1";
                            listaResultado.Add(bE_Ticket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = new List<BE_Ticket>();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Activity> ListarActivityByreponsible(string StatusValue, string ReponsibleId, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@StatusValue", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = StatusValue;

                    Parametro[1] = new SqlParameter("@ResponsibleId", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = ReponsibleId;

                    Parametro[2] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = StatusCategory;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_QUANTITY_ACTIVITY_BY_RESPONSIBLE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.ResponsibleActivity = DataUtil.ObjectToString(reader["ReponsibleNameActivity"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.PersonAlias = DataUtil.ObjectToString(reader["PersonAlias"]);
                            bE_Activity.PercentageNumber = DataUtil.ObjectToString(reader["NumberPercentage"]);
                            bE_Activity.CodeColorOperation = DataUtil.ObjectToString(reader["CodeColor"]);
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

        public List<BE_Grafic_Value> ListQuantityTicketStatus(int RegistrationUser, string fechaInicio, string fechaFin, string ValueTicketFilter)
        {
            SqlConnection conexion = null;
            List<BE_Grafic_Value> listaResultado = new List<BE_Grafic_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[4];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = RegistrationUser;

                    Parametro[1] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = fechaInicio;

                    Parametro[2] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = fechaFin;

                    Parametro[3] = new SqlParameter("@ValueTicketFilter", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = ValueTicketFilter;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_QUANTITY_STATUS_TICKET", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();

                            bE_Grafic_Value.ColumnValue = DataUtil.ObjectToString(reader["ColumnValue"]);
                            bE_Grafic_Value.CantidadTicketCompletado = DataUtil.ObjectToInt(reader["CantidadTicketCompletado"]);
                            bE_Grafic_Value.CantidadTicketPendiente = DataUtil.ObjectToInt(reader["CantidadTicketPendiente"]);
                            bE_Grafic_Value.ValorConsulta = "1";
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

        public List<BE_Grafic_Value> ListQuantityTickePenCom(string StatusTicket, string StatusTicketCreation, string ValueTicketFilter, string OperationId)
        {
            SqlConnection conexion = null;
            List<BE_Grafic_Value> listaResultado = new List<BE_Grafic_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[4];

                    Parametro[0] = new SqlParameter("@StatusTicker", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = StatusTicket;

                    Parametro[1] = new SqlParameter("@ValueTicketFilter", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = ValueTicketFilter;

                    Parametro[2] = new SqlParameter("@OperationId", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = OperationId;

                    Parametro[3] = new SqlParameter("@StatusTicketCreation", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = StatusTicketCreation;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_QUANTITY_TICKET_ALL_VALIDITY", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();

                            bE_Grafic_Value.IdTicket =  DataUtil.ObjectToInt(reader["IdTicket"]);
                            bE_Grafic_Value.OperationName = DataUtil.ObjectToString(reader["OperationName"]); 
                            bE_Grafic_Value.ResponsibleName = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Grafic_Value.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Grafic_Value.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Grafic_Value.NumberTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Grafic_Value.DifferenceDays = DataUtil.ObjectToInt(reader["DiferenciaEnDias"]);
                            bE_Grafic_Value.Statusticket = DataUtil.ObjectToString(reader["EstadoTicket"]);
                            bE_Grafic_Value.ValorConsulta = "1";
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

        public string CrearReportTicketDetail(BE_TicketDetail bE_TicketDetail)
        {
            SqlConnection conexion = null;
            string resultado = "";
            //List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[11];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_TicketDetail.RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_TicketDetail.IdTicket;

                    Parametro[2] = new SqlParameter("@TituloInforme", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_TicketDetail.TituloInforme;

                    Parametro[3] = new SqlParameter("@ParaQuienInforme", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_TicketDetail.ParaQuienInforme;

                    Parametro[4] = new SqlParameter("@AsuntoInforme", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_TicketDetail.AsuntoInforme;

                    Parametro[5] = new SqlParameter("@OperacionNombre", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_TicketDetail.OperacionNombre;

                    Parametro[6] = new SqlParameter("@FechaRegistroInforme", SqlDbType.VarChar);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_TicketDetail.FechaRegistroInforme;

                    Parametro[7] = new SqlParameter("@AntecedentesInforme", SqlDbType.VarChar);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = bE_TicketDetail.AntecedentesInforme;

                    Parametro[8] = new SqlParameter("@ActivityDevelop", SqlDbType.VarChar);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = bE_TicketDetail.ActivityDevelopInforme;

                    Parametro[9] = new SqlParameter("@ConclusionesInforme", SqlDbType.VarChar);
                    Parametro[9].Direction = ParameterDirection.Input;
                    Parametro[9].Value = bE_TicketDetail.ConclusionesInforme;

                    Parametro[10] = new SqlParameter("@RecomendacionesInforme", SqlDbType.VarChar);
                    Parametro[10].Direction = ParameterDirection.Input;
                    Parametro[10].Value = bE_TicketDetail.RecomendacionesInforme;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_CREATE_TICKET_DETAIL", Parametro))
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

        public string EditReportTicketDetail(BE_TicketDetail bE_TicketDetail)
        {
            SqlConnection conexion = null;
            string resultado = "";
            //List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[12];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_TicketDetail.RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_TicketDetail.IdTicket;

                    Parametro[2] = new SqlParameter("@TituloInforme", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_TicketDetail.TituloInforme;

                    Parametro[3] = new SqlParameter("@ParaQuienInforme", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_TicketDetail.ParaQuienInforme;

                    Parametro[4] = new SqlParameter("@AsuntoInforme", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_TicketDetail.AsuntoInforme;

                    Parametro[5] = new SqlParameter("@OperacionNombre", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_TicketDetail.OperacionNombre;

                    Parametro[6] = new SqlParameter("@FechaRegistroInforme", SqlDbType.VarChar);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_TicketDetail.FechaRegistroInforme;

                    Parametro[7] = new SqlParameter("@AntecedentesInforme", SqlDbType.VarChar);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = bE_TicketDetail.AntecedentesInforme;

                    Parametro[8] = new SqlParameter("@ActivityDevelop", SqlDbType.VarChar);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = bE_TicketDetail.ActivityDevelopInforme;

                    Parametro[9] = new SqlParameter("@ConclusionesInforme", SqlDbType.VarChar);
                    Parametro[9].Direction = ParameterDirection.Input;
                    Parametro[9].Value = bE_TicketDetail.ConclusionesInforme;

                    Parametro[10] = new SqlParameter("@RecomendacionesInforme", SqlDbType.VarChar);
                    Parametro[10].Direction = ParameterDirection.Input;
                    Parametro[10].Value = bE_TicketDetail.RecomendacionesInforme;

                    Parametro[11] = new SqlParameter("@IdPathFile", SqlDbType.Int);
                    Parametro[11].Direction = ParameterDirection.Input;
                    Parametro[11].Value = bE_TicketDetail.IdTicketDetailReports;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_UPDATE_TICKET_DETAIL", Parametro))
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

        public String ValidationByOperation(int IdTicket, int RegistrationUser)
        {
            SqlConnection conexion = null;
            var listaResultado = "";
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdTicket;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_VALIDATION_OPERATION", Parametro))
                    {
                        while (reader.Read())
                        {
                            listaResultado = DataUtil.ObjectToString(reader["Resultado"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }
            return listaResultado;
        }

    }
}
