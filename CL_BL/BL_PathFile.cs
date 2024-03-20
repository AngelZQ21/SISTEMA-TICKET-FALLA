using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_PathFile
    {
        public List<BE_PathFile> CrearRuta(BE_PathFile bE_PathFile)
        {
            var listaResultado = new List<BE_PathFile>();
            try
            {
                listaResultado = new DA_PathFile().CrearRuta(bE_PathFile);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_PathFile bE_Path = new BE_PathFile();
                bE_Path.ValorConsulta = "0";
                bE_Path.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Path);
            }
            return listaResultado;
        }

        public List<BE_PathFile> CrearRutaTicket(BE_PathFile bE_PathFile)
        {
            var listaResultado = new List<BE_PathFile>();
            try
            {
                listaResultado = new DA_PathFile().CrearRutaTicket(bE_PathFile);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_PathFile bE_Path = new BE_PathFile();
                bE_Path.ValorConsulta = "0";
                bE_Path.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Path);
            }
            return listaResultado;
        }

        public List<BE_PathFile> CrearRutaActivity(BE_PathFile bE_PathFile)
        {
            var listaResultado = new List<BE_PathFile>();
            try
            {
                listaResultado = new DA_PathFile().CrearRutaActivity(bE_PathFile);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_PathFile bE_Path = new BE_PathFile();
                bE_Path.ValorConsulta = "0";
                bE_Path.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Path);
            }
            return listaResultado;
        }

        public List<BE_PathFile> ListarRutaArchivo(string idsPathFiles, string TableAbrev, string IdRegister, string FileType)
        {
            var listaResultado = new List<BE_PathFile>();
            try
            {
                listaResultado = new DA_PathFile().ListarRutaArchivo(idsPathFiles, TableAbrev, IdRegister, FileType);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_PathFile bE_Path = new BE_PathFile();
                bE_Path.ValorConsulta = "0";
                bE_Path.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Path);
            }
            return listaResultado;
        }

        public string EliminarRuta(BE_PathFile bE_Path)
        {

            string resultado = "";

            try
            {
                resultado = new DA_PathFile().EliminarRuta(bE_Path);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string ActualizarRutaArchivo(int UpdateUser, string pathFileAnterior, string pathFileActual)
        {

            string resultado = "";

            try
            {
                resultado = new DA_PathFile().ActualizarRutaArchivo(UpdateUser, pathFileAnterior, pathFileActual);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

    }
}
