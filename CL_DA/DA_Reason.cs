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
    public class DA_Reason
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Reason> ListarReason()
        {

            SqlConnection conexion = null;
            List<BE_Reason> listaResultado = new List<BE_Reason>();
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

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_REASON"))
                    {
                        while (reader.Read())
                        {
                            BE_Reason bE_Reason = new BE_Reason();
                            bE_Reason.IdReason = DataUtil.ObjectToInt32(reader["IdReason"]);
                            bE_Reason.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Reason.ValorConsulta = "1";
                            listaResultado.Add(bE_Reason);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Reason bE_Reason = new BE_Reason();
                bE_Reason.ValorConsulta = "0";
                bE_Reason.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Reason);
            }

            return listaResultado;
        }

        public List<BE_Location> ListarLocation()
        {

            SqlConnection conexion = null;
            List<BE_Location> listaResultado = new List<BE_Location>();
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

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_LOCATION"))
                    {
                        while (reader.Read())
                        {
                            BE_Location bE_Location = new BE_Location();
                            bE_Location.IdLocation = DataUtil.ObjectToInt32(reader["IdLocation"]);
                            bE_Location.LocationName = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Location.ValorConsulta = "1";
                            listaResultado.Add(bE_Location);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Location bE_Location = new BE_Location();
                bE_Location.ValorConsulta = "0";
                bE_Location.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Location);
            }

            return listaResultado;
        }

        public string CrearReason(BE_Reason bE_Reason)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Reason.RegistrationUser;

                    Parametro[1] = new SqlParameter("@ReasonName", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Reason.ReasonName;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_REASON_CREATE", Parametro))
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

        public string CrearLocacion(BE_Location bE_Location)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Location.RegistrationUser;

                    Parametro[1] = new SqlParameter("@LocationName", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Location.LocationName;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_LOCATION_CREATE", Parametro))
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
