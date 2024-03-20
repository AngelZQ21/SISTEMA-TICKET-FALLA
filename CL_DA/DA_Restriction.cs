using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using AccesoDatos;

namespace CL_DA
{
    public class DA_Restriction
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Restriction> ListarRestriccion(string valorBusqueda, string valorConsulta)
        {
            /**/
            SqlConnection conexion = null;
            List<BE_Restriction> listaResultado = new List<BE_Restriction>();
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

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_RESTRICTION_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Restriction bE_Restriction = new BE_Restriction();
                            bE_Restriction.IdRestriction = DataUtil.ObjectToInt32(reader["IdRestriction"]);
                            bE_Restriction.RestrictionName = DataUtil.ObjectToString(reader["RestrictionName"]);
                            bE_Restriction.RestrictionTable = DataUtil.ObjectToString(reader["RestrictionTable"]);
                            bE_Restriction.RestrictionTableDesc = DataUtil.ObjectToString(reader["RestrictionTableDesc"]);
                            bE_Restriction.RestrictionColumn = DataUtil.ObjectToString(reader["RestrictionColumn"]);

                            bE_Restriction.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
                            bE_Restriction.RegistrationStatusDesc = DataUtil.ObjectToString(reader["RegistrationStatusDesc"]);
                            bE_Restriction.UserDesc = DataUtil.ObjectToString(reader["UpdateUserDesc"]); //USUARIO ACTUALIZACION
                            bE_Restriction.UpdateDate = DataUtil.ObjectToDateTime(reader["UpdateDate"]); //FECHA ACTUALIZACION
                            bE_Restriction.UserRegistrationDesc = DataUtil.ObjectToString(reader["RegistrationUserDesc"]); // 
                            bE_Restriction.RegistrationDate = DataUtil.ObjectToDateTime(reader["RegistrationDate"]);
                            bE_Restriction.ValorConsulta = "1";
                            listaResultado.Add(bE_Restriction);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Restriction bE_Restriction = new BE_Restriction();
                bE_Restriction.ValorConsulta = "0";
                bE_Restriction.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Restriction);
            }

            return listaResultado;
        }
        public string CrearRestriccion(BE_Restriction bE_Restriction)
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
                    Parametro[0].Value = bE_Restriction.RegistrationUser;

                    Parametro[1] = new SqlParameter("@RestrictionName", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Restriction.RestrictionName;

                    Parametro[2] = new SqlParameter("@RestrictionTable", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Restriction.RestrictionTable;

                    //Parametro[3] = new SqlParameter("@RestrictionColumn", SqlDbType.VarChar);
                    //Parametro[3].Direction = ParameterDirection.Input;
                    //Parametro[3].Value = bE_Restriction.RestrictionColumn;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_RESTRICTION_CREATE", Parametro))
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
        public string EditarRestriccion(BE_Restriction bE_Restriction)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[7];
                    Parametro[0] = new SqlParameter("@UpdateProcess", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Restriction.UpdateProcess;

                    Parametro[1] = new SqlParameter("@IdRestriction", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Restriction.IdRestriction;

                    Parametro[2] = new SqlParameter("@RestrictionName", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Restriction.RestrictionName;

                    Parametro[3] = new SqlParameter("@RestrictionTable", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Restriction.RestrictionTable;

                    Parametro[4] = new SqlParameter("@RestrictionColumn", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_Restriction.RestrictionColumn;

                    Parametro[5] = new SqlParameter("@UpdateUser", SqlDbType.Int);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_Restriction.UpdateUser;

                    Parametro[6] = new SqlParameter("@OldColumnName", SqlDbType.VarChar);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_Restriction.OldColumnName;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_RESTRICTION_UPDATE", Parametro))
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
        public string EliminarRestriccion(BE_Restriction bE_Restriction)
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
                    Parametro[0].Value = bE_Restriction.UpdateUser;

                    Parametro[1] = new SqlParameter("@IdRestriction", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Restriction.IdRestriction;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_RESTRICTION_DELETE", Parametro))
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
        public List<BE_Restriction> ValidarRelacionRestriccionMapa(int IdRestriction, string RestrictionTable, string RestrictionColumn)
        {

            SqlConnection conexion = null;
            List<BE_Restriction> listaResultado = new List<BE_Restriction>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[3];
                    Parametro[0] = new SqlParameter("@IdRestriction", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdRestriction;

                    Parametro[1] = new SqlParameter("@RestrictionTable", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RestrictionTable;

                    Parametro[2] = new SqlParameter("@RestrictionColumn", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = RestrictionColumn;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_RESTRICTION_VALIDATE_DEPENDENCY_STATUS", Parametro))
                    {
                        while (reader.Read())
                        {

                            BE_Restriction bE_Restriction = new BE_Restriction();

                            bE_Restriction.IdValidationMap = DataUtil.ObjectToInt32(reader["IdValidationMap"]);
                            bE_Restriction.ValidationDescription = DataUtil.ObjectToString(reader["ValidationDescription"]);
                            bE_Restriction.IdRestriction = DataUtil.ObjectToInt32(reader["IdRestriction"]);
                            bE_Restriction.RestrictionName = DataUtil.ObjectToString(reader["RestrictionName"]);
                            //bE_Restriction.Status = DataUtil.ObjectToString(reader["Status"]);
                            bE_Restriction.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Restriction);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Restriction bE_Restriction = new BE_Restriction();
                bE_Restriction.ValorConsulta = "0";
                bE_Restriction.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Restriction);
            }

            return listaResultado;
        }
    }
}
