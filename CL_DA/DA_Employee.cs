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
    public class DA_Employee
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cn"]].ConnectionString;
        public List<BE_Employee> ListarTrabajadores(int IdOperation)
        {
            SqlConnection conexion = null;
            List<BE_Employee> listaResultado = new List<BE_Employee>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@IdOperation", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = IdOperation;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "LSP_EMPLOYEE_LIST", Parametro))
                    {
                        while (reader.Read())
                        {
                            BE_Employee bE_Employee = new BE_Employee();
                            bE_Employee.bE_Person = new BE_Person();
                            bE_Employee.bE_Area = new BE_Area();
                            bE_Employee.bE_Position = new BE_Position();
                            bE_Employee.bE_Operation = new BE_Operation();
                            bE_Employee.IdEmployee = DataUtil.ObjectToInt32(reader["IdEmployee"]);
                            bE_Employee.bE_Person.FullName = DataUtil.ObjectToString(reader["FullName"]);
                            bE_Employee.bE_Area.AreaName = DataUtil.ObjectToString(reader["AreaName"]);
                            bE_Employee.bE_Position.PositionName = DataUtil.ObjectToString(reader["PositionName"]);
                            bE_Employee.bE_Operation.OperationName = DataUtil.ObjectToString(reader["OperationName"]);
                            bE_Employee.ValorConsulta = DataUtil.ObjectToString(reader["ValorConsulta"]);
                            listaResultado.Add(bE_Employee);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Employee bE_Employee = new BE_Employee();
                bE_Employee.ValorConsulta = "0";
                bE_Employee.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Employee);
            }

            return listaResultado;
        }

        public string CrearTrabajador(BE_Employee bE_Employee)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[13];
                    Parametro[0] = new SqlParameter("@RegistrationUser", SqlDbType.Int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = bE_Employee.RegistrationUser;

                    Parametro[1] = new SqlParameter("@DocumentId", SqlDbType.Int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = bE_Employee.bE_Person.DocumentId;

                    Parametro[2] = new SqlParameter("@DocumentNumber", SqlDbType.VarChar);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = bE_Employee.bE_Person.DocumentNumber;

                    Parametro[3] = new SqlParameter("@PersonName", SqlDbType.VarChar);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = bE_Employee.bE_Person.PersonName;

                    Parametro[4] = new SqlParameter("@FirstLastName", SqlDbType.VarChar);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = bE_Employee.bE_Person.FirstLastName;

                    Parametro[5] = new SqlParameter("@SecondLastName", SqlDbType.VarChar);
                    Parametro[5].Direction = ParameterDirection.Input;
                    Parametro[5].Value = bE_Employee.bE_Person.SecondLastName;

                    Parametro[6] = new SqlParameter("@PersonMainAddress", SqlDbType.VarChar);
                    Parametro[6].Direction = ParameterDirection.Input;
                    Parametro[6].Value = bE_Employee.bE_Person.PersonMainAddress;

                    Parametro[7] = new SqlParameter("@PersonMail", SqlDbType.VarChar);
                    Parametro[7].Direction = ParameterDirection.Input;
                    Parametro[7].Value = bE_Employee.bE_Person.PersonMail;

                    Parametro[8] = new SqlParameter("@PersonPhone", SqlDbType.VarChar);
                    Parametro[8].Direction = ParameterDirection.Input;
                    Parametro[8].Value = bE_Employee.bE_Person.PersonPhone;

                    Parametro[9] = new SqlParameter("@Birthdate", SqlDbType.VarChar);
                    Parametro[9].Direction = ParameterDirection.Input;
                    Parametro[9].Value = bE_Employee.bE_Person.Birthdate;

                    Parametro[10] = new SqlParameter("@IdArea", SqlDbType.Int);
                    Parametro[10].Direction = ParameterDirection.Input;
                    Parametro[10].Value = bE_Employee.bE_Area.IdArea;

                    Parametro[11] = new SqlParameter("@IdPosition", SqlDbType.Int);
                    Parametro[11].Direction = ParameterDirection.Input;
                    Parametro[11].Value = bE_Employee.bE_Position.IdPosition;

                    Parametro[12] = new SqlParameter("@IdOperation", SqlDbType.Int);
                    Parametro[12].Direction = ParameterDirection.Input;
                    Parametro[12].Value = bE_Employee.bE_Operation.IdOperation;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "MSP_EMPLOYEE_CREATE", Parametro))
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
