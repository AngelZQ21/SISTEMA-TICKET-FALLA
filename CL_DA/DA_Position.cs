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
    public class DA_Position
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Position> ListarCargos()
        {
            SqlConnection conexion = null;
            List<BE_Position> listaResultado = new List<BE_Position>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_POSITION_LIST"))
                    {
                        while (reader.Read())
                        {
                            BE_Position bE_Position = new BE_Position();
                            bE_Position.IdPosition = DataUtil.ObjectToInt32(reader["IdPosition"]);
                            bE_Position.PositionName = DataUtil.ObjectToString(reader["PositionName"]);
                            bE_Position.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Position);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Position bE_Position = new BE_Position();
                bE_Position.ValorConsulta = "0";
                bE_Position.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Position);
            }

            return listaResultado;
        }

        public string CrearCargo(BE_Position bE_Position)
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
                    Parametro[0].Value = bE_Position.RegistrationUser;

                    Parametro[1] = new SqlParameter("@PositionName", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Position.PositionName;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_POSITION_CREATE", Parametro))
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
