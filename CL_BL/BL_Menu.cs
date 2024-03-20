using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_Menu
    {
        public List<BE_Menu_Profile> ListarMenu(int idProfile, string valorConsulta)
        {
            var listaResultado = new List<BE_Menu_Profile>();
            try
            {
                listaResultado = new DA_Menu().ListarMenu(idProfile, valorConsulta);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Menu_Profile bE_Menu_Profile = new BE_Menu_Profile();
                bE_Menu_Profile.ValorConsulta = "0";
                bE_Menu_Profile.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Menu_Profile);
            }
            return listaResultado;
        }


        public string ValidarMenuPerfilActual(int idPerfil, string Controlador, string Vista)
        {
            string resultado = "";
            try
            {
                List<BE_Menu> listaResultado = new List<BE_Menu>();
                listaResultado = new DA_Menu().ValidarMenuPerfilActual(idPerfil, Controlador, Vista);

                if (listaResultado.Count >= 1)
                {
                    if (listaResultado[0].ValorConsulta == "1")
                    {
                        resultado = "1";
                    }
                    else
                    {
                        resultado = listaResultado[0].MensajeConsulta;
                    }
                }
                else
                {
                    resultado = "0";
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
