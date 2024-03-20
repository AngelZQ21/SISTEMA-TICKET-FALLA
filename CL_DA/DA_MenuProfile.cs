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
    public class DA_MenuProfile
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;


        public String actualizarEstadoMenuPerfilP1(int idPerfil)
        {

            string resultado = "";
            SqlConnection conexion = null;
            try
            {
                    using (conexion = new SqlConnection(cadenaConexion))
                    {

                        SqlParameter[] Parametro = new SqlParameter[1];
                        Parametro[0] = new SqlParameter("@IdProfile", SqlDbType.Int);
                        Parametro[0].Direction = ParameterDirection.Input;
                        Parametro[0].Value = idPerfil;

                        using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_MENU_PROFILE_UPDATE_STATE_P1", Parametro))
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

        public String actualizarEstadoMenuPerfilP2(String arrayIdMenu, int idPerfil)
        {
            string[] arraySeparador = new string[] { "," };
            string[] idMenu = arrayIdMenu.Split(arraySeparador, StringSplitOptions.RemoveEmptyEntries);

            string resultado = "";
            int incrementador = 0;
            SqlConnection conexion = null;
            try{
            //1 recorre todos los Id's de menús recibidos como parámetro y los setea  a activos 
            //en la tabla TB_MENU_PROFILE según el id Perfil
            for (int i = 0; i < idMenu.Length; i++)
            {
                
                    using (conexion = new SqlConnection(cadenaConexion))
                    {

                        SqlParameter[] Parametro = new SqlParameter[2];
                        Parametro[0] = new SqlParameter("@MainId", SqlDbType.Int);
                        Parametro[0].Direction = ParameterDirection.Input;
                        Parametro[0].Value = idMenu[i];

                        Parametro[1] = new SqlParameter("@IdProfile", SqlDbType.Int);
                        Parametro[1].Direction = ParameterDirection.Input;
                        Parametro[1].Value = idPerfil;

                        using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_MENU_PROFILE_UPDATE_STATE_P2", Parametro))
                        {

                            while (reader.Read())
                            {
                                resultado = DataUtil.ObjectToString(reader["Resultado"]);
                                //2 Si actualiza el valor correctamente en cada recorrido, aumenta la variable incrementador en 1
                                if (resultado == "1") {
                                    incrementador++;
                                }
                            }
                        }
                    }
                }
            //3 Compara el tamaño del array con la cantidad de actualizaciones, si es igual envía "1" que significa "éxito"
            if (idMenu.Length == incrementador)
            {
                resultado = "1";
            }
            else {
                resultado = "0";
            }
 
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public String actualizarEstadoMenuPerfilP3(int idProfile, int idMenu)
        {

            string resultado = "";
            SqlConnection conexion = null;
            try
            {
                    using (conexion = new SqlConnection(cadenaConexion))
                    {

                        SqlParameter[] Parametro = new SqlParameter[2];
                        Parametro[0] = new SqlParameter("@IdProfile", SqlDbType.Int);
                        Parametro[0].Direction = ParameterDirection.Input;
                        Parametro[0].Value = idProfile;

                        Parametro[1] = new SqlParameter("@IdMenu", SqlDbType.Int);
                        Parametro[1].Direction = ParameterDirection.Input;
                        Parametro[1].Value = idMenu;

                        using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "USP_MENU_PROFILE_UPDATE_STATE_P3", Parametro))
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
