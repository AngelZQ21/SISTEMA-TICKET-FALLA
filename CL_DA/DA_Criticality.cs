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
    public class DA_Criticality
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Criticality> ListarCriticality()
        {

            SqlConnection conexion = null;
            List<BE_Criticality> listaResultado = new List<BE_Criticality>();
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

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_CRITICALITY"))
                    {
                        while (reader.Read())
                        {
                            BE_Criticality bE_Criticality = new BE_Criticality();
                            bE_Criticality.IdCriticality = DataUtil.ObjectToInt32(reader["IdCriticality"]);
                            bE_Criticality.CriticalityNameTime = DataUtil.ObjectToString(reader["CriticalityNameTime"]);
                            bE_Criticality.ValorConsulta = "1";
                            listaResultado.Add(bE_Criticality);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Criticality bE_Criticality = new BE_Criticality();
                bE_Criticality.ValorConsulta = "0";
                bE_Criticality.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Criticality);
            }

            return listaResultado;
        }
    }
}
