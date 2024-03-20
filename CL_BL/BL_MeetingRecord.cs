using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_MeetingRecord
    {
        public List<BE_Meeting_Record> ListarReporteActaDeReunion(string StartDate, string EndDate, string IdsOperacion, int IdUser)
        {

            var listaResultado = new List<BE_Meeting_Record>();
            try
            {
                listaResultado = new DA_MeetingRecord().ListarReporteActaDeReunion(StartDate, EndDate, IdsOperacion, IdUser);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Meeting_Record bE_Meeting_Record = new BE_Meeting_Record();
                bE_Meeting_Record.ValorConsulta = "0";
                bE_Meeting_Record.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Meeting_Record);
            }
            return listaResultado;
        }
        
        public List<BE_Meeting_Record_Detail> ListarActaDeReunionDetalle(int IdMeetingRecord, int IdOperation)
        {

            var listaResultado = new List<BE_Meeting_Record_Detail>();
            try
            {
                listaResultado = new DA_MeetingRecord().ListarActaDeReunionDetalle(IdMeetingRecord, IdOperation);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Meeting_Record_Detail bE_Meeting_Record_Detail = new BE_Meeting_Record_Detail();
                bE_Meeting_Record_Detail.ValorConsulta = "0";
                bE_Meeting_Record_Detail.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Meeting_Record_Detail);
            }
            return listaResultado;
        }

        public string RegistrarActaDeReunion(BE_Meeting_Record bE_Meeting_Record)
        {
            string resultado = "";

            try
            {
                resultado = new DA_MeetingRecord().RegistrarActaDeReunion(bE_Meeting_Record);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
        
        public string ActualizarActaDeReunion(BE_Meeting_Record bE_Meeting_Record)
        {
            string resultado = "";

            try
            {
                resultado = new DA_MeetingRecord().ActualizarActaDeReunion(bE_Meeting_Record);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
    }
}
