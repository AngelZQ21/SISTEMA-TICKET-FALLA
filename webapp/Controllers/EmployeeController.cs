using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BE;
using CL_BL;

namespace SmartAdminMvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public JsonResult ListarTrabajadores(int IdOperation)
        {
            var lista = new BL_Employee().ListarTrabajadores(IdOperation);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult CrearTrabajador(int TipoDocumento, string NroDocumento, string Nombres, string ApellidoPat, string ApellidoMat, string Direccion, string Email, string Telefono, string FechaNacimiento, int IdArea, int IdCargo, int IdOperacion)
        {

            BE_Employee bE_Employee = new BE_Employee();
            bE_Employee.bE_Area = new BE_Area();
            bE_Employee.bE_Position = new BE_Position();
            bE_Employee.bE_Person = new BE_Person();
            bE_Employee.bE_Operation = new BE_Operation();
            bE_Employee.bE_Person.DocumentId = TipoDocumento;
            bE_Employee.bE_Person.DocumentNumber = NroDocumento.Trim().ToUpper();
            bE_Employee.bE_Person.PersonName = Nombres.Trim().ToUpper();
            bE_Employee.bE_Person.FirstLastName = ApellidoPat.Trim().ToUpper();
            bE_Employee.bE_Person.SecondLastName = ApellidoMat.Trim().ToUpper();
            bE_Employee.bE_Person.PersonMainAddress = Direccion.Trim().ToUpper();
            bE_Employee.bE_Person.PersonMail = Email.Trim().ToUpper();
            bE_Employee.bE_Person.PersonPhone = Telefono.Trim();
            bE_Employee.bE_Person.Birthdate = FechaNacimiento.Trim();
            bE_Employee.bE_Area.IdArea = IdArea;
            bE_Employee.bE_Position.IdPosition = IdCargo;
            bE_Employee.bE_Operation.IdOperation = IdOperacion;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Employee.RegistrationUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_Employee().CrearTrabajador(bE_Employee);
            return Json(lista, JsonRequestBehavior.AllowGet);

        }

    }
}