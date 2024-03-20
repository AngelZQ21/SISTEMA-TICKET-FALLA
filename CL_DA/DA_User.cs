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
    public class DA_User
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_User> ValidarUsuario(BE_User bE_User)
        {

            SqlConnection conexion = null;
            List<BE_User> listaResultado = new List<BE_User>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];
                    Parametro[0] = new SqlParameter("@UUser", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_User.UUser;

                    Parametro[1] = new SqlParameter("@UPassword", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_User.UPassword;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_USER_VALIDATE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_User bE_UserSalida = new BE_User();
                            bE_UserSalida.IdUser = DataUtil.ObjectToInt32(reader["IdUser"]);
                            bE_UserSalida.UUser = DataUtil.ObjectToString(reader["UUser"]);
                            bE_UserSalida.IdProfile = DataUtil.ObjectToInt32(reader["IdProfile"]);
                            bE_UserSalida.UserType = DataUtil.ObjectToString(reader["UserType"]);
                            bE_UserSalida.Attempts = DataUtil.ObjectToInt32(reader["Attempts"]);
                            bE_UserSalida.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
                            bE_UserSalida.RegistrationStatusDesc = DataUtil.ObjectToString(reader["RegistrationStatusDesc"]);
                            bE_UserSalida.MaxAttempts = DataUtil.ObjectToInt32(reader["MaxAttempts"]);

                            bE_UserSalida.Name = DataUtil.ObjectToString(reader["Name"]);
                            bE_UserSalida.Controller = DataUtil.ObjectToString(reader["Controller"]);
                            bE_UserSalida.ViewController = DataUtil.ObjectToString(reader["ViewController"]);
                            bE_UserSalida.ValorConsulta = "1";
                            listaResultado.Add(bE_UserSalida);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_User bE_UserSalida = new BE_User();
                bE_UserSalida.ValorConsulta = "0";
                bE_UserSalida.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_UserSalida);
            }
            
            return listaResultado;
        }
        public string ActualizarIntentosEstadoUsuario(string UUser, string StatusQuery)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];
                    Parametro[0] = new SqlParameter("@UUser", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = UUser;

                    Parametro[1] = new SqlParameter("@StatusQuery", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = StatusQuery;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_USER_UPDATE_ATTEMPTS", Parametro))
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

        /// <summary>
        /// Lista todos los usuarios que se encuentran habilitados y deshabilitados
        /// </summary>
        /// <param name="valorBusqueda">Valor para realizar la busqueda en los registros</param>
        /// <param name="valorConsulta">Valor para seleccionar el modo de listado</param>
        /// <returns></returns>
        public List<BE_User> ListarUser(string valorBusqueda, string valorConsulta)
        {

            SqlConnection conexion = null;
            List<BE_User> listaResultado = new List<BE_User>();
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

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_USER_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_User bE_User = new BE_User();
                            bE_User.IdUser = DataUtil.ObjectToInt32(reader["IdUser"]);

                            BE_Person bE_Person = new BE_Person()
                            {
                                IdPerson = DataUtil.ObjectToInt32(reader["IdPerson"]),
                                DocumentId = DataUtil.ObjectToInt32(reader["DocumentId"]),
                                DocumentNumber = DataUtil.ObjectToString(reader["DocumentNumber"]),
                                PersonName = DataUtil.ObjectToString(reader["PersonName"]),
                                FirstLastName = DataUtil.ObjectToString(reader["FirstLastName"]),
                                SecondLastName = DataUtil.ObjectToString(reader["SecondLastName"])
                            };
                            bE_User.Person = bE_Person;
                            BE_Profile bE_Profile = new BE_Profile();
                            bE_Profile.IdProfile = DataUtil.ObjectToInt32(reader["IdProfile"]);
                            bE_Profile.ProfileName = DataUtil.ObjectToString(reader["ProfileName"]);
                            bE_User.bE_Profile = bE_Profile;                           
                            bE_User.IdProfile = DataUtil.ObjectToInt32(reader["IdProfile"]);
                            bE_User.UserType = DataUtil.ObjectToString(reader["UserType"]);
                            bE_User.UUser = DataUtil.ObjectToString(reader["UUser"]);
                            bE_User.Attempts = DataUtil.ObjectToInt32(reader["Attempts"]);                                                        
                            bE_User.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
                            bE_User.RegistrationStatusDesc = DataUtil.ObjectToString(reader["RegistrationStatusDesc"]);
                            bE_User.UserDesc = DataUtil.ObjectToString(reader["UpdateUserDesc"]); //USUARIO ACTUALIZACION
                            bE_User.UpdateDate = DataUtil.ObjectToDateTime(reader["UpdateDate"]); //FECHA ACTUALIZACION
                            bE_User.UserRegistrationDesc = DataUtil.ObjectToString(reader["RegistrationUserDesc"]); // 
                            bE_User.RegistrationDate = DataUtil.ObjectToDateTime(reader["RegistrationDate"]);
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

        public string CrearUser(BE_User bE_User)
        {
            string resultado = "";
            string[] resultado2 = null;
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[6];
                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_User.RegistrationUser;

                    Parametro[1] = new SqlParameter("@IdPerson", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_User.Person.IdPerson;

                    Parametro[2] = new SqlParameter("@IdProfile", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_User.IdProfile;

                    Parametro[3] = new SqlParameter("@UserType", SqlDbType.Char);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_User.UserType;

                    Parametro[4] = new SqlParameter("@UUser", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_User.UUser;

                    Parametro[5] = new SqlParameter("@UPassword", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_User.UPassword;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_USER_CREATE", Parametro))
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

        public string EditarUser(BE_User bE_User)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[9];
                    Parametro[0] = new SqlParameter("@UpdateProcess", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_User.UpdateProcess;

                    Parametro[1] = new SqlParameter("@IdUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_User.IdUser;

                    Parametro[2] = new SqlParameter("@IdPerson", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_User.Person.IdPerson;

                    Parametro[3] = new SqlParameter("@IdProfile", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_User.IdProfile;

                    Parametro[4] = new SqlParameter("@UserType", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_User.UserType;

                    Parametro[5] = new SqlParameter("@UUser", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_User.UUser;

                    Parametro[6] = new SqlParameter("@UPassword", SqlDbType.VarChar);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_User.UPassword;

                    Parametro[7] = new SqlParameter("@UpdateUser", SqlDbType.Int);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = bE_User.UpdateUser;

                    Parametro[8] = new SqlParameter("@actualPassword", SqlDbType.VarChar);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = bE_User.actualPassword;
                    //

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_USER_UPDATE", Parametro))
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

        public string EliminarUser(BE_User bE_User)
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
                    Parametro[0].Value = bE_User.UpdateUser;

                    Parametro[1] = new SqlParameter("@IdUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_User.IdUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_USER_DELETE", Parametro))
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

        public List<BE_User> ValidarRelacionUsuarioPersona(int idUser)
        {

            SqlConnection conexion = null;
            List<BE_User> listaResultado = new List<BE_User>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@IdUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = idUser;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_USER_PERSON_VALIDATE_DEPENDENCY_STATUS", Parametro))
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
                            bE_User.RegistrationStatusDesc = DataUtil.ObjectToString(reader["RegistrationStatus"]);
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

    }
}
