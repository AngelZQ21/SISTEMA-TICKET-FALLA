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
    public class DA_Components
    {

        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Components> ListarComponentes(string valorBusqueda)
        {
            SqlConnection conexion = null;
            List<BE_Components> listaResultado = new List<BE_Components>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {

                    SqlParameter[] Parametro = new SqlParameter[1];

                    Parametro[0] = new SqlParameter("@valorBusqueda", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = valorBusqueda;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_COMPONENT_LIST" , Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Components bE_Components = new BE_Components();
                            bE_Components.IdComponent = DataUtil.ObjectToInt32(reader["IdComponent"]);
                            bE_Components.ComponentName = DataUtil.ObjectToString(reader["ComponentName"]);
                            bE_Components.RegistrationDateStrings = DataUtil.ObjectToString(reader["RegistrationDate"]);
                            bE_Components.UserCreation = DataUtil.ObjectToString(reader["UUser"]);
                            bE_Components.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Components);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Components bE_Components = new BE_Components();
                bE_Components.ValorConsulta = "0";
                bE_Components.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Components);
            }
            return listaResultado;
        }

        public string CrearComponente(string txtComponente, int RegistrationUser)
        {
            SqlConnection conexion = null;
            string resultado = "";
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];

                    Parametro[0] = new SqlParameter("@ComponentName", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = txtComponente;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_CREATE_COMPONENT", Parametro))
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

        public string EditarComponente(int idComponent, string txtComponente, int RegistrationUser)
        {
            SqlConnection conexion = null;
            string resultado = "";
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[3];

                    Parametro[0] = new SqlParameter("@ComponentName", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = txtComponente;

                    Parametro[1] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = RegistrationUser;

                    Parametro[2] = new SqlParameter("@ComponentId", SqlDbType.Int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = idComponent;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_EDIT_COMPONENT", Parametro))
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
