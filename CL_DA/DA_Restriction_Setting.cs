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
    public class DA_Restriction_Setting
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public DataTable ListarConfiguracionRestriccion(string RestrictionTable, string Search, string QueryValue)
        {
            SqlConnection conexion = null;

            DataTable dt = new DataTable();

            //  Crear Columnas en DataTable
            DataColumn column = new DataColumn();
            dt.Columns.Add("ValorConsulta", typeof(string));
            dt.Columns.Add("MensajeConsulta", typeof(string));

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_RESTRICTION_SETTING"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conexion;
                        cmd.CommandTimeout = 999999;
                        cmd.Parameters.AddWithValue("@RestrictionTable", RestrictionTable);
                        cmd.Parameters.AddWithValue("@Search", Search);
                        cmd.Parameters.AddWithValue("@QueryValue", QueryValue);

                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;

                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            row["ValorConsulta"] = "1";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //  Llenar el DataTable
                DataRow row;
                row = dt.NewRow();
                row["ValorConsulta"] = "0";
                row["MensajeConsulta"] = ex.Message;

                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable ListarConfiguracionRestriccionColumn(string RestrictionTable)
        {
            SqlConnection conexion = null;

            DataTable dt = new DataTable();

            //  Crear Columnas en DataTable
            DataColumn column = new DataColumn();
            dt.Columns.Add("ValorConsulta", typeof(string));
            dt.Columns.Add("MensajeConsulta", typeof(string));

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_RESTRICTION_SETTING_COLUMN"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conexion;
                        cmd.CommandTimeout = 999999;
                        cmd.Parameters.AddWithValue("@RestrictionTable", RestrictionTable);

                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;

                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            row["ValorConsulta"] = "1";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //  Llenar el DataTable
                DataRow row;
                row = dt.NewRow();
                row["ValorConsulta"] = "0";
                row["MensajeConsulta"] = ex.Message;

                dt.Rows.Add(row);
            }
            return dt;
        }

        public string CrearMapaA(int IdUser, string Nombre, string TablaRestriccion, string RestriccionesSeleccionadas, string RestrictionColumns)
        {
            string resultado = "";
            SqlConnection conexion = null;
          
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    
                    //definição do comando sql
                    string sql = "DECLARE @Result VARCHAR(500) SET @Result=0 BEGIN" +
                        "IF NOT EXISTS(SELECT ValidationDescription FROM " + TablaRestriccion + " WHERE ValidationDescription = '" + Nombre + "') " +
                        " BEGIN " +
                        "INSERT INTO " + TablaRestriccion + 
                        " (RegistrationUser, ValidationDescription, ";

                    for (int i = 0; i < RestrictionColumns.Length; i++)
                    {
                        sql = sql + RestrictionColumns[i];
                    }

                    sql = sql + ") VALUES (" + IdUser + ", '" + Nombre + "', ";

                    string[] arrayRestrictionColumns = RestrictionColumns.Split(',');
                    string[] arrayRestriccionesSeleccionadas = RestriccionesSeleccionadas.Split(',');

                    for (int i = 0; i < arrayRestrictionColumns.Length; i++)
                    {
                        int valor = 0;

                        for (int x = 0; x < arrayRestriccionesSeleccionadas.Length; x++)
                        {
                            if (arrayRestrictionColumns[i].ToString().Trim().Equals(arrayRestriccionesSeleccionadas[x].ToString().Trim()))
                            {
                                valor = 1;
                                break;
                            }
                            else
                            {
                                valor = 0;
                            }
                        }

                        if (valor == 1)
                        {
                            sql = sql + "1,";
                        }
                        else
                        {
                            sql = sql + "0,";
                        }
                    }

                    string sqlnew = sql.Substring(0, sql.Length - 1) + ")" +
                        " BEGIN IF (@@ROWCOUNT = 0) BEGIN SET @RESULT = '0' ELSE BEGIN SET @RESULT = '1' END END END" +
                        " END " +
                        " END "; 


                    SqlCommand comando = new SqlCommand(sqlnew, conexion);
                    comando.CommandType = CommandType.Text;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();

                    resultado = "1";
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;               
            }

            return "";
        }

        public string CrearMapa(string sql)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@sql", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = sql;                   

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_MAP_CREATE", Parametro))
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

        public string EditarMapa(string sql)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@sql", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = sql;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_MAP_UPDATE", Parametro))
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

        public string EditarEstadoRestriccionMapa(int Id, int IdUser, string TablaRestriccion)
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
                    Parametro[0].Value = IdUser;

                    Parametro[1] = new SqlParameter("@Id", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = Id;

                    Parametro[2] = new SqlParameter("@RestrictionTable", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = TablaRestriccion;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_MAP_STATUS_UPDATE", Parametro))
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

        public string EliminarMapa(int Id, int IdUser, string TablaRestriccion)
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
                    Parametro[0].Value = IdUser;

                    Parametro[1] = new SqlParameter("@Id", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = Id;

                    Parametro[2] = new SqlParameter("@RestrictionTable", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = TablaRestriccion;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_MAP_DELETE", Parametro))
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

        public string GrabarMapaVehiculo(string sql)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@sql", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = sql;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_MAP_VEHICLES_UPDATE", Parametro))
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

        public List<BE_Restriction> ValidarRelacionRestriccionMapa(int IdValidationMap, string RestrictionTable)
        {

            SqlConnection conexion = null;
            List<BE_Restriction> listaResultado = new List<BE_Restriction>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[2];
                    Parametro[0] = new SqlParameter("@IdValidationMap", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdValidationMap;

                    Parametro[1] = new SqlParameter("@RestrictionTable", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RestrictionTable;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_RESTRICTION_MAP_VALIDATE_DEPENDENCY_STATUS", Parametro))
                    {
                        while (reader.Read())
                        {

                            BE_Restriction bE_Restriction = new BE_Restriction();

                            bE_Restriction.IdValidationMap = DataUtil.ObjectToInt32(reader["IdValidationMap"]);
                            bE_Restriction.ValidationDescription = DataUtil.ObjectToString(reader["ValidationDescription"]);                                                        
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
    }
}
