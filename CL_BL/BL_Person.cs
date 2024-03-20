using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_Person
    {
        public List<BE_Person> ListarPerson(string valorBusqueda, string valorConsulta)
        {
            var listaResultado = new List<BE_Person>();
            try
            {
                listaResultado = new DA_Person().ListarPerson(valorBusqueda, valorConsulta);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Person bE_Person = new BE_Person();
                bE_Person.ValorConsulta = "0";
                bE_Person.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Person);
            }
            return listaResultado;
        }

        public List<BE_Person> ListarPersonaTicket(int IdOperation)
        {
            var listaResultado = new List<BE_Person>();
            try
            {
                listaResultado = new DA_Person().ListarPersonaTicket(IdOperation);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Person bE_Person = new BE_Person();
                bE_Person.ValorConsulta = "0";
                bE_Person.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Person);
            }
            return listaResultado;
        }

        public List<BE_Person> ListarPersonaTicketTodos()
        {
            var listaResultado = new List<BE_Person>();
            try
            {
                listaResultado = new DA_Person().ListarPersonaTicketTodos();
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Person bE_Person = new BE_Person();
                bE_Person.ValorConsulta = "0";
                bE_Person.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Person);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarResponsibleNotMain(int IdResponsible, int RegistrationUser)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Person().ListarResponsibleNotMain(IdResponsible,RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public string CrearPerson(BE_Person bE_Person)
        {

            string resultado = "";

            try
            {
                resultado = new DA_Person().CrearPerson(bE_Person);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
        public string EditarPerson(BE_Person bE_Person)
        {

            string resultado = "";

            try
            {
                resultado = new DA_Person().EditarPerson(bE_Person);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
        public string EliminarPerson(BE_Person bE_Person)
        {

            var resultado = "";

            try
            {
                resultado = new DA_Person().EliminarPerson(bE_Person);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        // SOLO GOLDFIELDS
        //public List<BE_Person> ListarPersonPorTipoRolPrincipal()
        //{
        //    var listaResultado = new List<BE_Person>();
        //    try
        //    {
        //        listaResultado = new DA_Person().ListarPersonPorTipoRolPrincipal();
        //    }
        //    catch (Exception ex)
        //    {
        //        BE_Person bE_Person = new BE_Person();
        //        bE_Person.ValorConsulta = "0";
        //        bE_Person.MensajeConsulta = ex.Message;
        //        listaResultado.Add(bE_Person);
        //    }
        //    return listaResultado;
        //}

        // SOLO GOLDFIELDS

        public List<BE_User> ValidarRelacionPersonaUsuario(int idPerson)
        {
            var listaResultado = new List<BE_User>();
            try
            {
                listaResultado = new DA_Person().ValidarRelacionPersonaUsuario(idPerson);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_User bE_User = new BE_User();
                bE_User.ValorConsulta = "0";
                bE_User.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_User);
            }
            return listaResultado;
        }

        public List<BE_Person> ValidarRelacionPersonaConductor(int idPerson)
        {
            var listaResultado = new List<BE_Person>();
            try
            {
                listaResultado = new DA_Person().ValidarRelacionPersonaConductor(idPerson);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Person bE_Person = new BE_Person();
                bE_Person.ValorConsulta = "0";
                bE_Person.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Person);
            }
            return listaResultado;
        }

        //public List<BE_Vehicle> ValidarRelacionPersonaVehiculo(int IdPerson)
        //{
        //    var listaResultado = new List<BE_Vehicle>();
        //    try
        //    {
        //        listaResultado = new DA_Person().ValidarRelacionPersonaVehiculo(IdPerson);
        //    }
        //    catch (Exception ex)
        //    {
        //        listaResultado.Clear();
        //        BE_Vehicle bE_Vehicle = new BE_Vehicle();
        //        bE_Vehicle.ValorConsulta = "0";
        //        bE_Vehicle.MensajeConsulta = ex.Message;
        //        listaResultado.Add(bE_Vehicle);
        //    }
        //    return listaResultado;
        //}


        public List<BE_Person> ValidarRelacionPersonaOperador(int idPerson)
        {
            var listaResultado = new List<BE_Person>();
            try
            {
                listaResultado = new DA_Person().ValidarRelacionPersonaOperador(idPerson);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Person bE_Person = new BE_Person();
                bE_Person.ValorConsulta = "0";
                bE_Person.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Person);
            }
            return listaResultado;
        }


    }
}
