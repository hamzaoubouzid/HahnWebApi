using Hahn.Services.Contract.Contract;
using Hahn.Services.EntityFramwork.Context;
using Hahn.Shared;
using Hahn.ticket.Entity;
using Microsoft.EntityFrameworkCore;

namespace Hahn.Services.EntityFramwork.ImplmentationRepository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly HahnAppContext _HahnAppContext;
        public TicketRepository(HahnAppContext hahnAppContext)
        {
            _HahnAppContext = hahnAppContext;
        }

        #region Ticket  Logic

        public bool AddTicket(Ticket ticket)
        {
            try
            {
                var IsExitsTicket = _HahnAppContext.Ticket.Where(m => m.Id == ticket.Id).Any();

                if (!IsExitsTicket)
                {
                    _HahnAppContext.Ticket.Add(ticket);
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteTicket(int Idticket)
        {
            try
            {
                var ticket = _HahnAppContext.Ticket.Where(x=>x.Id == Idticket).FirstOrDefault();

                if (ticket != null)
                {
                    _HahnAppContext.Ticket.Remove(ticket);
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Ticket>> GetAllTickets(Pager filter)
        {
            try
            {
                var pager = new Pager() { Page = filter.Page, PageSize = filter.PageSize };
                var Tickets =    _HahnAppContext.Ticket.AsQueryable().GetPage(pager);
                if (Tickets.Count() > 0)
                    return Tickets;
                return new List<Ticket>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Ticket GetTicketById(int Id)
        {
            try
            {
                var TicketDetails = _HahnAppContext.Ticket.Where(x=>x.Id == Id).FirstOrDefault();

                if (TicketDetails != null)
                    return TicketDetails;

                return new Ticket();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateTicket(Ticket ticket)
        {
            try
            {
                var TicketResulte = _HahnAppContext.Ticket.Where(x=>x.Id == ticket.Id).FirstOrDefault();

                if (TicketResulte != null)
                {
                    TicketResulte.Description = ticket.Description;
                    TicketResulte.Status = ticket.Status;
                    TicketResulte.Date = ticket.Date;
                    _HahnAppContext.Ticket.Update(TicketResulte);
                    Save();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Save()
        {
            _HahnAppContext.SaveChanges();
        }

        #endregion
    }
}
