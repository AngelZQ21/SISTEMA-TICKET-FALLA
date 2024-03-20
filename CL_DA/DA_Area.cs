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
    public class DA_Area
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Area> ListarAreas()
        {
            SqlConnection conexion = null;
            List<BE_Area> listaResultado = new List<BE_Area>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_AREA_LIST"))
                    {
                        while (reader.Read())
                        {
                            BE_Area bE_Area = new BE_Area();
                            bE_Area.IdArea = DataUtil.ObjectToInt32(reader["IdArea"]);
                            bE_Area.AreaName = DataUtil.ObjectToString(reader["AreaName"]);
                            bE_Area.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Area);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Area bE_Area = new BE_Area();
                bE_Area.ValorConsulta = "0";
                bE_Area.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Area);
            }

            return listaResultado;
        }

        public string CrearArea(BE_Area bE_Area)
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
                    Parametro[0].Value = bE_Area.RegistrationUser;

                    Parametro[1] = new SqlParameter("@AreaName", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Area.AreaName;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_AREA_CREATE", Parametro))
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
