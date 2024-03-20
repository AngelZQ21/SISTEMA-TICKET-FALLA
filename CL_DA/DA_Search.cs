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
    public class DA_Search
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Search> ListaResultadoBusquedaInteligente(string valorBusqueda)
        {
            /**/
            SqlConnection conexion = null;
            List<BE_Search> listaResultado = new List<BE_Search>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@SearchValue", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = valorBusqueda;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_SMART_SEARCH_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Search bE_Search = new BE_Search();
                            bE_Search.Controller = DataUtil.ObjectToString(reader["Controller"]);
                            bE_Search.ViewController = DataUtil.ObjectToString(reader["ViewController"]);
                            bE_Search.VisualName = DataUtil.ObjectToString(reader["VisualName"]);
                            bE_Search.Description = DataUtil.ObjectToString(reader["Description"]);
                            bE_Search.Type = DataUtil.ObjectToString(reader["Type"]);
                            bE_Search.SearchValue = DataUtil.ObjectToString(reader["SearchValue"]);
                            bE_Search.RegistrationStatus = DataUtil.ObjectToString(reader["RegistrationStatus"]);
                            bE_Search.TableName = DataUtil.ObjectToString(reader["TableName"]); 
                            bE_Search.StartDate = DataUtil.ObjectToString(reader["StartDate"]); 
                            bE_Search.EndDate = DataUtil.ObjectToString(reader["EndDate"]);
                            bE_Search.IdProduct = DataUtil.ObjectToInt32(reader["IdProduct"]);
                            bE_Search.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Search);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Search bE_Search = new BE_Search();
                bE_Search.ValorConsulta = "0";
                bE_Search.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Search);
            }

            return listaResultado;
        }
    }
}
