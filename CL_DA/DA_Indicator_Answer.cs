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
    public class DA_Indicator_Answer
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;
        public string CrearRespuestaIndicador(BE_Indicator_Answer bE_Indicator_Answer)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];
                    Parametro[0] = new SqlParameter("@IdIndicatorUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Indicator_Answer.bE_Indicator_User.IdIndicatorUser;

                    Parametro[1] = new SqlParameter("@Comment", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Indicator_Answer.Comment;

                    Parametro[2] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Indicator_Answer.RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_INDICATOR_COMMENT_CREATE", Parametro))
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

        public string CrearRespuestaIndicadorAdjunto(BE_Indicator_Answer bE_Indicator_Answer)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[9];
                    Parametro[0] = new SqlParameter("@IdIndicatorUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Indicator_Answer.bE_Indicator_User.IdIndicatorUser;

                    Parametro[1] = new SqlParameter("@Comment", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Indicator_Answer.Comment;

                    Parametro[2] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Indicator_Answer.RegistrationUser;

                    Parametro[3] = new SqlParameter("@PathFile", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Indicator_Answer.PathFile;

                    Parametro[4] = new SqlParameter("@FileName", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_Indicator_Answer.FileName;

                    Parametro[5] = new SqlParameter("@FileSize", SqlDbType.Int);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_Indicator_Answer.FileSize;

                    Parametro[6] = new SqlParameter("@FileExtension", SqlDbType.VarChar);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_Indicator_Answer.FileExtension;

                    Parametro[7] = new SqlParameter("@FileType", SqlDbType.VarChar);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = bE_Indicator_Answer.FileType;

                    Parametro[8] = new SqlParameter("@QueryValue", SqlDbType.VarChar);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = bE_Indicator_Answer.QueryValue;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_INDICATOR_COMMENT_CREATE", Parametro))
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

        public string ActualizarRespuestaIndicador(BE_Indicator_Answer bE_Indicator_Answer)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];
                    Parametro[0] = new SqlParameter("@IdIndicatorComment", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Indicator_Answer.IdIndicatorComment;

                    Parametro[1] = new SqlParameter("@Comment", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Indicator_Answer.Comment;

                    Parametro[2] = new SqlParameter("@UpdateUser", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Indicator_Answer.RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_INDICATOR_COMMENT_UPDATE", Parametro))
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

        public string ActualizarRespuestaIndicadorAdjunto(BE_Indicator_Answer bE_Indicator_Answer)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[9];
                    Parametro[0] = new SqlParameter("@IdIndicatorComment", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Indicator_Answer.IdIndicatorComment;

                    Parametro[1] = new SqlParameter("@Comment", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Indicator_Answer.Comment;

                    Parametro[2] = new SqlParameter("@UpdateUser", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Indicator_Answer.RegistrationUser;

                    Parametro[3] = new SqlParameter("@PathFile", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Indicator_Answer.PathFile;

                    Parametro[4] = new SqlParameter("@FileName", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_Indicator_Answer.FileName;

                    Parametro[5] = new SqlParameter("@FileSize", SqlDbType.Int);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_Indicator_Answer.FileSize;

                    Parametro[6] = new SqlParameter("@FileExtension", SqlDbType.VarChar);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_Indicator_Answer.FileExtension;

                    Parametro[7] = new SqlParameter("@FileType", SqlDbType.VarChar);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = bE_Indicator_Answer.FileType;

                    Parametro[8] = new SqlParameter("@QueryValue", SqlDbType.VarChar);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = bE_Indicator_Answer.QueryValue;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_INDICATOR_COMMENT_UPDATE", Parametro))
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

        public string EliminarRespuestaIndicador(BE_Indicator_Answer bE_Indicator_Answer)
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
                    Parametro[0].Value = bE_Indicator_Answer.UpdateUser;

                    Parametro[1] = new SqlParameter("@IdIndicatorComment", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Indicator_Answer.IdIndicatorComment;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_INDICATOR_COMMENT_DELETE", Parametro))
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

        public List<BE_Indicator_Answer> ListarRespuestaIndicador(int IdIndicatorUser, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Indicator_Answer> listaResultado = new List<BE_Indicator_Answer>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];
                    Parametro[0] = new SqlParameter("@IdIndicatorUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdIndicatorUser;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_INDICATOR_COMMENT_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Indicator_Answer bE_Indicator_Answer = new BE_Indicator_Answer();
                            BE_Indicator_User bE_Indicator_User = new BE_Indicator_User();
                            bE_Indicator_Answer.IdIndicatorComment = DataUtil.ObjectToInt32(reader["IdIndicatorComment"]);

                            bE_Indicator_User.IdIndicatorUser = DataUtil.ObjectToInt32(reader["IdIndicatorUser"]);
                            bE_Indicator_User.UserDesc = DataUtil.ObjectToString(reader["UUser"]);

                            bE_Indicator_Answer.Comment = DataUtil.ObjectToString(reader["Comment"]);
                            bE_Indicator_Answer.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
                            bE_Indicator_Answer.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);
                            bE_Indicator_Answer.RegistrationUser = DataUtil.ObjectToInt32(reader["RegistrationUser"]);
                            bE_Indicator_Answer.RegistrationUserName = DataUtil.ObjectToString(reader["RegistrationUserName"]);
                            bE_Indicator_Answer.RegistrationDate = DataUtil.ObjectToDateTime(reader["RegistrationDate"]);
                            bE_Indicator_Answer.UpdateUser = DataUtil.ObjectToInt32(reader["UpdateUser"]);
                            bE_Indicator_Answer.UpdateUserName = DataUtil.ObjectToString(reader["UpdateUserName"]);
                            bE_Indicator_Answer.UpdateDate = DataUtil.ObjectToDateTime(reader["UpdateDate"]);

                            bE_Indicator_Answer.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDateString"]);
                            bE_Indicator_Answer.UpdateDateString = DataUtil.ObjectToString(reader["UpdateDateString"]);

                            bE_Indicator_Answer.PathFile = DataUtil.ObjectToString(reader["PathFile"]);
                            bE_Indicator_Answer.FileName = DataUtil.ObjectToString(reader["FileName"]);


                            bE_Indicator_Answer.bE_Indicator_User = bE_Indicator_User;

                            bE_Indicator_Answer.ValorConsulta = "1";

                            listaResultado.Add(bE_Indicator_Answer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator_Answer bE_Indicator_Answer = new BE_Indicator_Answer();
                bE_Indicator_Answer.ValorConsulta = "0";
                bE_Indicator_Answer.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Indicator_Answer);
            }

            return listaResultado;
        }
    }
}
