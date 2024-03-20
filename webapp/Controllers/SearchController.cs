﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BL;
using CL_BE;
namespace SmartAdminMvc.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VSearch()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "Search", "VSearch");

                if (Valicacion == "1")
                {
                    return View();
                }
                else
                {
                    TempData["MsgTmp"] = "Validacion retornada " + Valicacion;
                    return RedirectToAction("Vnoautorizado", "Error");
                }
            }
            catch (Exception e)
            {
                TempData["MsgTmp"] = "Validacion retornada " + e.Message;
                return RedirectToAction("Login", "Account");
            }


        }


        public JsonResult ListaResultadoBusquedaInteligente(string valorBusqueda)
        {
            var lista = new BL_Search().ListaResultadoBusquedaInteligente(valorBusqueda);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
    }
}