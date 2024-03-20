using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BL;
using CL_BE;

namespace SmartAdminMvc.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vperson()
        {
            try { 
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            string validacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "Person", "Vperson");

            if (validacion == "1")
            {
                return View();
            }
            else
            {
                TempData["MsgTmp"] = "Validacion retornada " + validacion;
                return RedirectToAction("Vnoautorizado", "Error");
            }
            }
            catch (Exception e)
            {
                TempData["MsgTmp"] = "Validacion retornada " + e.Message;
                return RedirectToAction("Login", "Account");
            }
        }
        public JsonResult ListarPersona(string valorBusqueda, string valorConsulta)
        {
            var lista = new BL_Person().ListarPerson(valorBusqueda, valorConsulta);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarPersonaTicket(int IdOperation)
        {
            var lista = new BL_Person().ListarPersonaTicket(IdOperation);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarResponsibleNotMain(int IdResponsible)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var user = 0;
            user = bE_Ticket.RegistrationUser;

            var lista = new BL_Person().ListarResponsibleNotMain(IdResponsible, user);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarPersonaTicketTodos()
        {
            var lista = new BL_Person().ListarPersonaTicketTodos();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult CrearPersona(int IdRole, int DocumentId, string DocumentNumber, string PersonName, string FirstLastName,
                                        string SecondLastName, string PersonMainAddress, string PersonPhone, string Birthdate,
                                        string PersonMail, string Photocheck, string UserStatus, string OperatorStatus, string DriverStatus)
        {
            BE_Person bE_Person = new BE_Person();
            bE_Person.IdRole = IdRole;
            bE_Person.DocumentId = DocumentId;
            bE_Person.DocumentNumber = DocumentNumber;
            bE_Person.PersonName = PersonName.ToUpper();
            bE_Person.FirstLastName = FirstLastName.ToUpper();
            bE_Person.SecondLastName = SecondLastName.ToUpper();
            bE_Person.PersonMainAddress = PersonMainAddress.ToUpper();
            bE_Person.PersonPhone = PersonPhone;
            bE_Person.Birthdate = Birthdate == "" ? "01/01/1950" : Birthdate;
            bE_Person.PersonMail = PersonMail.ToUpper();
            bE_Person.Photocheck = Photocheck;
            bE_Person.UserStatus = UserStatus;
            bE_Person.OperatorStatus = OperatorStatus;
            bE_Person.DriverStatus = DriverStatus;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Person.RegistrationUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Person().CrearPerson(bE_Person);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
        public JsonResult EditarPersona(int IdPerson, int IdRole, int DocumentId, string DocumentNumber, string PersonName, string FirstLastName,
                                        string SecondLastName, string PersonMainAddress, string PersonPhone, string Birthdate, string PersonMail,
                                        string Photocheck, string UserStatus, string OperatorStatus, string DriverStatus)
        {
            BE_Person bE_Person = new BE_Person();
            bE_Person.IdPerson = IdPerson;
            bE_Person.IdRole = IdRole;
            bE_Person.DocumentId = DocumentId;
            bE_Person.DocumentNumber = DocumentNumber;
            bE_Person.PersonName = PersonName.ToUpper();
            bE_Person.FirstLastName = FirstLastName.ToUpper();
            bE_Person.SecondLastName = SecondLastName.ToUpper();
            bE_Person.PersonMainAddress = PersonMainAddress.ToUpper();
            bE_Person.PersonPhone = PersonPhone;
            bE_Person.Birthdate = Birthdate == "" ? "01/01/1950" : Birthdate;
            bE_Person.PersonMail = PersonMail.ToUpper();
            bE_Person.Photocheck = Photocheck;
            bE_Person.UserStatus = UserStatus;
            bE_Person.OperatorStatus = OperatorStatus;
            bE_Person.DriverStatus = DriverStatus;
            bE_Person.UpdateProcess = 1;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Person.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Person().EditarPerson(bE_Person);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
        public JsonResult EditarEstadoPersona(int IdPerson)
        {
            BE_Person bE_Person = new BE_Person();
            bE_Person.IdPerson = IdPerson;
            bE_Person.Birthdate = "01/01/1950";
            bE_Person.UpdateProcess = 0;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Person.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Person().EditarPerson(bE_Person);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
        public JsonResult EliminarPersona(int IdPerson)
        {
            BE_Person bE_Person = new BE_Person();
            bE_Person.IdPerson = IdPerson;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Person.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Person().EliminarPerson(bE_Person);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
        //SOLO GOLDFIELDS
        //public JsonResult ListarPersonPorTipoRolPrincipal()
        //{
        //    var lista = new BL_Person().ListarPersonPorTipoRolPrincipal();
        //    var a = Json(lista, JsonRequestBehavior.AllowGet);
        //    a.MaxJsonLength = int.MaxValue;
        //    return a;
        //}
        //SOLO GOLDFIELDS
        public JsonResult ValidarRelacionPersonaUsuario(int idPerson)
        {
            var lista = new BL_Person().ValidarRelacionPersonaUsuario(idPerson);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ValidarRelacionPersonaConductor(int idPerson)
        {
            var lista = new BL_Person().ValidarRelacionPersonaConductor(idPerson);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        //public JsonResult ValidarRelacionPersonaVehiculo(int IdPerson)
        //{
        //    var lista = new BL_Person().ValidarRelacionPersonaVehiculo(IdPerson);
        //    var a = Json(lista, JsonRequestBehavior.AllowGet);
        //    a.MaxJsonLength = int.MaxValue;
        //    return a;
        //}

        public JsonResult ValidarRelacionPersonaOperador(int idPerson)
        {
            var lista = new BL_Person().ValidarRelacionPersonaOperador(idPerson);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }


    }
}