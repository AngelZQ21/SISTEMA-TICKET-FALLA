using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using AccesoDatos;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;

namespace CL_DA
{
    public class DA_Profile
    {
         string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

         public List<BE_Profile> ListarPerfil(string valorBusqueda, string valorConsulta)
        {
            SqlConnection conexion = null;
            List<BE_Profile> listaResultado = new List<BE_Profile>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];
                    Parametro[0] = new SqlParameter("@Search", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = valorBusqueda;

                    Parametro[1] = new SqlParameter("@QueryValue", SqlDbType.Char);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = valorConsulta;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_PROFILE_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Profile bE_Profile = new BE_Profile();
                            bE_Profile.IdProfile = DataUtil.ObjectToInt32(reader["IdProfile"]);
                            bE_Profile.ProfileName = DataUtil.ObjectToString(reader["ProfileName"]);
                            bE_Profile.MaxAttempts = DataUtil.ObjectToInt32(reader["MaxAttempts"]);
                            bE_Profile.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
                            bE_Profile.RegistrationStatusDesc = DataUtil.ObjectToString(reader["RegistrationStatusDesc"]);
                            bE_Profile.UserDesc = DataUtil.ObjectToString(reader["UpdateUserDesc"]); //USUARIO ACTUALIZACION
                            bE_Profile.UpdateDate = DataUtil.ObjectToDateTime(reader["UpdateDate"]); //FECHA ACTUALIZACION
                            bE_Profile.UserRegistrationDesc = DataUtil.ObjectToString(reader["RegistrationUserDesc"]); // 
                            bE_Profile.RegistrationDate = DataUtil.ObjectToDateTime(reader["RegistrationDate"]);
                            bE_Profile.ValorConsulta = "1";
                            listaResultado.Add(bE_Profile);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Profile bE_Profile = new BE_Profile();
                bE_Profile.ValorConsulta = "0";
                bE_Profile.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Profile);
            }

            return listaResultado;
        }

        public string CrearPerfil(BE_Profile bE_Profile)
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
                    Parametro[0].Value = bE_Profile.RegistrationUser;

                    Parametro[1] = new SqlParameter("@ProfileName", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Profile.ProfileName;

                    Parametro[2] = new SqlParameter("@MaxAttempts", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Profile.MaxAttempts;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_PROFILE_CREATE", Parametro))
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

        public string EditarPerfil(BE_Profile bE_Profile)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];
                    Parametro[0] = new SqlParameter("@UpdateProcess", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Profile.UpdateProcess;

                    Parametro[1] = new SqlParameter("@IdProfile", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Profile.IdProfile;

                    Parametro[2] = new SqlParameter("@ProfileName", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Profile.ProfileName;

                    Parametro[3] = new SqlParameter("@MaxAttempts", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Profile.MaxAttempts;

                    Parametro[4] = new SqlParameter("@UpdateUser", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_Profile.UpdateUser;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_PROFILE_UPDATE", Parametro))
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

        public string EliminarPerfil(BE_Profile bE_Profile)
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
                    Parametro[0].Value = bE_Profile.UpdateUser;

                    Parametro[1] = new SqlParameter("@IdProfile", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Profile.IdProfile;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_PROFILE_DELETE", Parametro))
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

        public List<BE_User> ValidarRelacionPerfil(int idPerfil)
        {

            SqlConnection conexion = null;
            List<BE_User> listaResultado = new List<BE_User>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@IdProfile", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = idPerfil;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_PROFILE_VALIDATE_DEPENDENCY_STATUS", Parametro))
                    {
                        while (reader.Read())
                        {

                            BE_Profile bE_Profile = new BE_Profile();

                            BE_User bE_User = new BE_User();
                            bE_User.IdUser = DataUtil.ObjectToInt32(reader["IdUser"]);
                            bE_User.UUser = DataUtil.ObjectToString(reader["UUser"]);

                            bE_Profile.IdProfile = DataUtil.ObjectToInt32(reader["IdProfile"]);
                            bE_Profile.ProfileName = DataUtil.ObjectToString(reader["ProfileName"]);

                            bE_User.bE_Profile = bE_Profile;
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

