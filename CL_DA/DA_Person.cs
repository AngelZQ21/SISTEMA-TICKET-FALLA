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
    public class DA_Person
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Person> ListarPerson(string valorBusqueda, string valorConsulta)
        {

            SqlConnection conexion = null;
            List<BE_Person> listaResultado = new List<BE_Person>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[2];
                    Parametro[0] = new SqlParameter("@Search", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = valorBusqueda;

                    Parametro[1] = new SqlParameter("@QueryValue", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = valorConsulta;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_PERSON_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Person bE_Person = new BE_Person();
                            bE_Person.IdPerson = DataUtil.ObjectToInt32(reader["IdPerson"]);
                            bE_Person.IdRole = DataUtil.ObjectToInt32(reader["IdRole"]);
                            bE_Person.DocumentId = DataUtil.ObjectToInt32(reader["DocumentId"]);
                            bE_Person.DocumentNumber = DataUtil.ObjectToString(reader["DocumentNumber"]);
                            bE_Person.PersonName = DataUtil.ObjectToString(reader["PersonName"]);
                            bE_Person.FirstLastName = DataUtil.ObjectToString(reader["FirstLastName"]);
                            bE_Person.SecondLastName = DataUtil.ObjectToString(reader["SecondLastName"]);
                            bE_Person.PersonMainAddress = DataUtil.ObjectToString(reader["PersonMainAddress"]);
                            bE_Person.PersonPhone = DataUtil.ObjectToString(reader["PersonPhone"]);
                            bE_Person.Birthdate = DataUtil.ObjectToString(reader["Birthdate"]);
                            bE_Person.PersonMail = DataUtil.ObjectToString(reader["PersonMail"]);
                            bE_Person.Photocheck = DataUtil.ObjectToString(reader["Photocheck"]);
                            bE_Person.UserStatus = DataUtil.ObjectToString(reader["UserStatus"]);
                            bE_Person.OperatorStatus = DataUtil.ObjectToString(reader["OperatorStatus"]);
                            bE_Person.DriverStatus = DataUtil.ObjectToString(reader["DriverStatus"]);
                            bE_Person.FullName = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Person.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
                            bE_Person.RegistrationStatusDesc = DataUtil.ObjectToString(reader["RegistrationStatusDesc"]);
                            bE_Person.UserDesc = DataUtil.ObjectToString(reader["UpdateUserDesc"]); //USUARIO ACTUALIZACION
                            bE_Person.UpdateDate = DataUtil.ObjectToDateTime(reader["UpdateDate"]); //FECHA ACTUALIZACION
                            bE_Person.UserRegistrationDesc = DataUtil.ObjectToString(reader["RegistrationUserDesc"]); // 
                            bE_Person.RegistrationDate = DataUtil.ObjectToDateTime(reader["RegistrationDate"]);

                            BE_Role bE_Role = new BE_Role();
                            bE_Role.IdRole = DataUtil.ObjectToInt32(reader["IdRole"]);
                            bE_Role.RoleName = DataUtil.ObjectToString(reader["RoleName"]);
                            bE_Person.Role = bE_Role;
                            bE_Person.ValorConsulta = "1";
                            listaResultado.Add(bE_Person);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Person bE_Person = new BE_Person();
                bE_Person.ValorConsulta = "0";
                bE_Person.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Person);
            }

            return listaResultado;
        }

        public List<BE_Person> ListarPersonaTicket(int IdOperation)
        {

            SqlConnection conexion = null;
            List<BE_Person> listaResultado = new List<BE_Person>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@IdOperation", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdOperation;

                    //Parametro[1] = new SqlParameter("@QueryValue", SqlDbType.VarChar);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = valorConsulta;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SP_OPERATOR_TO_PERSON_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Person bE_Person = new BE_Person();
                            bE_Person.IdPerson = DataUtil.ObjectToInt32(reader["IdPerson"]);
                            bE_Person.FullNameOperation = DataUtil.ObjectToString(reader["FullNameOperator"]);
                            bE_Person.ValorConsulta = "1";
                            listaResultado.Add(bE_Person);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Person bE_Person = new BE_Person();
                bE_Person.ValorConsulta = "0";
                bE_Person.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Person);
            }

            return listaResultado;
        }

        public List<BE_Person> ListarPersonaTicketTodos()
        {

            SqlConnection conexion = null;
            List<BE_Person> listaResultado = new List<BE_Person>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    //SqlParameter[] Parametro = new SqlParameter[1];

                    //Parametro[0] = new SqlParameter("@IdOperation", SqlDbType.Int);
                    //Parametro[0].Direction = ParameterDirection.Input;
                    //Parametro[0].Value = IdOperation;

                    //Parametro[1] = new SqlParameter("@QueryValue", SqlDbType.VarChar);
                    //Parametro[1].Direction = ParameterDirection.Input;
                    //Parametro[1].Value = valorConsulta;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SP_RESPONSIBLE_ALL"))
                    {
                        while (reader.Read())
                        {
                            BE_Person bE_Person = new BE_Person();
                            bE_Person.IdPerson = DataUtil.ObjectToInt32(reader["IdPerson"]);
                            bE_Person.PersonMail = DataUtil.ObjectToString(reader["PersonMail"]);
                            bE_Person.FullNameOperation = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Person.ValorConsulta = "1";
                            listaResultado.Add(bE_Person);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Person bE_Person = new BE_Person();
                bE_Person.ValorConsulta = "0";
                bE_Person.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Person);
            }

            return listaResultado;
        }

        public List<BE_Ticket> ListarResponsibleNotMain(int IdResponsible, int RegistrationUser)
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

                    Parametro[1] = new SqlParameter("@IdResponsible", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = IdResponsible;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_RESPONSIBLE_NOT_MAIN", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Ticket bE_Ticket = new BE_Ticket();
                            bE_Ticket.ResponsibleId = DataUtil.ObjectToInt32(reader["IdPerson"]);
                            bE_Ticket.FullName = DataUtil.ObjectToString(reader["FullName"]);
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

        public string CrearPerson(BE_Person bE_Person)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[15];
                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Person.RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdRole", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Person.IdRole;

                    Parametro[2] = new SqlParameter("@DocumentId", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Person.DocumentId;

                    Parametro[3] = new SqlParameter("@DocumentNumber", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Person.DocumentNumber;

                    Parametro[4] = new SqlParameter("@PersonName", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_Person.PersonName;

                    Parametro[5] = new SqlParameter("@FirstLastName", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_Person.FirstLastName;

                    Parametro[6] = new SqlParameter("@SeconLastName", SqlDbType.VarChar);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_Person.SecondLastName;

                    Parametro[7] = new SqlParameter("@PersonMainAddress", SqlDbType.VarChar);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = DataUtil.ObjectToString(bE_Person.PersonMainAddress);

                    Parametro[8] = new SqlParameter("@PersonPhone", SqlDbType.VarChar);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = DataUtil.ObjectToString(bE_Person.PersonPhone);

                    Parametro[9] = new SqlParameter("@Birthdate", SqlDbType.Date);
                    Parametro[9].Direction = ParameterDirection.Input;
                    Parametro[9].Value = DataUtil.ObjectToDateTime(bE_Person.Birthdate);

                    Parametro[10] = new SqlParameter("@PersonMail", SqlDbType.VarChar);
                    Parametro[10].Direction = ParameterDirection.Input;
                    Parametro[10].Value = DataUtil.ObjectToString(bE_Person.PersonMail);

                    Parametro[11] = new SqlParameter("@Photocheck", SqlDbType.VarChar);
                    Parametro[11].Direction = ParameterDirection.Input;
                    Parametro[11].Value = DataUtil.ObjectToString(bE_Person.Photocheck);

                    Parametro[12] = new SqlParameter("@UserStatus", SqlDbType.VarChar);
                    Parametro[12].Direction = ParameterDirection.Input;
                    Parametro[12].Value = bE_Person.UserStatus;

                    Parametro[13] = new SqlParameter("@OperatorStatus", SqlDbType.VarChar);
                    Parametro[13].Direction = ParameterDirection.Input;
                    Parametro[13].Value = bE_Person.OperatorStatus;

                    Parametro[14] = new SqlParameter("@DriverStatus", SqlDbType.VarChar);
                    Parametro[14].Direction = ParameterDirection.Input;
                    Parametro[14].Value = bE_Person.DriverStatus;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_PERSON_CREATE", Parametro))
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
        public string EditarPerson(BE_Person bE_Person)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[17];
                    Parametro[0] = new SqlParameter("@UpdateProcess", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Person.UpdateProcess;

                    Parametro[1] = new SqlParameter("@IdPerson", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Person.IdPerson;

                    Parametro[2] = new SqlParameter("@IdRole", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Person.IdRole;

                    Parametro[3] = new SqlParameter("@DocumentId", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Person.DocumentId;

                    Parametro[4] = new SqlParameter("@DocumentNumber", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = DataUtil.ObjectToString(bE_Person.DocumentNumber);

                    Parametro[5] = new SqlParameter("@PersonName", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = DataUtil.ObjectToString(bE_Person.PersonName);

                    Parametro[6] = new SqlParameter("@FirstLastName", SqlDbType.VarChar);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = DataUtil.ObjectToString(bE_Person.FirstLastName);

                    Parametro[7] = new SqlParameter("@SecondLastName", SqlDbType.VarChar);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = DataUtil.ObjectToString(bE_Person.SecondLastName);

                    Parametro[8] = new SqlParameter("@PersonMainAddress", SqlDbType.VarChar);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = DataUtil.ObjectToString(bE_Person.PersonMainAddress);

                    Parametro[9] = new SqlParameter("@PersonPhone", SqlDbType.VarChar);
                    Parametro[9].Direction = ParameterDirection.Input;
                    Parametro[9].Value = DataUtil.ObjectToString(bE_Person.PersonPhone);

                    Parametro[10] = new SqlParameter("@Birthdate", SqlDbType.Date);
                    Parametro[10].Direction = ParameterDirection.Input;
                    Parametro[10].Value = DataUtil.ObjectToDateTime(bE_Person.Birthdate);

                    Parametro[11] = new SqlParameter("@PersonMail", SqlDbType.VarChar);
                    Parametro[11].Direction = ParameterDirection.Input;
                    Parametro[11].Value = DataUtil.ObjectToString(bE_Person.PersonMail);

                    Parametro[12] = new SqlParameter("@Photocheck", SqlDbType.VarChar);
                    Parametro[12].Direction = ParameterDirection.Input;
                    Parametro[12].Value = DataUtil.ObjectToString(bE_Person.Photocheck);

                    Parametro[13] = new SqlParameter("@UserStatus", SqlDbType.VarChar);
                    Parametro[13].Direction = ParameterDirection.Input;
                    Parametro[13].Value = DataUtil.ObjectToString(bE_Person.UserStatus);

                    Parametro[14] = new SqlParameter("@OperatorStatus", SqlDbType.VarChar);
                    Parametro[14].Direction = ParameterDirection.Input;
                    Parametro[14].Value = DataUtil.ObjectToString(bE_Person.OperatorStatus);

                    Parametro[15] = new SqlParameter("@DriverStatus", SqlDbType.VarChar);
                    Parametro[15].Direction = ParameterDirection.Input;
                    Parametro[15].Value = DataUtil.ObjectToString(bE_Person.DriverStatus);

                    Parametro[16] = new SqlParameter("@UpdateUser", SqlDbType.Int);
                    Parametro[16].Direction = ParameterDirection.Input;
                    Parametro[16].Value = bE_Person.UpdateUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_PERSON_UPDATE", Parametro))
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
        public string EliminarPerson(BE_Person bE_Person)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];
                    Parametro[0] = new SqlParameter("@UpdateUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Person.UpdateUser;

                    Parametro[1] = new SqlParameter("@IdPerson", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Person.IdPerson;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_PERSON_DELETE", Parametro))
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

        // SOLO GOLDFIELDS
        //public List<BE_Person> ListarPersonPorTipoRolPrincipal()
        //{

        //    SqlConnection conexion = null;
        //    List<BE_Person> listaResultado = new List<BE_Person>();
        //    try
        //    {
        //        using (conexion = new SqlConnection(cadenaConexion))
        //        {
        //            using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_PERSON_BY_ROLETYPE_LIST"))
        //            {
        //                while (reader.Read())
        //                {
        //                    BE_Person bE_Person = new BE_Person();
        //                    bE_Person.IdPerson = DataUtil.ObjectToInt32(reader["IdPerson"]);
        //                    bE_Person.IdRole = DataUtil.ObjectToInt32(reader["IdRole"]);
        //                    bE_Person.DocumentId = DataUtil.ObjectToInt32(reader["DocumentId"]);
        //                    bE_Person.DocumentNumber = DataUtil.ObjectToString(reader["DocumentNumber"]);
        //                    bE_Person.PersonName = DataUtil.ObjectToString(reader["PersonName"]);
        //                    bE_Person.FirstLastName = DataUtil.ObjectToString(reader["FirstLastName"]);
        //                    bE_Person.SecondLastName = DataUtil.ObjectToString(reader["SecondLastName"]);
        //                    bE_Person.PersonMainAddress = DataUtil.ObjectToString(reader["PersonMainAddress"]);
        //                    bE_Person.PersonPhone = DataUtil.ObjectToString(reader["PersonPhone"]);
        //                    bE_Person.Birthdate = DataUtil.ObjectToString(reader["Birthdate"]);
        //                    bE_Person.PersonMail = DataUtil.ObjectToString(reader["PersonMail"]);
        //                    bE_Person.Photocheck = DataUtil.ObjectToString(reader["Photocheck"]);
        //                    bE_Person.UserStatus = DataUtil.ObjectToString(reader["UserStatus"]);
        //                    bE_Person.OperatorStatus = DataUtil.ObjectToString(reader["OperatorStatus"]);
        //                    bE_Person.DriverStatus = DataUtil.ObjectToString(reader["DriverStatus"]);
        //                    bE_Person.FullName = DataUtil.ObjectToString(reader["FullName"]);
        //                    bE_Person.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
        //                    bE_Person.RegistrationStatusDesc = DataUtil.ObjectToString(reader["RegistrationStatusDesc"]);
        //                    bE_Person.UserDesc = DataUtil.ObjectToString(reader["UUser"]);
        //                    bE_Person.UpdateDate = DataUtil.ObjectToDateTime(reader["UpdateDate"]);
        //                    bE_Person.ValorConsulta = "1";
        //                    listaResultado.Add(bE_Person);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        listaResultado.Clear();
        //        BE_Person bE_Person = new BE_Person();
        //        bE_Person.ValorConsulta = "0";
        //        bE_Person.MensajeConsulta = ex.Message;
        //        listaResultado.Add(bE_Person);
        //    }

        //    return listaResultado;
        //}
        // SOLO GOLDFIELDS

        public List<BE_User> ValidarRelacionPersonaUsuario(int idPerson)
        {

            SqlConnection conexion = null;
            List<BE_User> listaResultado = new List<BE_User>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@IdPerson", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = idPerson;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_USER_VALIDATE_DEPENDENCY_STATUS", Parametro))
                    {
                        while (reader.Read())
                        {

                            BE_Person bE_Person = new BE_Person();

                            BE_User bE_User = new BE_User();
                            bE_User.IdUser = DataUtil.ObjectToInt32(reader["IdUser"]);
                            bE_User.UUser = DataUtil.ObjectToString(reader["UUser"]);

                            bE_Person.IdPerson = DataUtil.ObjectToInt32(reader["IdPerson"]);
                            bE_Person.FullName = DataUtil.ObjectToString(reader["PersonName"]);
                            bE_User.Person = bE_Person;
                            bE_User.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDateString"]);
                            bE_User.UpdateDateString = DataUtil.ObjectToString(reader["UpdateDateString"]);
                            bE_User.ValorConsulta = "1";
                            listaResultado.Add(bE_User);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_User bE_User = new BE_User();
                bE_User.ValorConsulta = "0";
                bE_User.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_User);
            }

            return listaResultado;
        }

        public List<BE_Person> ValidarRelacionPersonaConductor(int idPerson)
        {

            SqlConnection conexion = null;
            List<BE_Person> listaResultado = new List<BE_Person>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@IdPerson", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = idPerson;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_DRIVER_VALIDATE_DEPENDENCY_STATUS", Parametro))
                    {
                        while (reader.Read())
                        {

                            BE_Person bE_Person = new BE_Person();

                            bE_Person.IdPerson = DataUtil.ObjectToInt32(reader["IdPerson"]);
                            bE_Person.FullName = DataUtil.ObjectToString(reader["PersonName"]);
                            bE_Person.Photocheck = DataUtil.ObjectToString(reader["Photocheck"]);
                            bE_Person.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDateString"]);
                            bE_Person.UpdateDateString = DataUtil.ObjectToString(reader["UpdateDateString"]);
                            bE_Person.ValorConsulta = "1";
                            listaResultado.Add(bE_Person);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Person bE_Person = new BE_Person();
                bE_Person.ValorConsulta = "0";
                bE_Person.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Person);
            }

            return listaResultado;
        }


        public List<BE_Person> ValidarRelacionPersonaOperador(int idPerson)
        {

            SqlConnection conexion = null;
            List<BE_Person> listaResultado = new List<BE_Person>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@IdPerson", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = idPerson;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_OPERATOR_VALIDATE_DEPENDENCY_STATUS", Parametro))
                    {
                        while (reader.Read())
                        {

                            BE_Person bE_Person = new BE_Person();

                            bE_Person.IdPerson = DataUtil.ObjectToInt32(reader["IdPerson"]);
                            bE_Person.FullName = DataUtil.ObjectToString(reader["PersonName"]);
                            bE_Person.Photocheck = DataUtil.ObjectToString(reader["Photocheck"]);
                            bE_Person.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDateString"]);
                            bE_Person.UpdateDateString = DataUtil.ObjectToString(reader["UpdateDateString"]);
                            bE_Person.ValorConsulta = "1";
                            listaResultado.Add(bE_Person);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Person bE_Person = new BE_Person();
                bE_Person.ValorConsulta = "0";
                bE_Person.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Person);
            }

            return listaResultado;
        }

    }
}
