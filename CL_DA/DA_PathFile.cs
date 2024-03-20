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
    public class DA_PathFile
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_PathFile> CrearRuta(BE_PathFile bE_PathFile)
        {
            SqlConnection conexion = null;
            List<BE_PathFile> listaResultado = new List<BE_PathFile>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[8];
                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_PathFile.RegistrationUser;

                    Parametro[1] = new SqlParameter("@PathFile", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_PathFile.PathFile;

                    Parametro[2] = new SqlParameter("@FileNameRegister", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_PathFile.FileNameRegister;

                    Parametro[3] = new SqlParameter("@FileSize", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_PathFile.FileSize;

                    Parametro[4] = new SqlParameter("@FileExtension", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_PathFile.FileExtension;

                    Parametro[5] = new SqlParameter("@FileType", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_PathFile.FileType;

                    Parametro[6] = new SqlParameter("@IdRegister", SqlDbType.Int);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_PathFile.IdRegister;

                    Parametro[7] = new SqlParameter("@FileTableAbbreviation", SqlDbType.VarChar);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = bE_PathFile.FileTableAbbreviation;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_PATH_FILE_CREATE", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_PathFile bE_Path = new BE_PathFile();
                            bE_Path.IdPathFile = DataUtil.ObjectToInt32(reader["IdPathFile"]);
                            bE_Path.PathFile = DataUtil.ObjectToString(reader["PathFile"]);
                            bE_Path.FileNameRegister = DataUtil.ObjectToString(reader["FileNameRegister"]);
                            bE_Path.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Path);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_PathFile bE_Path = new BE_PathFile();
                bE_Path.ValorConsulta = "0";
                bE_Path.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Path);
            }

            return listaResultado;
        }

        public List<BE_PathFile> CrearRutaTicket(BE_PathFile bE_PathFile)
        {
            SqlConnection conexion = null;
            List<BE_PathFile> listaResultado = new List<BE_PathFile>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[9];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_PathFile.RegistrationUser;

                    Parametro[1] = new SqlParameter("@PathFile", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_PathFile.PathFile;

                    Parametro[2] = new SqlParameter("@FileNameRegister", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_PathFile.FileNameRegister;

                    Parametro[3] = new SqlParameter("@FileSize", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_PathFile.FileSize;

                    Parametro[4] = new SqlParameter("@FileExtension", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_PathFile.FileExtension;

                    Parametro[5] = new SqlParameter("@FileType", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_PathFile.FileType;

                    Parametro[6] = new SqlParameter("@IdRegister", SqlDbType.Int);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_PathFile.IdRegister;

                    Parametro[7] = new SqlParameter("@FileTableAbbreviation", SqlDbType.VarChar);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = bE_PathFile.FileTableAbbreviation;

                    Parametro[8] = new SqlParameter("@OperationName", SqlDbType.VarChar);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = bE_PathFile.OperationName;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_PATH_FILE_CREATE_TICKET", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_PathFile bE_Path = new BE_PathFile();
                            bE_Path.IdPathFile = DataUtil.ObjectToInt32(reader["IdPathFile"]);
                            bE_Path.PathFile = DataUtil.ObjectToString(reader["PathFile"]);
                            bE_Path.FileNameRegister = DataUtil.ObjectToString(reader["FileNameRegister"]);
                            bE_Path.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Path);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_PathFile bE_Path = new BE_PathFile();
                bE_Path.ValorConsulta = "0";
                bE_Path.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Path);
            }

            return listaResultado;
        }

        public List<BE_PathFile> CrearRutaActivity(BE_PathFile bE_PathFile)
        {
            SqlConnection conexion = null;
            List<BE_PathFile> listaResultado = new List<BE_PathFile>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[9];
                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_PathFile.RegistrationUser;

                    Parametro[1] = new SqlParameter("@PathFile", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_PathFile.PathFile;

                    Parametro[2] = new SqlParameter("@FileNameRegister", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_PathFile.FileNameRegister;

                    Parametro[3] = new SqlParameter("@FileSize", SqlDbType.Int);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_PathFile.FileSize;

                    Parametro[4] = new SqlParameter("@FileExtension", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_PathFile.FileExtension;

                    Parametro[5] = new SqlParameter("@FileType", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_PathFile.FileType;

                    Parametro[6] = new SqlParameter("@IdRegister", SqlDbType.Int);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_PathFile.IdRegister;

                    Parametro[7] = new SqlParameter("@FileTableAbbreviation", SqlDbType.VarChar);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = bE_PathFile.FileTableAbbreviation;

                    Parametro[8] = new SqlParameter("@OperationName", SqlDbType.VarChar);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = bE_PathFile.OperationName;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_PATH_FILE_CREATE_ACTIVITY_DETAIL", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_PathFile bE_Path = new BE_PathFile();
                            bE_Path.IdPathFile = DataUtil.ObjectToInt32(reader["IdPathFile"]);
                            bE_Path.PathFile = DataUtil.ObjectToString(reader["PathFile"]);
                            bE_Path.FileNameRegister = DataUtil.ObjectToString(reader["FileNameRegister"]);
                            bE_Path.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Path);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_PathFile bE_Path = new BE_PathFile();
                bE_Path.ValorConsulta = "0";
                bE_Path.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Path);
            }

            return listaResultado;
        }

        public List<BE_PathFile> ListarRutaArchivo(string idsPathFiles, string TableAbrev, string IdRegister, string FileType)
        {
            SqlConnection conexion = null;
            List<BE_PathFile> listaResultado = new List<BE_PathFile>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[4];

                    Parametro[0] = new SqlParameter("@IdsPathFiles", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = idsPathFiles;

                    Parametro[1] = new SqlParameter("@FileTableAbbreviation", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = TableAbrev;

                    Parametro[2] = new SqlParameter("@IdRegister", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = IdRegister;

                    Parametro[3] = new SqlParameter("@FileType", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = FileType;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_PATH_FILE_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_PathFile bE_Path = new BE_PathFile();
                            bE_Path.IdPathFile = DataUtil.ObjectToInt32(reader["IdPathFile"]);
                            bE_Path.FileTableAbbreviation = DataUtil.ObjectToString(reader["FileTableAbbreviation"]);
                            bE_Path.IdRegister = DataUtil.ObjectToInt32(reader["IdRegister"]);
                            bE_Path.PathFile = DataUtil.ObjectToString(reader["PathFile"]);
                            bE_Path.FileNameRegister = DataUtil.ObjectToString(reader["FileNameRegister"]);
                            bE_Path.FileSize = DataUtil.ObjectToString(reader["FileSize"]);
                            bE_Path.FileType = DataUtil.ObjectToString(reader["FileType"]);
                            bE_Path.FullName = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Path.RegistrationDate = DataUtil.ObjectToDateTime(reader["RegistrationDate"]);
                            bE_Path.RegistrationDateString = DataUtil.ObjectToString(reader["RegistrationDateString"]);
                            bE_Path.ValorConsulta = "1";
                            listaResultado.Add(bE_Path);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_PathFile bE_Path = new BE_PathFile();
                bE_Path.ValorConsulta = "0";
                bE_Path.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Path);
            }

            return listaResultado;
        }

        public string EliminarRuta(BE_PathFile bE_Path)
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
                    Parametro[0].Value = bE_Path.UpdateUser;

                    Parametro[1] = new SqlParameter("@IdPathFile", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Path.IdPathFile;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_PATH_FILE_DELETE", Parametro))
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

        public string ActualizarRutaArchivo(int UpdateUser, string pathFileAnterior, string pathFileActual)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@UpdateUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = UpdateUser;

                    Parametro[1] = new SqlParameter("@PathFile", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = pathFileAnterior;

                    Parametro[2] = new SqlParameter("@PathFileUpdate", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = pathFileActual;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_PATH_FILE_UPDATE_PATH", Parametro))
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

    }
}
