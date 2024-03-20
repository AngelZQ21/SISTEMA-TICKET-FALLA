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
    public class DA_Activity
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Activity> CrearTicket(BE_Activity bE_Activity)
        {
            SqlConnection conexion = null;
            //string resultado = "";
            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Activity.RegistrationUser;

                    Parametro[1] = new SqlParameter("@NroTicket", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Activity.NroTicket;

                    Parametro[2] = new SqlParameter("@IdReposible", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Activity.IdResponsible;

                    Parametro[3] = new SqlParameter("@ActivityText", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Activity.ActivityText;

                    //Parametro[4] = new SqlParameter("@DescripcionActivity", SqlDbType.VarChar);
                    //Parametro[4].Direction = ParameterDirection.Input;
                    //Parametro[4].Value = bE_Activity.DescripcionActivity;

                    Parametro[4] = new SqlParameter("@FechaCierre", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_Activity.FechaCierre;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_CREATE_ACTIVIY", Parametro))
                    {
                        while (reader.Read())
                        {
                            //resultado = DataUtil.ObjectToString(reader["Resultado"]);
                            //BE_Activity bE_Activity = new BE_Activity();

                            bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            //bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.PersonMail = DataUtil.ObjectToString(reader["PersonMail"]);
                            bE_Activity.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDate"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            //bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            bE_Activity.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            //bE_Activity.ValorConsulta = "1";
                            listaResultado.Add(bE_Activity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //resultado = ex.Message;
                //listaResultado.Clear();
                //BE_Activity bE_Activity = new BE_Activity();
                bE_Activity.ValorConsulta = "0";
                bE_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Activity);
            }

            return listaResultado;
        }

        public List<BE_Activity> EditarActivity(BE_Activity bE_Activity)
        {
            SqlConnection conexion = null;
            //string resultado = "";
            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Activity.RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdActivity", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Activity.IdActivity;

                    Parametro[2] = new SqlParameter("@IdReposible", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Activity.IdResponsible;

                    Parametro[3] = new SqlParameter("@ActivityText", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Activity.ActivityText;

                    //Parametro[4] = new SqlParameter("@DescripcionActivity", SqlDbType.VarChar);
                    //Parametro[4].Direction = ParameterDirection.Input;
                    //Parametro[4].Value = bE_Activity.DescripcionActivity;

                    Parametro[4] = new SqlParameter("@FechaCierre", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_Activity.FechaCierre;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_EDITAR_ACTIVIY", Parametro))
                    {
                        while (reader.Read())
                        {
                            //resultado = DataUtil.ObjectToString(reader["Resultado"]);
                            //BE_Activity bE_Activity = new BE_Activity();

                            bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            //bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.PersonMail = DataUtil.ObjectToString(reader["PersonMail"]);
                            bE_Activity.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDate"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            //bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            bE_Activity.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            //bE_Activity.ValorConsulta = "1";
                            listaResultado.Add(bE_Activity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //resultado = ex.Message;
                //listaResultado.Clear();
                //BE_Activity bE_Activity = new BE_Activity();
                bE_Activity.ValorConsulta = "0";
                bE_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Activity);
            }

            return listaResultado;
        }

        public List<BE_Board> ActualizarRegistrarVitacora(BE_Board BE_Board)
        {
            SqlConnection conexion = null;
            //string resultado = "";
            List<BE_Board> listaResultado = new List<BE_Board>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = BE_Board.RegistrationUser;

                    Parametro[1] = new SqlParameter("@NroTicket", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = BE_Board.NroTicket;

                    Parametro[2] = new SqlParameter("@BoardDescription", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = BE_Board.DescripcionActivity;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_CREATE_BOARD", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Board bE_Board = new BE_Board();

                            bE_Board.DescriptionBoard = DataUtil.ObjectToString(reader["DescriptionBoard"]);
                            bE_Board.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDate"]);
                            bE_Board.NameUser = DataUtil.ObjectToString(reader["NameUser"]);
                            bE_Board.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);

                            listaResultado.Add(bE_Board);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //resultado = ex.Message;
                //listaResultado.Clear();
                BE_Board bE_Board = new BE_Board();
                bE_Board.ValorConsulta = "0";
                bE_Board.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Board);
            }

            return listaResultado;
        }

        public List<BE_Board> ActualizarRegistrarVitacoraActivityDetail(BE_Board BE_Board)
        {
            SqlConnection conexion = null;
            //string resultado = "";
            List<BE_Board> listaResultado = new List<BE_Board>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = BE_Board.RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdActivity", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = BE_Board.IdActivity;

                    Parametro[2] = new SqlParameter("@BoardDescription", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = BE_Board.DescripcionActivity;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_CREATE_BOARD_DETAIL", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Board bE_Board = new BE_Board();

                            bE_Board.DescriptionBoard = DataUtil.ObjectToString(reader["DescriptionBoard"]);
                            bE_Board.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDate"]);
                            bE_Board.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);

                            listaResultado.Add(bE_Board);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //resultado = ex.Message;
                //listaResultado.Clear();
                BE_Board bE_Board = new BE_Board();
                bE_Board.ValorConsulta = "0";
                bE_Board.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Board);
            }

            return listaResultado;
        }

        public List<BE_Activity> ListarActivityCreado(string NroTicket, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@NroTicket", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = NroTicket;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITY_GENERATE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            //bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            //bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            bE_Activity.ValidationButton = DataUtil.ObjectToString(reader["ValidationButton"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.IdResponsible = DataUtil.ObjectToInt(reader["IdResponsible"]);
                            bE_Activity.IdResponsibleActivity = DataUtil.ObjectToInt(reader["ResponsbileActivity"]); 
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

        public List<BE_Activity> ListarActivityCreadoUsuario(string NroTicket, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@NroTicket", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = NroTicket;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITY_GENERATE_USER", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            //bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            //bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            bE_Activity.ValidationButton = DataUtil.ObjectToString(reader["ValidationButton"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.IdResponsible = DataUtil.ObjectToInt(reader["IdResponsible"]);
                            bE_Activity.IdResponsibleActivity = DataUtil.ObjectToInt(reader["ResponsbileActivity"]);
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

        public List<BE_Activity> ListarActivityExpirationbDash(string NroTicket, int RegistrationUser, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@NroTicket", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = NroTicket;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    Parametro[2] = new SqlParameter("@StatusCategory", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = StatusCategory;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITY_EXPIRATION_DASH", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();
                            /*------------ TICKET ------------*/

                            bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Activity.StartHour = DataUtil.ObjectToString(reader["StartHour"]);
                            bE_Activity.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Activity.UsuarioNameTicket = DataUtil.ObjectToString(reader["UsuarioName"]);
                            bE_Activity.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Activity.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Activity.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Activity.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Activity.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Activity.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Activity.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
                            bE_Activity.StatusTicket = DataUtil.ObjectToString(reader["StatusTicket"]);
                            bE_Activity.CategoryTicketStatus = DataUtil.ObjectToString(reader["CategoryTicketName"]);
                            bE_Activity.ProblemTicket = DataUtil.ObjectToString(reader["ProblemTicket"]);
                            bE_Activity.SolutionTicket = DataUtil.ObjectToString(reader["SolutionTicket"]);
                            bE_Activity.TicketTypeStatus = DataUtil.ObjectToString(reader["TicketTypeStatus"]);
                            bE_Activity.ValidationUserOpId = DataUtil.ObjectToString(reader["ValidationUserOpId"]);
                            bE_Activity.DateValidationUserOp = DataUtil.ObjectToString(reader["DateValidationUserOp"]);
                            bE_Activity.WhoCallId = DataUtil.ObjectToInt(reader["WhoCallId"]);
                            bE_Activity.StartDateTime = DataUtil.ObjectToString(reader["StartDateTime"]);
                            bE_Activity.EndDateTime = DataUtil.ObjectToString(reader["EndDateTime"]);
                            bE_Activity.ComponentIds = DataUtil.ObjectToString(reader["ComponentIds"]);
                            bE_Activity.WhoCallId = DataUtil.ObjectToInt32(reader["WhoCallId"]);
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

        public List<BE_Activity> ListarActivityToTicketToAct(int IdTicket)
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

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITY_TO_TICKET_TO_ACT", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            //bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            //bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            bE_Activity.ValidationButton = DataUtil.ObjectToString(reader["ValidationButton"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsible"]);
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

        public List<BE_Activity> ListarActivityToTicketToActPendiente(int IdTicket, int RegistrationUser)
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

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITY_TO_TICKET_TO_ACT_PENDIENTE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            //bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            //bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            bE_Activity.ValidationButton = DataUtil.ObjectToString(reader["ValidationButton"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsible"]);
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

        public List<BE_Activity> ListarActivityToTicketToActCompletado(int IdTicket, int RegistrationUser)
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

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITY_TO_TICKET_TO_ACT_COMPLETADO", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            //bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            //bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            bE_Activity.ValidationButton = DataUtil.ObjectToString(reader["ValidationButton"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsible"]);
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

        public List<BE_Activity> ListarActivityCreadoDASH(string NroTicket, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@NroTicket", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = NroTicket;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITY_GENERATE_DASH", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            //bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            //bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            bE_Activity.ValidationButton = DataUtil.ObjectToString(reader["ValidationButton"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.IdResponsible = DataUtil.ObjectToInt(reader["IdResponsible"]);
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

        public List<BE_Activity> ListarActivityBusqueda(string NroTicket, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@NroTicket", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = NroTicket;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITY_BUSQUEDA", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            //bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            //bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            bE_Activity.ValidationButton = DataUtil.ObjectToString(reader["ValidationButton"]);
                            bE_Activity.PercentageNumber = DataUtil.ObjectToString(reader["NumberPercentage"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
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

        public List<BE_Activity> ListarActividadesCompletadas(string StartDate, string EndDate, string IdUsuarios, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Activity> listaResultado = new List<BE_Activity>();
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

                    Parametro[3] = new SqlParameter("@IdUsuarios", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = IdUsuarios;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITY_COMPLETE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            //bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NroTicket"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);

                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            //bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
                            //bE_Activity.ValidationButton = DataUtil.ObjectToString(reader["ValidationButton"]);
                            //bE_Activity.PercentageNumber = DataUtil.ObjectToString(reader["NumberPercentage"]);
                            
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

        public List<BE_Board> ListarDescriptionVitacora(string NroTicket, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Board> listaResultado = new List<BE_Board>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@NroTicket", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = NroTicket;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_BUSQUEDA", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Board bE_Board = new BE_Board();

                            //bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);

                            bE_Board.DescriptionBoard = DataUtil.ObjectToString(reader["DescriptionBoard"]);
                            bE_Board.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDate"]);
                            bE_Board.NameUser = DataUtil.ObjectToString(reader["NameUser"]); 
                            bE_Board.ValorConsulta = "1";

                            listaResultado.Add(bE_Board);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Board bE_Board = new BE_Board();
                bE_Board.ValorConsulta = "0";
                bE_Board.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Board);
            }
            return listaResultado;
        }

        public List<BE_Board> ListarDescriptionVitacoraActivityDetail(int IdActivity, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Board> listaResultado = new List<BE_Board>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@IdActivity", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdActivity;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_TICKET_BUSQUEDA_DETAIL", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Board bE_Board = new BE_Board();

                            //bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);

                            bE_Board.DescriptionBoard = DataUtil.ObjectToString(reader["DescriptionBoard"]);
                            bE_Board.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDate"]);
                            bE_Board.ValorConsulta = "1";

                            listaResultado.Add(bE_Board);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Board bE_Board = new BE_Board();
                bE_Board.ValorConsulta = "0";
                bE_Board.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Board);
            }
            return listaResultado;
        }

        public List<BE_Activity> ListarActividadesTodas(int RegistrationUser, int IdPerson, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Activity> listaResultado = new List<BE_Activity>();
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

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITIES_ALL", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            /*------------ TICKET ------------*/
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

                            /*------------ ACTIVITY ------------*/
                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.OldDifferenceDate = DataUtil.ObjectToString(reader["OldDifferenceDate"]);
                            //bE_Activity.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            bE_Activity.ValidationButton = DataUtil.ObjectToString(reader["ValidationButton"]);
                            //bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsible"]);
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

        public string ListValidationActivity(int IdActivity)
        {
            SqlConnection conexion = null;
            string resultado = "";
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@IdActivity", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdActivity;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "", Parametro))
                    {
                        while (reader.Read())
                        {
                            //BE_Activity bE_Activity = new BE_Activity();

                            resultado = DataUtil.ObjectToString(reader["CantidadActividad"]);
                            //bE_Activity.ValorConsulta = "1";
                            //listaResultado.Add(bE_Activity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                //listaResultado.Clear();
                //BE_Activity bE_Activity = new BE_Activity();
                //bE_Activity.ValorConsulta = "0";
                //bE_Activity.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_Activity);
            }
            return resultado;
        }

        public List<BE_Activity> ListarActividadesCompletas(int RegistrationUser, string StatusCategory)
        {
            SqlConnection conexion = null;
            List<BE_Activity> listaResultado = new List<BE_Activity>();
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

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITIES_COMPLETE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Activity.StartHour = DataUtil.ObjectToString(reader["StartHour"]);
                            bE_Activity.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Activity.UsuarioNameTicket = DataUtil.ObjectToString(reader["UsuarioName"]);
                            bE_Activity.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Activity.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Activity.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Activity.TitleDetalle = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Activity.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Activity.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Activity.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
                            bE_Activity.StatusTicket = DataUtil.ObjectToString(reader["StatusTicket"]);
                            bE_Activity.CategoryTicketStatus = DataUtil.ObjectToString(reader["CategoryTicketName"]);
                            bE_Activity.ProblemTicket = DataUtil.ObjectToString(reader["ProblemTicket"]);
                            bE_Activity.SolutionTicket = DataUtil.ObjectToString(reader["SolutionTicket"]);
                            bE_Activity.TicketTypeStatus = DataUtil.ObjectToString(reader["TicketTypeStatus"]);
                            bE_Activity.ValidationUserOpId = DataUtil.ObjectToString(reader["ValidationUserOpId"]);
                            bE_Activity.DateValidationUserOp = DataUtil.ObjectToString(reader["DateValidationUserOp"]);
                            bE_Activity.WhoCallId = DataUtil.ObjectToInt(reader["WhoCallId"]);
                            bE_Activity.StartDateTime = DataUtil.ObjectToString(reader["StartDateTime"]);
                            bE_Activity.EndDateTime = DataUtil.ObjectToString(reader["EndDateTime"]);
                            bE_Activity.ComponentIds = DataUtil.ObjectToString(reader["ComponentIds"]);

                            /*------------ ACTIVITY ------------*/

                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);

                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            //bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            bE_Activity.ValidationButton = DataUtil.ObjectToString(reader["ValidationButton"]);

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

        public string CrearReportActivityDetail(BE_ActivityDetail bE_ActivityDetail)
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
                    Parametro[0].Value = bE_ActivityDetail.RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdActivity", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_ActivityDetail.IdActivity;

                    Parametro[2] = new SqlParameter("@TituloInforme", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_ActivityDetail.TituloInforme;

                    Parametro[3] = new SqlParameter("@ParaQuienInforme", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_ActivityDetail.ParaQuienInforme;

                    Parametro[4] = new SqlParameter("@AsuntoInforme", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_ActivityDetail.AsuntoInforme;

                    Parametro[5] = new SqlParameter("@OperacionNombre", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_ActivityDetail.OperacionNombre;

                    Parametro[6] = new SqlParameter("@FechaRegistroInforme", SqlDbType.VarChar);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_ActivityDetail.FechaRegistroInforme;

                    Parametro[7] = new SqlParameter("@AntecedentesInforme", SqlDbType.VarChar);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = bE_ActivityDetail.AntecedentesInforme;

                    Parametro[8] = new SqlParameter("@ActivityDevelop", SqlDbType.VarChar);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = bE_ActivityDetail.ActivityDevelopInforme;

                    Parametro[9] = new SqlParameter("@ConclusionesInforme", SqlDbType.VarChar);
                    Parametro[9].Direction = ParameterDirection.Input;
                    Parametro[9].Value = bE_ActivityDetail.ConclusionesInforme;

                    Parametro[10] = new SqlParameter("@RecomendacionesInforme", SqlDbType.VarChar);
                    Parametro[10].Direction = ParameterDirection.Input;
                    Parametro[10].Value = bE_ActivityDetail.RecomendacionesInforme;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_CREATE_ACTIVIY_DETAIL", Parametro))
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
                ////listaResultado.Clear();
                ////BE_Activity bE_Activity = new BE_Activity();
                //bE_Activity.ValorConsulta = "0";
                //bE_Activity.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_Activity);
            }

            return resultado;
        }

        public string EditarReportActivityDetail(BE_ActivityDetail bE_ActivityDetail)
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
                    Parametro[0].Value = bE_ActivityDetail.RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdActivity", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_ActivityDetail.IdActivity;

                    Parametro[2] = new SqlParameter("@TituloInforme", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_ActivityDetail.TituloInforme;

                    Parametro[3] = new SqlParameter("@ParaQuienInforme", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_ActivityDetail.ParaQuienInforme;

                    Parametro[4] = new SqlParameter("@AsuntoInforme", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_ActivityDetail.AsuntoInforme;

                    Parametro[5] = new SqlParameter("@OperacionNombre", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_ActivityDetail.OperacionNombre;

                    Parametro[6] = new SqlParameter("@FechaRegistroInforme", SqlDbType.VarChar);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_ActivityDetail.FechaRegistroInforme;

                    Parametro[7] = new SqlParameter("@AntecedentesInforme", SqlDbType.VarChar);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = bE_ActivityDetail.AntecedentesInforme;

                    Parametro[8] = new SqlParameter("@ConclusionesInforme", SqlDbType.VarChar);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = bE_ActivityDetail.ConclusionesInforme;

                    Parametro[9] = new SqlParameter("@ActivityDevelop", SqlDbType.VarChar);
                    Parametro[9].Direction = ParameterDirection.Input;
                    Parametro[9].Value = bE_ActivityDetail.ActivityDevelopInforme;

                    Parametro[10] = new SqlParameter("@RecomendacionesInforme", SqlDbType.VarChar);
                    Parametro[10].Direction = ParameterDirection.Input;
                    Parametro[10].Value = bE_ActivityDetail.RecomendacionesInforme;

                    Parametro[11] = new SqlParameter("@IdActivityDetail", SqlDbType.Int);
                    Parametro[11].Direction = ParameterDirection.Input;
                    Parametro[11].Value = bE_ActivityDetail.IdActivityDetail;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_EDITAR_ACTIVIY_DETAIL", Parametro))
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
                ////listaResultado.Clear();
                ////BE_Activity bE_Activity = new BE_Activity();
                //bE_Activity.ValorConsulta = "0";
                //bE_Activity.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_Activity);
            }

            return resultado;
        }

        public List<BE_ActivityDetail> ListarInformeDetalleActivity(BE_ActivityDetail bE_ActivityDetail)
        {
            SqlConnection conexion = null;
            List<BE_ActivityDetail> listaResultado = new List<BE_ActivityDetail>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@IdActivity", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_ActivityDetail.IdActivity;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_ActivityDetail.RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_FILES_REPORT", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_ActivityDetail bE_ActivityDetail_2 = new BE_ActivityDetail();

                            bE_ActivityDetail_2.IdActivityDetail = DataUtil.ObjectToInt32(reader["IdActivityDetail"]);
                            bE_ActivityDetail_2.TituloInforme = DataUtil.ObjectToString(reader["TitleName"]);
                            bE_ActivityDetail_2.IdParaQuienInforme = DataUtil.ObjectToInt(reader["IdParaInforme"]);
                            bE_ActivityDetail_2.NameParaQuienInforme = DataUtil.ObjectToString(reader["ForWhoReport"]);
                            bE_ActivityDetail_2.AsuntoInforme = DataUtil.ObjectToString(reader["ReportMatter"]);
                            bE_ActivityDetail_2.OperacionNombre = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_ActivityDetail_2.FechaRegistroInforme = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_ActivityDetail_2.AntecedentesInforme = DataUtil.ObjectToString(reader["ReportBackground"]);
                            bE_ActivityDetail_2.ConclusionesInforme = DataUtil.ObjectToString(reader["ReportConclusions"]);
                            bE_ActivityDetail_2.ActivityDevelopInforme = DataUtil.ObjectToString(reader["ActivityDevelopment"]);
                            bE_ActivityDetail_2.RecomendacionesInforme = DataUtil.ObjectToString(reader["ReportRecommendations"]);
                            bE_ActivityDetail_2.FileNameRegister = DataUtil.ObjectToString(reader["FileNameRegister"]);
                            bE_ActivityDetail_2.PathFile = DataUtil.ObjectToString(reader["PathFile"]);
                            bE_ActivityDetail_2.FileSize = DataUtil.ObjectToString(reader["FileSize"]);
                            //bE_ActivityDetail_2.RegistrationUserName = DataUtil.ObjectToString(reader["RegistrationUserName"]);
                            bE_ActivityDetail_2.TipoArchivo = DataUtil.ObjectToString(reader["TipoArchivo"]);
                            bE_ActivityDetail_2.ValorConsulta = "1";
                            listaResultado.Add(bE_ActivityDetail_2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                //BE_ActivityDetail bE_ActivityDetail = new BE_ActivityDetail();
                bE_ActivityDetail.ValorConsulta = "0";
                bE_ActivityDetail.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_ActivityDetail);
            }
            return listaResultado;
        }

        public string EditPercentageActivity(BE_Activity bE_Activity)
        {
            SqlConnection conexion = null;
            string resultado = "";
            //List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@IdActivity", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Activity.IdActivity;

                    Parametro[1] = new SqlParameter("@NumberPercentage", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Activity.PercentageNumber;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_UPDATE_PERCENTAGE_ADVANCE", Parametro))
                    {
                        while (reader.Read())
                        {

                            resultado = DataUtil.ObjectToString(reader["NumberPercentage"]).Trim();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                ////listaResultado.Clear();
                ////BE_Activity bE_Activity = new BE_Activity();
                //bE_Activity.ValorConsulta = "0";
                //bE_Activity.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_Activity);
            }

            return resultado;
        }

        public string ValidationEnableActivity(BE_Activity bE_Activity)
        {
            SqlConnection conexion = null;
            string resultado = "";
            //List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@IdActivity", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Activity.IdActivity;

                    Parametro[1] = new SqlParameter("@ValidationButton", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Activity.ValidationButton;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_EDT_VALIDATION_ACTIVITY", Parametro))
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
                ////listaResultado.Clear();
                ////BE_Activity bE_Activity = new BE_Activity();
                //bE_Activity.ValorConsulta = "0";
                //bE_Activity.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_Activity);
            }

            return resultado;
        }

        public List<BE_Activity> StatusActivities(int IdTicket)
        {
            SqlConnection conexion = null;
            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    //Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    //Parametro[0].Direction = ParameterDirection.Input;
                    //Parametro[0].Value = RegistrationUser;

                    Parametro[0] = new SqlParameter("@IdTicket", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdTicket;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_STATUS_ACTIVITY_TICKET", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            bE_Activity.ValueActivity = DataUtil.ObjectToString(reader["ValueActivity"]);
                            bE_Activity.ValueFilesTicket= DataUtil.ObjectToString(reader["ValueFilesTicket"]);
                            bE_Activity.ValuesComponents = DataUtil.ObjectToString(reader["ValuesComponents"]);
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

        public string EliminarActivityDetail(int IdActivityDetail, int RegistrationUser)
        {
            SqlConnection conexion = null;
            string resultado = "";
            //List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@IdActivityDetail", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdActivityDetail;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_DELETE_FILE_ACITIVTY_DETAIL", Parametro))
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
                ////listaResultado.Clear();
                ////BE_Activity bE_Activity = new BE_Activity();
                //bE_Activity.ValorConsulta = "0";
                //bE_Activity.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_Activity);
            }

            return resultado;
        }

        public string ActivityFinish(BE_Activity bE_Activity)
        {
            SqlConnection conexion = null;
            string resultado = "";
            //List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@IdActivity", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Activity.IdActivity;

                    //Parametro[1] = new SqlParameter("@ValidationButton", SqlDbType.VarChar);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = bE_Activity.ValidationButton;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_ACTIVITY_FINISH", Parametro))
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
                ////listaResultado.Clear();
                ////BE_Activity bE_Activity = new BE_Activity();
                //bE_Activity.ValorConsulta = "0";
                //bE_Activity.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_Activity);
            }

            return resultado;
        }

        public String ChangeStatus(int IdActivity, string Comentario, int RegistrationUser)
        {
            SqlConnection conexion = null;
            var listaResultado = "";
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@IdActivity", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdActivity;

                    Parametro[1] = new SqlParameter("@Commentary", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = Comentario;

                    Parametro[2] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_CHANGE_STATUS_ACTIVITY", Parametro))
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
