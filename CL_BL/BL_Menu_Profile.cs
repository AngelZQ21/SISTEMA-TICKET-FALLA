using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_Menu_Profile
    {
        public string guardarConfiguracionMenuPerfil(String arrayIdMenu, int idPerfil, int mainId, int idMenu)
        {
            string resultado = "0";
            //resultado = 0 - No se actualizaron todas las vistas en la base de datos (Error durante ejecución del SP)
            //resultado = 1 - éxito
            //resultado = 2 - La vista principal seleccionada no esta dentro del las vistas activas para el perfil
            BE_Menu_Profile g = new BE_Menu_Profile();
            
            try
            {
                
                string[] arraySeparador = new string[] { "," };
                string[] mainIdArray = arrayIdMenu.Split(arraySeparador, StringSplitOptions.RemoveEmptyEntries);

                if (mainIdArray.Length == 0) {

                    resultado = "2";

                }
                    for (int i = 0; i < mainIdArray.Length; i++)
                {
                    if (Convert.ToInt32(mainIdArray[i]) == mainId)
                    {
                        resultado = "1";
                        break;
                    }
                    else {
                        resultado = "2"; 
                    }
                }
                if (resultado == "1") {

                    if (new DA_MenuProfile().actualizarEstadoMenuPerfilP1(idPerfil) == "1")
                    {
                        if (new DA_MenuProfile().actualizarEstadoMenuPerfilP2(arrayIdMenu, idPerfil) == "1")
                        {
                            if (new DA_MenuProfile().actualizarEstadoMenuPerfilP3(idPerfil, idMenu) == "1")
                            {
                                resultado = "1";
                            }else { resultado = "0";}
                        }else { resultado = "0"; }
                    }else { resultado = "0"; }

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
