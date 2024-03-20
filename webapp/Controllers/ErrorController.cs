using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/
        public ActionResult Index(/*int error = 0*/)
        {
            /*switch (error)
            {
                case 505:
                    ViewBag.Title = "Ocurrio un error inesperado";
                    ViewBag.Description = "Esto es muy vergonzoso, esperemos que no vuelva a pasar ..";
                    break;

                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "La URL que está intentando ingresar no existe";
                    break;

                default:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "Algo salio muy mal :( ..";
                    break;
            }

            return View("~/views/Error/Vnoautorizado.cshtml");*/
            return View();
        }

        public ActionResult Vnoautorizado()
        {
            //try
            //{
            //    //ViewBag.Mensaje = TempData["MsgTmp"].ToString();
            //    Response.StatusCode = 403;
            //    return PartialView();
            //}
            //catch (Exception e)
            //{
            //    TempData["MsgTmp"] = "Validacion retornada " + e.Message;
            //    return RedirectToAction("Login", "Account");
            //}

            Response.StatusCode = 403;
            return PartialView();
            
        }

        public ActionResult Error404() {
            Response.StatusCode = 404;
            return PartialView();
        }

        public ActionResult Error500()
        {
            Response.StatusCode = 500;
            return PartialView();
        }


    }
}