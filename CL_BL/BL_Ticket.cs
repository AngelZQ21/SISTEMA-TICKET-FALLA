using CL_BE;
using CL_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BL
{
    public class BL_Ticket
    {
        public List<BE_Ticket> CrearTicket(BE_Ticket bE_Ticket)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().CrearTicket(bE_Ticket);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                //BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketCreado(string StartDate, string EndDate, string IdTicket, int ValueFilter)
        {

            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketCreado(StartDate, EndDate, IdTicket, ValueFilter);
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

        public List<BE_Ticket> ListarVigenciaFechas(string StartDate, string EndDate, string IdTicket, string IdResponsable, string TypeValue)
        {

            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarVigenciaFechas(StartDate, EndDate, IdTicket, IdResponsable, TypeValue);
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

        public List<BE_Ticket> ListNumberTicket(BE_Ticket bE_Ticket)
        {

            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListNumberTicket(bE_Ticket);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                //BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketBusqueda(string StartDate, string EndDate, int RegistrationUser, string StatusCategory, string NumberTicketSearch, string FilterType)
        {

            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketBusqueda(StartDate, EndDate, RegistrationUser, StatusCategory, NumberTicketSearch, FilterType);
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

        public List<BE_Ticket> ListarTicketPendientes(BE_Ticket bE_Ticket)
        {

            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketPendientes(bE_Ticket);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                //BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketCompletados(BE_Ticket bE_Ticket)
        {

            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketCompletados(bE_Ticket);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                //BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public String AnularTicket(int IdTicket, int RegistrationUser)
        {

            var listaResultado = "";
            try
            {
                listaResultado = new DA_Ticket().AnularTicket(IdTicket, RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }

            return listaResultado;
        }

        public String ActualizarSolutionTicketMovil(int TicketIdMovil, string ValueLstComponent, string TicketProblem, string TicketSolution, int RegistrationUser)
        {

            var listaResultado = "";
            try
            {
                listaResultado = new DA_Ticket().ActualizarSolutionTicketMovil(TicketIdMovil, ValueLstComponent, TicketProblem, TicketSolution , RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }

            return listaResultado;
        }

        public List<BE_Ticket> ActualizarDetalleTicketMovil(int TicketIdMovil, string TitleDetailMovil, int IdLocationDetail, string DetailTicket, int RegistrationUser)
        {

            var listaResultado = new List<BE_Ticket>();

            try
            {
                listaResultado = new DA_Ticket().ActualizarDetalleTicketMovil(TicketIdMovil, TitleDetailMovil, IdLocationDetail, DetailTicket, RegistrationUser);
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

        public List<BE_Grafic_Value> ListarTicketsXOperacion(int RegistrationUser,string fechaInicio, string fechaFin,string Estado, string StatusCategory)
        {
            var listaResultado = new List<BE_Grafic_Value>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketsXOperacion(RegistrationUser, fechaInicio, fechaFin, Estado, StatusCategory);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }

        public List<BE_Grafic_Value> ListCycleTicketVehicle(string ValueYear, string ValueMonth)
        {
            var listaResultado = new List<BE_Grafic_Value>();
            try
            {
                listaResultado = new DA_Ticket().ListCycleTicketVehicle(ValueYear, ValueMonth);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }

        public List<BE_Grafic_Value> ListarTicketsXMeses(int RegistrationUser, string fechaInicio, string fechaFin, string Estado, string StatusCategory)
        {
            var listaResultado = new List<BE_Grafic_Value>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketsXMeses(RegistrationUser, fechaInicio, fechaFin, Estado, StatusCategory);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }


        public List<BE_Grafic_Value> ListarActividadesXOperacion(int RegistrationUser)
        {
            var listaResultado = new List<BE_Grafic_Value>();
            try
            {
                listaResultado = new DA_Ticket().ListarActividadesXOperacion(RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }

        public List<BE_Grafic_Value> ListarActividadesXUsuario(int RegistrationUser,string fechaInicio, string fechaFin, string Estado, string StatusCategory)
        {
            var listaResultado = new List<BE_Grafic_Value>();
            try
            {
                listaResultado = new DA_Ticket().ListarActividadesXUsuario(RegistrationUser, fechaInicio, fechaFin, Estado, StatusCategory);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarDetalleTicketGraphic(string NumberTicket)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarDetalleTicketGraphic(NumberTicket);
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

        public List<BE_Grafic_Value> ListarTicketXActividad(int IdTicket, string StatusCategory)
        {
            var listaResultado = new List<BE_Grafic_Value>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketXActividad(IdTicket, StatusCategory);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }

        public List<BE_Grafic_Value> ListActivityXTicket(string fechaInicio, string fechaFin, string Estado, string StatusCategory)
        {
            var listaResultado = new List<BE_Grafic_Value>();
            try
            {
                listaResultado = new DA_Ticket().ListActivityXTicket(fechaInicio, fechaFin, Estado, StatusCategory);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }

        public List<BE_PathFile> ListarArchivoTicket(int IdTicket)
        {
            var listaResultado = new List<BE_PathFile>();
            try
            {
                listaResultado = new DA_Ticket().ListarArchivoTicket(IdTicket);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_PathFile bE_PathFile = new BE_PathFile();
                bE_PathFile.ValorConsulta = "0";
                bE_PathFile.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_PathFile);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketCriticidad(int RegistrationUser, string StatusCategory)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketCriticidad(RegistrationUser, StatusCategory);
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

        public List<BE_Ticket> ListarTicketBuscarUsuario(int RegistrationUser,int IdPerson, string StatusCategory)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketBuscarUsuario(RegistrationUser, IdPerson, StatusCategory);
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

        public List<BE_Ticket> ListarTicketCriticidadMediaCA(int RegistrationUser,string StatusCategory)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketCriticidadMediaCA(RegistrationUser, StatusCategory);
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

        public List<BE_Ticket> ListarTicketCriticidadBajaCA(int RegistrationUser, string StatusCategory)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketCriticidadBajaCA(RegistrationUser, StatusCategory);
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

        public List<BE_Ticket> ListarTicketMedia(int RegistrationUser, string StatusCategory)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketMedia(RegistrationUser, StatusCategory);
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

        public List<BE_Ticket> ListarTicketGraphic(string OperationName)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketGraphic(OperationName);
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

        public List<BE_Ticket> ListarTicketResponsibleGraphic(int IdResponsible)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketResponsibleGraphic(IdResponsible);
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

        public List<BE_PathFile> ListarFileTicketGraphic(int IdTicket)
        {
            var listaResultado = new List<BE_PathFile>();
            try
            {
                listaResultado = new DA_Ticket().ListarFileTicketGraphic(IdTicket);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_PathFile bE_PathFile = new BE_PathFile();
                bE_PathFile.ValorConsulta = "0";
                bE_PathFile.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_PathFile);
            }
            return listaResultado;
        }

        public List<BE_Activity> ListarTicketPorActividad(int IdTicket, string Estado)
        {
            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketPorActividad(IdTicket, Estado);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Activity bE_Activity = new BE_Activity();
                bE_Activity.ValorConsulta = "0";
                bE_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Activity);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketBaja(int RegistrationUser, string StatusCategory)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketBaja(RegistrationUser, StatusCategory);
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

        public List<BE_Ticket> ListarTicketAlta(int RegistrationUser, string StatusCategory)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketAlta(RegistrationUser, StatusCategory);
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

        public List<BE_Ticket> ListarActRefereceTicket(string NroTicket)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarActRefereceTicket(NroTicket);
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

        public List<BE_Ticket> ListarActRefereceTicketPendiente(string NroTicket)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarActRefereceTicketPendiente(NroTicket);
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

        public List<BE_Ticket> ListarActRefereceTicketCompletado(string NroTicket)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarActRefereceTicketCompletado(NroTicket);
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

        public List<BE_Grafic_Value> ListarActividadesXUsuarioASSAC()
        {
            var listaResultado = new List<BE_Grafic_Value>();
            try
            {
                listaResultado = new DA_Ticket().ListarActividadesXUsuarioASSAC();
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketCombo(int RegistrationUser)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketCombo(RegistrationUser);
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

        public List<BE_Ticket> ListarTicketxResponsable(string StartDate, string EndDate, string IdsResponsible, string IdsTicket, int RegistrationUser)
        {

            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketxResponsable(StartDate, EndDate, IdsResponsible, IdsTicket, RegistrationUser);
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

        public List<BE_Ticket> ListarTicketxResponsable2(string StartDate, string EndDate, string IdsTicket, int RegistrationUser)
        {

            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketxResponsable2(StartDate, EndDate, IdsTicket, RegistrationUser);
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

        public String EditarResponsible(int ResponsibleId, int TicketId ,int RegistrationUser)
        {

            var listaResultado = "";

            try
            {
                listaResultado = new DA_Ticket().EditarResponsible(ResponsibleId, TicketId , RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }

            return listaResultado;
        }

        public String EditarTicketResponsible(int ResponsibleId, string TicketId)
        {

            var listaResultado = "";

            try
            {
                listaResultado = new DA_Ticket().EditarTicketResponsible(ResponsibleId, TicketId);
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }

            return listaResultado;
        }

        public String AnularArchivoTicket(int IdTicketFile, int RegistrationUser)
        {

            var listaResultado = "";

            try
            {
                listaResultado = new DA_Ticket().AnularArchivoTicket(IdTicketFile, RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }

            return listaResultado;
        }

        public String TicketClose(int IdTicket, int RegistrationUser)
        {

            var listaResultado = "";

            try
            {
                listaResultado = new DA_Ticket().TicketClose(IdTicket, RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }

            return listaResultado;
        }

        public String TicketOperando(int IdTicket, int RegistrationUser)
        {

            var listaResultado = "";

            try
            {
                listaResultado = new DA_Ticket().TicketOperando(IdTicket, RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }

            return listaResultado;
        }

        public List<BE_Ticket> ListarResponsableReport(string StartDate, string EndDate, string IdsResponsible, string NumberTicket, int RegistrationUser)
        {

            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarResponsableReport(StartDate, EndDate, IdsResponsible, NumberTicket, RegistrationUser);
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
        
        public List<BE_Ticket> ListarTicketsCompletados(string StartDate, string EndDate, string IdTickets, int RegistrationUser)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketsCompletados(StartDate, EndDate, IdTickets, RegistrationUser);
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

        public String ChangeStatus(int IdActivity, string Comentario , int RegistrationUser)
        {
            var listaResultado = "";
            try
            {
                listaResultado = new DA_Ticket().ChangeStatus(IdActivity, Comentario , RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarDiagramaTicketActividades()
        {

            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarDiagramaTicketActividades();
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

        public List<BE_Ticket> ListarTreeViewTicketActivity(string idTickets, string FechaInicio, string FechaFin, string ValueRadio)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTreeViewTicketActivity(idTickets, FechaInicio, FechaFin, ValueRadio);
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

        public List<BE_Ticket> ListarTicketsMenu(string ValueTicketMenu)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketsMenu(ValueTicketMenu);
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

        public List<BE_Activity> ListarActivityMenu(string ValueActivityMenu)
        {
            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Ticket().ListarActivityMenu(ValueActivityMenu);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Activity bE_Activity = new BE_Activity();
                bE_Activity.ValorConsulta = "0";
                bE_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Activity);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicketToday(int RegistrationUser, string StatusCategory, int OperationId)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketToday(RegistrationUser, StatusCategory, OperationId);
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

        public List<BE_Ticket> CantidadTicketByEvent()
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().CantidadTicketByEvent();
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

        public List<BE_Ticket> ListarTicketsHistoricos(string StatusCategory,string StartDate, string EndDate)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_Ticket().ListarTicketsHistoricos(StatusCategory, StartDate, EndDate);
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

        public List<BE_Activity> ListarActivityByreponsible(string StatusValue, string ReponsibleId, string StatusCategory)
        {
            var listaResultado = new List<BE_Activity>();

            try
            {
                listaResultado = new DA_Ticket().ListarActivityByreponsible(StatusValue, ReponsibleId, StatusCategory);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Activity bE_Activity = new BE_Activity();
                bE_Activity.ValorConsulta = "0";
                bE_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Activity);
            }
            return listaResultado;
        }

        public List<BE_Grafic_Value> ListQuantityTicketStatus(int RegistrationUser, string fechaInicio, string fechaFin, string ValueTicketFilter)
        {
            var listaResultado = new List<BE_Grafic_Value>();

            try
            {
                listaResultado = new DA_Ticket().ListQuantityTicketStatus(RegistrationUser, fechaInicio, fechaFin, ValueTicketFilter);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }

        public List<BE_Grafic_Value> ListQuantityTickePenCom(string StatusTicket, string StatusTicketCreation, string ValueTicketFilter, string OperationId)
        {
            var listaResultado = new List<BE_Grafic_Value>();

            try
            {
                listaResultado = new DA_Ticket().ListQuantityTickePenCom(StatusTicket, StatusTicketCreation, ValueTicketFilter, OperationId);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }

        public string CrearReportTicketDetail(BE_TicketDetail bE_TicketDetail)
        {
            var listaResultado = "";

            try
            {
                listaResultado = new DA_Ticket().CrearReportTicketDetail(bE_TicketDetail);
            }
            catch (Exception ex)
            {

                listaResultado = ex.Message;

            }

            return listaResultado;
        }


        public string EditReportTicketDetail(BE_TicketDetail bE_TicketDetail)
        {
            var listaResultado = "";
            //var listaResultado = new List<BE_ActivityDetail>();
            try
            {
                listaResultado = new DA_Ticket().EditReportTicketDetail(bE_TicketDetail);
            }
            catch (Exception ex)
            {

                listaResultado = ex.Message;
                //listaResultado.Clear();
                //BE_ActivityDetail bE_ActivityDetail = new BE_ActivityDetail();
                //bE_ActivityDetail.ValorConsulta = "0";
                //bE_ActivityDetail.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_ActivityDetail);

            }

            return listaResultado;
        }

        public String ValidationByOperation(int IdTicket, int RegistrationUser)
        {

            var listaResultado = "";
            try
            {
                listaResultado = new DA_Ticket().ValidationByOperation(IdTicket, RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }

            return listaResultado;
        }


    }
}
