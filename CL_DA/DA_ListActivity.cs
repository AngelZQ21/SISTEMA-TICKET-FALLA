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
    public class DA_ListActivity
    {

        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;

        public List<BE_Activity> ListadoActividaDesUsuarios(string StartDate, string EndDate, string IdsTicket, string IdsPeople, int RegistrationUser)
        {
            SqlConnection conexion = null;
            List<BE_Activity> listaResultado = new List<BE_Activity>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];

                    Parametro[0] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = StartDate;

                    Parametro[1] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = EndDate;

                    Parametro[2] = new SqlParameter("@IdsTicket", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = IdsTicket;

                    Parametro[3] = new SqlParameter("@IdsPeople", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = IdsPeople;

                    Parametro[4] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = RegistrationUser;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SPR_LIST_ACTIVITY_PER_USER", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Activity bE_Activity = new BE_Activity();

                            /*------------ TICKET ------------*/

                            bE_Activity.IdTicket = DataUtil.ObjectToInt32(reader["IdTicket"]);
                            bE_Activity.NroTicket = DataUtil.ObjectToString(reader["NumberTicket"]);
                            bE_Activity.StartDate = DataUtil.ObjectToString(reader["StartDate"]);
                            bE_Activity.FullNameTicket = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Activity.UsuarioNameTicket = DataUtil.ObjectToString(reader["UsuarioName"]);
                            bE_Activity.ResponsibleNameTicket = DataUtil.ObjectToString(reader["ResponsibleName"]);
                            bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.ReasonName = DataUtil.ObjectToString(reader["ReasonName"]);
                            bE_Activity.LocationNameTicket = DataUtil.ObjectToString(reader["LocationName"]);
                            bE_Activity.CriticalityName = DataUtil.ObjectToString(reader["CriticalityName"]);
                            bE_Activity.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Activity.DetalleText = DataUtil.ObjectToString(reader["DescriptionText"]);
                            bE_Activity.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsibleTicket"]);
                            bE_Activity.MigrationStatus = DataUtil.ObjectToString(reader["MigrationStatus"]);

                            /*------------ ACTIVITY ------------*/

                            bE_Activity.IdActivity = DataUtil.ObjectToInt(reader["IdActivity"]);
                            bE_Activity.OldDifferenceDate = DataUtil.ObjectToString(reader["OldDifferenceDate"]);
                            //bE_Activity.TitleDescription = DataUtil.ObjectToString(reader["TitleDescription"]);
                            bE_Activity.ActivityText = DataUtil.ObjectToString(reader["ActivityText"]);
                            bE_Activity.FullNameActivity = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Activity.DescripcionActivity = DataUtil.ObjectToString(reader["DescripcionActivity"]);
                            bE_Activity.FechaCierre = DataUtil.ObjectToString(reader["FechaCierre"]);
                            bE_Activity.Estado = DataUtil.ObjectToString(reader["Estado"]);
                            bE_Activity.ValidationButton = DataUtil.ObjectToString(reader["ValidationButton"]);
                            //bE_Activity.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Activity.ResponsibleId = DataUtil.ObjectToInt(reader["IdResponsible"]);
                            bE_Activity.ValorConsulta = "1";
                            listaResultado.Add(bE_Activity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Activity bE_Activity = new BE_Activity();
                bE_Activity.ValorConsulta = "0";
                bE_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Activity);
            }
            return listaResultado;
        }

    }
}
