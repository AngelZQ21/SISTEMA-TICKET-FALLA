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
    public class DA_Value
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Value> ListadoAlarmaConCodigo()
        {
            SqlConnection conexion = null;
            List<BE_Value> listaResultado = new List<BE_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_ALERT_LIST_WITH_CODE"))
                    {
                        while (reader.Read())
                        {
                            BE_Value bE_Value = new BE_Value();
                            bE_Value.Attribute = DataUtil.ObjectToString(reader["Id"]);
                            bE_Value.Meaning = DataUtil.ObjectToString(reader["TypeAlarm"]);
                            bE_Value.Comment = DataUtil.ObjectToString(reader["TypeAlarmDesc"]);

                            bE_Value.ValorConsulta = "1";
                            listaResultado.Add(bE_Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Value bE_Value = new BE_Value();
                bE_Value.ValorConsulta = "0";
                bE_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Value);
            }
            return listaResultado;
        }

        public List<BE_Value> ListarValues(string valorBusqueda, string nombreTabla, string nombreColumna)
        {

            SqlConnection conexion = null;
            List<BE_Value> listaResultado = new List<BE_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];
                    Parametro[0] = new SqlParameter("@Search", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = valorBusqueda;

                    Parametro[1] = new SqlParameter("@TableName", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = nombreTabla;

                    Parametro[2] = new SqlParameter("@ColumnName", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = nombreColumna;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_VALUE_LIST",Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Value bE_Value = new BE_Value();
                            bE_Value.IdValue = DataUtil.ObjectToInt32(reader["IdValue"]);
                            bE_Value.TableName = DataUtil.ObjectToString(reader["TableName"]);
                            bE_Value.ColumnName = DataUtil.ObjectToString(reader["ColumnName"]);
                            bE_Value.Attribute = DataUtil.ObjectToString(reader["Attribute"]);
                            bE_Value.Meaning = DataUtil.ObjectToString(reader["Meaning"]);
                            bE_Value.Comment = DataUtil.ObjectToString(reader["Comment"]);
                            bE_Value.ValorConsulta = "1";
                            listaResultado.Add(bE_Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Value bE_Value = new BE_Value();
                bE_Value.ValorConsulta = "0";
                bE_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Value);
            }

            return listaResultado;
        }

        public List<BE_Value> ListarAnos()
        {

            SqlConnection conexion = null;
            List<BE_Value> listaResultado = new List<BE_Value>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_YEAR_LIST"))
                    {
                        while (reader.Read())
                        {
                            BE_Value bE_Value = new BE_Value();
                            bE_Value.IdYear = DataUtil.ObjectToInt32(reader["IdYear"]);
                            bE_Value.YearNumber = DataUtil.ObjectToInt32(reader["YearNumber"]);
                            bE_Value.ValorConsulta = "1";
                            listaResultado.Add(bE_Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Value bE_Value = new BE_Value();
                bE_Value.ValorConsulta = "0";
                bE_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Value);
            }

            return listaResultado;
        }

    }
}
