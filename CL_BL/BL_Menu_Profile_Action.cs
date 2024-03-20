using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;
namespace CL_BL
{
    public class BL_Menu_Profile_Action
    {
        public List<BE_Menu_Profile_Action> ListarMenuPerfilAction(int idPerfil, string valorConsulta)
        {
            var listaResultado = new List<BE_Menu_Profile_Action>();
            try
            {
                listaResultado = new DA_Menu_Profile_Action().ListarMenuPerfilAction(idPerfil, valorConsulta);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Menu_Profile_Action bE_Menu_Profile_Action = new BE_Menu_Profile_Action();
                bE_Menu_Profile_Action.ValorConsulta = "0";
                bE_Menu_Profile_Action.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Menu_Profile_Action);
            }
            return listaResultado;
        }

        public string guardarConfiguracionMenuPerfilAccion(String arrayIdMenu, int idPerfil)
        {
            string resultado = "0";
            //resultado = 0 - No se actualizaron todas las vistas en la base de datos (Error durante ejecución del SP)
            //resultado = 1 - éxito
            try
            {

                if (new DA_Menu_Profile_Action().actualizarEstadoMenuAccionPerfilP1(idPerfil) == "1")
                    {
                        if (new DA_Menu_Profile_Action().actualizarEstadoMenuAccionPerfilP2(arrayIdMenu, idPerfil) == "1")
                        {
                            resultado = "1";
                        }
                        else { resultado = "0"; }
                    }
                    else { resultado = "0"; }

            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
    }
}
