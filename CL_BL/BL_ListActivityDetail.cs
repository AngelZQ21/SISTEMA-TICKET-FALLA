using CL_BE;
using CL_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BL
{
    public class BL_ListActivityDetail
    {

        public string RegistrarActivityDetail(BE_ActivityDetail bE_ActivityDetail)
        {

            string resultado = "";
            try
            {
                resultado = new DA_ListActivityDetail().RegistrarActivityDetail(bE_ActivityDetail);

            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string UpdateStateActivityDetail(BE_ActivityDetail bE_ActivityDetail)
        {

            string resultado = "";

            try
            {
                resultado = new DA_ListActivityDetail().UpdateStateActivityDetail(bE_ActivityDetail);

            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

    }
}
