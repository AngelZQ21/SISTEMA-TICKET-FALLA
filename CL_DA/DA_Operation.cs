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
    public class DA_Operation
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Operation> ListarOperaciones()
        {
            SqlConnection conexion = null;
            List<BE_Operation> listaResultado = new List<BE_Operation>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_OPERATION_LIST"))
                    {
                        while (reader.Read())
                        {
                            BE_Operation bE_Operation = new BE_Operation();
                            bE_Operation.IdOperation = DataUtil.ObjectToInt32(reader["IdOperation"]);
                            bE_Operation.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Operation.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Operation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Operation bE_Operation = new BE_Operation();
                bE_Operation.ValorConsulta = "0";
                bE_Operation.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Operation);
            }
            return listaResultado;
        }

        public string CrearOperacion(BE_Operation bE_Operation)
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
                    Parametro[0].Value = bE_Operation.RegistrationUser;

                    Parametro[1] = new SqlParameter("@OperationName", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Operation.OperationName;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_OPERATION_CREATE", Parametro))
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
