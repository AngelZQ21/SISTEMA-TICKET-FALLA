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
    public class DA_Role
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Role> ListarRole(string valorBusqueda, string valorConsulta)
        {

            SqlConnection conexion = null;
            List<BE_Role> listaResultado = new List<BE_Role>();
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

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_ROLE_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Role bE_Role = new BE_Role();
                            bE_Role.IdRole = DataUtil.ObjectToInt32(reader["IdRole"]);
                            bE_Role.RoleName = DataUtil.ObjectToString(reader["RoleName"]);
                            bE_Role.RoleAbbreviation = DataUtil.ObjectToString(reader["RoleAbbreviation"]);
                            bE_Role.RoleType = DataUtil.ObjectToString(reader["RoleType"]);
                            bE_Role.RoleTypeDesc = DataUtil.ObjectToString(reader["RoleTypeDesc"]);
                            bE_Role.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
                            bE_Role.RegistrationStatusDesc = DataUtil.ObjectToString(reader["RegistrationStatusDesc"]);
                            bE_Role.UserDesc = DataUtil.ObjectToString(reader["UpdateUserDesc"]); //USUARIO ACTUALIZACION
                            bE_Role.UpdateDate = DataUtil.ObjectToDateTime(reader["UpdateDate"]); //FECHA ACTUALIZACION
                            bE_Role.UserRegistrationDesc = DataUtil.ObjectToString(reader["RegistrationUserDesc"]); // 
                            bE_Role.RegistrationDate = DataUtil.ObjectToDateTime(reader["RegistrationDate"]);

                            bE_Role.ValorConsulta = "1";
                            listaResultado.Add(bE_Role);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Role bE_Role = new BE_Role();
                bE_Role.ValorConsulta = "0";
                bE_Role.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Role);
            }

            return listaResultado;
        }

        public string CrearRol(BE_Role bE_Role)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[4];
                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Role.RegistrationUser;

                    Parametro[1] = new SqlParameter("@RoleName", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Role.RoleName;

                    Parametro[2] = new SqlParameter("@RoleAbbreviation", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Role.RoleAbbreviation;

                    Parametro[3] = new SqlParameter("@RoleType", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Role.RoleType;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_ROLE_CREATE", Parametro))
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

        public string EditarRol(BE_Role bE_Role)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[6];
                    Parametro[0] = new SqlParameter("@UpdateProcess", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Role.UpdateProcess;

                    Parametro[1] = new SqlParameter("@IdRole", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Role.IdRole;

                    Parametro[2] = new SqlParameter("@RoleName", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Role.RoleName;

                    Parametro[3] = new SqlParameter("@RoleAbbreviation", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Role.RoleAbbreviation;

                    Parametro[4] = new SqlParameter("@RoleType", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_Role.RoleType;
                   
                    Parametro[5] = new SqlParameter("@UpdateUser", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_Role.UpdateUser;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_ROLE_UPDATE", Parametro))
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

        public string EliminarRol(BE_Role bE_Role)
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
                    Parametro[0].Value = bE_Role.UpdateUser;

                    Parametro[1] = new SqlParameter("@IdRol", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Role.IdRole;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_ROLE_DELETE", Parametro))
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


        public List<BE_Person> ValidarRelacionRol(int idRole)
        {

            SqlConnection conexion = null;
            List<BE_Person> listaResultado = new List<BE_Person>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@IdRole", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = idRole;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_ROLE_VALIDATE_DEPENDENCY_STATUS", Parametro))
                    {
                        while (reader.Read())
                        {

                            BE_Person bE_Person = new BE_Person();

                            BE_Role bE_Role = new BE_Role();
                            bE_Role.IdRole = DataUtil.ObjectToInt32(reader["IdRole"]);
                            bE_Role.RoleName = DataUtil.ObjectToString(reader["RoleName"]);

                            bE_Person.Role = bE_Role;

                            bE_Person.IdPerson = DataUtil.ObjectToInt32(reader["IdPerson"]);
                            bE_Person.FullName = DataUtil.ObjectToString(reader["PersonName"]);
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
